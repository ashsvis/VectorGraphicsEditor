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
            // здесь задаём размер макера в 5 единиц и смешение от центра маркера в -2 единицы
            path.AddRectangle(new RectangleF(-2f, -2f, 5f, 5f));
            Geometry = new PrimitiveGeometry(path, AllowedOperations.All);
        }

        /// <summary>
        /// Нормализация локальных координат
        /// </summary>
        public PointF NormalizedLocalCoordinates { get; set; }
    }
}
