using System;
using System.Collections.Generic;
using EditorModel.Style;

namespace EditorModel.Figures
{
    /// <summary>
    /// Слой, содержащий все фигуры
    /// </summary>
    [Serializable]
    public class Layer
    {
        private readonly List<Figure> _figures = new List<Figure>();

        public List<Figure> Figures 
        {   
            get { return _figures; }
            set
            {
                _figures.Clear();
                _figures.AddRange(value);
            }
        }

        /// <summary>
        /// Свойство для хранения данных кисти
        /// </summary>
        public Fill FillStyle { get; set; }

        public Layer()
        {
            FillStyle = new DefaultFill { IsVisible = false };
        }

    }
}
