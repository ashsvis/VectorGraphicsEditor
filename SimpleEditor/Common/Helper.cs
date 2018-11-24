using System;
using System.Drawing;

namespace SimpleEditor.Common
{
    static class Helper
    {
// ReSharper disable InconsistentNaming
        public const float EPSILON = 0.01f;
// ReSharper restore InconsistentNaming

        /// <summary>
        /// ������ ������������ ���������������
        /// </summary>
        /// <param name="marker">����� �������</param>
        /// <param name="anchor">����� �����</param>
        /// <param name="mouse">��������� �����</param>
        /// <returns></returns>
        public static float GetScale(PointF marker, PointF anchor, PointF mouse)
        {
            var a = marker.Sub(anchor); // ������ ������ Anchor-Marker
            var m = mouse.Sub(anchor);  // ������ ������ Anchor-Mouse(position)
            // ������� �����������
            var scale = m.DotScalar(a) / a.LengthSqr();
            // ������ ���������� �� "�������" ������� �������
            if (Math.Abs(scale) < EPSILON) scale = EPSILON;
            return scale;
        }

        /// <summary>
        /// ������ ���� �������� (� ��������)
        /// </summary>
        /// <param name="marker">����� �������</param>
        /// <param name="anchor">����� �����</param>
        /// <param name="mouse">��������� �����</param>
        /// <returns></returns>
        public static float GetAngle(PointF marker, PointF anchor, PointF mouse)
        {
            var a = marker.Sub(anchor);
            var m = mouse.Sub(anchor);
            return m.Angle(a) * PointFExtension.TO_DEGREES;
        }
    }
}