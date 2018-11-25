using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using EditorModel.Figures;
using System.Windows.Forms;
using SimpleEditor.Controllers;
using SimpleEditor.Commands;

namespace SimpleEditor
{
    public partial class FormSimpleEditor : Form
    {
        readonly Layer _layer;
        readonly SelectionController _selectionController;
        readonly UndoRedoManager _undoRedoManager;

        public FormSimpleEditor()
        {
            InitializeComponent();
            _layer = new Layer();
            _undoRedoManager = new UndoRedoManager();

            _undoRedoManager.StateChanged += _undoRedoManager_StateChanged;

            _selectionController = new SelectionController(_layer, _undoRedoManager);
            
            // пока что эти события требуют обновить поверхность pbCanvas, когда будет время...
            _selectionController.SelectedFigureChanged += () => pbCanvas.Invalidate();
            _selectionController.SelectedTransformChanging += () => pbCanvas.Invalidate();
            _selectionController.SelectedTransformChanged += () => pbCanvas.Invalidate();
            _selectionController.SelectedModeChanged += _selectionController_SelectedModeChanged;
            _selectionController.SelectedRangeChanging += _selectionController_SelectedRangeChanging;
            _selectionController.EditorModeChanged += _selectionController_EditorModeChanged;
        }

        private void _undoRedoManager_StateChanged(UndoRedoManager sender, UndoRedoEventArgs e)
        {
            tsbUndo.Enabled = tsmUndo.Enabled = e.UndoCount > 0;
            tsbRedo.Enabled = tsmRedo.Enabled = e.RedoCount > 0;
            pbCanvas.Invalidate();
        }

        private void _selectionController_SelectedModeChanged(SelectedMode mode)
        {
            tsFigures.Enabled = mode == SelectedMode.Default;
            pbCanvas.Invalidate();
        }

        private void _selectionController_EditorModeChanged(EditorMode mode)
        {
            tsslEditorMode.Text = string.Format("Режим: {0}", mode);
        }

        private void _selectionController_SelectedRangeChanging(Rectangle rect)
        {
            tsslRibbonRect.Text = string.Format("Выбор: {0}", rect);
            pbCanvas.Invalidate();
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
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

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
            foreach (ToolStripButton btn in tsFigures.Items)
                btn.Checked = false;
            ((ToolStripButton)sender).Checked = true;

            if (tsbArrow.Checked)
            {
                _selectionController.EditorMode = EditorMode.Select;
                return;
            }

            Func<Figure> figureCreator = null;

            if (tsbPolyline.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    new FigureBuilder().BuildPolygoneGeometry(fig);//todo
                    return fig;
                };
            else if (tsbPolygon.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    new FigureBuilder().BuildPolygoneGeometry(fig);
                    return fig;
                };
            else if (tsbRect.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    new FigureBuilder().BuildRectangleGeometry(fig);
                    return fig;
                };
            else if (tsbSquare.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    new FigureBuilder().BuildSquareGeometry(fig);
                    return fig;
                };
            else if (tsbEllipse.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    new FigureBuilder().BuildEllipseGeometry(fig);
                    return fig;
                };
            else if (tsbCircle.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    new FigureBuilder().BuildCircleGeometry(fig);
                    return fig;
                };

            _selectionController.CreateFigureRequest = figureCreator;
        }

        private void cmsCanvasPopup_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tsmiSkewSelectMode.Checked = _selectionController.Mode == SelectedMode.Skew;
            tsmiVerticiesSelectMode.Checked = _selectionController.Mode == SelectedMode.Verticies;
            tsmiDefaultSelectMode.Checked = _selectionController.Mode == SelectedMode.Default;
        }

        private void tsmEditMenu_DropDownOpening(object sender, EventArgs e)
        {
            tsmSkewSelectMode.Checked = _selectionController.Mode == SelectedMode.Skew;
            tsmVerticiesSelectMode.Checked = _selectionController.Mode == SelectedMode.Verticies;
            tsmDefaultSelectMode.Checked = _selectionController.Mode == SelectedMode.Default;
        }

        private void tsmDefaultSelectMode_Click(object sender, EventArgs e)
        {
            _selectionController.Mode = SelectedMode.Default;
        }

        private void tsmiSkewSelectMode_Click(object sender, EventArgs e)
        {
            _selectionController.Mode = SelectedMode.Skew;
        }

        private void tsmVerticiesSelectMode_Click(object sender, EventArgs e)
        {
            _selectionController.Mode = SelectedMode.Verticies;
        }

        private void tsmUndo_Click(object sender, EventArgs e)
        {
            _undoRedoManager.Undo();
        }

        private void tsmRedo_Click(object sender, EventArgs e)
        {
            _undoRedoManager.Redo();
        }
    }
}
