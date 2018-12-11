using System;
using System.Drawing;
using EditorModel.Figures;

namespace EditorModel.Renderers
{
    /// <summary>
    /// Класс рисовальщика фигуры с тенью
    /// </summary>
    [Serializable]
    public class ShadowRenderer : RendererDecorator
    {
        private readonly Renderer _renderer;
        private int _opacity;
        public PointF Offset { get; set; }

        public int Opacity
        {
            get { return _opacity; }
            set
            {
                if (value < 0 || value > 255) return;
                _opacity = value;
            }
        }

        public ShadowRenderer(Renderer renderer) 
            : base(renderer)
        {
            _renderer = renderer;
            Offset = new PointF(10, 10);
            Opacity = 128;
        }

        public override void Render(Graphics graphics, Figure figure)
        {
            // получаем путь для рисования, трансформированный методом фигуры
            using (var path = figure.GetTransformedPath().Path)
            {
                graphics.TranslateTransform(Offset.X, Offset.Y);
                var shadowColor = Color.FromArgb(Opacity, Color.Black);
                if (figure.Style.FillStyle != null)
                {
                    if ((!figure.Style.FillStyle.IsVisible) &&
                        figure.Style.BorderStyle != null && figure.Style.BorderStyle.IsVisible)
                        using (var pen = figure.Style.BorderStyle.GetPen(figure))
                        {
                            pen.Color = shadowColor;
                            graphics.DrawPath(pen, path);
                        }
                    if (figure.Style.FillStyle.IsVisible)
                        using (var brush = new SolidBrush(shadowColor))
                            graphics.FillPath(brush, path);
                }
                graphics.TranslateTransform(-Offset.X, -Offset.Y);
            }
            _renderer.Render(graphics, figure);
        }

        /// <summary>
        /// Свойство возвращает ограничения для подключения декораторов
        /// </summary>
        public override AllowedRendererDecorators AllowedDecorators
        {
            get { return AllowedRendererDecorators.All; }
        }

    }
}
