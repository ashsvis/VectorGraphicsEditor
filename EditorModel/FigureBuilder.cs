using System.Drawing;
using System.Drawing.Drawing2D;

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
            var path = new GraphicsPath();
            path.AddRectangle(new RectangleF(-0.5f, -0.5f, 1, 1));
            figure.Geometry = new PrimitiveGeometry(path);
        }

        /// <summary>
        /// Построение пути для круга
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        public void BuildCircleGeometry(Figure figure)
        {
            var path = new GraphicsPath();
            path.AddEllipse(new RectangleF(-0.5f, -0.5f, 1, 1));
            figure.Geometry = new PrimitiveGeometry(path);
        }

        //и т.д. для всех примитивных фигур
        //todo

        public void BuildTextGeometry(Figure figure)
        {
            var txtGeometry = new TextGeometry()
            {
                Text = "Hello, World!"
            };
            figure.Geometry = txtGeometry;
        }

    }
}
