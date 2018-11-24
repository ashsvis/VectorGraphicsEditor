using System;
using EditorModel.Figures;
using System.Windows.Forms;
using SimpleEditor.Controllers;

namespace SimpleEditor
{
    public partial class FormSimpleEditor : Form
    {
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
            _selectionController.SelectedRangeChanging += (rect) =>
                                        { tsslRibbonRect.Text = rect.IsEmpty ? string.Empty : string.Format("{0}", rect); };
            _selectionController.EditorModeChanged += (mode) => { tsslEditorMode.Text = string.Format("Режим {0}:", mode); };
            _selectionController.UndoRedoChanged += _selectionController_UndoRedoChanged;
            _selectionController.LayerChanged += (count) => pbCanvas.Invalidate();
        }

        private void _selectionController_UndoRedoChanged(Commands.UndoRedoManager manager, Commands.UndoRedoEventArgs arg)
        {
            tsmUndo.Enabled = tsbUndo.Enabled = arg.UndoCount > 0;
            tsmRedo.Enabled = tsbRedo.Enabled = arg.RedoCount > 0;
        }

        private void FormSimpleEditor_Load(object sender, EventArgs e)
        {
            tsslEditorMode.Text = string.Format("Режим {0}:", EditorMode.Select);
            tsslRibbonRect.Text = "";
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
            Cursor = _selectionController.GetCursor(e.Location, ModifierKeys);
            if (e.Button == MouseButtons.Left)
            {
                _selectionController.OnMouseMove(e.Location, ModifierKeys);
            }
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
                // возврат в режим выбора фигур
                tsbArrow_Click(tsbArrow, new EventArgs());            
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

        private void tsbArrow_Click(object sender, EventArgs e)
        {
            foreach (ToolStripButton btn in tsFigures.Items) btn.Checked = false;
            ((ToolStripButton)sender).Checked = true;
            if (!tsbArrow.Checked)
                _selectionController.Clear();
            if (tsbPolyline.Checked)
                _selectionController.EditorMode = EditorMode.AddLine;
            else if (tsbPolygon.Checked)
                _selectionController.EditorMode = EditorMode.AddPolygon;
            else if (tsbRect.Checked)
                _selectionController.EditorMode = EditorMode.AddRectangle;
            else if (tsbSquare.Checked)
                _selectionController.EditorMode = EditorMode.AddSquare;
            else if (tsbEllipse.Checked)
                _selectionController.EditorMode = EditorMode.AddEllipse;
            else if (tsbCircle.Checked)
                _selectionController.EditorMode = EditorMode.AddCircle;
            else
                _selectionController.EditorMode = EditorMode.Select;
        }

        private void tsbUndo_Click(object sender, EventArgs e)
        {
            _selectionController.Undo();
        }

        private void tsbRedo_Click(object sender, EventArgs e)
        {
            _selectionController.Redo();
        }
    }
}
