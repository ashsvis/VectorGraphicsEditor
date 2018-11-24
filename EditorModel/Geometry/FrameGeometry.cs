using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorModel.Figures
{
    /// <summary>
    /// �������� ��������� �����, ���������� ���� �������
    /// </summary>
    [Serializable]
    public class FrameGeometry : Geometry
    {
        /// <summary>
        /// ��������� ���� ��� �������� ����
        /// </summary>
        private readonly GraphicsPath _path = new GraphicsPath();

        /// <summary>
        /// �������� ���������� ����������� � ������������ ����������� ��� ��������
        /// </summary>
        public override AllowedOperations AllowedOperations { get { return AllowedOperations.None; } }

        public override GraphicsPath Path
        {
            get
            {
                _path.Reset();
                var minX = Math.Min(StartPoint.X, EndPoint.X);
                var maxX = Math.Max(StartPoint.X, EndPoint.X);
                var minY = Math.Min(StartPoint.Y, EndPoint.Y);
                var maxY = Math.Max(StartPoint.Y, EndPoint.Y);
                var rect = new Rectangle(minX, minY, maxX - minX + 1, maxY - minY + 1);
                _path.AddRectangle(rect);
                return _path;
            }
        }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        /// <summary>
        /// �����������, ����������� ��� ������� EditorModel
        /// (������ ��� ����������� �������������)
        /// </summary>
        internal FrameGeometry(Point startPoint)
        {
            EndPoint = StartPoint = startPoint;
        }
    }
}