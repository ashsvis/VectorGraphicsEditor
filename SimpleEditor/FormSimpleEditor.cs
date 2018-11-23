using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using EditorModel.Figures;
using System.Windows.Forms;
using SimpleEditor.Common;
using SimpleEditor.Controllers;

namespace SimpleEditor
{
    public enum EditorMode
    {
        Select,
        Drag,
        AddLine,
        AddPolygon,
        AddRectangle,
        AddSquare,
        AddEllipse,
        AddCircle
    }

    public partial class FormSimpleEditor : Form
    {
        EditorMode _editorMode = EditorMode.Select;
        private Rectangle _ribbonRect;
        private Point _мouseDownLocation;
        private readonly FigureBuilder _builder;
        private Figure _ribbonFigure;

        private Cursor _mouseDownCursor;
        readonly Layer _layer;
        readonly SelectionController _selectionController;

        public FormSimpleEditor()
        {
            InitializeComponent();
            _layer = new Layer();
            _selectionController = new SelectionController(_layer);
            _builder = new FigureBuilder();
            
            // пока что эти события требуют обновить поверхность pbCanvas, когда будет время...
            _selectionController.SelectedFigureChanged += () => pbCanvas.Invalidate();
            _selectionController.SelectedTransformChanging += () => pbCanvas.Invalidate();
            _selectionController.SelectedTransformChanged += () => pbCanvas.Invalidate();
        }

        /// <summary>
        /// Нажали мышкой на канве для рисования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            // запоминаем точку нажатия мышкой
            _мouseDownLocation = e.Location;
            // обнуляем рамку выбора
            _ribbonRect = Rectangle.Empty;
            // если установлен другой режим, кроме выбора прямоугольником
            if (_editorMode != EditorMode.Select)
                _selectionController.Clear();   // очищаем список выбранных

            if (e.Button == MouseButtons.Left)
            {
                if (_editorMode == EditorMode.Select)
                {
                    // запоминаем курсор в этой точке
                    _mouseDownCursor = _selectionController.GetCursor(e.Location, ModifierKeys);
                    // в этом методе мы что-то выбираем или не выбираем
                    _selectionController.OnMouseDown(e.Location, ModifierKeys);
                    // что-то выбрано, тогда "тянем"
                    if (_selectionController.Selection.Count > 0)
                        _editorMode = EditorMode.Drag;
                    else if (_editorMode == EditorMode.Select)
                        Cursor = _mouseDownCursor = CursorFactory.GetCursor(UserCursor.SelectByRibbonRect);
                }
            }
        }

        /// <summary>
        /// Двигаем мышку по канве для рисования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // если "тащим", то курсор - тот который сохранили
                Cursor = _mouseDownCursor;
                _selectionController.OnMouseMove(e.Location, ModifierKeys);

                // нормализация параметров для рамки выбора
                // в случае, если мы "растягиваем" прямоугольник не только по "главной" диагонали
                _ribbonRect.X = Math.Min(_мouseDownLocation.X, e.Location.X);
                _ribbonRect.Y = Math.Min(_мouseDownLocation.Y, e.Location.Y);
                // размеры должны быть всегда положительные числа
                _ribbonRect.Width = Math.Abs(_мouseDownLocation.X - e.Location.X);
                _ribbonRect.Height = Math.Abs(_мouseDownLocation.Y - e.Location.Y);

