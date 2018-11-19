using System;
using System.Drawing;

namespace EditorModel.Figures
{
    /// <summary>
    /// Класс рисовальщика фигуры
    /// </summary>
    [Serializable]
    public class Renderer
    {
        private readonly Figure _figure;

        public Renderer(Figure figure)
        {
            _figure = figure;
        }

        /// <summary>
        /// Метод отрисовки фигуры на канве
        /// </summary>
        /// <param name="graphics">Канва для рисования</param>
        /// <param name="figure">Фигура со свойствами для рисования</param>
        public virtual void Render(Graphics graphics, Figure figure = null)
        {
            var fig = figure ?? _figure;
            // плучаем путь для присования, трансформиованный методом фигуры
            using (var path = fig.GetTransformedPath())
            {
                // если разрешено использование заливки
                if (fig.Style.FillStyle.IsVisible)
                    // то получаем кисть из стиля рисования фигуры
                    using (var brush = fig.Style.FillStyle.GetBrush(fig))
                        graphics.FillPath(brush, path);
                // если разрешено рисование контура
                if (fig.Style.BorderStyle.IsVisible)
                    // то получаем карандаш из стиля рисования фигуры
                    using (var pen = fig.Style.BorderStyle.GetPen(fig))
                        graphics.DrawPath(pen, path);
            }
        }
    }

}
