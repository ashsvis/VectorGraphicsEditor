using EditorModel.Figures;
using System.Drawing;

namespace EditorModel.Style
{
    public interface IGradientFill
    {
        PointF[] GetGradientPoints(Figure figure);
        void SetGradientPoints(Figure figure, PointF[] points);
        Color GradientColor { get; set; }
    }
}
