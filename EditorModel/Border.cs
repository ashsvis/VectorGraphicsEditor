using System.Drawing;

namespace EditorModel
{
    /// <summary>
    /// Класс хранения данных контура фигуры
    /// </summary>
    public class Border
    {
        /// <summary>
        /// Признак возможности рисования контура
        /// </summary>
        public bool Draw { get; internal set; }

        /// <summary>
        /// Предоставление карандаша для рисования контура
        /// </summary>
        /// <param name="figure">Ссылка на фигуру</param>
        /// <returns></returns>
        public Pen GetPen(Figure figure)
        {
            return figure.Style.BorderStyle.GetPen(figure);
        }
    }

}
