using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using EditorModel.Common;

namespace EditorModel.Figures
{
    /// <summary>
    /// Класс рисовальщика текстового блока
    /// </summary>
    [Serializable]
    public class TextRenderer : Renderer
    {
        /// <summary>
        /// Текст для построения пути
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Имя файла шрифта
        /// </summary>
        public string FontName { get; set; }

        /// <summary>
        /// Размер шрифта
        /// </summary>
        public float FontSize { get; set; }

        /// <summary>
        /// Выравнивание текста
        /// </summary>
        public ContentAlignment TextAlign { get; set; }


        public TextRenderer(string text)
        {
            Text = text;
            FontName = "Arial";
            FontSize = 14f;
            TextAlign = ContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// Метод отрисовки фигуры на канве
        /// </summary>
        /// <param name="graphics">Канва для рисования</param>
        /// <param name="figure">Фигура со свойствами для рисования</param>
        public override void Render(Graphics graphics, Figure figure)
        {
            // получаем путь для рисования, трансформированный методом фигуры
            using (var path = figure.GetTransformedPath().Path)
            using (var sf = new StringFormat(StringFormatFlags.DisplayFormatControl))
            {
                Helper.UpdateStringFormat(sf, TextAlign);
                var bounds = path.GetBounds();
                if (!figure.Style.FillStyle.IsVisible) return;
                var rendered = figure.Renderer as TextRenderer;
                if (rendered == null) return;
                graphics.TranslateTransform(bounds.Left + bounds.Width/2, bounds.Top + bounds.Height/2);
                var angle = Helper.GetAngle(figure.Transform);
                graphics.RotateTransform(angle);
                using (var font = new Font(rendered.FontName, rendered.FontSize))
                using (var brush = figure.Style.FillStyle.GetBrush(figure))
                {
                    int charFitted, linesFilled;
                    var ms = graphics.MeasureString(rendered.Text, font, bounds.Size, sf, out charFitted, out linesFilled);
                    var x = -ms.Width / 2;
                    var dx = 0; // (float)(bounds.Width / 2 - ms.Width);
                    switch (sf.Alignment)
                    {
                        case StringAlignment.Near:
                            x = -ms.Width - dx;
                            break;
                        case StringAlignment.Far:
                            x = 0 + dx;
                            break;
                    }
                    var y = -ms.Height / 2;
                    var dy = 0; // (float)(bounds.Height / 2 - ms.Height);
                    switch (sf.LineAlignment)
                    {
                        case StringAlignment.Near:
                            y = -ms.Height - dy;
                            break;
                        case StringAlignment.Far:
                            y = 0 + dy;
                            break;
                    }
                    Console.WriteLine("cos: " + Math.Abs(Math.Cos(angle)) + " sin: " + Math.Abs(Math.Sin(angle)) + " tan: " + Math.Abs(Math.Tan(angle)));
                    var rect = new RectangleF(x, y, ms.Width, ms.Height);
                    //graphics.DrawRectangles(Pens.Magenta, new [] {rect});
                    graphics.DrawString(rendered.Text, font, brush, rect);
                }
                graphics.ResetTransform();
            }
        }
    }
}
