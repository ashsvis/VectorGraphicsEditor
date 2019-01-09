using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorModel.Figures
{
    /// <summary>
    /// Класс хранения данных контура фигуры
    /// </summary>
    [Serializable]
    public class Border
    {
        /// <summary>
        /// Конструктор класса хранения данных контура фигуры
        /// </summary>
        public Border()
        {
            // по умолчанию заливка разрешена
            IsVisible = true;
            // по умолчанию чёрный цвет контура
            Color = Color.Black;
            // по умолчанию 1 единица
            Width = 1f;
            DashStyle = DashStyle.Solid;
        }

        /// <summary>
        /// Толщина линии для рисования контура
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Цвет для рисования контура (цвет карандаша)
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Признак возможности рисования контура
        /// </summary>
        public bool IsVisible { get; set; }

        public DashStyle DashStyle { get; set; }

        /// <summary>
        /// Предоставление карандаша для рисования контура
        /// </summary>
        /// <param name="figure">Ссылка на фигуру</param>
        /// <returns></returns>
        public Pen GetPen(Figure figure)
        {
            // возвращаем созданный и настроенный карандаш для контура фигуры
            return new Pen(Color, Width) { DashStyle = DashStyle };
        }
    }

}
