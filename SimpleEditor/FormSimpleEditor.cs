using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using EditorModel.Figures;
using System.Windows.Forms;
using EditorModel.Geometry;
using EditorModel.Selections;
using EditorModel.Style;
using SimpleEditor.Common;
using SimpleEditor.Controllers;
using SimpleEditor.Controls;

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
            _selectionController.SelectedFigureChanged += BuildInterface;
            _selectionController.SelectedTransformChanging += UpdateInterface;
            _selectionController.SelectedTransformChanged += UpdateInterface;
            _selectionController.SelectedRangeChanging += _selectionController_SelectedRangeChanging;
            _selectionController.EditorModeChanged += _ => UpdateInterface();
            _selectionController.LayerStartChanging += () => OnLayerStartChanging(_selectionController.EditorMode.ToString());
            _selectionController.LayerChanged += OnLayerChanged;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BuildInterface();
        }

        void OnLayerChanged()
        {
            _undoRedoController.OnFinishOperation();
            UpdateCanvasSize();
        }

        void OnLayerStartChanging(string opName)
        {
            _undoRedoController.OnStartOperation(opName);
        }

        void BuildInterface()
        {
            //build tools
            foreach (var editor in pnTools.Controls.OfType<IEditor<Selection>>()) //get editors of figure
                editor.Build(_selectionController.Selection);

            //
            UpdateInterface();
        }

        private void UpdateInterface()
        {
            tsbUndo.Enabled = tsmUndo.Enabled = UndoRedoManager.Instance.CanUndo;
            tsbRedo.Enabled = tsmRedo.Enabled = UndoRedoManager.Instance.CanRedo;
            tsslEditorMode.Text = string.Format("Mode: {0}", _selectionController.EditorMode);
            tsFigures.Enabled = _selectionController.EditorMode == EditorMode.Select;
            var exists = _selectionController.Selection.ForAll(f => f.Geometry as PrimitiveGeometry != null);
            tsddbGeometySwitcher.Enabled = exists;
            tsddbFillBrushSwitcher.Enabled = _selectionController.Selection.Count > 0;

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
            var bmp = new Bitmap(pbCanvas.Width, pbCanvas.Height);
            using (var graphics = Graphics.FromImage(bmp))
            {
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphics.Clear(Color.WhiteSmoke);
                // отрисовка созданных фигур
                foreach (var fig in _layer.Figures)
                    fig.Renderer.Render(graphics, fig);
                // отрисовка выделения
                _selectionController.Selection.Renderer.Render(graphics,
                                                               _selectionController.Selection);
                // отрисовка маркеров
                foreach (var marker in _selectionController.Markers)
                    marker.Renderer.Render(graphics, marker);
            }
            e.Graphics.DrawImage(bmp, Point.Empty);
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
            else if (tsbRegular4.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    new FigureBuilder().BuildRegularGeometry(fig, 4);
                    return fig;
                };
            else if (tsbRegular8.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    new FigureBuilder().BuildRegularGeometry(fig, 8);
                    return fig;
                };
            else if (tsbText.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    //new FigureBuilder().BuildTextGeometry(fig, "Текст");
                    new FigureBuilder().BuildTextRenderGeometry(fig, "Это длинный предлинный текст");
                    return fig;
                };
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

        private void pnStyle_StartChanging(object sender, ChangingEventArgs e)
        {
            OnLayerStartChanging(e.ChangingName);
        }

        private void pnStyle_Changed(object sender, EventArgs e)
        {
            OnLayerChanged();
            UpdateInterface();
        }

        private ToolStripMenuItem _switchGeometry;

        private void tsddbGeometySwitcher_ButtonClick(object sender, EventArgs e)
        {
            if (_switchGeometry == null)
                tsddbGeometySwitcher.ShowDropDown();
            else
                ChangePrimitiveGeometry(_switchGeometry);
        }

        private void tsmiPrimitiveGeometry_Click(object sender, EventArgs e)
        {
            _switchGeometry = (ToolStripMenuItem) sender;
            ChangePrimitiveGeometry(_switchGeometry);
        }

        private void ChangePrimitiveGeometry(ToolStripItem sender)
        {
            var exists = _selectionController.Selection.ForAll(f => f.Geometry as PrimitiveGeometry != null);
            if (!exists) return;
            tsddbGeometySwitcher.Text = @"Geometry: " + sender.Text;
            var primitives = _selectionController.Selection.Where(f => f.Geometry is PrimitiveGeometry).ToList();
            var builder = new FigureBuilder();
            if (sender.Tag != null)
            {
                var vertexCount = int.Parse(sender.Tag.ToString());
                OnLayerStartChanging("Change to Regular Geometry");
                foreach (var figure in primitives)
                    builder.BuildRegularGeometry(figure, vertexCount);
                OnLayerChanged();
            }
            else if (sender == tsmiCyrcle)
            {
                OnLayerStartChanging("Change to Cyrcle Geometry");
                foreach (var figure in primitives)
                    builder.BuildCircleGeometry(figure);
                OnLayerChanged();
            }
            else if (sender == tsmiEllipse)
            {
                OnLayerStartChanging("Change to Ellipse Geometry");
                foreach (var figure in primitives)
                    builder.BuildEllipseGeometry(figure);
                OnLayerChanged();
            }
            else if (sender == tsmiRectangle)
            {
                OnLayerStartChanging("Change to Rectangle Geometry");
                foreach (var figure in primitives)
                    builder.BuildRectangleGeometry(figure);
                OnLayerChanged();
            }
            else if (sender == tsmiSquare)
            {
                OnLayerStartChanging("Change to Square Geometry");
                foreach (var figure in primitives)
                    builder.BuildSquareGeometry(figure);
                OnLayerChanged();
            }
            _selectionController.UpdateMarkers();
            BuildInterface();
        }

        private void UpdateCanvasSize()
        {
            if (_layer == null) return;
            var size = new SizeF();
            foreach (var figrect in _layer.Figures.Select(figure => 
                figure.GetTransformedPath().Path.GetBounds()))
            {
                if (size.Width < figrect.Right) size.Width = figrect.Right;
                if (size.Height < figrect.Bottom) size.Height = figrect.Bottom;
            }
            pbCanvas.Size = Size.Ceiling(size);
            var panelSize = panelForScroll.ClientSize;
            if (pbCanvas.Width < panelSize.Width) pbCanvas.Width = panelSize.Width;
            if (pbCanvas.Height < panelSize.Height) pbCanvas.Height = panelSize.Height;
        }

        private void panelForScroll_SizeChanged(object sender, EventArgs e)
        {
            UpdateCanvasSize();
        }

        private ToolStripMenuItem _switchBrush;

        private void tsmiSolidBrush_Click(object sender, EventArgs e)
        {
            _switchBrush = (ToolStripMenuItem)sender;
            ChangeFillBrush(_switchBrush);
        }

        private void tsmiLinearGradientBrush_Click(object sender, EventArgs e)
        {
            _switchBrush = (ToolStripMenuItem)sender;
            ChangeFillBrush(_switchBrush);
        }

        private void tsddbFillBrushSwitcher_Click(object sender, EventArgs e)
        {
            if (_switchBrush == null)
                tsddbFillBrushSwitcher.ShowDropDown();
            else
                ChangeFillBrush(_switchBrush);
        }

        private void ChangeFillBrush(ToolStripItem sender)
        {
            var exists = _selectionController.Selection.Count > 0;
            if (!exists) return;
            var list = new List<Figure>();
            tsddbFillBrushSwitcher.Text = @"Fill: " + sender.Text;
            var figures = _selectionController.Selection.ToList();
            if (sender == tsmiSolidBrush)
            {
                OnLayerStartChanging("Change Solid Fill Brush");
                foreach (var figure in figures)
                {
                    var fillStyle = figure.Style.FillStyle.DeepClone();
                    figure.Style.FillStyle = new Fill { Color = fillStyle.Color, IsVisible = fillStyle.IsVisible };
                    list.Add(figure);
                }
                OnLayerChanged();
            }
            else if (sender == tsmiLinearGradientBrush)
            {
                OnLayerStartChanging("Change Line Gradient Fill Brush");
                foreach (var figure in figures)
                {
                    var fillStyle = figure.Style.FillStyle.DeepClone();
                    if (fillStyle.GetType() != typeof(LineGradientFill))
                    figure.Style.FillStyle = new LineGradientFill
                        {
                            Color = fillStyle.Color, 
                            IsVisible = fillStyle.IsVisible,
                            GradientColor = fillStyle.Color
                        };
                    list.Add(figure);
                }
                OnLayerChanged();
            }
            _selectionController.UpdateMarkers();
            BuildInterface();
        }
    }
}
