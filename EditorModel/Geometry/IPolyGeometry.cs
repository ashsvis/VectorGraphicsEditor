using System.Collections.Generic;
using System.Drawing;

namespace EditorModel.Geometry
{
    public interface IPolyGeometry
    {
        List<PointF> Points { get; set; }
    }
}
