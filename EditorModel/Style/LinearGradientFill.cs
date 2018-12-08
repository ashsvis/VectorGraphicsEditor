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

        public LinearGradientMode GradientMode { get; set; }

        public override Brush GetBrush(Figure figure)
        {
            // возвращаем созданную и настроенную кисть для фигуры
            var pts = new[] { new PointF(-0.5f, 0.5f), new PointF(0.5f, 0.5f) };
            switch (GradientMode)
            {
                case LinearGradientMode.Vertical:
                    pts = new[] { new PointF(0.5f, -0.5f), new PointF(0.5f, 0.5f) };
                    break;
                case LinearGradientMode.ForwardDiagonal:
                    pts = new[] { new PointF(-0.5f, -0.5f), new PointF(0.5f, 0.5f) };
                    break;
                case LinearGradientMode.BackwardDiagonal:
                    pts = new[] { new PointF(0.5f, 0.5f), new PointF(-0.5f, -0.5f) };
                    break;
            }
            figure.Transform.Matrix.TransformPoints(pts);
            return new LinearGradientBrush(pts[0], pts[1], Color, GradientColor);
        }

    }

}
