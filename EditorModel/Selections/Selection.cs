using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using EditorModel.Common;
using EditorModel.Figures;
using EditorModel.Geometry;

namespace EditorModel.Selections
{
    /// <summary>
    /// Набор выделенных фигур и операции над ними
    /// </summary>
    [Serializable]
    public class Selection : Figure, IEnumerable<Figure>
    {
        // внутренний набор для хранения списка выделенных фигур
        private readonly HashSet<Figure> _selected = new HashSet<Figure>();
        private bool _isFrameVisible = true;

        /// <summary>
        /// Очистка списка выделенных фигур
        /// </summary>
        public void Clear()
        {
            _selected.Clear();
            GrabGeometry();
        }

        /// <summary>
        /// Добавление фигуры к списку выделенных фигур
        /// </summary>
        /// <param name="fig">Добавляемая фигура</param>
        public void Add(Figure fig)
        {
            _selected.Add(fig);
            GrabGeometry();
        }

        /// <summary>
        /// Исключение фигуры из списка выделенных фигур
        /// </summary>
        /// <param name="fig">Исключаемая фигура</param>
        public void Remove(Figure fig)
        {
            _selected.Remove(fig);
            GrabGeometry();
        }

        /// <summary>
        /// Запрет рисовать рамку вокруг выбранных фигур
        /// </summary>
        public bool IsFrameVisible
        {
            get { return _isFrameVisible; }
            set
            {
                if (_isFrameVisible == value) return;
                _isFrameVisible = value;
                GrabGeometry();
            }
        }

        /// <summary>
        /// Ищем попадание в контур фигуры
        /// </summary>
        /// <param name="point">Положение курсора</param>
        /// <param name="layer">Ссылка на слой</param>
        /// <returns>Контур фигуры найден</returns>
        public bool IsHit(Layer layer, Point point)
        {
            var found = false;
            using (var pen = new Pen(Color.Black, 5))
            {
                // просмотр начинаем с конца списка - там самые "верхние" фигуры
                for (var i = layer.Figures.Count - 1; i >= 0; i--)
                {
                    var fig = layer.Figures[i];
                    var path = fig.GetTransformedPath();
                    // проверяем также попадание на контур фигуры
                    if (!path.Path.IsOutlineVisible(point, pen)) continue;
                    found = true;
                    break;
                }
            }
            return found;
        }

        /// <summary>
        /// Ищем фигуру в данной точке
        /// </summary>
        /// <param name="layer">Ссылка на слой</param>
        /// <param name="point">Положение курсора</param>
        /// <param name="figure">Найденная фигура или null</param>
        /// <returns>True - фигура найдена</returns>
        public bool FindFigureAt(Layer layer, Point point, out Figure figure)
        {
            figure = null;
            var found = false;
            using (var pen = new Pen(Color.Black, 5))
            {
                // просмотр начинаем с конца списка - там самые "верхние" фигуры
                for (var i = layer.Figures.Count - 1; i >= 0; i--)
                {
                    var fig = layer.Figures[i];
                    var path = fig.GetTransformedPath();
                    if (path.Path.IsVisible(point))
                    {
                        figure = fig;
                        found = true;
                        break;
                    }
                    // проверяем также попадание на контур фигуры
                    if (!path.Path.IsOutlineVisible(point, pen)) continue;
                    figure = fig;
                    found = true;
                    break;
                }
            }
            return found;
        }

        /// <summary>
        /// Копирование геометрий выделенных фигур в свою геометрию
        /// </summary>
        private void GrabGeometry()
        {
            // захватываем геометрию выбранных фигур
            var path = new SerializableGraphicsPath();
            foreach (var fig in _selected)
            {
                path.Path.SetMarkers();
                path.Path.AddPath(fig.GetTransformedPath(), false);
            }

            // нарисовать рамку вокруг выбранных фигур 
            if (IsFrameVisible)
            {
                var bounds = path.Path.GetBounds();
                path.Path.AddRectangle(bounds);
            }
            // выбираем разрешённые операции
            // если выбрана только одна фигура - просто используем её AllowedOperations
            // иначе - разрешаем все операции
            var allowedOperations = _selected.Count == 1
                ? _selected.First().Geometry.AllowedOperations
                : AllowedOperations.All;

            // присваиваем геометрию
            Geometry = new PrimitiveGeometry(path, allowedOperations);

            // сбрасываем преобразование в единичную матрицу
            Transform = new SerializableGraphicsMatrix();
        }

