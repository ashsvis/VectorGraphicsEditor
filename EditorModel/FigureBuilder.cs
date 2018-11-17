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
        public void BuildSquareGeometry(Figure figure)
        {
            var path = new SerializableGraphicsPath();
            path.Path.AddRectangle(new RectangleF(-0.5f, -0.5f, 1, 1));
            figure.Geometry = new PrimitiveGeometry(path);
        }

        /// <summary>
        /// Построение пути для круга
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        public void BuildCircleGeometry(Figure figure)
        {
            var path = new SerializableGraphicsPath();
            path.Path.AddEllipse(new RectangleF(-0.5f, -0.5f, 1, 1));
            figure.Geometry = new PrimitiveGeometry(path);
        }

        //и т.д. для всех примитивных фигур
        //todo

        public void BuildTextGeometry(Figure figure, string text)
        {
            figure.Geometry = new TextGeometry { Text = text };
        }

    }
}
