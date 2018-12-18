using EditorModel.Figures;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace EditorModel.Common
{
    public static class ExportImport
    {
        public static void SaveToImage(string fileName, Layer layer)
        {
            HandleFillStyle(layer, out GroupFigure group, out int width, out int height);
            var format = GetFileFormat(fileName);
            SaveImage(fileName, layer, group, width, height, format);
        }

        private static void HandleFillStyle(Layer layer, out GroupFigure group, out int width, out int height)
        {
            group = new GroupFigure(layer.Figures);
            var bounds = @group.GetTransformedPath().Path.GetBounds();
            if (layer.FillStyle.IsVisible)
            {
                width = (int)(bounds.Left * 2 + bounds.Width);
                height = (int)(bounds.Top * 2 + bounds.Height);
            }
            else
            {
                width = (int)(bounds.Width + 2);
                height = (int)(bounds.Height + 2);
                @group.Transform.Matrix.Translate(-bounds.Left, -bounds.Top);
            }
        }

        private static void SaveImage(string fileName, Layer layer, GroupFigure group, int width, int height, System.Drawing.Imaging.ImageFormat format)
        {
            using (var image = new Bitmap(width, height))
            {
                using (var g = Graphics.FromImage(image))
                {
                    if (layer.FillStyle.IsVisible)
                        g.Clear(Color.FromArgb(layer.FillStyle.Opacity, layer.FillStyle.Color));
                    @group.Renderer.Render(g, @group);
                }
                image.Save(fileName, format);
            }
        }

        private static ImageFormat GetFileFormat(string fileName)
        {
            var extension = Path.GetExtension(fileName);

            switch (extension.ToLower())
            {
                case ".png": return ImageFormat.Png;
                case ".jpg": return ImageFormat.Jpeg;
                case ".emf": return ImageFormat.Emf;
                case ".gif": return ImageFormat.Gif;
                case ".ico": return ImageFormat.Icon;
                case ".tif": return ImageFormat.Tiff;
                default: return ImageFormat.Bmp;
            }
        }
    }
}
