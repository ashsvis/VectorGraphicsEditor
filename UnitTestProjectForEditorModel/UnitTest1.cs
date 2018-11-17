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
        /* пока отставить
        [TestMethod]
        public void SerializationFigureTestMethod()
        {
            var builder = new FigureBuilder();
            // создаём фигуру, чтобы помучить
            var rect = new Figure();
            // настраиваем геометрию на прямоугольник
            builder.BuildRectangleGeometry(rect, new RectangleF(10f, 10f, 180f, 80f));
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(rect);

            byte[] buff;
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, rect);
                buff = ms.GetBuffer();
            }
            Figure restored;
            using (var fs = new MemoryStream(buff, false))
                restored = (Figure)new BinaryFormatter().Deserialize(fs);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    rect.Renderer.Render(canvas, rect);
                bmp.Save("RestoredRectangleFigure.bmp");
            }
        }
        */

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
            // настраиваем геометрию на текст
            builder.BuildTextGeometry(textfigure, 
                "The test for text string rendering complete.",
                new RectangleF(10f, 10f, 190f, 80f));
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(textfigure);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    textfigure.Renderer.Render(canvas, textfigure);
                bmp.Save("CreateTextFigure.bmp");
            }
        }

        [TestMethod]
        public void CreateSquareFigureTestMethod()
        {
            var builder = new FigureBuilder();
            var square = new Figure();
            // настраиваем геометрию на квадрат
            builder.BuildSquareGeometry(square, new PointF(50f, 10f), 80f);
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(square);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    square.Renderer.Render(canvas, square);
                bmp.Save("CreateSquareFigure.bmp");
            }
        }

        [TestMethod]
        public void CreateCircleFigureTestMethod()
        {
            var builder = new FigureBuilder();
            var circle = new Figure();
            // настраиваем геометрию на круг
            builder.BuildCircleGeometry(circle, new PointF(100f, 50f), 40f);
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(circle);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    circle.Renderer.Render(canvas, circle);
                bmp.Save("CreateCircleFigure.bmp");
            }
        }

        [TestMethod]
        public void CreateRectangleFigureTestMethod()
        {
            var builder = new FigureBuilder();
            // создаём фигуру, чтобы помучить
            var rect = new Figure();
            // настраиваем геометрию на прямоугольник
            builder.BuildRectangleGeometry(rect, new RectangleF(10f, 10f, 180f, 80f));
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(rect);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    rect.Renderer.Render(canvas, rect);
                bmp.Save("CreateRectangleFigure.bmp");
            }
        }

        [TestMethod]
        public void CreateEllipceFigureTestMethod()
        {
            var builder = new FigureBuilder();
            // создаём фигуру, чтобы помучить
            var rect = new Figure();
            // настраиваем геометрию на овал
            builder.BuildEllipceGeometry(rect, new RectangleF(10f, 10f, 180f, 80f));
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(rect);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    rect.Renderer.Render(canvas, rect);
                bmp.Save("CreateEllipceFigure.bmp");
            }
        }
    }
}
