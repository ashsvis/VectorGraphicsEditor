using System;
using System.Drawing.Drawing2D;

namespace EditorModel.Figures
{
    /// <summary>
    /// Содержит геометрию фиксированной формы
    /// </summary>
    [Serializable]
    internal class PrimitiveGeometry : Geometry
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
        /// Свойство возвращает путь, указанный в конструкторе
        /// </summary>
        public override GraphicsPath Path { get { return _path; } }

        /// <summary>
        /// Свойство возвращает определённые в конструкторе ограничения для операций
        /// </summary>
        public override AllowedOperations AllowedOperations { get { return _allowedOperations; } }

        /// <summary>
        /// Конструктор, недоступный вне проекта EditorModel
        /// (только для внутреннего использования)
        /// </summary>
        /// <param name="path">Закрепляемый путь для примитивной геометрии</param>
        /// <param name="allowed">набор прав для операций</param>
        internal PrimitiveGeometry(GraphicsPath path, AllowedOperations allowed)
        {
            // запоминаем переданный в конструкторе путь в локальном поле
            _path = path;
            // запоминаем ограничения для операций в локальном поле
            _allowedOperations = allowed;
        }
    }
}
