using System.Collections.Generic;

namespace EditorModel.Figures
{
    /// <summary>
    /// Слой, содержащий все фигуры
    /// </summary>
    public class Layer
    {
        private readonly List<Figure> _figures = new List<Figure>();

        public List<Figure> Figures
        {
            get { return _figures; }
        }
    }
}
