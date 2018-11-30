using EditorModel.Common;
using EditorModel.Geometry;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorModel.Selections
{
    public static class SelectionHelper
    {
        /// <summary>
        /// Переводит точку из локальных нормализированных координат (0,0)-(1,1) в мировые координаты
        /// </summary>
        public static PointF ToWorldCoordinates(this Selection selection, PointF point)
        {
            var bounds = selection.GetTransformedPath().Path.GetBounds();
            return new PointF(bounds.Left + point.X * bounds.Width, bounds.Top + point.Y * bounds.Height);
        }

        /// <summary>
        /// Отражение по горизонтали
        /// </summary>
        public static void FlipX(this Selection selection)
        {
            //можем вращать?
            var allowRotate = selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Rotate);

            if (!allowRotate)
                return; //не можем вращать

            var m = new SerializableGraphicsMatrix();
            var anchor = selection.ToWorldCoordinates(new PointF(0.5f, 0.5f));
            m.Matrix.Translate(anchor.X, anchor.Y);    //переводим центр координат в якорь
            //отражаем по горизонтали относительно якоря
            m.Matrix.Multiply(new Matrix(-1, 0, 0, 1, 0, 0));
            m.Matrix.Translate(-anchor.X, -anchor.Y);  //возвращаем центр координат
            //
            selection.Transform = m;
        }

        /// <summary>
        /// Отражение по вертикали
        /// </summary>
        public static void FlipY(this Selection selection)
        {
            //можем вращать?
            var allowRotate = selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Rotate);

            if (!allowRotate)
                return; //не можем вращать

            var m = new SerializableGraphicsMatrix();
            var anchor = selection.ToWorldCoordinates(new PointF(0.5f, 0.5f));
            m.Matrix.Translate(anchor.X, anchor.Y);    //переводим центр координат в якорь
            //отражаем по вертикали относительно якоря
            m.Matrix.Multiply(new Matrix(1, 0, 0, -1, 0, 0));
            m.Matrix.Translate(-anchor.X, -anchor.Y);  //возвращаем центр координат
            //
            selection.Transform = m;
        }

        /// <summary>
        /// Поворот на четверть по часовой стрелке
        /// </summary>
        public static void Rotate90Cw(this Selection selection)
        {
            //можем вращать?
            var allowRotate = selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Rotate);

            if (!allowRotate)
                return; //не можем вращать

            var m = new SerializableGraphicsMatrix();
            var anchor = selection.ToWorldCoordinates(new PointF(0.5f, 0.5f));
            m.Matrix.Translate(anchor.X, anchor.Y);    //переводим центр координат в якорь
            //отражаем по вертикали относительно якоря
            m.Matrix.Multiply(new Matrix(0, 1, -1, 0, 0, 0));
            m.Matrix.Translate(-anchor.X, -anchor.Y);  //возвращаем центр координат
            //
            selection.Transform = m;
        }

        /// <summary>
        /// Поворот на четверть против часовой стрелки
        /// </summary>
        public static void Rotate90Ccw(this Selection selection)
        {
            //можем вращать?
            var allowRotate = selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Rotate);

            if (!allowRotate)
                return; //не можем вращать

            var m = new SerializableGraphicsMatrix();
            var anchor = selection.ToWorldCoordinates(new PointF(0.5f, 0.5f));
            m.Matrix.Translate(anchor.X, anchor.Y);    //переводим центр координат в якорь
            //отражаем по вертикали относительно якоря
            m.Matrix.Multiply(new Matrix(0, -1, 1, 0, 0, 0));
            m.Matrix.Translate(-anchor.X, -anchor.Y);  //возвращаем центр координат
            //
            selection.Transform = m;
        }

        /// <summary>
        /// Поворот на 180 градусов
        /// </summary>
        public static void Rotate180(this Selection selection)
        {
            //можем вращать?
            var allowRotate = selection.Geometry.AllowedOperations.HasFlag(AllowedOperations.Rotate);

            if (!allowRotate)
                return; //не можем вращать

            var m = new SerializableGraphicsMatrix();
            var anchor = selection.ToWorldCoordinates(new PointF(0.5f, 0.5f));
            m.Matrix.Translate(anchor.X, anchor.Y);    //переводим центр координат в якорь
            //отражаем по вертикали относительно якоря
            m.Matrix.Multiply(new Matrix(-1, 0, 0, -1, 0, 0));
            m.Matrix.Translate(-anchor.X, -anchor.Y);  //возвращаем центр координат
            //
            selection.Transform = m;
        }

    }
}
