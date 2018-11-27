using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using EditorModel.Figures;
using System.Windows.Forms;
using SimpleEditor.Controllers;

namespace SimpleEditor
{
    public partial class FormSimpleEditor : Form
    {
        readonly Layer _layer;
        readonly SelectionController _selectionController;
        readonly UndoRedoController _undoRedoController;

        public FormSimpleEditor()
        {
            InitializeComponent();
            _layer = new Layer();
            _undoRedoController = new UndoRedoController(_layer);

            _selectionController = new SelectionController(_layer);
            
            _selectionController.SelectedFigureChanged += UpdateInterface;
            _selectionController.SelectedTransformChanging += UpdateInterface;
            _selectionController.SelectedTransformChanged += UpdateInterface;
            _selectionController.SelectedRangeChanging += _selectionController_SelectedRangeChanging;
            _selectionController.EditorModeChanged += (_) => UpdateInterface();
            _selectionController.LayerStartChanging += () => OnLayerStartChanging(_selectionController.EditorMode.ToString());
            _selectionController.LayerChanged += OnLayerChanged;
        }

        void OnLayerChanged()
        {
            _undoRedoController.OnFinishOperation();
        }

        void OnLayerStartChanging(string opName)
        {
            _undoRedoController.OnStartOperation(opName);
        }

        private void UpdateInterface()
        {
            tsbUndo.Enabled = tsmUndo.Enabled = UndoRedoManager.Instance.CanUndo;
            tsbRedo.Enabled = tsmRedo.Enabled = UndoRedoManager.Instance.CanRedo;
            tsslEditorMode.Text = string.Format("Mode: {0}", _selectionController.EditorMode);
            tsFigures.Enabled = _selectionController.EditorMode == EditorMode.Select;

            pbCanvas.Invalidate();
        }

        private void _selectionController_SelectedRangeChanging(Rectangle rect)
        {
            tsslRibbonRect.Text = string.Format("{0}", rect);
            UpdateInterface();
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
            tsmiSkewSelectMode.Checked = _selectionController.EditorMode == EditorMode.Skew;
            tsmiVerticiesSelectMode.Checked = _selectionController.EditorMode == EditorMode.Verticies;
            tsmiDefaultSelectMode.Checked = _selectionController.EditorMode == EditorMode.Select;
        }

        private void tsmEditMenu_DropDownOpening(object sender, EventArgs e)
        {
            tsmSkewSelectMode.Checked = _selectionController.EditorMode == EditorMode.Skew;
            tsmVerticiesSelectMode.Checked = _selectionController.EditorMode == EditorMode.Verticies;
            tsmDefaultSelectMode.Checked = _selectionController.EditorMode == EditorMode.Select;
        }

        private void tsmDefaultSelectMode_Click(object sender, EventArgs e)
        {
            _selectionController.EditorMode = EditorMode.Select;
        }

        private void tsmiSkewSelectMode_Click(object sender, EventArgs e)
        {
            _selectionController.EditorMode = EditorMode.Skew;
        }

        private void tsmVerticiesSelectMode_Click(object sender, EventArgs e)
        {
            _selectionController.EditorMode = EditorMode.Verticies;
        }

        private void tsmUndo_Click(object sender, EventArgs e)
        {
            _selectionController.Clear();
            UndoRedoManager.Instance.Undo();
            UpdateInterface();
        }

        private void tsmRedo_Click(object sender, EventArgs e)
        {
            _selectionController.Clear();
            UndoRedoManager.Instance.Redo();
            UpdateInterface();
        }
    }
}
