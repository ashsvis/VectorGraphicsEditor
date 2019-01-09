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
                    using (var pen = new Pen(Color.Black, 0f))
                    {
                        pen.DashStyle = DashStyle.Dot;
                        graphics.DrawRectangles(pen, new[] { bounds });
                        using (var sf = new StringFormat(StringFormat.GenericTypographic))
                        {
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Center;
                            graphics.DrawString("Image Place Holder", SystemFonts.DefaultFont, Brushes.Black, bounds, sf);
                        }
                    }
                }
                else
                {
                    PointF[] destinationPoints = { new PointF(-0.5f, -0.5f),    // destination for upper-left point of original
                                                   new PointF(0.5f, -0.5f),     // destination for upper-right point of original
                                                   new PointF(-0.5f, 0.5f)};    // destination for lower-left point of original
                    figure.Transform.Matrix.TransformPoints(destinationPoints);
                    var unit = GraphicsUnit.Pixel;
                    var rect = Image.Bitmap.GetBounds(ref unit);
                    graphics.DrawImage(image, destinationPoints, rect, GraphicsUnit.Pixel);
                }
            }
        }

        /// <summary>
        /// Свойство возвращает ограничения для подключения декораторов
        /// </summary>
        public override AllowedRendererDecorators AllowedDecorators
        {
            get { return AllowedRendererDecorators.All ^ 
                    (AllowedRendererDecorators.Shadow | 
                     AllowedRendererDecorators.Glow | 
                     AllowedRendererDecorators.TextBlock); }
        }
    }
}
