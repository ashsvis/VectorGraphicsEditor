using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorModel.Figures
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
            figure.Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^ AllowedOperations.Size);
        }

        /// <summary>
        /// Построение пути для прямоугольника
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        public void BuildRectangleGeometry(Figure figure)
        {
            var path = new GraphicsPath();
            path.AddRectangle(new RectangleF(-0.5f, -0.5f, 1, 1));
            figure.Geometry = new PrimitiveGeometry(path, AllowedOperations.All);
        }

        /// <summary>
        /// Построение пути для круга
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        public void BuildCircleGeometry(Figure figure)
        {
            var path = new GraphicsPath();
            path.AddEllipse(new RectangleF(-0.5f, -0.5f, 1, 1));
            figure.Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^ AllowedOperations.Size);
        }

        /// <summary>
        /// Построение пути для эллипса
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        public void BuildEllipseGeometry(Figure figure)
        {
            var path = new GraphicsPath();
            path.AddEllipse(new RectangleF(-0.5f, -0.5f, 1, 1));
            figure.Geometry = new PrimitiveGeometry(path, AllowedOperations.All);
        }

        /// <summary>
        /// Построение пути для маркера
        /// </summary>
        /// <param name="marker"></param>
        public void BuildMarkerGeometry(Marker marker)
        {
            var path = new GraphicsPath();
            // здесь задаём размер макера в 5 единиц и смешение от центра маркера в -2 единицы
            path.AddRectangle(new RectangleF(-2f, -2f, 5f, 5f));
            marker.Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^ 
                (AllowedOperations.Size | AllowedOperations.Rotate | AllowedOperations.Select));         
        }

        //и т.д. для всех примитивных фигур
        //todo
        // а ромб - это примитивная геометрия или нет?
        // наверно нет, так как нет метода Path.Add..., чтобысразу его нарисовать

        /// <summary>
        /// Подключаем к фигуре геометрию текстовой строки
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        /// <param name="text">Текстовая строка</param>
        public void BuildTextGeometry(Figure figure, string text)
        {
            figure.Geometry = new TextGeometry { Text = text };
        }

        /// <summary>
        /// Подключаем к фигуре геометрию полигона
        /// </summary>
        /// <param name="figure"></param>
        public void BuildPolygoneGeometry(Figure figure)
        {
            figure.Geometry = new PolygoneGeometry();
        }
    }
}
