using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows;

namespace EditorModel.Common
{
    public static class Helper
    {
        public static float GetAngle(Matrix matrix)
        {
            // взято из ответов https://stackoverflow.com/questions/14125771/calculate-angle-from-matrix-transform
            var x = new Vector(1, 0);
            var matr = new System.Windows.Media.Matrix(matrix.Elements[0], matrix.Elements[1], matrix.Elements[2],
                                                       matrix.Elements[3], matrix.Elements[4], matrix.Elements[5]);
            var rotated = Vector.Multiply(x, matr);
            var angleBetween = Vector.AngleBetween(x, rotated);
            return (float)angleBetween;
        }

        /// <summary>
        /// Преобразование ContentAlignment в StringFormat.Alignment и StringFormat.LineAlignment
        /// </summary>
        /// <param name="stringFormat">Ссылка на объект StringFormat</param>
        /// <param name="alignment">Значения для установки</param>
        public static void UpdateStringFormat(StringFormat stringFormat, ContentAlignment alignment)
        {
            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleCenter:
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleRight:
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomRight:
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Far;
                    break;
            }
        }
    }
}
