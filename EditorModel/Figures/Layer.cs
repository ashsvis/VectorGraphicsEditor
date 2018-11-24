using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EditorModel.Figures
{
    /// <summary>
    /// Слой, содержащий все фигуры
    /// </summary>
    public class Layer
    {
        private readonly ObservableCollection<Figure> _figures;

        public Layer()
        {
            _figures = new ObservableCollection<Figure>();
            _figures.CollectionChanged += (o, e) => OnFiguresCountChanged();
        }

        public ObservableCollection<Figure> Figures
        {
            get { return _figures; }
        }
 
        /// <summary>
        /// Изменилось количество фигур
        /// </summary>
        public event Action FiguresCountChanged = delegate { };

        private void OnFiguresCountChanged()
        {
            FiguresCountChanged();
        }
    }
}
