using System.Drawing.Drawing2D;
using EditorModel.Common;
using System;
using System.Drawing;
using EditorModel.Figures;
using System.IO;

namespace EditorModel.Renderers
{
    /// <summary>
    /// Класс рисовальщика картинки
    /// </summary>
    [Serializable]
    public sealed class ImageRenderer : Renderer
    {
        private string _base64ImageString;

        public Image Image
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_base64ImageString))
                    return null;
                var imageBytes = Convert.FromBase64String(_base64ImageString);
                using (var m = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(m);
                }
            }
            set
            {
                if (value == null) return;
                using (var m = new MemoryStream())
                {
                    value.Save(m, value.RawFormat);
                    var imageBytes = m.ToArray();
                    // Convert byte[] to Base64 String
                    _base64ImageString = Convert.ToBase64String(imageBytes);
                }
            }
        }

        public bool IsStretch { get; set; }

        public bool IsTile { get; set; }

        public ImageRenderer(Image image)
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
                graphics.TranslateTransform(bounds.Left + bounds.Width / 2, bounds.Top + bounds.Height / 2);
                var angle = Helper.GetAngle(figure.Transform);
                var size = Helper.GetSize(figure.Transform);
                graphics.RotateTransform(angle);
                var clientRect = new RectangleF(-size.Width / 2, -size.Height / 2, size.Width, size.Height);
                var image = Image;
                if (image == null)
                {
                    using (var pen = new Pen(Color.Black, 1f))
                    {
                        pen.DashStyle = DashStyle.DashDot;
                        graphics.DrawRectangles(pen, new[] { clientRect });
                    }
                }
                else if (IsStretch)
                    graphics.DrawImage(image, clientRect);
                else if (IsTile)
                {
                    var rsize = new Size(image.Width, image.Height);
                    var rowcount = (int)Math.Ceiling(clientRect.Height / rsize.Height);
                    var colcount = (int)Math.Ceiling(clientRect.Width / rsize.Width);
                    for (var row = 0; row < rowcount; row++)
                    {
                        for (var col = 0; col < colcount; col++)
                        {
                            var p = Point.Ceiling(clientRect.Location);
                            p.Offset(col * rsize.Width, row * rsize.Height);
                            var r = new Rectangle(p, new Size(rsize.Width, rsize.Height));
                            var master = Rectangle.Ceiling(clientRect);
                            master.Intersect(r);
                            graphics.DrawImageUnscaledAndClipped(image, master);
                        }
                    }
                }
                else
                    graphics.DrawImage(image, clientRect.Location);
                graphics.ResetTransform();
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
