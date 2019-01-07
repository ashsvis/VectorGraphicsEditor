using EditorModel.Common;
using EditorModel.Figures;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorModel.Style
{
    [Serializable]
    public class TextureFill : FillDecorator
    {
        private readonly Fill _fill;

        public Bitmap Image { get; set; }

        public WrapMode WrapMode { get; set; } = WrapMode.Tile;

        public float Scale { get; set; } = 1f;

        public TextureFill(Fill fill) : base(fill)
        {
            _fill = fill;
            WrapMode = WrapMode.Tile;
        }
        public override Brush GetBrush(Figure figure)
        {
            if (Image == null)
                return new SolidBrush(Color.Transparent);
            var textureBrush = new TextureBrush(Image, WrapMode);
            textureBrush.ScaleTransform(Scale, Scale);
            return textureBrush;
        }

        /// <summary>
        /// Свойство возвращает ограничения для подключения декораторов
        /// </summary>
        public override AllowedFillDecorators AllowedDecorators
        {
            get { return AllowedFillDecorators.None; }
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
