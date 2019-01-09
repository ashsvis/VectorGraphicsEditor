using EditorModel.Common;
using System;
using System.Drawing.Drawing2D;
using EditorModel.Renderers;

namespace EditorModel.Figures
{
    /// <summary>
    /// Класс для наследования фигур
    /// </summary>
    [Serializable]
    public class Figure
    {
        /// <summary>
        /// Свойство трансформера фигуры
        /// </summary>
        public SerializableGraphicsMatrix Transform { get; set; }

        /// <summary>
        /// Свойство источника геометрии фигуры
        /// </summary>
        public Geometry.Geometry Geometry { get; set; }

        /// <summary>
        /// Свойство стиля рисования фигуры
        /// </summary>
        public Style.Style Style { get; private set; }

        /// <summary>
        /// Свойство рисовальщика фигуры
        /// </summary>
        public Renderer Renderer { get; set; }

        /// <summary>
        /// Конструктор фигуры для задания свойств по умолчанию
        /// </summary>
        public Figure()
        {
            Transform = new SerializableGraphicsMatrix();
            Style = new Style.Style();
            Renderer = new DefaultRenderer();
        }

        /// <summary>
        /// Предоставление трансформированной геометрии для рисования
        /// </summary>
        /// <returns>Путь для рисования</returns>
        public virtual SerializableGraphicsPath GetTransformedPath()
        {
            // создаём копию геометрии фигуры
            var path = (GraphicsPath)Geometry.Path.Path.Clone();
            // трансформируем её при помощи Трансформера
            path.Transform(Transform);
            return path;
        }
    
        public virtual void PushTransform(Matrix matrix)
        {
            Transform.Matrix.Multiply(matrix, MatrixOrder.Append);
        }

    }

}
