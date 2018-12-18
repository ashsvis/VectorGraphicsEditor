using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using EditorModel.Common;
using EditorModel.Figures;

namespace EditorModel.Renderers
{
    /// <summary>
    /// Класс рисовальщика текстового блока
    /// </summary>
    [Serializable]
    public class TextRenderer : Renderer, IRendererTransformedPath
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
        /// Тип шрифта
        /// </summary>
        public FontStyle FontStyle { get; set; }
        
        /// <summary>
        /// Выравнивание текста
        /// </summary>
        public ContentAlignment Alignment { get; set; }


        public TextRenderer(string text)
        {
            Text = text;
            FontName = "Arial";
            FontSize = 36f;
            Alignment = ContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// Метод отрисовки фигуры на канве
        /// </summary>
        /// <param name="graphics">Канва для рисования</param>
        /// <param name="figure">Фигура со свойствами для рисования</param>
        public override void Render(Graphics graphics, Figure figure)
        {
            if (figure.Style.FillStyle != null && figure.Style.FillStyle.IsVisible)
            {
                using (var gp = GetTransformedPath(graphics, figure))
                using (var brush = figure.Style.FillStyle.GetBrush(figure))
                    graphics.FillPath(brush, gp);
            }
        }

        public GraphicsPath GetTransformedPath(Graphics graphics, Figure figure)
        {
            var text = string.IsNullOrWhiteSpace(Text) ? "(empty)" : Text;
            var graphicsPath = new GraphicsPath();
            using (var sf = new StringFormat(StringFormat.GenericTypographic))
            {
                Helper.UpdateStringFormat(sf, Alignment);
                graphicsPath.AddString(text, new FontFamily(FontName), (int)FontStyle, FontSize, PointF.Empty, sf);
            }
            var textBounds = graphicsPath.GetBounds();
            var pts = graphicsPath.PathPoints;
            var outRectSize = Helper.GetSize(figure.Transform);
            var eps = 0.0001f;
            var kfx = (outRectSize.Width < eps) ? eps : 1 / outRectSize.Width;
            var kfy = (outRectSize.Height < eps) ? eps : 1 / outRectSize.Height;
            var dx = outRectSize.Width - textBounds.Width;
            var dy = outRectSize.Height - textBounds.Height;
            switch (Alignment)
            {
                case ContentAlignment.TopLeft:
                    dx = 0;
                    dy = 0;
                    break;
                case ContentAlignment.TopCenter:
                    dx /= 2f;
                    dy = 0;
                    break;
                case ContentAlignment.TopRight:
                    dy = 0;
                    break;
                case ContentAlignment.MiddleLeft:
                    dx = 0;
                    dy /= 2f;
                    break;
                case ContentAlignment.MiddleCenter:
                    dx /= 2f;
                    dy /= 2f;
                    break;
                case ContentAlignment.MiddleRight:
                    dy /= 2f;
                    break;
                case ContentAlignment.BottomLeft:
                    dx = 0;
                    break;
                case ContentAlignment.BottomCenter:
                    dx /= 2f;
                    break;
            }
            for (var i = 0; i < pts.Length; i++)
            {
                pts[i].X = kfx * (pts[i].X - textBounds.Left + dx) - 0.5f;
                pts[i].Y = kfy * (pts[i].Y - textBounds.Top + dy) - 0.5f;
            }
            var ptt = graphicsPath.PathTypes;
            figure.Transform.Matrix.TransformPoints(pts);
            return new GraphicsPath(pts, ptt);
        }

        /// <summary>
        /// Свойство возвращает ограничения для подключения декораторов
        /// </summary>
        public override AllowedRendererDecorators AllowedDecorators
        {
            get
            {
                return AllowedRendererDecorators.All;
            }
        }
    }
}
