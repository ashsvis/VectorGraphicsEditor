using System;
using System.Collections.Generic;

namespace EditorModel.Figures
{
    public enum GroupJoin
    {
        None,
        Intersect,
        Union,
        Xor,
        Exclude,
        Complement
    }

    /// <summary>
    /// Класс для группирования фигур
    /// </summary>
    [Serializable]
    public class GroupFigure : Figure
    {
        private readonly List<Figure> _figures = new List<Figure>();

        public IEnumerable<Figure> Figures
        {
            get { return _figures.ToArray(); }
            set
            {
                _figures.Clear();
                _figures.AddRange(value);
            }
        }
    }

}
