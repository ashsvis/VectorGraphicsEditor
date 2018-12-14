using EditorModel.Figures;
using EditorModel.Renderers;
using System.Drawing;
using System.IO;

namespace EditorModel.Common
{
    public static class ExportImport
    {
        public static void SaveToImage(string fileName, Layer layer)
        {
            var ext = Path.GetExtension(fileName).ToLower();
            var group = new GroupFigure(layer.Figures);
            var bounds = group.GetTransformedPath().Path.GetBounds();
            int width, height;
            if (layer.FillStyle.IsVisible)
            {
                width = (int)(bounds.Left * 2 + bounds.Width);
                height = (int)(bounds.Top * 2 + bounds.Height);
            }
            else
            {
                width = (int)(bounds.Width + 2);
                height = (int)(bounds.Height + 2);
                group.Transform.Matrix.Translate(-bounds.Left, -bounds.Top);
            }
            System.Drawing.Imaging.ImageFormat format;
            switch (ext)
            {
                case ".png":
                    format = System.Drawing.Imaging.ImageFormat.Png;
                    break;
                case ".jpg":
                    format = System.Drawing.Imaging.ImageFormat.Jpeg;
                    break;
                case ".emf":
                    format = System.Drawing.Imaging.ImageFormat.Emf;
                    break;
                case ".gif":
                    format = System.Drawing.Imaging.ImageFormat.Gif;
                    break;
                case ".ico":
                    format = System.Drawing.Imaging.ImageFormat.Icon;
                    break;
                case ".tif":
                    format = System.Drawing.Imaging.ImageFormat.Tiff;
                    break;
                default:
                    format = System.Drawing.Imaging.ImageFormat.Bmp;
                    break;
            }
            using (var image = new Bitmap(width, height))
            {
                using (var g = Graphics.FromImage(image))
                {
                    if (layer.FillStyle.IsVisible)
                        g.Clear(Color.FromArgb(layer.FillStyle.Opacity, layer.FillStyle.Color));
                    group.Renderer.Render(g, group);
                }
                image.Save(fileName, format);
            }
        }
    }
}
