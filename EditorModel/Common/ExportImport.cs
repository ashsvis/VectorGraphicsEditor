using EditorModel.Figures;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;
using System.Text;
using EditorModel.Geometry;

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

        private static void SaveImage(string fileName, Layer layer, GroupFigure group, 
            int width, int height, ImageFormat format)
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

        private static string ColorToHex(Color color)
        {
            return string.Format("{0:X}{1:X}{2:X}", color.R, color.G, color.B).ToLower();
        }

        private static string ColorToStr(Color color)
        {
            return color.IsKnownColor 
                ? color.ToKnownColor().ToString().ToLower()
                : string.Format("rgb({0},{1},{2})", color.R, color.G, color.B);
        }

        public static void ExportToSvg(string fileName, Layer layer)
        {
            var fp = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            var list = new List<string>
            {
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>",
                "<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\"",
                " \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">"
            };
            list.Add("<svg width=\"1000\" height=\"1000\"  xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">");
            foreach (var fig in layer.Figures)
            {
                var stroke = fig.Style.BorderStyle != null && fig.Style.BorderStyle.IsVisible ?
                    string.Format(fp, "stroke:{0};stroke-width:{1};",
                       ColorToStr(fig.Style.BorderStyle.Color), fig.Style.BorderStyle.Width) : "";
                var fill = fig.Style.FillStyle != null && fig.Style.FillStyle.IsVisible ?
                    string.Format("fill:{0};", ColorToStr(fig.Style.FillStyle.Color)) : "fill:none;";

                var style = string.Format("style=\"{0}{1}\"", fill, stroke);
                //var rect = fig.GetTransformedPath().Path.GetBounds();
                var points = fig.GetTransformedPath().Path.PathPoints;
                var prim = new StringBuilder();
                foreach (var pt in points)
                    prim.AppendFormat(fp, "{0},{1} ", pt.X, pt.Y);
                var m = fig.Transform.Matrix.Elements;
                var transform = string.Format(fp, "transform=\"matrix({0}, {1}, {2}, {3}, {4}, {5})\"", 
                                              m[0], m[1], m[2], m[3], m[4], m[5]);
                switch (fig.Geometry.ToString())
                {
                    case "Rectangle":
                    case "Square":
                    case "Ellipse":
                    case "Circle":
                        list.Add(string.Format("<polygon points=\"{1}\" {2}/>", fig.Geometry.ToString().ToLower(), prim, style));
                        break;
                    case "Polygon":
                    case "Polyline":
                        var pg = fig.Geometry as PolygoneGeometry;
                        var sb = new StringBuilder();
                        foreach (var pt in pg.Points)
                            sb.AppendFormat(fp, "{0},{1} ", pt.X, pt.Y);
                        list.Add(string.Format("<{0} points=\"{1}\" {2} {3}/>", fig.Geometry.ToString().ToLower(), sb, transform, style));
                        break;
                }
            }
            list.Add("</svg>");
            File.WriteAllLines(fileName, list, Encoding.UTF8);
        }
    }
}
