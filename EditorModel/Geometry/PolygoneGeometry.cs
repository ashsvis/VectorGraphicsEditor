using EditorModel.Common;
using System;
using System.Drawing;
using EditorModel.Figures;

namespace EditorModel.Geometry
{
    /// <summary>
    /// Содержит геометрию полигона
    /// </summary>
    [Serializable]
    public sealed class PolygoneGeometry : Geometry, IDisposable
    {
        private PointF[] _points;
        private bool _isClosed = true;

        /// <summary>
        /// Локальное поле для хранения пути
        /// </summary>
        private readonly SerializableGraphicsPath _path = new SerializableGraphicsPath();

        /// <summary>
        /// Локальное поле для хранения ограничений для операций
        /// </summary>
        private readonly AllowedOperations _allowedOperations;

        /// <summary>
        /// Признак замкнутого контура фигуры
        /// </summary>
        public bool IsClosed
        {
            get { return _isClosed; }
            set { _isClosed = value; }
        }

        public bool IsSmoothed { get; set; }

        /// <summary>
        /// Точки контура фигуры
        /// </summary>
        public PointF[] Points
        {
            get { return _points; }
            set { _points = value; }
        }

        /// <summary>
        /// Get Transformed Points
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public PointF[] GetTransformedPoints(Figure owner)
        {
            var points = (PointF[])Points.Clone();
            owner.Transform.Matrix.TransformPoints(points);
            return points;
        }

        /// <summary>
        /// Set Transformed Points
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="points"></param>
        public void SetTransformedPoints(Figure owner, PointF[] points)
        {
            points = (PointF[])points.Clone();
            var m = owner.Transform.Matrix.Clone();
            m.Invert();
            m.TransformPoints(points);
            Points = points;
        }

        public void Dispose()
        {
            _path?.Dispose();
        }

        /// <summary>
        /// Конструктор с настройками по умолчанию
        /// </summary>
        internal PolygoneGeometry(bool isClosed = true)
        {
            IsClosed = isClosed;
            _allowedOperations = AllowedOperations.All ^ AllowedOperations.Pathed;
            var rect = new RectangleF(-0.5f, -0.5f, 1, 1);
            if (isClosed)
                _points = new[]
                    {
                        new PointF(rect.Left, rect.Top),
                        new PointF(rect.Left + rect.Width/2, rect.Top),
                        new PointF(rect.Left + rect.Width, rect.Top),
                        new PointF(rect.Left + rect.Width, rect.Top + rect.Height/2),
                        new PointF(rect.Left + rect.Width, rect.Top + rect.Height),
                        new PointF(rect.Left + rect.Width/2, rect.Top + rect.Height),
                        new PointF(rect.Left, rect.Top + rect.Height),
                        new PointF(rect.Left, rect.Top + rect.Height/2)
                    };
            else
                _points = new[]
                    {
                        new PointF(rect.Left, rect.Top),
                        new PointF(rect.Left + rect.Width/2, rect.Top + rect.Height/2),
                        new PointF(rect.Left + rect.Width, rect.Top + rect.Height)
                    };
        }

        /// <summary>
        /// Свойство возвращает путь, построенный по точкам
        /// </summary>
        public override SerializableGraphicsPath Path
        {
            get
            {
                // сброс пути
                _path.Path.Reset();
                // добавляем в путь построенный по точкам единичного прямоугольника полигон
                if (IsClosed)
                {
                    if (IsSmoothed)
                        _path.Path.AddClosedCurve(_points);
                    else
                        _path.Path.AddPolygon(_points);
                }
                else
                {
                    if (IsSmoothed)
                        _path.Path.AddCurve(_points);
                    else
                        _path.Path.AddLines(_points);
                }
                // возвращаем настроенный путь
                return _path;
            }
        }

        /// <summary>
        /// Свойство возвращает определённые в конструкторе ограничения для операций
        /// </summary>
        public override AllowedOperations AllowedOperations { get { return _allowedOperations; } }

        public override string ToString()
        {
            return IsClosed ? "Polygone" : "Polyline";
        }

    }
}