                pbCanvas.Invalidate();
            }
            else // иначе тот курсор, который определяем в текущий момент
                if (_editorMode == EditorMode.Select || _editorMode == EditorMode.Drag)
                    Cursor = _selectionController.GetCursor(e.Location, ModifierKeys);
                else
                    Cursor = _mouseDownCursor;
        }

        /// <summary>
        /// Отпустили мышку на канве для рисования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_editorMode == EditorMode.Select)
                {
                    // добавляем все фигуры, которые оказались охваченными прямоугольником выбора
                    // в список выбранных фигур
                    foreach (var fig in _layer.Figures.Where(fig =>
                        _ribbonRect.Contains(Rectangle.Ceiling(fig.GetTransformedPath().GetBounds()))))
                        _selectionController.Selection.Add(fig);                    
                }
                else if (_editorMode != EditorMode.Drag && _ribbonFigure != null)
                {
                    var p = _ribbonRect.Location;
                    p.Offset(_ribbonRect.Width/2, _ribbonRect.Height/2);
                    _ribbonFigure.Transform.Translate(p.X, p.Y);
                    _ribbonFigure.Transform.Scale(_ribbonRect.Width, _ribbonRect.Height);
                    _layer.Figures.Add(_ribbonFigure);
                }
                // при выборе рамкой так же нужно вызывать этот метод 
                _selectionController.OnMouseUp(e.Location, ModifierKeys);
                Cursor = Cursors.Default;

                // возвращаем режим
                _editorMode = EditorMode.Select;
                tsbArrow_Click(tsbArrow, new EventArgs());

                // обнуление рамки выбора
                _ribbonRect = Rectangle.Empty;
                pbCanvas.Invalidate();
            
            }
        }

        /// <summary>
        /// Рисовальщик содержимого слоя, выделения и маркеров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            // отрисовка созданных фигур
            foreach (var fig in _layer.Figures)
                fig.Renderer.Render(e.Graphics, fig);
            // отрисовка выделения
            _selectionController.Selection.Renderer.Render(e.Graphics,
                                                           _selectionController.Selection);
            // отрисовка маркеров
            foreach (var marker in _selectionController.Markers)
                marker.Renderer.Render(e.Graphics, marker);

            if (_ribbonRect.IsEmpty) return;
            if (_ribbonFigure != null)
            {
                var allowSize = _ribbonFigure.Geometry.AllowedOperations.HasFlag(AllowedOperations.Size);
                if (!allowSize)
                {
                    var max = Math.Max(_ribbonRect.Width, _ribbonRect.Height);
                    _ribbonRect.Size = new Size(max, max);
                }
            }
            if (_editorMode != EditorMode.Drag)
            {
                // рисуем рамку прямоугольника выбора
                using (var pen = new Pen(Color.Black))
                {
                    pen.DashStyle = DashStyle.Dot;
                    e.Graphics.DrawRectangle(pen, _ribbonRect);
                }
            }
        }

        private void tsbArrow_Click(object sender, EventArgs e)
        {
            foreach (ToolStripButton btn in tsFigures.Items) btn.Checked = false;
            ((ToolStripButton)sender).Checked = true;
            if (!tsbArrow.Checked)
            {
                _selectionController.Clear();
                pbCanvas.Invalidate();
            }
            if (tsbPolyline.Checked)
            {
                _editorMode = EditorMode.AddLine;
                _ribbonFigure = null;       // stub
                Cursor = Cursors.Default;   // stub
            }
            else if (tsbPolygon.Checked)
            {
                _editorMode = EditorMode.AddPolygon;
                _ribbonFigure = new Figure();
                _builder.BuildPolygoneGeometry(_ribbonFigure);
                Cursor = _mouseDownCursor = CursorFactory.GetCursor(UserCursor.CreateRect);
            }
            else if (tsbRect.Checked)
            {
                _editorMode = EditorMode.AddRectangle;
                _ribbonFigure = new Figure();
                _builder.BuildRectangleGeometry(_ribbonFigure);
                Cursor = _mouseDownCursor = CursorFactory.GetCursor(UserCursor.CreateRect);
            }
            else if (tsbSquare.Checked)
            {
                _editorMode = EditorMode.AddSquare;
                _ribbonFigure = new Figure();
                _builder.BuildSquareGeometry(_ribbonFigure);
                Cursor = _mouseDownCursor = CursorFactory.GetCursor(UserCursor.CreateRect);
            }
            else if (tsbEllipse.Checked)
            {
                _editorMode = EditorMode.AddEllipse;
                _ribbonFigure = new Figure();
                _builder.BuildEllipseGeometry(_ribbonFigure);
                Cursor = _mouseDownCursor = CursorFactory.GetCursor(UserCursor.CreateEllipse);
            }
            else if (tsbCircle.Checked)
            {
                _editorMode = EditorMode.AddCircle;
                _ribbonFigure = new Figure();
                _builder.BuildCircleGeometry(_ribbonFigure);
                Cursor = _mouseDownCursor = CursorFactory.GetCursor(UserCursor.CreateEllipse);
            }
            else
            {
                _editorMode = EditorMode.Select;
                _ribbonFigure = null;
                Cursor = _mouseDownCursor = Cursors.Default;
            }
        }
    }
}
