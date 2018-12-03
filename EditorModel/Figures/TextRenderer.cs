using System;
using System.Drawing;
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
            using (var sf = new StringFormat(StringFormat.GenericTypographic))
            {
                AlignHelper.UpdateStringFormat(sf, TextAlign);
                var bounds = path.GetBounds();
                if (!figure.Style.FillStyle.IsVisible) return;
                var rendered = figure.Renderer as TextRenderer;
                if (rendered == null) return;
                using (var font = new Font(rendered.FontName, rendered.FontSize))
                using (var brush = figure.Style.FillStyle.GetBrush(figure))
                {
                    graphics.DrawString(rendered.Text, font, brush, bounds, sf);
                }
            }
        }
    }
}
