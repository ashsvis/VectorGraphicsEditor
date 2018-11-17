using System.Drawing;

namespace EditorModel
{
    /// <summary>
    /// Строит компоненты фигуры
    /// </summary>
    public class FigureBuilder
    {
        /// <summary>
        /// Построение пути для квадрата
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        /// <param name="origin">левый верхний угол</param>
        /// <param name="side">размер стороны квадрата</param>
        public void BuildSquareGeometry(Figure figure, PointF origin, float side)
        {
            //var path = new GraphicsPath();
            var serializablePath = new SerializableGraphicsPath();
            // path.AddRectangle(new RectangleF(origin.X, origin.Y, side, side));
            serializablePath.Path.AddRectangle(new RectangleF(origin.X, origin.Y, side, side));
            figure.Geometry = new PrimitiveGeometry(serializablePath);
        }

        /// <summary>
        /// Построение пути для круга
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        /// <param name="center">Центр окружности</param>
        /// <param name="radius">Радиус</param>
        public void BuildCircleGeometry(Figure figure, PointF center, float radius)
        {
            //var path = new GraphicsPath();
            var serializablePath = new SerializableGraphicsPath();
            serializablePath.Path.AddEllipse(new RectangleF(center.X - radius, center.Y - radius, radius * 2, radius * 2));
            figure.Geometry = new PrimitiveGeometry(serializablePath);
        }

        //и т.д. для всех примитивных фигур
        //todo

        public void BuildTextGeometry(Figure figure, string text, RectangleF rectangle)
        {
            figure.Geometry = new TextGeometry { Text = text, Bounds = rectangle };
        }

        public void BuildRectangleGeometry(Figure figure, RectangleF rectangle)
        {
            figure.Geometry = new RectangleGeometry { Bounds = rectangle };
        }

        public void BuildEllipceGeometry(Figure figure, RectangleF rectangle)
        {
            figure.Geometry = new EllipceGeometry { Bounds = rectangle };
        }

    }
}
