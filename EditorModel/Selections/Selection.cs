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
        private bool _aroundFrameDisable;

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
        public bool AroundFrameDisable
        {
            get { return _aroundFrameDisable; }
            set
            {
                if (_aroundFrameDisable == value) return;
                _aroundFrameDisable = value;
                GrabGeometry();
            }
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
            if (!AroundFrameDisable)
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
            PathDataModified = false;
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
        /// Переводит точку из локальных нормализированных координат (0,0)-(1,1) в мировые координаты
        /// </summary>
        public PointF ToWorldCoordinates(PointF point)
        {
            var bounds = GetTransformedPath().Path.GetBounds();
            return new PointF(bounds.Left + point.X * bounds.Width, bounds.Top + point.Y * bounds.Height);
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
            //сдвигаем относительно якоря
            var m = new SerializableGraphicsMatrix();
            m.Matrix.Translate(anchor.X, anchor.Y);    //переводим центр координат в якорь
            m.Matrix.Shear(skewX, skewY);              //сдвигаем
            m.Matrix.Translate(-anchor.X, -anchor.Y);  //возвращаем центр координат

            //
            Transform = m;
        }

        /// <summary>
        /// Отражение по горизонтали
        /// </summary>
        public void FlipX()
        {
            var m = new SerializableGraphicsMatrix();
            var anchor = ToWorldCoordinates(new PointF(0.5f, 0.5f));
            m.Matrix.Translate(anchor.X, anchor.Y);    //переводим центр координат в якорь
            //отражаем по горизонтали относительно якоря
            m.Matrix.Multiply(new Matrix(-1, 0, 0, 1, 0, 0));
            m.Matrix.Translate(-anchor.X, -anchor.Y);  //возвращаем центр координат
            //
            Transform = m;
        }

        /// <summary>
        /// Отражение по вертикали
        /// </summary>
        public void FlipY()
        {
            var m = new SerializableGraphicsMatrix();
            var anchor = ToWorldCoordinates(new PointF(0.5f, 0.5f));
            m.Matrix.Translate(anchor.X, anchor.Y);    //переводим центр координат в якорь
            //отражаем по вертикали относительно якоря
            m.Matrix.Multiply(new Matrix(1, 0, 0, -1, 0, 0));
            m.Matrix.Translate(-anchor.X, -anchor.Y);  //возвращаем центр координат
            //
            Transform = m;
        }

        /// <summary>
        /// Поворот на четверть по часовой стрелке
        /// </summary>
        public void Rotate90Cw()
        {
            var m = new SerializableGraphicsMatrix();
            var anchor = ToWorldCoordinates(new PointF(0.5f, 0.5f));
            m.Matrix.Translate(anchor.X, anchor.Y);    //переводим центр координат в якорь
            //отражаем по вертикали относительно якоря
            m.Matrix.Multiply(new Matrix(0, 1, -1, 0, 0, 0));
            m.Matrix.Translate(-anchor.X, -anchor.Y);  //возвращаем центр координат
            //
            Transform = m;
        }

        /// <summary>
        /// Поворот на четверть против часовой стрелки
        /// </summary>
        public void Rotate90Ccw()
        {
            var m = new SerializableGraphicsMatrix();
            var anchor = ToWorldCoordinates(new PointF(0.5f, 0.5f));
            m.Matrix.Translate(anchor.X, anchor.Y);    //переводим центр координат в якорь
            //отражаем по вертикали относительно якоря
            m.Matrix.Multiply(new Matrix(0, -1, 1, 0, 0, 0));
            m.Matrix.Translate(-anchor.X, -anchor.Y);  //возвращаем центр координат
            //
            Transform = m;
        }

        /// <summary>
        /// Поворот на 180 градусов
        /// </summary>
        public void Rotate180()
        {
            var m = new SerializableGraphicsMatrix();
            var anchor = ToWorldCoordinates(new PointF(0.5f, 0.5f));
            m.Matrix.Translate(anchor.X, anchor.Y);    //переводим центр координат в якорь
            //отражаем по вертикали относительно якоря
            m.Matrix.Multiply(new Matrix(-1, 0, 0, -1, 0, 0));
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
        public int Count { get { return _selected.Count; }  }

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
        public bool PathDataModified { get; private set; }

        /// <summary>
        /// Перемещение маркера вершины
        /// </summary>
        /// <param name="owner">Фигура, владелец маркера</param>
        /// <param name="index">Индекс вершины</param>
        /// <param name="marker">Координаты маркера вершины</param>
        /// <param name="mouse">Координаты мышки</param>
        /// <returns>Новые координаты маркера вершины</returns>
        public PointF MoveVertex(Figure owner, int index, PointF marker, PointF mouse)
        {
            var points = Geometry.Path.Path.PathPoints;
            var types = Geometry.Path.Path.PathTypes;
            var offset = new SizeF(mouse.X - marker.X, mouse.Y - marker.Y);
            PathDataModified = !offset.IsEmpty;
            points[index] = PointF.Add(points[index], offset);
            var newPath = new SerializableGraphicsPath {Path = new GraphicsPath(points, types)};
            Geometry = new PrimitiveGeometry(newPath, Geometry.AllowedOperations);
            return PointF.Add(marker, offset);
        }

        /// <summary>
        /// Удаление выбранной вершины фигуры
        /// </summary>
        /// <param name="owner">Фигура</param>
        /// <param name="index">Индекс вершины</param>
        public void RemoveVertex(Figure owner, int index)
        {
            var points = new List<PointF>(Geometry.Path.Path.PathPoints);
            if (owner.Solid && points.Count < 4) return;
            if (!owner.Solid && points.Count < 3) return;
            points.RemoveAt(index);
            var types = new List<byte>(Geometry.Path.Path.PathTypes);
            types.RemoveAt(index);
            var newPath = new SerializableGraphicsPath
                {
                    Path = new GraphicsPath(points.ToArray(), types.ToArray())
                };
            if (owner.Solid) newPath.Path.CloseAllFigures();
            Geometry = new PrimitiveGeometry(newPath, Geometry.AllowedOperations);
            PathDataModified = true;
        }

        /// <summary>
        /// Вставка новой вершины в контур фигуры
        /// </summary>
        /// <param name="owner">Фигура</param>
        /// <param name="point">Положение указателя мышки</param>
        public void InsertVertex(Figure owner, PointF point)
        {
            var points = new List<PointF>(owner.GetTransformedPath().Path.PathPoints);
            var types = new List<byte>(owner.GetTransformedPath().Path.PathTypes);
            using (var pen = new Pen(Color.Black, 5))
            {
                // поищем, на какой стороне фигуры добавлять новую вершину
                var k = owner.Solid ? 0 : 1;
                for (var i = k; i < points.Count(); i++)
                {
                    // замыкаем контур отрезком, соединяющим начало и конец фигуры
                    var pt1 = i == 0 ? points[points.Count-1] : points[i - 1];
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
        /// Применение своего Path к Path выделенной фигуры
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
        /// Группировка выбранных фигур в одну
        /// </summary>
        /// <returns></returns>
        public Figure Group()
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
        /// Разгруппировка списка фигур в ещё больший список, но по отдельности
        /// todo: Настройки AllowedOperations для примитивных фигур теряются!
        /// </summary>
        /// <returns></returns>
        public List<Figure> Ungroup()
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
                            Solid = closed,
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
