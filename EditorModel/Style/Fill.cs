using System;
using System.Drawing;
using EditorModel.Figures;

namespace EditorModel.Style
{
    /// <summary>
    /// Класс хранения данных заливки фигуры
    /// </summary>
    [Serializable]
    public class Fill
    {
        /// <summary>
        /// Конструктор класса хранения данных заливки фигуры
        /// </summary>
        public Fill()
        {
            // по умолчанию заливка разрешена
            IsVisible = true;
            // по умолчанию белый цвет заливки
            Color = Color.White;
            // по умолчанию полная непрозрачность
            Opacity = 255;
        }

        /// <summary>
        /// Величина прозрачности цвета заливки
        /// </summary>
        public int Opacity { get; set; }

        /// <summary>
        /// Цвет для заполнения фона (цвет заливки)
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Признак возможности заливки фигуры
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// Предоставление кисти для заливки фигуры
        /// </summary>
        /// <param name="figure">Ссылка на фигуру</param>
        /// <returns>Возвращаем настроенную кисть</returns>
        public virtual Brush GetBrush(Figure figure)
        {
            // возвращаем созданную и настроенную кисть для фигуры
            return new SolidBrush(Color.FromArgb(Opacity, Color));
        }
    }

}
