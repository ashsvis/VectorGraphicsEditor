using EditorModel.Figures;
using System;
using System.Drawing;

namespace EditorModel.Renderers
{
    /// <summary>
    /// Класс рисовальщика фигуры со "свечением"
    /// </summary>
    [Serializable]
    public class GlowRenderer : RendererDecorator
    {
        private readonly Renderer _renderer;

        public GlowRenderer(Renderer renderer)
            : base(renderer)
        {
            _renderer = renderer;
        }

        public override void Render(Graphics graphics, Figure figure)
        {
            // получаем путь для рисования, трансформированный методом фигуры
            using (var path = figure.GetTransformedPath().Path)
            {
                if (figure.Style.BorderStyle != null && figure.Style.BorderStyle.IsVisible)
                    // то получаем карандаш из стиля рисования фигуры
                    using (var pen = figure.Style.BorderStyle.GetPen(figure))
                    {
                        for (var i = 0; i < 4; i++)
                        {
                            pen.Color = Color.FromArgb(pen.Color.A / 2, pen.Color);
                            pen.Width += 4;
                            graphics.DrawPath(pen, path);
                        }
                    }
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
