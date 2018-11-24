using System;
using System.Drawing;

namespace SimpleEditor.Commands
{
    /// <summary>
    /// Примерчик от Storm23
    /// </summary>
    public class ChangeColorCommand : ICommand
    {
        private Rects _rects;
        private readonly Color _color;
        private Color _prevColor;

        public ChangeColorCommand(Rects rects, Color color)
        {
            _rects = rects;
            _color = color;
        }

        public string Name
        {
            get { return "Change color"; }
        }

        public void Execute()
        {
            //запоминаем предыдущий цвет
            _prevColor = _rects.LastRect.Color;
            //присваиваем новый цвет
            _rects.LastRect.Color = _color;
            //сигнализируем об изменениях
            _rects.OnChanged();
        }

        public void UnExecute()
        {
            //возвращаем предыдущий цвет
            _rects.LastRect.Color = _prevColor;
            //сигнализируем об изменениях
            _rects.OnChanged();
        }
    }

    public class Rects
    {
        public Rect LastRect { get; internal set; }

        internal void OnChanged()
        {
            throw new NotImplementedException();
        }
    }

    public class Rect
    {
        public Color Color { get; internal set; }
    }
}
