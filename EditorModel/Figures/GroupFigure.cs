using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using EditorModel.Common;

namespace EditorModel.Figures
{
    /// <summary>
    /// Класс для группирования фигур
    /// </summary>
    [Serializable]
    public class GroupFigure : Figure
    {
        private readonly List<Figure> _figures = new List<Figure>();

        public Figure[] Figures { get { return _figures.ToArray(); } }

        public GroupFigure(IEnumerable<Figure> figures)
        {
            foreach (var figure in figures)
                _figures.Add(figure.DeepClone());
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
