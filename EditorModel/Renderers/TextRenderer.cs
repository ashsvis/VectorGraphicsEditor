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
        //public float FontSize { get; set; }

        /// <summary>
        /// Выравнивание текста
        /// </summary>
        public StringAlignment Alignment { get; set; }


        public TextRenderer(string text)
        {
            Text = text;
            FontName = "Arial";
            //FontSize = 14f;
            Alignment = StringAlignment.Center;
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
                using (var gp = GetTransformedPath(figure))
                using (var brush = figure.Style.FillStyle.GetBrush(figure))
                    graphics.FillPath(brush, gp);
            }
            else
            {
                var bounds = figure.GetTransformedPath().Path.GetBounds();
                using (var pen = new Pen(Color.Black, 0f))
                {
                    pen.DashStyle = DashStyle.Dot;
                    graphics.DrawRectangles(pen, new[] { bounds });
                    using (var sf = new StringFormat(StringFormat.GenericTypographic))
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        graphics.DrawString("Text Place Holder", SystemFonts.DefaultFont, Brushes.Black, bounds, sf);
                    }
                }
            }
        }

        public GraphicsPath GetTransformedPath(Figure figure)
        {
            var text = string.IsNullOrWhiteSpace(Text) ? "(empty)" : Text;
            var graphicsPath = new GraphicsPath();
            using (var sf = new StringFormat(StringFormat.GenericTypographic))
            {
                sf.Alignment = Alignment;
                graphicsPath.AddString(
                    text,
                    new FontFamily(FontName),
                    0, //(int)FontStyle.Bold,
                    14f, // FontSize,
                    PointF.Empty,
                    sf
                );
            }
            var bounds = graphicsPath.GetBounds();
            var pts = graphicsPath.PathPoints;
            for (var i = 0; i < pts.Length; i++)
            {
                pts[i].X = (pts[i].X - bounds.Left) / bounds.Width - 0.5f;
                pts[i].Y = (pts[i].Y - bounds.Top) / bounds.Height - 0.5f;
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
                return AllowedRendererDecorators.All; // ^
                    //(AllowedRendererDecorators.Shadow | AllowedRendererDecorators.Glow);
            }
        }
    }
}
