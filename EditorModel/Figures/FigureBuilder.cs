using System;
using System.Collections.Generic;
using EditorModel.Common;
using System.Drawing;
using EditorModel.Geometry;
using EditorModel.Renderers;
using EditorModel.Style;

namespace EditorModel.Figures
{
    /// <summary>
    /// Строит компоненты фигуры
    /// </summary>
    public static class FigureBuilder
    {
// ReSharper disable InconsistentNaming
        private const int MARKER_SIZE = 8;
// ReSharper restore InconsistentNaming

        /// <summary>
        /// Построение пути для квадрата
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        public static void BuildSquareGeometry(Figure figure)
        {
            var path = new SerializableGraphicsPath();
            path.Path.AddRectangle(new RectangleF(-0.5f, -0.5f, 1, 1));
            figure.Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^
                (AllowedOperations.Size | AllowedOperations.Vertex))
            { Name = "Square" };
        }

        /// <summary>
        /// Построение пути для прямоугольника
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        public static void BuildRectangleGeometry(Figure figure)
        {
            var path = new SerializableGraphicsPath();
            path.Path.AddRectangle(new RectangleF(-0.5f, -0.5f, 1, 1));
            figure.Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^ AllowedOperations.Vertex)
            { Name = "Rectangle" };
        }

        /// <summary>
        /// Построение пути для круга
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        public static void BuildCircleGeometry(Figure figure)
        {
            var path = new SerializableGraphicsPath();
            path.Path.AddEllipse(new RectangleF(-0.5f, -0.5f, 1, 1));
            figure.Geometry = new PrimitiveGeometry(path, 
                AllowedOperations.All ^ (AllowedOperations.Size | AllowedOperations.Rotate | AllowedOperations.Vertex))
            { Name = "Circle" };
        }

        /// <summary>
        /// Построение пути для эллипса
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        public static void BuildEllipseGeometry(Figure figure)
        {
            var path = new SerializableGraphicsPath();
            path.Path.AddEllipse(new RectangleF(-0.5f, -0.5f, 1, 1));
            figure.Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^ AllowedOperations.Vertex)
            { Name = "Ellipse" };
        }

        /// <summary>
        /// Построение пути для маркера
        /// </summary>
        /// <param name="marker"></param>
        public static void BuildMarkerGeometry(Figure marker)
        {
            var path = new SerializableGraphicsPath();
            // здесь задаём размер макера в 5 единиц и смешение от центра маркера в -2 единицы
            path.Path.AddRectangle(new RectangleF(-MARKER_SIZE / 2f, -MARKER_SIZE / 2f, MARKER_SIZE, MARKER_SIZE));
            marker.Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^ 
                (AllowedOperations.Size | AllowedOperations.Rotate | AllowedOperations.Select | 
                 AllowedOperations.Skew | AllowedOperations.Vertex))
            { Name = "Marker" };
        }

        /// <summary>
        /// Подключаем к фигуре геометрию текстовой строки
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        /// <param name="text">Текстовая строка</param>
        public static void BuildTextGeometry(Figure figure, string text)
        {
            figure.Geometry = new TextGeometry { Text = text, Name = "Text" };
            figure.Style.FillStyle = new DefaultFill(AllowedFillDecorators.All ^
                AllowedFillDecorators.RadialGradient) { Color = Color.Black };
            figure.Style.BorderStyle.IsVisible = false; // рамка по умолчанию выключена
        }

        /// <summary>
        /// Подключаем к фигуре геометрию текстового блока
        /// </summary>
        /// <param name="figure">Фигура для присвоения геометрии</param>
        /// <param name="text">Текстовая строка</param>
        public static void BuildTextRenderGeometry(Figure figure, string text)
        {
            var path = new SerializableGraphicsPath();
            path.Path.AddRectangle(new RectangleF(-0.5f, -0.5f, 1, 1));

            figure.Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^ 
                (AllowedOperations.Vertex | AllowedOperations.Pathed))
            { Name = "TextBlock" };

            figure.Style.BorderStyle = null; // отключение рамки для рендера
            figure.Style.FillStyle = new DefaultFill(AllowedFillDecorators.All ^
                AllowedFillDecorators.RadialGradient) { Color = Color.Black };

            figure.Renderer = new TextRenderer(text);
        }

        /// <summary>
        /// Подключаем к фигуре геометрию и рендерер внешнего графического файла
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="image"></param>
        public static void BuildImageRenderGeometry(Figure figure, Bitmap image)
        {
            var path = new SerializableGraphicsPath();
            path.Path.AddRectangle(new RectangleF(-0.5f, -0.5f, 1, 1));

            figure.Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^
                (AllowedOperations.Vertex | AllowedOperations.Pathed))
            { Name = "Image" };
            figure.Style.BorderStyle = null; // отключение рамки для рендера
            figure.Style.FillStyle = null; // отключение заливки для рендера
            figure.Renderer = new ImageRenderer(image);     
        }

        /// <summary>
        /// Подключаем к фигуре геометрию полигона
        /// </summary>
        /// <param name="figure"></param>
        public static void BuildPolygoneGeometry(Figure figure)
        {
            figure.Style.FillStyle.IsVisible = false;
            figure.Geometry = new PolygoneGeometry() { Name = "Polygone" };
        }

        /// <summary>
        /// Подключаем к фигуре геометрию полигона
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="vertexCount">Количество вершин</param>
        public static void BuildRegularGeometry(Figure figure, int vertexCount)
        {
            if (vertexCount < 3) throw new ArgumentOutOfRangeException("vertexCount", 
                "Количество вершин должно быть три и более.");

            const float radius = 0.5f;
            var points = new List<PointF>();
            var stepAngle = Math.PI * 2 / vertexCount;
            var angle = - Math.PI * 2;
            for (var i = 0; i < vertexCount; i++)
            {
                points.Add(new PointF((float)(radius * Math.Cos(angle)), (float)(radius * Math.Sin(angle))));
                angle += stepAngle;
            }

            var path = new SerializableGraphicsPath();
            path.Path.AddPolygon(points.ToArray());

            var names = new[] {"Nothing", "Circle", "Line", "Triangle", "Romb", "Pentagon", "Gexagon" };

            figure.Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^ 
                (AllowedOperations.Vertex | AllowedOperations.Size | AllowedOperations.Skew))
            { Name = vertexCount <= 6 ? names[vertexCount] : "Regular" + vertexCount };
        }

        /// <summary>
        /// Подключаем к фигуре геометрию ломаной линии
        /// </summary>
        /// <param name="figure"></param>
        public static void BuildPolylineGeometry(Figure figure)
        {
            figure.Style.FillStyle.IsVisible = false;
            figure.Geometry = new PolygoneGeometry(isClosed: false) { Name = "Polyline" };
        }

        /// <summary>
        /// Определение вида рамки выбора
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="startPoint"></param>
        public static void BuildFrameGeometry(Figure figure, Point startPoint)
        {
            figure.Geometry = new FrameGeometry(startPoint) { Name = "Frame" };
        }
    }
}
