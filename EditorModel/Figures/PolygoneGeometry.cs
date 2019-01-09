using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorModel.Figures
{
    /// <summary>
    /// Содержит геометрию полигона
    /// </summary>
    [Serializable]
    internal class PolygoneGeometry : Geometry
    {
        /// <summary>
        /// Локальное поле для хранения пути
        /// </summary>
        private readonly GraphicsPath _path = new GraphicsPath();

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
        }

        /// <summary>
        /// Свойство возвращает путь, построенный по точкам фигуры
        /// </summary>
        public override GraphicsPath Path
        {
            get
            {
                // сброс пути.
                _path.Reset();
                var rect = new RectangleF(-0.5f, -0.5f, 1, 1);
                var points = new List<PointF>
                {
                    new PointF(rect.Left, rect.Top),
                    new PointF(rect.Left + rect.Width, rect.Top),
                    new PointF(rect.Left + rect.Width, rect.Top + rect.Height),
                    new PointF(rect.Left, rect.Top + rect.Height)
                };
                // добавляем в путь построенный по точкам единичного прямоугольника полигон
                _path.AddPolygon(points.ToArray());
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
