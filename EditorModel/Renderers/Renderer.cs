using System;
using System.Drawing;
using EditorModel.Figures;

namespace EditorModel.Renderers
{
    /// <summary>
    /// Допустимые операции над геометрией
    /// </summary>
    [Serializable]
    [Flags]
    public enum AllowedRendererDecorators : uint
    {
        None = 0x0,         // ничего нельзя
        Shadow = 0x1,       // может задавать тень
        Glow = 0x2,         // может задавать "свечение"
        TextBlock = 0x4,    // может задавать внутренний текстовый блок
        // новые режимы добавлять здесь

        All = 0xffffffff,   // всё можно
    }

    /// <summary>
    /// Класс рисовальщика фигуры
    /// </summary>
    [Serializable]
    public abstract class Renderer
    {
        /// <summary>
        /// Метод отрисовки фигуры на канве
        /// </summary>
        /// <param name="graphics">Канва для рисования</param>
        /// <param name="figure">Фигура со свойствами для рисования</param>
        public abstract void Render(Graphics graphics, Figure figure);

        /// <summary>
        /// Допустимые операции над геометрией
        /// </summary>
        public abstract AllowedRendererDecorators AllowedDecorators { get; }
    }
}
