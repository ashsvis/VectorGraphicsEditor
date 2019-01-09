using System;
using System.Drawing;
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
                fig.Renderer.Render(graphics, fig);
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
