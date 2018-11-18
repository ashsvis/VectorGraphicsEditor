using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;

namespace EditorModel
{
    /// <summary>
    /// Набор выделенных фигур и операции над ними
    /// </summary>
    public class Selection : Figure
    {
        // внутренний набор для хранения списка выделенных фигур
        private HashSet<Figure> _selected = new HashSet<Figure>();

        /// <summary>
        /// Очистка списка выделенных фигур
        /// </summary>
        public void Clear()
        {
            _selected.Clear();
            GrabGeometry();
        }

        /// <summary>
        /// Добавление фигуры к списку выделенных фигур
        /// </summary>
        /// <param name="fig"></param>
        public void Add(Figure fig)
        {
            _selected.Add(fig);
            GrabGeometry();
        }

        /// <summary>
        /// Исключение фигуры из списка выделенных фигур
        /// </summary>
        /// <param name="fig"></param>
        public void Remove(Figure fig)
        {
            _selected.Remove(fig);
            GrabGeometry();
        }

        /// <summary>
        /// Копирование геометрий выделенных фигур в свою геометрию
        /// </summary>
        private void GrabGeometry()
        {
            // захватываем геометрию выбранных фигур
            var path = new SerializableGraphicsPath();
            foreach (var fig in _selected)
                ((GraphicsPath)path).AddPath(fig.GetTransformedPath(), false);

            // нарисовать рамку вокруг выбранных фигур 
            var bounds = ((GraphicsPath)path).GetBounds();
            ((GraphicsPath)path).AddRectangle(bounds);

            // выбираем разрешённые операции
            // если выбрана только одна фигура - просто используем её AllowedOperations
            // иначе - разрешаем все операции
            var allowedOperations = _selected.Count == 1 ? _selected.First().Geometry.AllowedOperations : AllowedOperations.All;

            // присваиваем геометрию
            Geometry = new PrimitiveGeometry(path, allowedOperations);

            // сбрасываем преобразование в единичную матрицу
            Transform = new SerializableGraphicsMatrix();
        }

        /// <summary>
        /// Применение своего Transform к Transform выделенных фигур
        /// </summary>
        public void PushTransformToSelectedFigures()
        {
            foreach (var fig in _selected)
                fig.Transform.Matrix.Multiply(Transform);

            GrabGeometry();
        }
    }
}
