using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorModel
{
    /// <summary>
    /// Содержит геометрию текстовой строки
    /// </summary>
    [Serializable]
    internal class TextGeometry : Geometry
    {
        /// <summary>
        /// Текст для построения пути
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Имя файла шрифта
        /// </summary>
        public string FontName { get; set; }

        /// <summary>
        /// Размер шрифта
        /// </summary>
        public float FontSize { get; set; }

        /// <summary>
        /// Локальное поле для хранения пути
        /// </summary>
        private readonly SerializableGraphicsPath path = new SerializableGraphicsPath();

        /// <summary>
        /// Свойство возвращает путь, построенный по данным строки и свойств шрифта
        /// </summary>
        public override GraphicsPath Path
        {
            get
            {
                // сброс пути. TODO: зачем?
                path.Path.Reset();
                // добавляем в путь текстовую строку
                path.Path.AddString(Text ?? "",
                    new FontFamily(FontName), 0, FontSize, PointF.Empty,
                                    StringFormat.GenericTypographic);
                // возвращаем настроенный путь
                return path;
            }
        }

        /// <summary>
        /// Конструктор, недоступный вне проекта EditorModel
        /// (только для внутреннего использования)
        /// </summary>
        internal TextGeometry()
        {
            Text = String.Empty;
            FontName = "Arial";
            FontSize = 14f;
        }
    }
}
