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
        Layer _layer;
        SelectionController _selectionController;
        private Keys _modifers;

        public FormSimpleEditor()
        {
            InitializeComponent();
            _layer = new Layer();
            _selectionController = new SelectionController(_layer);
            var builder = new FigureBuilder();
            //создаем первую фигуру
            var fig1 = new Figure();
            fig1.Transform.Translate(150, 150);
            fig1.Transform.Scale(30, 30);
            builder.BuildEllipseGeometry(fig1);
            _layer.Figures.Add(fig1);
            //создаем вторую фигуру
            var fig2 = new Figure();
            fig2.Transform.Translate(200, 200);
            fig2.Transform.Scale(30, 30);
            builder.BuildRectangleGeometry(fig2);
            _layer.Figures.Add(fig2);
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
            pbCanvas.Invalidate();
        }

        private void pbCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            _selectionController.OnMouseMove(e.Location, _modifers);
            pbCanvas.Invalidate();
        }

        private void pbCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            _selectionController.OnMouseUp(e.Location, _modifers);
            pbCanvas.Invalidate();
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var fig in _layer.Figures)
                fig.Renderer.Render(e.Graphics);
            if (_selectionController.Selection.Count > 0)
                _selectionController.Selection.Renderer.Render(e.Graphics);
            foreach (var marker in _selectionController.Markers)
            {
                // todo чего-то маркеры какие-то мелкие...
                marker.Renderer.Render(e.Graphics);
            }
        }
    }
}
