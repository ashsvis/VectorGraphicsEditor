using System;
using System.Drawing;

namespace EditorModel.Figures
{
    public class Marker : Figure
    {
        /// <summary>
        /// Нормализация локальных координат
        /// </summary>
        public PointF NormalizedLocalCoordinates { get; set; }

        /// <summary>
        /// Реакция маркера на перемещение мышью
        /// </summary>
        public Action<Marker, Point> Moved;

        public Func<object> GetCursor;

        public PointF AbsolutePosition { get; set; }

        public PointF Anchor { get; set; }

        public PointF AnchorPosition { get; set; }
    }
}
