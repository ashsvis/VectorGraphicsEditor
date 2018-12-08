using EditorModel.Figures;
using EditorModel.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorModel.Renderers
{
    /// <summary>
    /// Класс рисовальщика фигуры со "свечением"
    /// </summary>
    [Serializable]
    public class GlowRenderer : Renderer
    {
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

        public GlowRenderer()
        {
            Offset = new PointF(5, 5);
            Opacity = 128;
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
            base.Render(graphics, figure);
        }
    }
}
