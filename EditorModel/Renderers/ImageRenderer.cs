using System.Drawing.Drawing2D;
using EditorModel.Common;
using System;
using System.Drawing;
using EditorModel.Figures;

namespace EditorModel.Renderers
{
    /// <summary>
    /// Класс рисовальщика картинки
    /// </summary>
    [Serializable]
    public sealed class ImageRenderer : Renderer
    {
        public SerializableGraphicsImage Image { get; set; }

        public ImageRenderer(Bitmap image)
        {
            Image = image;
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
            {
                var bounds = path.GetBounds();
                var image = Image.Bitmap;
                if (image == null)
                {
                    using (var pen = new Pen(Color.Black, 1f))
                    {
                        pen.DashStyle = DashStyle.DashDot;
                        graphics.DrawRectangles(pen, new[] { bounds });
                    }
                }
                else
                {
                    PointF[] destinationPoints = { new PointF(-0.5f, -0.5f),    // destination for upper-left point of original
                                                   new PointF(0.5f, -0.5f),     // destination for upper-right point of original
                                                   new PointF(-0.5f, 0.5f)};    // destination for lower-left point of original
                    figure.Transform.Matrix.TransformPoints(destinationPoints);
                    graphics.DrawImage(image, destinationPoints);
                }
            }
        }

        /// <summary>
        /// Свойство возвращает ограничения для подключения декораторов
        /// </summary>
        public override AllowedRendererDecorators AllowedDecorators
        {
            get { return AllowedRendererDecorators.All ^ (AllowedRendererDecorators.Shadow | AllowedRendererDecorators.Glow); }
        }
    }
}
