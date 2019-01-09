using System;
using System.Drawing;
using EditorModel.Figures;

namespace EditorModel.Renderers
{
    /// <summary>
    /// Класс рисовальщика фигуры
    /// </summary>
    [Serializable]
    public class DefaultRenderer : Renderer
    {
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
                // если разрешено использование заливки
                if (figure.Style.FillStyle != null && figure.Style.FillStyle.IsVisible)
                    // то получаем кисть из стиля рисования фигуры
                    using (var brush = figure.Style.FillStyle.GetBrush(figure))
                        graphics.FillPath(brush, path);
                // если разрешено рисование контура
                if (figure.Style.BorderStyle != null && figure.Style.BorderStyle.IsVisible)
                    // то получаем карандаш из стиля рисования фигуры
                    using (var pen = figure.Style.BorderStyle.GetPen(figure))
                        graphics.DrawPath(pen, path);
            }
        }

        /// <summary>
        /// Свойство возвращает ограничения для подключения декораторов
        /// </summary>
        public override AllowedRendererDecorators AllowedDecorators
        {
            get { return AllowedRendererDecorators.All; }
        }
    }

}
