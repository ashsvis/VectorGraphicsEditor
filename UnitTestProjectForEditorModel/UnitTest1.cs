using System;
using EditorModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UnitTestProjectForEditorModel
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateTextFigureTestMethod()
        {
            var builder = new FigureBuilder();
            var text = new Figure()
            {
                Style = new Style()
                {
                    BorderStyle = new Border(),
                    FillStyle = new Fill()
                },
                Transform = new Matrix(),
                Renderer = new Renderer()
            };
            // настраиваем геометрию на квадрат
            builder.BuildTextGeometry(text);
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(text);
            // пробуем отрисовывать
            using (var pictbox = new PictureBox())
            {
                using (var canvas = pictbox.CreateGraphics())
                {
                    text.Renderer.Render(canvas, text);
                }
            }
        }

        [TestMethod]
        public void CreateSquareFigureTestMethod()
        {
            var builder = new FigureBuilder();
            var square = new Figure()
            {
                Style = new Style()
                {
                    BorderStyle = new Border(),
                    FillStyle = new Fill()
                },
                Transform = new Matrix(),
                Renderer = new Renderer()
            };
            // настраиваем геометрию на квадрат
            builder.BuildSquareGeometry(square);
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(square);
            // пробуем отрисовывать
            using (var pictbox = new PictureBox())
            {
                using (var canvas = pictbox.CreateGraphics())
                {
                    square.Renderer.Render(canvas, square);
                }
            }
        }

        [TestMethod]
        public void CreateCircleFigureTestMethod()
        {
            var builder = new FigureBuilder();
            var circle = new Figure()
            {
                Style = new Style()
                {
                    BorderStyle = new Border(),
                    FillStyle = new Fill()
                },
                Transform = new Matrix(),
                Renderer = new Renderer()
            };
            // настраиваем геометрию на квадрат
            builder.BuildCircleGeometry(circle);
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(circle);
            // пробуем отрисовывать
            using (var pictbox = new PictureBox())
            {
                using (var canvas = pictbox.CreateGraphics())
                {
                    circle.Renderer.Render(canvas, circle);
                }
            }
        }

        private static void CheckInternalClassesConnection(Figure square)
        {
            // проверим, что все внутренние классы были подключены
            Assert.AreNotEqual(square.Geometry, null, "Класс Figure.Geometry не подключен");
            Assert.AreNotEqual(square.Style, null, "Класс Figure.Style не подключен");
            Assert.AreNotEqual(square.Style.BorderStyle, null, "Класс Style.BorderStyle не подключен");
            Assert.AreNotEqual(square.Style.FillStyle, null, "Класс Style.BorderStyle не подключен");
            Assert.AreNotEqual(square.Transform, null, "Класс Figure.Transform не подключен");
            Assert.AreNotEqual(square.Renderer, null, "Класс Figure.Renderer не подключен");
        }

        class RectangleGeometry : Geometry
        {
            public override GraphicsPath Path
            {
                get
                {
                    var path = new GraphicsPath();
                    path.AddRectangle(new RectangleF(0, 0, 200, 100));
                    return path;
                }
            }
        }

        [TestMethod]
        public void CreateFigureTestMethod()
        {
            // создаём фигуру, чтобы помучить
            var fig = new Figure
            {
                Geometry = new RectangleGeometry(),
                Style = new Style()
                {
                    BorderStyle = new Border(),
                    FillStyle = new Fill()
                },
                Transform = new Matrix(),
                Renderer = new Renderer()
            };
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(fig);
            // пробуем отрисовывать
            using (var pictbox = new PictureBox())
            {
                using (var canvas = pictbox.CreateGraphics())
                {
                    fig.Renderer.Render(canvas, fig);
                }
            }
        }
    }
}
