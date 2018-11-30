using System;
using System.Collections.Generic;
using System.Drawing;
using EditorModel.Common;

namespace EditorModel.Geometry
{
    /// <summary>
    /// Содержит геометрию полигона
    /// </summary>
    [Serializable]
    internal class RegularGeometry : Geometry
    {
        private readonly PointF[] _points;

        /// <summary>
        /// Локальное поле для хранения пути
        /// </summary>
        private readonly SerializableGraphicsPath _path = new SerializableGraphicsPath();

        /// <summary>
        /// Локальное поле для хранения ограничений для операций
        /// </summary>
        private readonly AllowedOperations _allowedOperations;

        /// <summary>
        /// Конструктор с настройками по умолчанию
        /// </summary>
        public RegularGeometry(int vertexCount)
        {
            if (vertexCount < 3) throw 
                new ArgumentOutOfRangeException("vertexCount", 
                    "Количество вершин должно быть три и более.");
            _allowedOperations = AllowedOperations.All ^
                (AllowedOperations.Vertex | AllowedOperations.Size | AllowedOperations.Skew);
            var rect = new RectangleF(0f, 0f, 1, 1);
            var radius = rect.Width/2;
            var points = new List<PointF>();
            var stepAngle = Math.PI*2/vertexCount;
            var angle = 0.0;
            for (var i = 0; i < vertexCount; i++)
            {
                points.Add(new PointF((float) (radius*Math.Cos(angle)), (float) (radius*Math.Sin(angle))));
                angle += stepAngle;
            }
            _points = points.ToArray();
        }

        /// <summary>
        /// Свойство возвращает путь, построенный по данным строки и свойств шрифта
        /// </summary>
        public override SerializableGraphicsPath Path
        {
            get
            {
                // сброс пути
                _path.Path.Reset();
                // добавляем в путь построенный по точкам единичного прямоугольника полигон
                _path.Path.AddPolygon(_points);
                // возвращаем настроенный путь
                return _path;
            }
        }

        /// <summary>
        /// Свойство возвращает определённые в конструкторе ограничения для операций
        /// </summary>
        public override AllowedOperations AllowedOperations { get { return _allowedOperations; } }
    }
}
