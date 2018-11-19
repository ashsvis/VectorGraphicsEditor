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
            var allowedOperations = _selected.Count == 1 ? _selected.First().Geometry.AllowedOperations : AllowedOperations.All;

            // присваиваем геометрию
            Geometry = new PrimitiveGeometry(path, allowedOperations);

            // сбрасываем преобразование в единичную матрицу
            Transform = new Matrix();
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

        /*
         *  Добавлено 19.11.2018 от Storm23
         */

        /// <summary>
        /// Переводит точку из локальных нормализированных координат (0,0)-(1,1) в мировые координаты
        /// </summary>
        internal PointF ToWorldCoordinates(PointF p)
        {
            var bounds = GetTransformedPath().GetBounds();
            return new PointF(bounds.Left + p.X * bounds.Width, bounds.Top + p.Y * bounds.Height);
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
        /// <param name="anchor">Координаты "якоря" (точки привязки)</param>
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

            //считаем якорь в мировых координатах
            var worldAnchor = ToWorldCoordinates(anchor);

            //шкалируем относительно якоря
            var m = new Matrix();
            m.Translate(worldAnchor.X, worldAnchor.Y);    //переводим центр координат в якорь
            m.Scale(scaleX, scaleY);                      //масштабируем
            m.Translate(-worldAnchor.X, -worldAnchor.Y);  //возвращаем центр координат

            //
            Transform = m;
        }

        /// <summary>
        /// Искривление
        /// </summary>
        /// <param name="skewX">Коэффициент сдвига по горизонтали</param>
        /// <param name="skewY">Коэффициент сдвига по вертикали</param>
        /// <param name="anchor">Координаты "якоря" (точки привязки)</param>
        public void Skew(float skewX, float skewY, PointF anchor)
        {
            //считаем якорь в мировых координатах
            var worldAnchor = ToWorldCoordinates(anchor);

            //сдвигаем относительно якоря
            var m = new Matrix();
            m.Translate(worldAnchor.X, worldAnchor.Y);    //переводим центр координат в якорь
            m.Shear(skewX, skewY);                        //сдвигаем
            m.Translate(-worldAnchor.X, -worldAnchor.Y);  //возвращаем центр координат

            //
            Transform = m;
        }

        /// <summary>
        /// Поворот
        /// </summary>
        /// <param name="angle">Угол поворота, в градусах</param>
        /// <param name="center">Координаты центра вращения</param>
        public void Rotate(float angle, PointF center)
        {
            //можем вращать?
            var allowRotate = Geometry.AllowedOperations.HasFlag(AllowedOperations.Rotate);

            if (!allowRotate)
                return; //не можем вращать

            //считаем якорь в мировых координатах
            var worldAnchor = ToWorldCoordinates(center);

            //вращаем относительно якоря
            var m = new Matrix();
            m.RotateAt(angle, worldAnchor);      //вращаем

            //
            Transform = m;
        }
    }
}
