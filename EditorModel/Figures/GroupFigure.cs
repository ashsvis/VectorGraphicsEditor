using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using EditorModel.Common;
using EditorModel.Geometry;
using EditorModel.Renderers;

namespace EditorModel.Figures
{
    public enum GroupJoin
    {
        None,
        Intersect,
        Union,
        Xor,
        Exclude,
        Complement
    }

    /// <summary>
    /// Класс для группирования фигур
    /// </summary>
    [Serializable]
    public class GroupFigure : Figure
    {
        private readonly List<Figure> _figures = new List<Figure>();

        private Figure _placeHolder;

        public IEnumerable<Figure> Figures
        {
            get { return _figures.ToArray(); }
            set
            {
                _figures.Clear();
                _figures.AddRange(value.DeepClone());
                if (_placeHolder != null)
                {
                    var size = Helper.GetSize(_placeHolder.Transform.Matrix);
                    var x = _placeHolder.Transform.Matrix.OffsetX - size.Width / 2;
                    var y = _placeHolder.Transform.Matrix.OffsetY - size.Height / 2;
                    var selection = new Selections.Selection();
                    foreach (var figure in _figures) selection.Add(figure);
                    selection.Translate(x, y);
                    selection.PushTransformToSelectedFigures();
                    _placeHolder = null;
                }
            }
        }

        public GroupFigure(List<Figure> figures = null)
        {
            if (figures == null)
            {
                _placeHolder = new Placeholder();
                figures = new List<Figure> { _placeHolder };
            }
            Style.BorderStyle = null;
            var path = new SerializableGraphicsPath();
            path.Path.AddRectangle(new RectangleF(-0.5f, -0.5f, 1, 1));
            foreach (var figure in figures)
            {
                var fig = figure.DeepClone();
                fig.Transform.Matrix.Multiply(Transform, MatrixOrder.Append);
                _figures.Add(fig);
            }
            Geometry = new PrimitiveGeometry(path, AllowedOperations.All ^ 
                (AllowedOperations.Vertex | AllowedOperations.Pathed))
            { Name = "Group" };
            Renderer = new GroupRenderer();
            Transform = new SerializableGraphicsMatrix();
        }

        /// <summary>
        /// Предоставление трансформированной геометрии для рисования
        /// </summary>
        /// <returns>Путь для рисования</returns>
        public override SerializableGraphicsPath GetTransformedPath()
        {
            // создаём копию геометрии фигуры
            var path = new SerializableGraphicsPath { Path = { FillMode = FillMode.Winding } };
            foreach (var figure in _figures)
            {
                path.Path.AddPath(figure.GetTransformedPath().Path, false);
            }
            // трансформируем её при помощи Трансформера
            path.Path.Transform(Transform);
            return path;
        }

        public override void PushTransform(Matrix matrix)
        {
            Transform.Matrix.Multiply(matrix, MatrixOrder.Append);
            foreach (var fig in _figures)
            {
                fig.Transform.Matrix.Multiply(Transform, MatrixOrder.Append);
                if (fig is Placeholder) _placeHolder = fig.DeepClone();
            }
            Transform = new SerializableGraphicsMatrix();
        }
    }

    [Serializable]
    public class Placeholder : Figure
    {
        public Placeholder()
        {
            Style.FillStyle.IsVisible = false;
            Style.BorderStyle.DashStyle = DashStyle.Dash;
            FigureBuilder.BuildRectangleGeometry(this);
            Geometry.Name = "Placeholder";
        }
    }


}
