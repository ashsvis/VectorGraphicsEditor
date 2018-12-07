using System.Drawing.Drawing2D;
using EditorModel.Common;
using System;
using System.Drawing;
using EditorModel.Figures;

namespace EditorModel.Renders
{
    /// <summary>
    /// Класс рисовальщика картинки
    /// </summary>
    [Serializable]
    public class ImageRenderer : Renderer, IDisposable
    {
        private Image _image;

        public Image Image
        {
            get { return _image; }
            set
            {
                if (_image != null) _image.Dispose();
                _image = value;
            }
        }

        public bool IsStretch { get; set; }

        public bool IsTile { get; set; }

        public ImageRenderer(Image image)
        {
            _image = image;
        }

        ~ImageRenderer()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_image == null) return;
            _image.Dispose();
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
                var rendered = figure.Renderer as ImageRenderer;
                if (rendered == null) return;
                graphics.TranslateTransform(bounds.Left + bounds.Width / 2, bounds.Top + bounds.Height / 2);
                var angle = Helper.GetAngle(figure.Transform);
                var size = Helper.GetSize(figure.Transform);
                graphics.RotateTransform(angle);
                var clientRect = new RectangleF(-size.Width / 2, -size.Height / 2, size.Width, size.Height);
                if (_image == null)
                {
                    using (var pen = new Pen(Color.Black, 1f))
                    {
                        pen.DashStyle = DashStyle.DashDot;
                        graphics.DrawRectangles(pen, new[] {clientRect});
                    }
                }
                else if (IsStretch)
                    graphics.DrawImage(_image, clientRect);
                else if (IsTile)
                {
                    var rsize = new Size(_image.Width, _image.Height);
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
                            graphics.DrawImageUnscaledAndClipped(_image, master);
                        }
                    }
                }
                else
                    graphics.DrawImage(_image, clientRect.Location);
                graphics.ResetTransform();
            }
        }
    }
}
