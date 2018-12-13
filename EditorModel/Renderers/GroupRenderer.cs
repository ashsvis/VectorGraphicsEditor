using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
