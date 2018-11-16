using System.Drawing.Drawing2D;

namespace EditorModel
{
    /// <summary>
    /// Класс-основа для задания геометрии фигуры
    /// </summary>
    public abstract class Geometry
    {
        /// <summary>
        /// Предоставление пути для рисования фигуры
        /// </summary>
        public abstract GraphicsPath Path { get; }
    }
}
