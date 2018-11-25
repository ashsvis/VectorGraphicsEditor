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
        /// Расчёт коэффициента масштабирования
        /// </summary>
        /// <param name="marker">Точка маркера</param>
        /// <param name="anchor">Точка якоря</param>
        /// <param name="mouse">Положение мышки</param>
        /// <returns></returns>
        public static float GetScale(PointF marker, PointF anchor, PointF mouse)
        {
            var a = marker.Sub(anchor); // строим вектор Anchor-Marker
            var m = mouse.Sub(anchor);  // строим вектор Anchor-Mouse(position)
            // считаем коэффициент
            var scale = m.DotScalar(a) / a.LengthSqr();
            // защита результата от "крайних" случаев расчёта
            if (Math.Abs(scale) < EPSILON) scale = EPSILON;
            return scale;
        }

        /// <summary>
        /// Расчет угла вращения (в градусах)
        /// </summary>
        /// <param name="marker">Точка маркера</param>
        /// <param name="anchor">Точка якоря</param>
        /// <param name="mouse">Положение мышки</param>
        /// <returns></returns>
        public static float GetAngle(PointF marker, PointF anchor, PointF mouse)
        {
            var a = marker.Sub(anchor);
            var m = mouse.Sub(anchor);
            return m.Angle(a) * PointFExtension.TO_DEGREES;
        }
    }
}