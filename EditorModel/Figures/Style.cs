using System;

namespace EditorModel.Figures
{
    /// <summary>
    /// Класс стилей фигуры
    /// </summary>
    [Serializable]
    public class Style
    {
        /// <summary>
        /// Свойство для хранения данных для карандаша
        /// </summary>
        public Border BorderStyle { get; private set; }

        /// <summary>
        /// Свойство для хранения данных кисти
        /// </summary>
        public Fill FillStyle { get; private set; }

        /// <summary>
        /// Конструктор стилей, для задания свойств по умолчанию
        /// </summary>
        public Style()
        {
            BorderStyle = new Border();
            FillStyle = new Fill();
        }
    }
}
