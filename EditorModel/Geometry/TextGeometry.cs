using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorModel.Figures
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
        private readonly GraphicsPath _path = new GraphicsPath();

        /// <summary>
        /// Локальное поле для хранения ограничений для операций
        /// </summary>
        private readonly AllowedOperations _allowedOperations;

        /// <summary>
        /// Свойство возвращает путь, построенный по данным строки и свойств шрифта
        /// </summary>
        public override GraphicsPath Path
        {
            get
            {
                // сброс пути.
                _path.Reset();
                // добавляем в путь текстовую строку
                _path.AddString(Text ?? "",
                    new FontFamily(FontName), 0, FontSize, PointF.Empty,
                                    StringFormat.GenericTypographic);
                // возвращаем настроенный путь
                return _path;
            }
        }

        /// <summary>
        /// Свойство возвращает определённые в конструкторе ограничения для операций
        /// </summary>
        public override AllowedOperations AllowedOperations { get { return _allowedOperations; } }

        /// <summary>
        /// Конструктор, недоступный вне проекта EditorModel
        /// (только для внутреннего использования)
        /// </summary>
        internal TextGeometry()
        {
            _allowedOperations = AllowedOperations.All;
            Text = String.Empty;
            FontName = "Arial";
            FontSize = 14f;
        }
    }
}
