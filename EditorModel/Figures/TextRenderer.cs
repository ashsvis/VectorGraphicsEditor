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
                var bounds = path.GetBounds();
                if (!figure.Style.FillStyle.IsVisible) return;
                var rendered = figure.Renderer as TextRenderer;
                if (rendered == null) return;
                Helper.UpdateStringFormat(sf, rendered.TextAlign);
                graphics.TranslateTransform(bounds.Left + bounds.Width/2, bounds.Top + bounds.Height/2);
                var angle = Helper.GetAngle(figure.Transform);
                graphics.RotateTransform(angle);
                using (var font = new Font(rendered.FontName, rendered.FontSize))
                using (var brush = figure.Style.FillStyle.GetBrush(figure))
                {
                    var ms = graphics.MeasureString(rendered.Text, font);
                    var x = -ms.Width / 2;
                    var y = -ms.Height / 2;
                    path.Reset();
                    path.AddString(rendered.Text, new FontFamily(rendered.FontName), 0, rendered.FontSize, new PointF(0, 0), sf);

                    path.AddRectangle(new RectangleF(x, y, ms.Width, ms.Height));

                    graphics.FillPath(brush, path);
                }
                graphics.ResetTransform();
            }
        }
    }
}
