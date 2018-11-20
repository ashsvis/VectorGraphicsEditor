using EditorModel;
using EditorModel.Figures;
using EditorModel.Selections;
using System.Windows.Forms;

namespace SimpleEditor
{
    public enum EditorMode
    {
        Select,
        Drag,
        AddRect
    }

    public partial class FormSimpleEditor : Form
    {
        EditorMode _editorMode = EditorMode.Select;

        private Cursor _mouseDownCursor;
        readonly Layer _layer;
        readonly SelectionController _selectionController;

        public FormSimpleEditor()
        {
            InitializeComponent();
            _layer = new Layer();
            _selectionController = new SelectionController(_layer);
            
            // пока что эти события требуют обновить поверхность pbCanvas, когда будет время...
            _selectionController.SelectedFigureChanged += () => pbCanvas.Invalidate();
            _selectionController.SelectedTransformChanging += () => pbCanvas.Invalidate();
            _selectionController.SelectedTransformChanged += () => pbCanvas.Invalidate();

            #region это для тестов

            var builder = new FigureBuilder();
            //создаем первую фигуру
            var fig1 = new Figure();
            fig1.Transform.Translate(150, 150);
            fig1.Transform.Scale(130, 130);
            builder.BuildCircleGeometry(fig1);
            _layer.Figures.Add(fig1);
            //создаем вторую фигуру
            var fig2 = new Figure();
            fig2.Transform.Translate(200, 200);
            fig2.Transform.Scale(130, 130);
            builder.BuildRectangleGeometry(fig2);
            _layer.Figures.Add(fig2);
            pbCanvas.Invalidate();
            
            #endregion
        }

        /// <summary>
        /// Нажали мышкой на канве для рисования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // запоминаем курсор в этой точке
                _mouseDownCursor = _selectionController.GetCursor(e.Location, ModifierKeys);
                _selectionController.OnMouseDown(e.Location, ModifierKeys);
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
            }
            else // иначе тот курсор, который определяем в текущий момент
                Cursor = _selectionController.GetCursor(e.Location, ModifierKeys);
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
                _selectionController.OnMouseUp(e.Location, ModifierKeys);
                Cursor = Cursors.Default;
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
        }
    }
}