        /// <summary>
        /// Применение своего Transform к Transform выделенных фигур
        /// </summary>
        public void PushTransformToSelectedFigures()
        {
            foreach (var fig in _selected)
                fig.Transform.Matrix.Multiply(Transform, MatrixOrder.Append);

            GrabGeometry();
        }

        /// <summary>
        /// Применение своего изменения пути к выделенным фигурам
        /// </summary>
        public void PushPathDataToSelectedFigures()
        {
            var fig = _selected.FirstOrDefault();
            if (fig != null)
            {
                var types = Geometry.Path.Path.PathTypes;
                var points = Geometry.Path.Path.PathPoints;
                fig.Geometry = new PrimitiveGeometry(
                    new SerializableGraphicsPath { Path = new GraphicsPath(points, types) },
                    fig.Geometry.AllowedOperations);
                fig.Transform = new SerializableGraphicsMatrix();
            }
            GrabGeometry();
        }

        /// <summary>
        /// Перенос фигур из списка
        /// </summary>
        /// <param name="offsetX">Смещение по горизонтали</param>
        /// <param name="offsetY">Смещение по вертикали</param>
        public void Translate(float offsetX, float offsetY)
        {
            var m = new SerializableGraphicsMatrix();
            m.Matrix.Translate(offsetX, offsetY);
            // делаем на "чистой" матрице
            Transform = m;
        }

        /// <summary>
        /// Масштабирование
        /// </summary>
        /// <param name="scaleX">Коэффициент масштабирования по горизонтали</param>
        /// <param name="scaleY">Коэффициент масштабирования по вертикали</param>
        /// <param name="anchor">Координаты "якоря" (в мировых координатах)</param>
        public void Scale(float scaleX, float scaleY, PointF anchor)
        {
            //можем менять размер?
            var allowSize = Geometry.AllowedOperations.HasFlag(AllowedOperations.Size);
            var allowScale = Geometry.AllowedOperations.HasFlag(AllowedOperations.Scale);

            if (!allowScale && !allowSize)
                return; //не можем менять размеры

            if (allowScale && !allowSize)
                //можем шкалировать, но с сохранением аспекта
                //сохраняем аспект
                scaleX = scaleY = Math.Max(scaleX, scaleY);

            //шкалируем относительно якоря
            var m = new SerializableGraphicsMatrix();
            m.Matrix.Translate(anchor.X, anchor.Y);    //переводим центр координат в якорь
            m.Matrix.Scale(scaleX, scaleY);            //масштабируем
            m.Matrix.Translate(-anchor.X, -anchor.Y);  //возвращаем центр координат

            //
            Transform = m;
        }

        /// <summary>
        /// Искривление
        /// </summary>
        /// <param name="skewX">Коэффициент сдвига по горизонтали</param>
        /// <param name="skewY">Коэффициент сдвига по вертикали</param>
        /// <param name="anchor">Координаты "якоря" (в мировых координатах)</param>
        public void Skew(float skewX, float skewY, PointF anchor)
        {
            //можем искажать?
            var allowSkew = Geometry.AllowedOperations.HasFlag(AllowedOperations.Skew);
            if (!allowSkew)
                return; //не можем искажать

            //сдвигаем относительно якоря
            var m = new SerializableGraphicsMatrix();
            m.Matrix.Translate(anchor.X, anchor.Y);    //переводим центр координат в якорь
            m.Matrix.Shear(skewX, skewY);              //сдвигаем
            m.Matrix.Translate(-anchor.X, -anchor.Y);  //возвращаем центр координат

            //
            Transform = m;
        }

