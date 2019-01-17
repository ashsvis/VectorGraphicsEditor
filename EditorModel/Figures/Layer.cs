using System;
using System.Collections.Generic;
using EditorModel.Style;
using System.Drawing;

namespace EditorModel.Figures
{
    /// <summary>
    /// Допустимые операции над геометрией
    /// </summary>
    [Serializable]
    [Flags]
    public enum LayerAllowedOperations : uint
    {
        None = 0x0,         // ничего нельзя
        Visible = 0x1,      // элементы этого слоя могут отображаться, быть выбраны, изменены и удалены
        Print = 0x2,        // могут быть распечатаны, экспортированы
        Actived = 0x4,      // слой делается активным и вновь добавляемые элементы автоматически добавляются к нему
        Locking = 0x8,      // только отображение элементов (как фон)
        Lashing = 0x10,     // элементы могут быть привязаны
        Gluing = 0x20,      // элементы могут быть приклеены
        Color = 0x40,       // цвет контура задаётся в настройках слоя
        // новые режимы добавлять здесь

        All = 0xffffffff,   // всё можно
    }

    [Serializable]
    public class LayerItem
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

        public LayerItem()
        {
            AllowedOperations = LayerAllowedOperations.All ^
                (LayerAllowedOperations.Actived | LayerAllowedOperations.Locking | LayerAllowedOperations.Color);
            BorderColor = Color.Transparent;
        }

        public string Name { get; set; }

        /// <summary>
        /// Допустимые операции в слое
        /// </summary>
        public LayerAllowedOperations AllowedOperations { get; }

        /// <summary>
        /// Цвет контура для элементов слоя
        /// </summary>
        public Color BorderColor { get; set; }

    }

    /// <summary>
    /// Слой, содержащий все фигуры
    /// </summary>
    [Serializable]
    public class Layer
    {
        private readonly List<Figure> _figures = new List<Figure>();
        private List<LayerItem> _layers = new List<LayerItem>();

        public List<Figure> Figures
        {
            get { return _figures; }
            set
            {
                _figures.Clear();
                _figures.AddRange(value);
            }
        }

        public List<LayerItem> Layers
        {
            get
            {
                return _layers;
            }
            set
            {
                // поддержка обратной совместимости
                if (_layers == null) _layers = new List<LayerItem>();
                _layers.Clear();
                _layers.AddRange(value);
            }
        }

        /// <summary>
        /// Свойство для хранения данных кисти
        /// </summary>
        public Fill FillStyle { get; set; }

        public Layer()
        {
            FillStyle = new DefaultFill { IsVisible = false };
            _figures = new List<Figure>();
            _layers = new List<LayerItem>();
        }

    }
}
