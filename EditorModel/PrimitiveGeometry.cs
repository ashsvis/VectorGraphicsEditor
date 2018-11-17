using System;
using System.Drawing.Drawing2D;

namespace EditorModel
{
    /// <summary>
    /// Содержит геометрию фиксированной формы
    /// </summary>
    [Serializable]
    internal class PrimitiveGeometry : Geometry
    {
        /// <summary>
        /// Локальное поле для хранения пути (нет возможности сериализовать!)
        /// </summary>
        //private readonly GraphicsPath _path;
        private readonly SerializableGraphicsPath _serializablePath = new SerializableGraphicsPath();

        /// <summary>
        /// Свойство возвращает путь, указанный в конструкторе
        /// </summary>
        public override GraphicsPath Path { get { return _serializablePath.Path; } }

        /// <summary>
        /// Конструктор, недоступный вне проекта EditorModel
        /// (только для внутреннего использования)
        /// </summary>
        /// <param name="path">Закрепляемый путь для примитивной геометрии</param>
        internal PrimitiveGeometry(SerializableGraphicsPath path /*GraphicsPath path*/)
        {
            // запоминаем переданный в конструкторе путь в локальном поле
            _serializablePath = path;
        }
    }
}
