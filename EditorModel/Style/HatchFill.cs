using System;
using System.Drawing;
using EditorModel.Figures;
using System.Drawing.Drawing2D;

namespace EditorModel.Style
{
    [Serializable]
    public class HatchFill : FillDecorator
    {
        private readonly Fill _fill;

        public HatchFill(Fill fill)
            : base(fill)
        {
            _fill = fill;
            HatchColor = Color.Gray;
            HatchStyle = HatchStyle.BackwardDiagonal;
        }

        /// <summary>
        /// Второй цвет для заполнения штриховки (цвет штриховки)
        /// </summary>
        public Color HatchColor { get; set; }

        public HatchStyle HatchStyle { get; set; }


        public override Brush GetBrush(Figure figure)
        {
            return new HatchBrush(HatchStyle, HatchColor, Color.FromArgb(_fill.Opacity, _fill.Color));
        }

        /// <summary>
        /// Свойство возвращает ограничения для подключения декораторов
        /// </summary>
        public override AllowedFillDecorators AllowedDecorators
        {
            get { return AllowedFillDecorators.None; }
        }
        /// <summary>
        /// Величина прозрачности цвета заливки
        /// </summary>
        public override int Opacity
        {
            get { return _fill.Opacity; }
            set { _fill.Opacity = value; }
        }

        /// <summary>
        /// Цвет для заполнения фона (цвет заливки)
        /// </summary>
        public override Color Color
        {
            get { return _fill.Color; }
            set { _fill.Color = value; }
        }

        /// <summary>
        /// Признак возможности заливки фигуры
        /// </summary>
        public override bool IsVisible
        {
            get { return _fill.IsVisible; }
            set { _fill.IsVisible = value; }
        }
    }
}
