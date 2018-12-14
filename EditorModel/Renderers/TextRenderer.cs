using System;
using System.Drawing;
using EditorModel.Common;
using EditorModel.Figures;

namespace EditorModel.Renderers
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
            if (figure.Style.FillStyle == null || !figure.Style.FillStyle.IsVisible) return;
            // получаем путь для рисования, трансформированный методом фигуры
            using (var path = figure.Geometry.GetTransformedPath(figure))
            using (var sf = new StringFormat(StringFormatFlags.DisplayFormatControl))
            {
                var bounds = figure.Geometry.GetTransformedBounds(figure);
                Helper.UpdateStringFormat(sf, TextAlign);
                //graphics.TranslateTransform(bounds.Left + bounds.Width/2, bounds.Top + bounds.Height/2);
                //var angle = Helper.GetAngle(figure.Transform);
                //var size = Helper.GetSize(figure.Transform);
                //graphics.RotateTransform(angle);
                //var clientRect = new RectangleF(-size.Width/2, -size.Height/2, size.Width, size.Height);
                using (var brush = figure.Style.FillStyle.GetBrush(figure))
                {
                    //var x = sf.Alignment == StringAlignment.Near
                    //            ? -clientRect.Width/2
                    //            : sf.Alignment == StringAlignment.Far ? clientRect.Width/2 : 0;
                    //var y = sf.LineAlignment == StringAlignment.Near
                    //            ? -clientRect.Height/2
                    //            : sf.LineAlignment == StringAlignment.Far ? clientRect.Height/2 : 0;
                    //path.Reset();
                    //path.AddString(Text, new FontFamily(FontName), 0, FontSize, new PointF(x, y), sf);
                    graphics.FillPath(brush, path);
                }
                //graphics.ResetTransform();
            }
        }

        /// <summary>
        /// Свойство возвращает ограничения для подключения декораторов
        /// </summary>
        public override AllowedRendererDecorators AllowedDecorators
        {
            get
            {
                return AllowedRendererDecorators.All ^
                    (AllowedRendererDecorators.Shadow | AllowedRendererDecorators.Glow);
            }
        }
    }
}
