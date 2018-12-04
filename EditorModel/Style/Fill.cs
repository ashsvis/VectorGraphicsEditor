using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        }

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
            return new SolidBrush(Color);
        }
    }

    #region На согласовании

    [Serializable]
    public class LineGradientFill : Fill
    {
        public LineGradientFill()
        {
            GradientColor = Color.White;
            Angle = 0;
        }

        /// <summary>
        /// Второй цвет для заполнения фона (цвет градиента)
        /// </summary>
        public Color GradientColor { get; set; }

        public float Angle { get; set; }

        public override Brush GetBrush(Figure figure)
        {
            // возвращаем созданную и настроенную кисть для фигуры
            var bounds = figure.GetTransformedPath().Path.GetBounds();
            var angle = /* figure.Transform.Angle + */ Angle;
            return new LinearGradientBrush(bounds, Color, GradientColor, angle);
        }

    }

    #endregion На согласовании

}
