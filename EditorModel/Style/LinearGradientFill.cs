using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using EditorModel.Figures;

namespace EditorModel.Style
{
    [Serializable]
    public class LinearGradientFill : Fill
    {
        private PointF[] _points;
        private LinearGradientMode _gradientMode;

        public LinearGradientFill()
        {
            _points = new[] { new PointF(-0.5f, 0f), new PointF(0.5f, 0f) };
            GradientColor = Color.White;
            Angle = 0;
        }

        /// <summary>
        /// Точки границ градиента
        /// </summary>
        public PointF[] Points
        {
            get { return _points; }
            set { _points = value; }
        }

        /// <summary>
        /// Get Gradient Points
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public PointF[] GetGradientPoints(Figure owner)
        {
            var points = (PointF[])Points.Clone();
            owner.Transform.Matrix.TransformPoints(points);
            return points;
        }

        /// <summary>
        /// Set Gradient Points
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="points"></param>
        public void SetGradientPoints(Figure owner, PointF[] points)
        {
            points = (PointF[])points.Clone();
            var m = owner.Transform.Matrix.Clone();
            m.Invert();
            m.TransformPoints(points);
            Points = points;
        }

        /// <summary>
        /// Второй цвет для заполнения фона (цвет градиента)
        /// </summary>
        public Color GradientColor { get; set; }

        public float Angle { get; set; }

        public LinearGradientMode GradientMode
        {
            get { return _gradientMode; }
            set
            {
                _gradientMode = value;
                switch (_gradientMode)
                {
                    case LinearGradientMode.Horizontal:
                        _points = new[] { new PointF(-0.5f, 0), new PointF(0.5f, 0) };
                        break;
                    case LinearGradientMode.Vertical:
                        _points = new[] { new PointF(0f, -0.5f), new PointF(0f, 0.5f) };
                        break;
                    case LinearGradientMode.ForwardDiagonal:
                        _points = new[] { new PointF(-0.5f, -0.5f), new PointF(0.5f, 0.5f) };
                        break;
                    case LinearGradientMode.BackwardDiagonal:
                        _points = new[] { new PointF(0.5f, 0.5f), new PointF(-0.5f, -0.5f) };
                        break;
                }
            }
        }

        public override Brush GetBrush(Figure figure)
        {
            // возвращаем созданную и настроенную кисть для фигуры
            var pts = (PointF[])_points.Clone();
            figure.Transform.Matrix.TransformPoints(pts);
            return new LinearGradientBrush(pts[0], pts[1], Color, GradientColor);
        }

    }

}
