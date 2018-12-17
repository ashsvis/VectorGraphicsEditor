using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using EditorModel.Common;
using EditorModel.Figures;

namespace EditorModel.Renderers
{
    public enum GroupJoin
    {
        None,
        Intersect,
        Union,
        Xor,
        Exclude,
        Complement
    }

    /// <summary>
    /// Класс рисовальщика группы фигур
    /// </summary>
    [Serializable]
    public class GroupRenderer : Renderer
    {
        public GroupJoin JoinMode { get; set; }

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
            if (JoinMode == GroupJoin.None)
            {
                foreach (var fig in group.Figures)
                {
                    var matrix = fig.Transform.DeepClone();
                    fig.Transform.Matrix.Multiply(group.Transform, MatrixOrder.Append);
                    fig.Renderer.Render(graphics, fig);
                    fig.Transform = matrix;
                }
            }
            else
            {
                var first = group.Figures.First();
                var firstMatrix = first.Transform.DeepClone();
                first.Transform.Matrix.Multiply(group.Transform, MatrixOrder.Append);
                using (var region = new Region(first.GetTransformedPath().Path))
                {
                    foreach (var fig in group.Figures.Skip(1))
                    {
                        var matrix = fig.Transform.DeepClone();
                        fig.Transform.Matrix.Multiply(group.Transform, MatrixOrder.Append);
                        switch (JoinMode)
                        {
                            case GroupJoin.Intersect:
                                region.Intersect(fig.GetTransformedPath().Path);
                                break;
                            case GroupJoin.Union:
                                region.Union(fig.GetTransformedPath().Path);
                                break;
                            case GroupJoin.Xor:
                                region.Xor(fig.GetTransformedPath().Path);
                                break;
                            case GroupJoin.Exclude:
                                region.Exclude(fig.GetTransformedPath().Path);
                                break;
                            case GroupJoin.Complement:
                                region.Complement(fig.GetTransformedPath().Path);
                                break;
                        }
                        fig.Transform = matrix;
                    }
                    if (figure.Style.FillStyle != null && figure.Style.FillStyle.IsVisible)
                    {
                        using (var brush = figure.Style.FillStyle.GetBrush(figure))
                            graphics.FillRegion(brush, region);
                    }
                }
                first.Transform = firstMatrix;
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
