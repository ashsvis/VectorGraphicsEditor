using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using EditorModel.Figures;

namespace EditorModel.Selections
{
    /// <summary>
    /// Набор выделенных фигур и операции над ними
    /// </summary>
    public class Selection : Figure
    {
        // внутренний набор для хранения списка выделенных фигур
        private readonly HashSet<Figure> _selected = new HashSet<Figure>();

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
        /// Копирование геометрий выделенных фигур в свою геометрию
        /// </summary>
        private void GrabGeometry()
        {
            // захватываем геометрию выбранных фигур
            var path = new GraphicsPath();
            foreach (var fig in _selected)
                path.AddPath(fig.GetTransformedPath(), false);

            // нарисовать рамку вокруг выбранных фигур 
            var bounds = path.GetBounds();
            path.AddRectangle(bounds);

            // выбираем разрешённые операции
            // если выбрана только одна фигура - просто используем её AllowedOperations
            // иначе - разрешаем все операции
            var allowedOperations = _selected.Count == 1 
                ? _selected.First().Geometry.AllowedOperations 
                : AllowedOperations.All;

            // присваиваем геометрию
            Geometry = new PrimitiveGeometry(path, allowedOperations);

            // сбрасываем преобразование в единичную матрицу
            Transform = new Matrix();
        }

        public IEnumerable<Figure> GetFigures()
        {
            return _selected;
        }

        /// <summary>
        /// Применение своего Transform к Transform выделенных фигур
        /// </summary>
        public void PushTransformToSelectedFigures()
        {
            foreach (var fig in _selected)
                fig.Transform.Multiply(Transform, MatrixOrder.Append);

            GrabGeometry();
        }

        public Matrix[] GetTransformFromSelectedFigures()
        {
            var list = new List<Matrix>();
            foreach (var fig in _selected)
                list.Add(fig.Transform);
            return list.ToArray();
        }

        public void PopTransformToSelectedFigures(Matrix[] matrices)
        {
            var i = 0;
            foreach (var fig in _selected)
                if (i < matrices.Length)
                    fig.Transform = matrices[i++];

            GrabGeometry();
        }

        /*
         *  Добавлено 19.11.2018 от Storm23
         */

        /// <summary>
        /// Переводит точку из локальных нормализированных координат (0,0)-(1,1) в мировые координаты
        /// </summary>
        public PointF ToWorldCoordinates(PointF point)
        {
            var bounds = GetTransformedPath().GetBounds();
            return new PointF(bounds.Left + point.X * bounds.Width, bounds.Top + point.Y * bounds.Height);
        }

        /// <summary>
        /// Переводит точку из мировых координат в локальные нормализированные координаты (0,0)-(1,1)
        /// </summary>
        public PointF ToLocalCoordinates(PointF point)
        {
            var bounds = GetTransformedPath().GetBounds();
            return new PointF((point.X - bounds.Left) / bounds.Width, (point.Y - bounds.Top) / bounds.Height);
        }

        /// <summary>
        /// Перенос фигур из списка
        /// </summary>
        /// <param name="offsetX">Смещение по горизонтали</param>
        /// <param name="offsetY">Смещение по вертикали</param>
        public void Translate(float offsetX, float offsetY)
        {
            var m = new Matrix();
            m.Translate(offsetX, offsetY);
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
            var m = new Matrix();
            m.Translate(anchor.X, anchor.Y);    //переводим центр координат в якорь
            m.Scale(scaleX, scaleY);            //масштабируем
            m.Translate(-anchor.X, -anchor.Y);  //возвращаем центр координат

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
            var m = new Matrix();
            m.Translate(anchor.X, anchor.Y);    //переводим центр координат в якорь
            m.Shear(skewX, skewY);              //сдвигаем
            m.Translate(-anchor.X, -anchor.Y);  //возвращаем центр координат

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
            var m = new Matrix();
            m.RotateAt(angle, center);      //вращаем

            //
            Transform = m;
        }

        /*
         *  Добавлено 19.11.2018 от ashsvis
         */

        /// <summary>
        /// Наличие фигуры в списке выбранных
        /// </summary>
        /// <param name="figure">Проверяемая фигура</param>
        /// <returns>True - фигура в списке</returns>
        public bool Contains(Figure figure)
        {
            return _selected.Contains(figure);
        }

        /*
         *  Добавлено 20.11.2018 от ashsvis
         */

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
    }
}