        /// <summary>
        /// Поворот
        /// </summary>
        /// <param name="angle">Угол поворота, в градусах</param>
        /// <param name="center">Координаты центра вращения (в мировых координатах)</param>
        public void Rotate(float angle, PointF center)
        {
            //можем вращать?
            var allowRotate = Geometry.AllowedOperations.HasFlag(AllowedOperations.Rotate);

            if (!allowRotate)
                return; //не можем вращать

            //вращаем относительно якоря
            var m = new SerializableGraphicsMatrix();
            m.Matrix.RotateAt(angle, center);      //вращаем

            //
            Transform = m;
        }

        /// <summary>
        /// Наличие фигуры в списке выбранных
        /// </summary>
        /// <param name="figure">Проверяемая фигура</param>
        /// <returns>True - фигура в списке</returns>
        public bool Contains(Figure figure)
        {
            return _selected.Contains(figure);
        }

        /// <summary>
        /// Конструктор с инициализацией по умолчанию
        /// </summary>
        public Selection()
        {
            // настройки вида рамки выбора
            Style.BorderStyle.DashStyle = DashStyle.Dash;
            Style.BorderStyle.Color = Color.Magenta;
            Style.FillStyle.IsVisible = false;
            // в списке ничего нет, но объект Geometry инициализируется
            GrabGeometry();
        }

        /// <summary>
        /// Количество фигур в списке
        /// </summary>
        public int Count { get { return _selected.Count; } }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Figure> GetEnumerator()
        {
            return _selected.GetEnumerator();
        }

        /// <summary>
        /// Состояние внутренних вершин фигур изменилось
        /// </summary>
        public event Action PathDataModified;

        public void OnPathDataModified()
        {
            PathDataModified();
        }

        /// <summary>
        /// Перемещение маркера вершины
        /// </summary>
        /// <param name="index">Индекс вершины</param>
        /// <param name="offset">Смещение маркера</param>
        /// <returns>Смещение для маркера вершины</returns>
        public SizeF MoveVertex(int index, SizeF offset)
        {
            //можем менять положение вершин?
            var allowVertex = Geometry.AllowedOperations.HasFlag(AllowedOperations.Vertex);

            if (!allowVertex)
                return SizeF.Empty; //не можем менять положение вершин

            var points = Geometry.Path.Path.PathPoints;
            var types = Geometry.Path.Path.PathTypes;
            points[index] = PointF.Add(points[index], offset);
            var newPath = new SerializableGraphicsPath { Path = new GraphicsPath(points, types) };
            Geometry = new PrimitiveGeometry(newPath, Geometry.AllowedOperations);
            return offset;
        }

        /// <summary>
        /// Удаление выбранной вершины фигуры
        /// </summary>
        /// <param name="owner">Фигура</param>
        /// <param name="index">Индекс вершины</param>
        public void RemoveVertex(Figure owner, int index)
        {
            //можем менять положение вершин?
            var allowVertex = Geometry.AllowedOperations.HasFlag(AllowedOperations.Vertex);

            if (!allowVertex)
                return; //не можем менять положение вершин

            var points = new List<PointF>(Geometry.Path.Path.PathPoints);
            if (owner.Geometry.IsClosed && points.Count < 4) return;
            if (!owner.Geometry.IsClosed && points.Count < 3) return;
            points.RemoveAt(index);
            var types = new List<byte>(Geometry.Path.Path.PathTypes);
            types.RemoveAt(index);
            var newPath = new SerializableGraphicsPath
            {
                Path = new GraphicsPath(points.ToArray(), types.ToArray())
            };
            if (owner.Geometry.IsClosed) newPath.Path.CloseAllFigures();
            owner.Geometry = new PrimitiveGeometry(newPath, owner.Geometry.AllowedOperations);
            owner.Transform = new SerializableGraphicsMatrix();
        }

