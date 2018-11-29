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
            
            // подключение обработчиков событий для контроллера выбора
            _selectionController.SelectedFigureChanged += UpdateInterface;
            _selectionController.SelectedTransformChanging += UpdateInterface;
            _selectionController.SelectedTransformChanged += UpdateInterface;
            _selectionController.SelectedRangeChanging += _selectionController_SelectedRangeChanging;
            _selectionController.EditorModeChanged += _ => UpdateInterface();
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
                if (e.Clicks == 2)
                    _selectionController.OnDblClick(e.Location, ModifierKeys);
                else
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
            // состояние курсора обрабатывается вне зависимости от нажатых клавиш мышки
            Cursor = _selectionController.GetCursor(e.Location, ModifierKeys, e.Button);
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

        /// <summary>
        /// Этот обработчик также подключен ко всем кнопкам выбора фигур
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbArrow_Click(object sender, EventArgs e)
        {
            foreach (var btn in tsFigures.Items.OfType<ToolStripButton>())
                btn.Checked = false;
            ((ToolStripButton)sender).Checked = true;

            Func<Figure> figureCreator = null;

            if (tsbPolyline.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    new FigureBuilder().BuildPolylineGeometry(fig);
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
            else if (tsbText.Checked)
            {
                var frm = new FormTextEditor();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    var text = frm.GetText;
                    if (string.IsNullOrWhiteSpace(text)) text = "Sample";
                    figureCreator = () =>
                        {
                            var fig = new Figure();
                            new FigureBuilder().BuildTextGeometry(fig, text);
                            fig.Style.FillStyle.Color = Color.Black;
                            return fig;
                        };
                }
            }
            _selectionController.CreateFigureRequest = figureCreator;
        }

        /// <summary>
        /// Происходит перед показом контекстного меню, отмечается текщий базовый режим 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsCanvasPopup_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tsmiSkewSelectMode.Checked = _selectionController.EditorMode == EditorMode.Skew;
            tsmiVerticiesSelectMode.Checked = _selectionController.EditorMode == EditorMode.Verticies;
            tsmiDefaultSelectMode.Checked = _selectionController.EditorMode == EditorMode.Select;
        }

        /// <summary>
        /// Происходит перед показом главного меню, отмечается текщий базовый режим 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmEditMenu_DropDownOpening(object sender, EventArgs e)
        {
            tsmSkewSelectMode.Checked = _selectionController.EditorMode == EditorMode.Skew;
            tsmVerticiesSelectMode.Checked = _selectionController.EditorMode == EditorMode.Verticies;
            tsmDefaultSelectMode.Checked = _selectionController.EditorMode == EditorMode.Select;
        }

        /// <summary>
        /// Переключение в базовый режим для создания, перетаскивания, изменения размеров и поворота
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmDefaultSelectMode_Click(object sender, EventArgs e)
        {
            _selectionController.EditorMode = EditorMode.Select;
        }

        /// <summary>
        /// Переключение в режим искажений (второй из базовых режимов)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiSkewSelectMode_Click(object sender, EventArgs e)
        {
            _selectionController.EditorMode = EditorMode.Skew;
        }

        /// <summary>
        /// Переключение в режим изменения вершин (третий из базовых режимов)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmVerticiesSelectMode_Click(object sender, EventArgs e)
        {
            _selectionController.EditorMode = EditorMode.Verticies;
        }

        /// <summary>
        /// Сюда подключены пункты для отмены действия из главного и контекстного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmUndo_Click(object sender, EventArgs e)
        {
            _selectionController.Clear();
            UndoRedoManager.Instance.Undo();
            UpdateInterface();
        }

        /// <summary>
        /// Сюда подключены пункты для возврата действия из главного и контекстного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmRedo_Click(object sender, EventArgs e)
        {
            _selectionController.Clear();
            UndoRedoManager.Instance.Redo();
            UpdateInterface();
        }

        /// <summary>
        /// Сюда подключены пункты для отражения по горизонтали из главного и контекстного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiFlipX_Click(object sender, EventArgs e)
        {
            _selectionController.FlipX();
            UpdateInterface();
        }

        /// <summary>
        /// Сюда подключены пункты для отражения по вертикали из главного и контекстного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiFlipY_Click(object sender, EventArgs e)
        {
            _selectionController.FlipY();
            UpdateInterface();
        }

        /// <summary>
        /// Сюда подключены пункты для поворота на четверть по часовой стрелке из главного и контекстного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiRotate90Cw_Click(object sender, EventArgs e)
        {
            _selectionController.Rotate90Cw();
            UpdateInterface();
        }

        /// <summary>
        /// Сюда подключены пункты для поворота на четверть против часовой стрелки из главного и контекстного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiRotate90Ccw_Click(object sender, EventArgs e)
        {
            _selectionController.Rotate90Ccw();
            UpdateInterface();
        }

        /// <summary>
        /// Сюда подключены пункты для поворота на 180° из главного и контекстного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiRotate180_Click(object sender, EventArgs e)
        {
            _selectionController.Rotate180();
            UpdateInterface();
        }

        private void tsmiBringToFront_Click(object sender, EventArgs e)
        {
            _selectionController.BringToFront();
            UpdateInterface();
        }

        private void tsmiSendToBack_Click(object sender, EventArgs e)
        {
            _selectionController.SendToBack();
            UpdateInterface();
        }

        private void tsmiGroup_Click(object sender, EventArgs e)
        {
            _selectionController.Group();
            UpdateInterface();
        }

        private void tsmiUngroup_Click(object sender, EventArgs e)
        {
            _selectionController.Ungroup();
            UpdateInterface();
        }
    }
}
