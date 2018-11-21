using System;
using System.Drawing;

namespace SimpleEditor.Common
{
    public static class PointFExtension
    {
        public static float Length(this PointF vector)
        {
            return (float) Math.Sqrt(vector.X*vector.X + vector.Y*vector.Y);
        }

        public static float MulScalar(this PointF vector1, PointF vector2)
        {
            var cos = (vector1.X*vector2.X + vector1.Y*vector2.Y)/
                      (Math.Sqrt(vector1.X*vector1.X + vector1.Y*vector1.Y)*
                       Math.Sqrt(vector2.X*vector2.X + vector2.Y*vector2.Y));
            return (float) (vector1.Length()*vector2.Length()*cos);
        }

        public static PointF Add(this PointF vector1, PointF vector2)
        {
            return new PointF(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }

        public static PointF Sub(this PointF vector2, PointF vector1)
        {
            return new PointF(vector2.X - vector1.X, vector2.Y - vector1.Y);
        }

        public static PointF Vector(this PointF point2, PointF point1)
        {
            return new PointF(point2.X - point1.X, point2.Y - point1.Y);
        }

        public static float Angle(this PointF point1, PointF point2)
        {
            var cos = (point1.X * point2.X + point1.Y * point2.Y) /
                      (Math.Sqrt(point1.X * point1.X + point1.Y * point1.Y) *
                       Math.Sqrt(point2.X * point2.X + point2.Y * point2.Y));
            return (float)Math.Acos(cos);
        }
    }
}
