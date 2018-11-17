using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EditorModel
{
    /// <summary>
    /// Содержит текст
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
        /// Локальное поле для хранения пути (нет возможности сериализовать!)
        /// </summary>
        //private GraphicsPath _path = new GraphicsPath();
        private readonly SerializableGraphicsPath _serializablePath = new SerializableGraphicsPath();

        /// <summary>
        /// Свойство возвращает путь, построенный по данным строки и свойств шрифта
        /// </summary>
        public override GraphicsPath Path
        {
            get
            {
                // сброс пути. TODO: зачем?
                //_path.Reset();
                _serializablePath.Path.Reset();
                // добавляем в путь текстовую строку
                //_path.AddString(Text ?? "", 
                //    new FontFamily(FontName), 0, FontSize, Bounds,
                //                   StringFormat.GenericTypographic);
                _serializablePath.Path.AddString(Text ?? "",
                    new FontFamily(FontName), 0, FontSize, Bounds,
                                    StringFormat.GenericTypographic);
                // возвращаем настроенный путь
                //return _path;
                return _serializablePath.Path;
            }
        }

        public RectangleF Bounds { get; internal set; }

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
