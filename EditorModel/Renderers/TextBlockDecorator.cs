using EditorModel.Common;
using EditorModel.Figures;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EditorModel.Renderers
{
    [Serializable]
    public class TextBlockDecorator : RendererDecorator, ITextBlock, IRendererTransformedPath
    {
        private readonly Renderer _renderer;

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


        public Padding Padding { get; set; }

        public TextBlockDecorator(Renderer renderer, Padding padding)
            : base(renderer)
        {
            _renderer = renderer;
            Text = "TextBlock";
            FontName = "Arial";
            FontSize = 14f;
            Alignment = ContentAlignment.MiddleCenter;
            Padding = padding;
        }

        /// <summary>
        /// Реализация интерфейса IRendererTransformedPath
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="figure"></param>
        /// <returns></returns>
        public GraphicsPath GetTransformedPath(Graphics graphics, Figure figure)
        {
            return TextRenderer.GetTextBlockTransformedPath(figure, this, Padding);
        }

        public override void Render(Graphics graphics, Figure figure)
        {
            _renderer.Render(graphics, figure);
            var baseRenderer = GetBaseRenderer(figure.Renderer) as IRendererTransformedPath;
            // получаем путь для рисования, трансформированный методом фигуры
            using (var path = baseRenderer != null
                ? baseRenderer.GetTransformedPath(graphics, figure)
                : figure.GetTransformedPath().Path)
            {
                using (var gp = GetTransformedPath(graphics, figure))
                using (var brush = new SolidBrush(Color.Black))
                    graphics.FillPath(brush, gp);
            }
        }

        /// <summary>
        /// Свойство возвращает ограничения для подключения декораторов
        /// </summary>
        public override AllowedRendererDecorators AllowedDecorators
        {
            get { return AllowedRendererDecorators.All ^ AllowedRendererDecorators.TextBlock; }
        }
    }
}
