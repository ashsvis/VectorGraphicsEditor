using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using EditorModel.Common;
using EditorModel.Figures;

namespace EditorModel.Style
{
    [Serializable]
    public class LinearGradientFill : Fill
    {
        public LinearGradientFill()
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
            var matrixAngle = Helper.GetAngle(figure.Transform);
            var angle = matrixAngle + Angle;
            return new LinearGradientBrush(bounds, Color, GradientColor, angle);
        }

    }

}
