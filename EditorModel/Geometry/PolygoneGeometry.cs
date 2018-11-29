using EditorModel.Common;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace EditorModel.Geometry
{
    /// <summary>
    /// Содержит геометрию полигона
    /// </summary>
    [Serializable]
    internal class PolygoneGeometry : Geometry
    {
        private readonly List<PointF> _points;

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
        internal PolygoneGeometry()
        {
            _allowedOperations = AllowedOperations.All;
            var rect = new RectangleF(-0.5f, -0.5f, 1, 1);
            _points = new List<PointF>
                {
                    new PointF(rect.Left, rect.Top),
                    new PointF(rect.Left + rect.Width, rect.Top),
                    new PointF(rect.Left + rect.Width, rect.Top + rect.Height),
                    new PointF(rect.Left, rect.Top + rect.Height)
                };
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
                _path.Path.AddPolygon(_points.ToArray());
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
