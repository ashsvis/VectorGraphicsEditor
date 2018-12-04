using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using EditorModel.Figures;

namespace EditorModel.Style
{
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
            var e = figure.Transform.Matrix.Elements;
            var max = 0f;
            for (var i = 0; i < 4; i++)
            {
                if (max < Math.Abs(e[i]))
                    max = Math.Abs(e[i]);
            }
            var tr = e[0]/max + e[3]/max + 1;
            var matrixAngle = (float)Math.Acos((tr - 1) / 2);

            //Console.WriteLine(matrixAngle);

            var angle = matrixAngle + Angle;
            return new LinearGradientBrush(bounds, Color, GradientColor, angle);
        }

    }

}
