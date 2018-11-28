using System.Drawing;
using System.Windows.Forms;
using EditorModel.Figures;

namespace SimpleEditor.Controllers
{
    public class Marker : Figure
    {
        public Cursor Cursor;
        public PointF Position { get; set; }
        public PointF AnchorPosition { get; set; }
        public MarkerType MarkerType { get; set; }
        public int Index { get; set; }
        public Figure Owner { get; set; }
    }

    public enum MarkerType
    {
        Scale,
        SizeX,
        SizeY,
        Rotate,
        SkewX,
        SkewY,
        Vertex
    }
}
