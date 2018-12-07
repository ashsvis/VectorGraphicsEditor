using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using EditorModel.Common;

namespace EditorModel.Figures
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
            // отрисовка фигур в группе
            foreach (var fig in group.Figures)
            {
                var e = fig.Transform.Matrix.Elements;
                fig.Transform.Matrix.Multiply(group.Transform, MatrixOrder.Append);
                //var style = fig.Style.DeepClone();
                //fig.Style = group.Style;
                fig.Renderer.Render(graphics, fig);
                //fig.Style = style;
                fig.Transform.Matrix = new Matrix(e[0], e[1], e[2], e[3], e[4], e[5]);
            }
        }
    }
}
