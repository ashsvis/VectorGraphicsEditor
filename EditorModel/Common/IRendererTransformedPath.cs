using EditorModel.Figures;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorModel.Common
{
    public interface IRendererTransformedPath
    {
        GraphicsPath GetTransformedPath(Graphics graphics, Figure figure);
    }
}
