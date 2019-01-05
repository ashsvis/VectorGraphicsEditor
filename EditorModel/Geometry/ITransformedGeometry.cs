using EditorModel.Figures;
using System.Drawing;

namespace EditorModel.Geometry
{
    public interface ITransformedGeometry
    {
        byte[] GetTransformedPointTypes(Figure owner);
        PointF[] GetTransformedPoints(Figure owner);
        void SetTransformedPoints(Figure owner, PointF[] points);
        bool IsClosed { get; }
    }
}
