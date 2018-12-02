using System;
using System.Drawing;

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

        public TextRenderer(string text)
        {
            Text = text;
            FontName = "Arial";
            FontSize = 14f;
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
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                var bounds = path.GetBounds();
                path.Reset();
                // добавляем в путь текстовую строку
                path.AddString(Text ?? "",
                    new FontFamily(FontName), 0, FontSize, bounds, sf);
                
                // если разрешено использование заливки
                if (figure.Style.FillStyle.IsVisible)
                    // то получаем кисть из стиля рисования фигуры
                    using (var brush = figure.Style.FillStyle.GetBrush(figure))
                        graphics.FillPath(brush, path);
                // если разрешено рисование контура
                if (figure.Style.BorderStyle.IsVisible)
                    // то получаем карандаш из стиля рисования фигуры
                    using (var pen = figure.Style.BorderStyle.GetPen(figure))
                        graphics.DrawPath(pen, path);
                path.Transform(figure.Transform);
            }
        }
    }
}
