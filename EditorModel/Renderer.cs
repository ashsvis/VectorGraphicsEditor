using System.Drawing;

namespace EditorModel
{
    /// <summary>
    /// Класс рисовальщика фигуры
    /// </summary>
    public class Renderer
    {
        /// <summary>
        /// Метод отрисовки фигуры на канве
        /// </summary>
        /// <param name="graphics">Канва для рисования</param>
        /// <param name="figure">Фигура со свойствами для рисования</param>
        public virtual void Render(Graphics graphics, Figure figure)
        {
            // плучаем путь для присования, трансформиованный методом фигуры
            using (var path = figure.GetTransformedPath())
            {
                // если разрешено использование заливки
                if (figure.Style.FillStyle.Draw)
                    // то получаем кисть из стиля рисования фигуры
                    using (var brush = figure.Style.FillStyle.GetBrush(figure))
                        graphics.FillPath(brush, path);
                // если разрешено рисование контура
                if (figure.Style.BorderStyle.Draw)
                    // то получаем карандаш из стиля рисования фигуры
                    using (var pen = figure.Style.BorderStyle.GetPen(figure))
                        graphics.DrawPath(pen, path);
            }
        }
    }

}
