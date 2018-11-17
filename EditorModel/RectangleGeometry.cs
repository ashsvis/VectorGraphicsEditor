using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorModel
{
    /// <summary>
    /// Содержит прямоугольник с настраиваемым размером
    /// </summary>
    [Serializable]
    internal class RectangleGeometry : Geometry
    {
        /// <summary>
        /// Локальное поле для хранения пути (нет возможности сериализовать!)
        /// </summary>
        //private readonly GraphicsPath _path = new GraphicsPath();
        private readonly SerializableGraphicsPath _serializablePath = new SerializableGraphicsPath();

        public override GraphicsPath Path
        {
            get
            {
                var path = new GraphicsPath();
                path.AddRectangle(new RectangleF(Bounds.Location, Bounds.Size));
                return path;
            }
        }

        public RectangleF Bounds { get; internal set; }

        /// <summary>
        /// Конструктор, недоступный вне проекта EditorModel
        /// (только для внутреннего использования)
        /// </summary>
        internal RectangleGeometry()
        {

        }
    }
}
