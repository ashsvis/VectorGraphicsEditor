using EditorModel.Common;
using System.Drawing;
using EditorModel.Geometry;

namespace EditorModel.Figures
{
    /// <summary>
    /// Строит компоненты фигуры
    /// </summary>
    public class FigureBuilder
    {
// ReSharper disable InconsistentNaming
        private const int MARKER_SIZE = 8;
// ReSharper restore InconsistentNaming

        /// <summary>
        /// Построение пути для квадрата
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        public void BuildSquareGeometry(Figure figure)
        {
            var path = new SerializableGraphicsPath();
            path.Path.AddRectangle(new RectangleF(-0.5f, -0.5f, 1, 1));
            figure.Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^ (AllowedOperations.Size | AllowedOperations.Vertex));
        }

        /// <summary>
        /// Построение пути для прямоугольника
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        public void BuildRectangleGeometry(Figure figure)
        {
            var path = new SerializableGraphicsPath();
            path.Path.AddRectangle(new RectangleF(-0.5f, -0.5f, 1, 1));
            figure.Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^ AllowedOperations.Vertex);
        }

        /// <summary>
        /// Построение пути для круга
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        public void BuildCircleGeometry(Figure figure)
        {
            var path = new SerializableGraphicsPath();
            path.Path.AddEllipse(new RectangleF(-0.5f, -0.5f, 1, 1));
            figure.Geometry = new PrimitiveGeometry(path, 
                AllowedOperations.All ^ (AllowedOperations.Size | AllowedOperations.Rotate | AllowedOperations.Vertex));
        }

        /// <summary>
        /// Построение пути для эллипса
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        public void BuildEllipseGeometry(Figure figure)
        {
            var path = new SerializableGraphicsPath();
            path.Path.AddEllipse(new RectangleF(-0.5f, -0.5f, 1, 1));
            figure.Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^ AllowedOperations.Vertex);
        }

        /// <summary>
        /// Построение пути для маркера
        /// </summary>
        /// <param name="marker"></param>
        public void BuildMarkerGeometry(Figure marker)
        {
            var path = new SerializableGraphicsPath();
            // здесь задаём размер макера в 5 единиц и смешение от центра маркера в -2 единицы
            path.Path.AddRectangle(new RectangleF(-MARKER_SIZE / 2f, -MARKER_SIZE / 2f, MARKER_SIZE, MARKER_SIZE));
            marker.Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^ 
                (AllowedOperations.Size | AllowedOperations.Rotate | AllowedOperations.Select | AllowedOperations.Skew | AllowedOperations.Vertex));         
        }

        //и т.д. для всех примитивных фигур
        //todo
        // а ромб - это примитивная геометрия или нет?
        // наверно нет, так как нет метода Path.Add..., чтобы сразу его нарисовать

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

        /// <summary>
        /// Подключаем к фигуре геометрию ломаной линии
        /// </summary>
        /// <param name="figure"></param>
        public void BuildPolylineGeometry(Figure figure)
        {
            figure.Geometry = new PolylineGeometry();
        }

        /// <summary>
        /// Определение вида рамки выбора
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="startPoint"></param>
        public void BuildFrameGeometry(Figure figure, Point startPoint)
        {
            figure.Geometry = new FrameGeometry(startPoint);
        }
    }
}
