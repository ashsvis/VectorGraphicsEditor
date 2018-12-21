using EditorModel.Common;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace EditorModel.Geometry
{
    [Serializable]
    public sealed class AddLineGeometry : Geometry, IDisposable
    {
        public readonly List<PointF> Points = new List<PointF>();

        /// <summary>
        /// Локальное поле для хранения пути
        /// </summary>
        private readonly SerializableGraphicsPath _path = new SerializableGraphicsPath();

        /// <summary>
        /// Свойство возвращает определённые в конструкторе ограничения для операций
        /// </summary>
        public override AllowedOperations AllowedOperations { get { return AllowedOperations.None; } }

        public override SerializableGraphicsPath Path
        {
            get
            {
                _path.Path.Reset();
                if (Points.Count > 0)
                    _path.Path.AddLines(Points.ToArray());
                return _path;
            }
        }

        /// <summary>
        /// Конструктор, недоступный вне проекта EditorModel
        /// (только для внутреннего использования)
        /// </summary>
        internal AddLineGeometry(PointF startPoint)
        {
            Points.Add(startPoint);
        }

        public void Dispose()
        {
            _path?.Dispose();
        }

        public void AddPoint(Point point)
        {
            Points.Add(point);
        }
    }
}
