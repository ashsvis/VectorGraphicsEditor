using EditorModel.Figures;
using EditorModel.Geometry;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorModel.Renderers
{
    [Serializable]
    public enum ArrowPosition
    {
        End,
        Start,
        Both
    }

    /// <summary>
    /// Класс рисовальщика линии (кривой) со стрелкой
    /// </summary>
    [Serializable]
    public class ArrowRendererDecorator : RendererDecorator
    {
        private readonly Renderer _renderer;

        /// <summary>
        /// Положение стрелок
        /// </summary>
        public ArrowPosition ArrowPosition { get; set; }
 
        /// <summary>
        /// Цвет для заливки стрелки
        /// </summary>
        public Color OtherColor { get; set; }

        /// <summary>
        /// Признак возможности заливки стрелки
        /// </summary>
        public bool IsOtherColorFilled { get; set; }

        public ArrowRendererDecorator(Renderer renderer)
            : base(renderer)
        {
            _renderer = renderer;
            OtherColor = Color.White;
        }

        public override void Render(Graphics graphics, Figure figure)
        {
            _renderer.Render(graphics, figure);
            var transformed = figure.Geometry as ITransformedGeometry;
            if (transformed == null) return;
            if (transformed.IsClosed) return;
            var points = transformed.GetTransformedPoints(figure);
            var types = transformed.GetTransformedPointTypes(figure);

            switch (ArrowPosition)
            {
                case ArrowPosition.Both:
                    DrawArrow(graphics, figure, points, types, true);
                    DrawArrow(graphics, figure, points, types);
                    break;
                case ArrowPosition.Start:
                    DrawArrow(graphics, figure, points, types, true);
                    break;
                default:
                    DrawArrow(graphics, figure, points, types);
                    break;
            }
        }

        private void DrawArrow(Graphics graphics, Figure figure, PointF[] points, byte[] types, bool arrowAtStart = false)
        {
            var prevPoint = arrowAtStart ? points[1] : points[points.Length - 2];
            var endPoint = arrowAtStart ? points[0] : points[points.Length - 1];
            try
            {
                using (var path = new GraphicsPath(points, types))
                {
                    path.Flatten(new Matrix(), 3f);
                    prevPoint = arrowAtStart ? path.PathPoints[1] : path.PathPoints[path.PathPoints.Length - 2];
                }
            }
            catch
            {
                prevPoint = arrowAtStart ? points[1] : points[points.Length - 2];
            }
            //расчёт точек стрелки
            var HeadWidth = 10f; // Ширина между ребрами стрелки
            var HeadHeight = 3f; // Длина ребер стрелки

            var theta = Math.Atan2(prevPoint.Y - endPoint.Y, prevPoint.X - endPoint.X);
            var sint = Math.Sin(theta);
            var cost = Math.Cos(theta);

            var pt1 = new PointF((float)(endPoint.X + (HeadWidth * cost - HeadHeight * sint)),
                                 (float)(endPoint.Y + (HeadWidth * sint + HeadHeight * cost)));
            var pt2 = new PointF((float)(endPoint.X + (HeadWidth * cost + HeadHeight * sint)),
                                 (float)(endPoint.Y - (HeadHeight * cost - HeadWidth * sint)));
            var arrow = new PointF[] { pt1, pt2, endPoint, pt1, pt2 };

            if (figure.Style.BorderStyle != null && figure.Style.BorderStyle.IsVisible)
            {
                using (var pen = figure.Style.BorderStyle.GetPen(figure))
                {
                    pen.DashStyle = DashStyle.Solid;
                    pen.StartCap = LineCap.Triangle;
                    pen.EndCap = LineCap.Triangle;
                    if (IsOtherColorFilled)
                    {
                        using (var brush = new SolidBrush(OtherColor))
                            graphics.FillPolygon(brush, arrow);
                    }
                    else
                    {
                        using (var brush = new SolidBrush(Color.FromArgb(figure.Style.BorderStyle.Opacity, pen.Color)))
                            graphics.FillPolygon(brush, arrow);
                    }
                    graphics.DrawLines(pen, arrow);
                }
            }
        }

        /// <summary>
        /// Свойство возвращает ограничения для подключения декораторов
        /// </summary>
        public override AllowedRendererDecorators AllowedDecorators
        {
            get { return AllowedRendererDecorators.All ^ (AllowedRendererDecorators.Arrow | AllowedRendererDecorators.TextBlock); }
        }

        public override string ToString()
        {
            return "Arrow";
        }
    }
}
