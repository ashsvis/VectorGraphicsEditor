using System;
using System.Collections.Generic;

namespace EditorModel.Figures
{
    /// <summary>
    /// Слой, содержащий все фигуры
    /// </summary>
    [Serializable]
    public class Layer
    {
        private List<Figure> _figures = new List<Figure>();

        public List<Figure> Figures { get { return _figures; } }
    }
}
