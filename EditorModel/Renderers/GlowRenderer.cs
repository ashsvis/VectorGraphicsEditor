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
            Color = Color.Yellow;
        }

        public override void Render(Graphics graphics, Figure figure)
        {
            // получаем путь для рисования, трансформированный методом фигуры
            using (var path = figure.GetTransformedPath().Path)
            {
                // то получаем карандаш из стиля рисования фигуры
                using (var pen = new Pen(Color))
                {
                    var color = Color;
                    for (var i = 0; i < 4; i++)
                    {
                        pen.Color = Color.FromArgb(color.A / 2, color);
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
