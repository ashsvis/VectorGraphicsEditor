using System.Drawing.Drawing2D;
using EditorModel.Figures;
using EditorModel.Selections;
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

        private static void Draw(string fileName, params Figure[] figures)
        {
            using (var bmp = new Bitmap(400, 400))
            {
                using (var canvas = Graphics.FromImage(bmp))
                {
                    canvas.Clear(Color.White);
                    foreach (var fig in figures)
                        fig.Renderer.Render(canvas, fig);
                }
                bmp.Save(fileName);
            }
        }

        [TestMethod]
        public void SelectionTest2()
        {
            //создаем первую фигуру
            var fig1 = new Figure();
            fig1.Transform.Matrix.Translate(150, 150);
            fig1.Transform.Matrix.Scale(30, 30);
            FigureBuilder.BuildEllipseGeometry(fig1);

            //создаем вторую фигуру
            var fig2 = new Figure();
            fig2.Transform.Matrix.Translate(200, 200);
            fig2.Transform.Matrix.Scale(30, 30);
            FigureBuilder.BuildRectangleGeometry(fig2);

            //рисуем до выделения
            Draw("2_1.png", fig1, fig2);

            //создаем selection
            var selection = new Selection();
            selection.Style.BorderStyle.Width = 1;
            selection.Style.BorderStyle.Color = Color.Magenta;

            //выделяем фигуры 
            selection.Add(fig1);
            selection.Add(fig2);

            //ресайз по X относительно левого края
            selection.Scale(2, 1, selection.ToWorldCoordinates(new PointF(0, 0.5f)));
            selection.PushTransformToSelectedFigures();
            //рисуем
            Draw("2_2.png", fig1, fig2, selection);

            //ресайз по Y относительно нижнего края
            selection.Scale(1, 2, selection.ToWorldCoordinates(new PointF(0.5f, 1)));
            selection.PushTransformToSelectedFigures();
            //рисуем
            Draw("2_3.png", fig1, fig2, selection);

            //вращение относительно центра
            selection.Rotate(45, selection.ToWorldCoordinates(new PointF(0.5f, 0.5f)));
            selection.PushTransformToSelectedFigures();
            //рисуем
            Draw("2_4.png", fig1, fig2, selection);

            //сдвиг
            selection.Translate(100, 100);
            selection.PushTransformToSelectedFigures();
            //рисуем
            Draw("2_5.png", fig1, fig2, selection);

            //skew по X относительно нижней границы
            selection.Skew(0.5f, 0, selection.ToWorldCoordinates(new PointF(0.5f, 1)));
            selection.PushTransformToSelectedFigures();
            //рисуем
            Draw("2_6.png", fig1, fig2, selection);

            //результат
            selection.Clear();
            Draw("2_7.png", fig1, fig2, selection);
        }

        [TestMethod]
        public void SelectionFigureTestMethod()
        {
            //создаем первую фигуру
            var fig1 = new Figure();
            fig1.Transform.Matrix.Translate(50, 50);
            fig1.Transform.Matrix.Scale(100, 100);
            FigureBuilder.BuildEllipseGeometry(fig1);

            //создаем вторую фигуру
            var fig2 = new Figure();
            fig2.Transform.Matrix.Translate(150, 150);
            fig2.Transform.Matrix.Scale(100, 100);
            FigureBuilder.BuildRectangleGeometry(fig2);

            //рисуем до выделения
            Draw("1_1.png", fig1, fig2);

            //создаем selection
            var selection = new Selection();
            selection.Style.BorderStyle.Width = 1;
            selection.Style.BorderStyle.Color = Color.Magenta;

            //выделяем фигуры 
            selection.Add(fig1);
            selection.Add(fig2);

            //рисуем после выделения
            Draw("1_2.png", fig1, fig2, selection);

            //вращаем и выделенные фигуры
            Matrix m = selection.Transform;
            m.RotateAt(45, new PointF(100, 100));
            selection.PushTransformToSelectedFigures();

            //рисуем после вращения выделенных фигур
            Draw("1_3.png", fig1, fig2, selection);

            //перемещаем выделенные фигуры
            m = selection.Transform;
            m.Translate(0, 100);
            selection.PushTransformToSelectedFigures();

            //рисуем после перемещения выделенных фигур
            Draw("1_4.png", fig1, fig2, selection);

            //снимаем выделение, отрисовываем результат
            selection.Clear();
            Draw("1_5.png", fig1, fig2, selection);
        }

        [TestMethod]
        public void TextFigureTestMethod()
        {
            var textfigure = new Figure();
            textfigure.Transform.Matrix.Translate(10, 10);
            // настраиваем геометрию на текст
            FigureBuilder.BuildTextGeometry(textfigure, 
                "The test for text string rendering complete.");
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(textfigure);
            textfigure = SerializeDeserialize(textfigure);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    textfigure.Renderer.Render(canvas, textfigure);
                bmp.Save("TextFigure.png");
            }
        }

        [TestMethod]
        public void PolygonFigureTestMethod()
        {
            var polygon = new Figure();
            polygon.Transform.Matrix.Translate(100, 50);
            polygon.Transform.Matrix.Scale(160, 80);
            // настраиваем геометрию на квадрат
            FigureBuilder.BuildPolyGeometry(polygon);
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(polygon);
            polygon = SerializeDeserialize(polygon);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    polygon.Renderer.Render(canvas, polygon);
                bmp.Save("PolygonFigure.png");
            }
        }

        [TestMethod]
        public void SquareFigureTestMethod()
        {
            var square = new Figure();
            square.Transform.Matrix.Translate(100, 50);
            square.Transform.Matrix.Scale(80, 80); 
            // настраиваем геометрию на квадрат
            FigureBuilder.BuildSquareGeometry(square);
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(square);
            square = SerializeDeserialize(square);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    square.Renderer.Render(canvas, square);
                bmp.Save("SquareFigure.png");
            }
        }

        [TestMethod]
        public void RectangleFigureTestMethod()
        {
            var rect = new Figure();
            rect.Transform.Matrix.Translate(100, 50);
            rect.Transform.Matrix.Scale(160, 80);
            // настраиваем геометрию на квадрат
            FigureBuilder.BuildRectangleGeometry(rect);
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(rect);
            rect = SerializeDeserialize(rect);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    rect.Renderer.Render(canvas, rect);
                bmp.Save("RectangleFigure.png");
            }
        }

        [TestMethod]
        public void CircleFigureTestMethod()
        {
            var circle = new Figure();
            circle.Transform.Matrix.Translate(100, 50);
            circle.Transform.Matrix.Scale(80, 80);
            // настраиваем геометрию на круг
            FigureBuilder.BuildCircleGeometry(circle);
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(circle);
            circle = SerializeDeserialize(circle);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    circle.Renderer.Render(canvas, circle);
                bmp.Save("CircleFigure.png");
            }
        }

        [TestMethod]
        public void EllipseFigureTestMethod()
        {
            var oval = new Figure();
            oval.Transform.Matrix.Translate(100, 50);
            oval.Transform.Matrix.Scale(160, 80);
            // настраиваем геометрию на круг
            FigureBuilder.BuildEllipseGeometry(oval);
            // проверим, что все внутренние классы были подключены
            CheckInternalClassesConnection(oval);
            oval = SerializeDeserialize(oval);
            // пробуем отрисовывать
            using (var bmp = new Bitmap(200, 100))
            {
                using (var canvas = Graphics.FromImage(bmp))
                    oval.Renderer.Render(canvas, oval);
                bmp.Save("EllipseFigure.png");
            }
        }

    }
}
