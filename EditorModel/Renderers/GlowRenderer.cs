using EditorModel.Common;
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

        /// <summary>
        /// Цвет для свечения
        /// </summary>
        public Color Color { get; set; }

        public GlowRenderer(Renderer renderer)
            : base(renderer)
        {
            _renderer = renderer;
            Color = Color.White;
        }

        public override void Render(Graphics graphics, Figure figure)
        {
            var baseRenderer = GetBaseRenderer(figure.Renderer) as IRendererTransformedPath;
            // получаем путь для рисования, трансформированный методом фигуры
            using (var path = baseRenderer != null
                ? baseRenderer.GetTransformedPath(graphics, figure)
                : figure.GetTransformedPath().Path)
            {
                // то получаем карандаш из стиля рисования фигуры
                using (var pen = new Pen(Color))
                {
                    var color = Color;
                    for (var i = 0; i < 8; i++)
                    {
                        pen.Color = color;
                        pen.Width += 4;
                        graphics.DrawPath(pen, path);
                        color = Color.FromArgb(color.A / 2, color);
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
