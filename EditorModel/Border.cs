using System.Drawing;

namespace EditorModel
{
    /// <summary>
    /// Класс хранения данных контура фигуры
    /// </summary>
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
        public bool IsVisible { get; internal set; }

        /// <summary>
        /// Предоставление карандаша для рисования контура
        /// </summary>
        /// <param name="figure">Ссылка на фигуру</param>
        /// <returns></returns>
        public Pen GetPen(Figure figure)
        {
            // возвращаем созданный и настроенный карандаш для контура фигуры
            //TODO: А зачем нам тогда параметр Figure figure?
            return new Pen(Color, Width);
        }
    }

}