        /// <summary>
        /// Вставка новой вершины в контур фигуры
        /// </summary>
        /// <param name="owner">Фигура</param>
        /// <param name="point">Положение указателя мышки</param>
        public void InsertVertex(Figure owner, PointF point)
        {
            //можем менять положение вершин?
            var allowVertex = Geometry.AllowedOperations.HasFlag(AllowedOperations.Vertex);

            if (!allowVertex)
                return; //не можем менять положение вершин

            var points = new List<PointF>(owner.GetTransformedPath().Path.PathPoints);
            var types = new List<byte>(owner.GetTransformedPath().Path.PathTypes);
            using (var pen = new Pen(Color.Black, 5))
            {
                // поищем, на какой стороне фигуры добавлять новую вершину
                var k = owner.Geometry.IsClosed ? 0 : 1;
                for (var i = k; i < points.Count(); i++)
                {
                    // замыкаем контур отрезком, соединяющим начало и конец фигуры
                    var pt1 = i == 0 ? points[points.Count - 1] : points[i - 1];
                    var pt2 = points[i];
                    using (var path = new GraphicsPath())
                    {
                        path.AddLine(pt1, pt2);
                        if (!path.IsOutlineVisible(point, pen)) continue;
                        // вставляем новую точку
                        points.Insert(i, point);
                        // вставляем тип узла (если индекс вставки нулевой, то вставляем перед конечным
                        // тип вставляемого узла - 1
                        types.Insert(i == 0 ? types.Count - 1 : i, 1);
                        var newPath = new SerializableGraphicsPath
                        {
                            Path = new GraphicsPath(points.ToArray(), types.ToArray())
                        };
                        owner.Geometry = new PrimitiveGeometry(newPath, owner.Geometry.AllowedOperations);
                        owner.Transform = new SerializableGraphicsMatrix();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Объединение выбранных фигур в группу
        /// </summary>
        /// <returns></returns>
        public Figure Group()
        {
            return new FigureGroup(_selected.ToList())
            {
                Geometry = new PolygoneGeometry()
            };
        }

        /// <summary>
        /// Извлечение фигур из группы
        /// </summary>
        /// <returns>Список извлеченных фигур</returns>
        public List<Figure> Ungroup()
        {
            var list = new List<Figure>();
            foreach (var grp in _selected.OfType<FigureGroup>())
            {
                foreach (var figure in grp.Figures)
                {
                    figure.Transform.Matrix.Multiply(grp.Transform, MatrixOrder.Append);
                    list.Add(figure);
                }
            }
            return list;
        }

        /// <summary>
        /// Объединение выбранных фигур в одну
        /// </summary>
        /// <returns>Новая фигура, содержащая фигуры группы</returns>
        public Figure Join()
        {
            var groupPath = new SerializableGraphicsPath();
            foreach (var fig in _selected)
            {
                groupPath.Path.AddPath(fig.GetTransformedPath().Path, false);
                if (_selected.Last() != fig)
                    groupPath.Path.SetMarkers();
            }
            var group = new Figure
            {
                Geometry = new PrimitiveGeometry(groupPath, AllowedOperations.All)
            };
            return group;
        }

        /// <summary>
        /// Разъединение фигур в список
        /// todo: Настройки AllowedOperations для примитивных фигур теряются!
        /// </summary>
        /// <returns>Список фигур, содержавшихся внутри группы</returns>
        public List<Figure> Unjoin()
        {
            var list = new List<Figure>();
            foreach (var pathIterator in _selected.Select(fig =>
                new GraphicsPathIterator(fig.GetTransformedPath().Path)))
            {
                pathIterator.Rewind();
                var pathSection = new SerializableGraphicsPath();
                bool closed;
                while (pathIterator.NextSubpath(pathSection.Path, out closed) > 0)
                {
                    var figure = new Figure
                    {
                        Geometry = new PrimitiveGeometry(pathSection, AllowedOperations.All)
                    };
                    pathSection = new SerializableGraphicsPath();
                    list.Add(figure);
                }
            }
            return list;
        }
    }
}
