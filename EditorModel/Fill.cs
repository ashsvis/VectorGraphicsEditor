using System;
using System.Drawing;

namespace EditorModel
{
    /// <summary>
    /// Класс хранения данных заливки фигуры
    /// </summary>
    public class Fill
    {
        /// <summary>
        /// Признак возможности заливки фигуры
        /// </summary>
        public bool Draw { get; internal set; }

        /// <summary>
        /// Предоставление кисти для заливки фигуры
        /// </summary>
        /// <param name="figure">Ссылка на фигуру</param>
        /// <returns></returns>
        public Brush GetBrush(Figure figure)
        {
            return figure.Style.FillStyle.GetBrush(figure);
        }
    }

}
