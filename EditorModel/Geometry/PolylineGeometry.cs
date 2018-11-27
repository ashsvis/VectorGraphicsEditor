using System;
using System.Collections.Generic;
using System.Drawing;
using EditorModel.Common;

namespace EditorModel.Geometry
{
    /// <summary>
    /// Содержит геометрию ломаной линии
    /// </summary>
    [Serializable]
    internal class PolylineGeometry : Geometry
    {
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
        internal PolylineGeometry()
        {
            _allowedOperations = AllowedOperations.All;
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
                var rect = new RectangleF(-0.5f, -0.5f, 1, 1);
                var points = new List<PointF>
                    {
                        new PointF(rect.Left, rect.Top),
                        new PointF(rect.Left + rect.Width, rect.Top + rect.Height)
                    };
                // добавляем в путь построенную по точкам единичного прямоугольника отрезок линии
                _path.Path.AddLines(points.ToArray());
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