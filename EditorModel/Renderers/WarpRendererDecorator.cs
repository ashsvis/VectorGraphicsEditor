using EditorModel.Common;
using EditorModel.Figures;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorModel.Renderers
{
    /// <summary>
    /// Класс рисовальщика фигуры с искажением
    /// </summary>
    [Serializable]
    public class WarpRendererDecorator : RendererDecorator
    {
        private readonly Renderer _renderer;
        private PointF[] _points;

        public WarpRendererDecorator(Renderer renderer)
            : base(renderer)
        {
            _renderer = renderer;
            _points = new[] { new PointF(-0.5f, -0.5f), new PointF(1, -0.5f), new PointF(1, 1),
                              new PointF(-0.5f, 1) };
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
        public PointF[] GetWarpPoints(Figure owner)
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
        public void SetWarpPoints(Figure owner, PointF[] points)
        {
            points = (PointF[])points.Clone();
            var m = owner.Transform.Matrix.Clone();
            m.Invert();
            m.TransformPoints(points);
            Points = points;
        }

        public override void Render(Graphics graphics, Figure figure)
        {
            var baseRenderer = GetBaseRenderer(figure.Renderer) as IRendererTransformedPath;
            // получаем путь для рисования, трансформированный методом фигуры
            using (var path = baseRenderer != null
                                ? baseRenderer.GetTransformedPath(graphics, figure)
                                : figure.GetTransformedPath().Path)
            {
                // поместить код искажения здесь
                var pts = (PointF[])Points.Clone();
                figure.Transform.Matrix.TransformPoints(pts);
                path.Warp(pts, path.GetBounds(), new Matrix(), WarpMode.Perspective);
                graphics.DrawPath(Pens.Black, path);
            }
            // этот рендерер по умолчанию потом спрятать
            //_renderer.Render(graphics, figure);
        }

        /// <summary>
        /// Свойство возвращает ограничения для подключения декораторов
        /// </summary>
        public override AllowedRendererDecorators AllowedDecorators
        {
            get { return AllowedRendererDecorators.All ^ 
                    (AllowedRendererDecorators.Warp | AllowedRendererDecorators.TextBlock); }
        }

    }
}
