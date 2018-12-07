using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using EditorModel.Common;
using EditorModel.Geometry;

namespace EditorModel.Figures
{
    /// <summary>
    /// Класс для группирования фигур
    /// </summary>
    [Serializable]
    public class GroupFigure : Figure
    {
        private readonly List<Figure> _figures = new List<Figure>();

        public IEnumerable<Figure> Figures { get { return _figures.ToArray(); } }

        public GroupFigure(IEnumerable<Figure> figures)
        {
            var path = new SerializableGraphicsPath();
            path.Path.AddRectangle(new RectangleF(-0.5f, -0.5f, 1, 1));
            foreach (var figure in figures)
                _figures.Add(figure.DeepClone());
            Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^ AllowedOperations.Vertex);
        }

        /// <summary>
        /// Предоставление трансформированной геометрии для рисования
        /// </summary>
        /// <returns>Путь для рисования</returns>
        public override SerializableGraphicsPath GetTransformedPath()
        {
            // создаём копию геометрии фигуры
            var path = new SerializableGraphicsPath { Path = { FillMode = FillMode.Winding } };
            foreach (var figure in _figures)
            {
                path.Path.AddPath(figure.GetTransformedPath().Path, false);
            }
            // трансформируем её при помощи Трансформера
            path.Path.Transform(Transform);
            return path;
        }
    }
}
