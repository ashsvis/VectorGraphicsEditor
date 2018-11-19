using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorModel.Figures
{
    public class Marker : Figure
    {
        /// <summary>
        /// Конструктор с настройками по умолчанию
        /// </summary>
        public Marker()
        {
            var path = new GraphicsPath();
            path.AddRectangle(new RectangleF(-0.5f, -0.5f, 1, 1));
            this.Geometry = new PrimitiveGeometry(path, 
                AllowedOperations.All ^ 
                (AllowedOperations.Size & AllowedOperations.Rotate & AllowedOperations.Select));
        }

        /// <summary>
        /// Нормализация локальных координат
        /// </summary>
        public PointF NormalizedLocalCoordinates { get; set; }
    }
}
