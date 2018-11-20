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
        readonly Layer _layer;
        readonly SelectionController _selectionController;
        private Keys _modifers;

        public FormSimpleEditor()
        {
            InitializeComponent();
            _layer = new Layer();
            _selectionController = new SelectionController(_layer);
            _selectionController.SelectedFigureChanged += _selectionController_SelectedFigureChanged;
            var builder = new FigureBuilder();
            //создаем первую фигуру
            var fig1 = new Figure();
            fig1.Transform.Translate(150, 150);
            fig1.Transform.Scale(130, 130);
            builder.BuildEllipseGeometry(fig1);
            _layer.Figures.Add(fig1);
            //создаем вторую фигуру
            var fig2 = new Figure();
            fig2.Transform.Translate(200, 200);
            fig2.Transform.Scale(130, 130);
            builder.BuildRectangleGeometry(fig2);
            _layer.Figures.Add(fig2);
            pbCanvas.Invalidate();
        }

        /// <summary>
        /// Что-то в выборе изменилось
        /// </summary>
        void _selectionController_SelectedFigureChanged()
        {
            // перерисуем на всякий случай
            pbCanvas.Invalidate();
        }

        private void FormSimpleEditor_KeyDown(object sender, KeyEventArgs e)
        {
            _modifers = e.Modifiers;
        }

        private void FormSimpleEditor_KeyUp(object sender, KeyEventArgs e)
        {
            _modifers = e.Modifiers;
        }

        private void pbCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            _selectionController.OnMouseDown(e.Location, _modifers);
        }

        private void pbCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor =  _selectionController.GetCursor(e.Location, _modifers);
            _selectionController.OnMouseMove(e.Location, _modifers);
        }

        private void pbCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            _selectionController.OnMouseUp(e.Location, _modifers);
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
                fig.Renderer.Render(e.Graphics);
            // отрисовка выделения
            _selectionController.Selection.Renderer.Render(e.Graphics);
            // отрисовка маркеров
            foreach (var marker in _selectionController.Markers)
                marker.Renderer.Render(e.Graphics);
        }
    }
}
