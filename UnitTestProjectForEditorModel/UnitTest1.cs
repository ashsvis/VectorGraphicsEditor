using EditorModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace UnitTestProjectForEditorModel
{
    [TestClass]
    public class UnitTest1
    {
        private static Figure SerializeDeserialize(Figure rect)
        {
            byte[] buff;
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, rect);
                buff = ms.GetBuffer();
            }
            using (var fs = new MemoryStream(buff, false))
                return  (Figure)new BinaryFormatter().Deserialize(fs);
        }

        private static void CheckInternalClassesConnection(Figure figure)
        {
            // проверим, что все внутренние классы были подключены
            Assert.AreNotEqual(figure.Geometry, null, "Класс Figure.Geometry не подключен");
            Assert.AreNotEqual(figure.Style, null, "Класс Figure.Style не подключен");
            Assert.AreNotEqual(figure.Style.BorderStyle, null, "Класс Style.BorderStyle не подключен");
            Assert.AreNotEqual(figure.Style.FillStyle, null, "Класс Style.BorderStyle не подключен");
            Assert.AreNotEqual(figure.Transform, null, "Класс Figure.Transform не подключен");
            Assert.AreNotEqual(figure.Renderer, null, "Класс Figure.Renderer не подключен");
        }

        [TestMethod]
        public void CreateTextFigureTestMethod()
        {
            var builder = new FigureBuilder();
            var textfigure = new Figure();
            textfigure.Transform.Matrix.Translate(10, 10);
            // настраиваем геометрию на текст
            builder.BuildTextGeometry(textfigure, 
                "The test for text string rendering complete.");
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(textfigure);
            textfigure = SerializeDeserialize(textfigure);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    textfigure.Renderer.Render(canvas, textfigure);
                bmp.Save("CreateTextFigure.bmp");
            }
        }

        [TestMethod]
        public void CreatePolygonFigureTestMethod()
        {
            var builder = new FigureBuilder();
            var polygon = new Figure();
            polygon.Transform.Matrix.Translate(100, 50);
            polygon.Transform.Matrix.Scale(160, 80);
            // настраиваем геометрию на квадрат
            builder.BuildPolygoneGeometry(polygon);
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(polygon);
            polygon = SerializeDeserialize(polygon);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    polygon.Renderer.Render(canvas, polygon);
                bmp.Save("CreatePolygonFigure.bmp");
            }
        }

        [TestMethod]
        public void CreateSquareFigureTestMethod()
        {
            var builder = new FigureBuilder();
            var square = new Figure();
            square.Transform.Matrix.Translate(100, 50);
            //square.Transform.Matrix.Scale(80, 80);
            square.Transform.Matrix.Scale(160, 80);  // здесь должно срабатывать ограничение AllowedOperations.Size
            // настраиваем геометрию на квадрат
            builder.BuildSquareGeometry(square);
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(square);
            square = SerializeDeserialize(square);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    square.Renderer.Render(canvas, square);
                bmp.Save("CreateSquareFigure.bmp");
            }
        }

        [TestMethod]
        public void CreateRectangleFigureTestMethod()
        {
            var builder = new FigureBuilder();
            var rect = new Figure();
            rect.Transform.Matrix.Translate(100, 50);
            rect.Transform.Matrix.Scale(160, 80);
            // настраиваем геометрию на квадрат
            builder.BuildRectangleGeometry(rect);
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(rect);
            rect = SerializeDeserialize(rect);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    rect.Renderer.Render(canvas, rect);
                bmp.Save("CreateRectangleFigure.bmp");
            }
        }

        [TestMethod]
        public void CreateCircleFigureTestMethod()
        {
            var builder = new FigureBuilder();
            var circle = new Figure();
            circle.Transform.Matrix.Translate(100, 50);
            //circle.Transform.Matrix.Scale(80, 80);
            circle.Transform.Matrix.Scale(160, 80);  // здесь должно срабатывать ограничение AllowedOperations.Size
            // настраиваем геометрию на круг
            builder.BuildCircleGeometry(circle);
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(circle);
            circle = SerializeDeserialize(circle);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    circle.Renderer.Render(canvas, circle);
                bmp.Save("CreateCircleFigure.bmp");
            }
        }

        [TestMethod]
        public void CreateEllipseFigureTestMethod()
        {
            var builder = new FigureBuilder();
            var oval = new Figure();
            oval.Transform.Matrix.Translate(100, 50);
            oval.Transform.Matrix.Scale(160, 80);
            // настраиваем геометрию на круг
            builder.BuildEllipseGeometry(oval);
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(oval);
            oval = SerializeDeserialize(oval);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    oval.Renderer.Render(canvas, oval);
                bmp.Save("CreateEllipseFigure.bmp");
            }
        }

    }
}
