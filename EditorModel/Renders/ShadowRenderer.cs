using System;
using System.Drawing;
using EditorModel.Figures;
using EditorModel.Geometry;

namespace EditorModel.Renders
{
    /// <summary>
    /// Класс рисовальщика фигуры с тенью
    /// </summary>
    [Serializable]
    public class ShadowRenderer : Renderer
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

        public ShadowRenderer()
        {
            Offset = new PointF(10, 10);
            Opacity = 128;
        }

        public override void Render(Graphics graphics, Figure figure)
        {
            // получаем путь для рисования, трансформированный методом фигуры
            using (var path = figure.GetTransformedPath().Path)
            {
                var rendered = figure.Renderer as ShadowRenderer;
                if (rendered == null) return;
                graphics.TranslateTransform(Offset.X, Offset.Y);
                var shadowColor = Color.FromArgb(Opacity, Color.Black);
                if ((!figure.Style.FillStyle.IsVisible ||
                     figure.Geometry is PolygoneGeometry && !(figure.Geometry as PolygoneGeometry).IsClosed) &&
                    figure.Style.BorderStyle != null && 
                    figure.Style.BorderStyle.IsVisible)
                    using (var pen = figure.Style.BorderStyle.GetPen(figure))
                    {
                        pen.Color = shadowColor;
                        graphics.DrawPath(pen, path);
                    }
                if (figure.Style.FillStyle.IsVisible)
                    using (var brush = new SolidBrush(shadowColor))
                        graphics.FillPath(brush, path);
                graphics.TranslateTransform(-Offset.X, -Offset.Y);
            }
            base.Render(graphics, figure);
        }

    }
}
