using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using EditorModel.Figures;

namespace EditorModel.Renderers
{
    /// <summary>
    /// Класс рисовальщика группы фигур
    /// </summary>
    [Serializable]
    public class GroupRenderer : Renderer
    {
        public override void Render(Graphics graphics, Figure figure)
        {
            var group = figure as GroupFigure;
            if (group == null) return;
            if (group.Figures.ToArray().Length == 0)
            {
                using (var path = figure.GetTransformedPath().Path)
                {
                    var bounds = path.GetBounds();
                    using (var pen = new Pen(Color.Black, 0f))
                    {
                        pen.DashStyle = DashStyle.Dot;
                        graphics.DrawRectangles(pen, new[] { bounds });
                        using (var sf = new StringFormat(StringFormat.GenericTypographic))
                        {
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Center;
                            graphics.DrawString("Picture Place Holder", SystemFonts.DefaultFont, Brushes.Black, bounds, sf);
                        }
                    }
                }
                return;
            }
            // отрисовка фигур в группе
            foreach (var fig in group.Figures)
            {
                var e = fig.Transform.Matrix.Elements;
                fig.Transform.Matrix.Multiply(group.Transform, MatrixOrder.Append);
                fig.Renderer.Render(graphics, fig);
                fig.Transform.Matrix = new Matrix(e[0], e[1], e[2], e[3], e[4], e[5]);
            }
        }

        /// <summary>
        /// Свойство возвращает ограничения для подключения декораторов
        /// </summary>
        public override AllowedRendererDecorators AllowedDecorators
        {
            get { return AllowedRendererDecorators.None; }
        }
    }
}
