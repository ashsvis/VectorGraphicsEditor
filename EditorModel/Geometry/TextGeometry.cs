using EditorModel.Common;
using System;
using System.Drawing;

namespace EditorModel.Geometry
{
    /// <summary>
    /// Содержит геометрию текстовой строки
    /// </summary>
    [Serializable]
    public sealed class TextGeometry : Geometry, IDisposable
    {
        /// <summary>
        /// Текст для построения пути
        /// </summary>
        public string Text { get; set; }

        public StringAlignment Alignment { get; set; }

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
        private readonly SerializableGraphicsPath _path = new SerializableGraphicsPath();

        /// <summary>
        /// Локальное поле для хранения ограничений для операций
        /// </summary>
        private readonly AllowedOperations _allowedOperations;

        /// <summary>
        /// Свойство возвращает путь, построенный по данным строки и свойств шрифта
        /// </summary>
        public override SerializableGraphicsPath Path
        {
            get
            {
                // сброс пути.
                _path.Path.Reset();
                // добавляем в путь текстовую строку
                using (var sf = new StringFormat(StringFormat.GenericTypographic))
                {
                    sf.Alignment = Alignment;
                    var text = string.IsNullOrWhiteSpace(Text) ? "(empty)" : Text;
                    _path.Path.AddString(text, new FontFamily(FontName), 0, FontSize, PointF.Empty, sf);
                }
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

        ~TextGeometry()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_path != null) _path.Dispose();
        }
        public override string ToString()
        {
            return "Text";
        }
    }
}
