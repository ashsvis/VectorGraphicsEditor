using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorModel
{
    /// <summary>
    /// Содержит овал с настраиваемым размером
    /// </summary>
    [Serializable]
    internal class EllipceGeometry : Geometry
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
                path.AddEllipse(new RectangleF(Bounds.Location, Bounds.Size));
                return path;
            }
        }

        public RectangleF Bounds { get; internal set; }

        /// <summary>
        /// Конструктор, недоступный вне проекта EditorModel
        /// (только для внутреннего использования)
        /// </summary>
        internal EllipceGeometry()
        {

        }
    }
}
