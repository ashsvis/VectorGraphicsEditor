using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using EditorModel.Figures;

namespace EditorModel.Style
{
    [Serializable]
    public class LinearGradientFill : FillDecorator, IGradientFill
    {
        private readonly Fill _fill;

        private PointF[] _points;

        public LinearGradientFill(Fill fill)
            : base(fill)
        {
            _fill = fill;
            _points = new[] { new PointF(-0.5f, 0.25f), new PointF(0.5f, 0.25f) };
            GradientColor = Color.Gray;
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

        public override Brush GetBrush(Figure figure)
        {
            // возвращаем созданную и настроенную кисть для фигуры
            var pts = (PointF[])_points.Clone();
            figure.Transform.Matrix.TransformPoints(pts);
            return new LinearGradientBrush(pts[0], pts[1], Color.FromArgb(_fill.Opacity, _fill.Color), GradientColor);
        }

        /// <summary>
        /// Свойство возвращает ограничения для подключения декораторов
        /// </summary>
        public override AllowedFillDecorators AllowedDecorators
        {
            get { return AllowedFillDecorators.None; }
        }
        /// <summary>
        /// Величина прозрачности цвета заливки
        /// </summary>
        public override int Opacity
        {
            get { return _fill.Opacity; }
            set { _fill.Opacity = value;  }
        }

        /// <summary>
        /// Цвет для заполнения фона (цвет заливки)
        /// </summary>
        public override Color Color
        {
            get { return _fill.Color; }
            set { _fill.Color = value; }
        }

        /// <summary>
        /// Признак возможности заливки фигуры
        /// </summary>
        public override bool IsVisible
        {
            get { return _fill.IsVisible; }
            set { _fill.IsVisible = value; }
        }

    }

}
