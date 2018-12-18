using EditorModel.Common;
using System;

namespace EditorModel.Geometry
{
    /// <summary>
    /// Содержит геометрию фиксированной формы
    /// </summary>
    [Serializable]
    public sealed class PrimitiveGeometry : Geometry, IDisposable
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
        /// Свойство возвращает путь, указанный в конструкторе
        /// </summary>
        public override SerializableGraphicsPath Path { get { return _path; } }

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
        internal PrimitiveGeometry(SerializableGraphicsPath path, AllowedOperations allowed)
        {
            Name = "Primitive";
            // запоминаем переданный в конструкторе путь в локальном поле
            _path = path;
            // запоминаем ограничения для операций в локальном поле
            _allowedOperations = allowed;
        }

        public void Dispose()
        {
            _path?.Dispose();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
