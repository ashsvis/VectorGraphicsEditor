using System;
using System.Drawing.Drawing2D;

namespace EditorModel
{
    /// <summary>
    /// Класс-основа для задания геометрии фигуры
    /// </summary>
    [Serializable]
    public abstract class Geometry
    {
        /// <summary>
        /// Предоставление пути для рисования фигуры
        /// </summary>
        public abstract GraphicsPath Path { get; }
    }
}
