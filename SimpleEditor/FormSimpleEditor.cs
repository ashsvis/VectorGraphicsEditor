using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using EditorModel.Figures;
using System.Windows.Forms;
using EditorModel.Geometry;
using EditorModel.Renderers;
using EditorModel.Selections;
using EditorModel.Style;
using SimpleEditor.Common;
using SimpleEditor.Controllers;
using SimpleEditor.Controls;
using System.IO;
using System.Text;

namespace SimpleEditor
{
    public partial class FormSimpleEditor : Form
    {
        readonly string _caption;
        readonly VersionInfo _versionInfo;

        readonly Layer _layer;
        readonly SelectionController _selectionController;
        readonly UndoRedoController _undoRedoController;

        public FormSimpleEditor()
        {
            InitializeComponent();
            _versionInfo = Helper.GetVersionInfo();
            _caption = string.Format("Simple Vector Graphics Editor (Ver 0.{0})", _versionInfo.Version);

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
            _selectionController.ResetFigureCreator += _selectionController_ResetCreateFigureSelector;
        }

        private void _selectionController_ResetCreateFigureSelector()
        {
            //stub
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
            foreach (var editor in pnTools.Controls.OfType <IEditor<LayerSelectionInfo>>()) //get editors of layer
                editor.Build(new LayerSelectionInfo { Layer = _layer, Selection = _selectionController.Selection });

            foreach (var editor in pnTools.Controls.OfType<IEditor<Selection>>()) //get editors of figure
                editor.Build(_selectionController.Selection);

            //
            UpdateInterface();
        }

        private void UpdateInterface()
        {
            tsbSelectMode.Checked = _selectionController.EditorMode == EditorMode.Select;
            tsbSkewMode.Checked = _selectionController.EditorMode == EditorMode.Skew;
            tsbVertexMode.Checked = _selectionController.EditorMode == EditorMode.Verticies;

            tsbUndo.Enabled = tsmUndo.Enabled = FileChanged = UndoRedoManager.Instance.CanUndo;
            tsbRedo.Enabled = tsmRedo.Enabled = UndoRedoManager.Instance.CanRedo;
            tsbSave.Enabled = tsmSave.Enabled = FileChanged;
            tsslEditorMode.Text = string.Format("Mode: {0}", _selectionController.EditorMode);
            var exists = _selectionController.Selection.ForAll(f => f.Geometry as PrimitiveGeometry != null);
            tsddbGeometySwitcher.Enabled = exists;
            tsddbFillBrushSwitcher.Enabled = tsddbEffectSwitcher.Enabled =
                                             tsbBringToFront.Enabled = tsbSendToBack.Enabled =
                                                                       tsbFlipX.Enabled =
                                                                       tsbFlipY.Enabled =
                                                                       tsbRotate90Ccw.Enabled = tsbRotate90Cw.Enabled =
                                                                                                tsbRotate180.Enabled =
                                                                                                _selectionController
                                                                                                    .Selection.Count > 0;

            tsbGroup.Enabled = tsbAlignLeft.Enabled = tsbAlignCenter.Enabled = tsbAlignRight.Enabled =
                                                                               tsbAlignTop.Enabled =
                                                                               tsbAlignMiddle.Enabled =
                                                                               tsbAlignBottom.Enabled =
                                                                               _selectionController.Selection.Count > 1;
            tsbEvenHorizontalSpaces.Enabled = tsbEvenVerticalSpaces.Enabled = _selectionController.Selection.Count > 2;
            tsbUngroup.Enabled = _selectionController.Selection.OfType<GroupFigure>().Any();

            tsbSameWidth.Enabled = tsbSameHeight.Enabled = tsbSameBothSizes.Enabled =
                                                           _selectionController.Selection.Count(
                                                               SelectionHelper.IsNotSkewAndRotated) > 1;

            pbCanvas.Invalidate();
        }

        private void _selectionController_SelectedRangeChanging(Rectangle rect, float angle)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Area: {0}", rect);
            if (Math.Abs(angle - 0) > float.Epsilon)
                sb.AppendFormat(" Rotate at: {0:0.0}°", angle);
            if (_selectionController.EditorMode == EditorMode.Drag &&
                _selectionController.Selection.Count > 0)
            {
                var figure = _selectionController.Selection.FirstOrDefault();
                if (figure != null)
                {
                    angle = EditorModel.Common.Helper.GetAngle(figure.Transform);
                    var size = EditorModel.Common.Helper.GetSize(figure.Transform);
                    sb.AppendFormat(" Figure: size {0}, rotated at {1:0.0}°", size, angle);
                }
            }

            tsslRibbonRect.Text = sb.ToString();
            UpdateInterface();
        }

        /// <summary>
        /// Нажали мышкой на канве для рисования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (e.Clicks == 2)
                _selectionController.OnDblClick(e.Location, ModifierKeys);
            else
                _selectionController.OnMouseDown(e.Location, ModifierKeys);
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
                _selectionController.OnMouseUp(e.Location, ModifierKeys);
        }

        /// <summary>
        /// Рисовальщик содержимого слоя, выделения и маркеров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            if (_layer.FillStyle.IsVisible)
                using (var brush = _layer.FillStyle.GetBrush(null))
                    graphics.FillRectangle(brush, pbCanvas.ClientRectangle);

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

        /// <summary>
        /// Выбор фигур для последующего создания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateFigure_Click(object sender, EventArgs e)
        {
            _selectionController.Clear();
            Func<Figure> figureCreator = null;

            if (sender == tsbPolyline || sender == btnPolyline)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildPolylineGeometry(fig);
                    return fig;
                };
            else if (sender == btnPolygone)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildPolygoneGeometry(fig);
                    return fig;
                };
            else if (sender == btnRectangle || sender == tsbRect)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildRectangleGeometry(fig);
                    return fig;
                };
            else if (sender == btnSquare)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildSquareGeometry(fig);
                    return fig;
                };
            else if (sender == btnEllipse)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildEllipseGeometry(fig);
                    return fig;
                };
            else if (sender == btnCircle)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildCircleGeometry(fig);
                    return fig;
                };
            else if (sender == tsbRomb || sender == btnRegular4)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildRegularGeometry(fig, 4);
                    return fig;
                };
            else if (sender == tsbText || sender == btnTextBlock)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildTextRenderGeometry(fig, "Текст");
                    return fig;
                };
            else if (sender == btnTextLine)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildTextGeometry(fig, "Текст");
                    return fig;
                };
            else if (sender == tsbPicture || sender == btnInsertImage)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildImageRenderGeometry(fig, null);
                    return fig;
                };
            else if (sender == btnInsertPicture)
                figureCreator = () =>
                {
                    var placeHolder = new Figure();
                    placeHolder.Style.FillStyle.IsVisible = false;
                    placeHolder.Style.BorderStyle.DashStyle = DashStyle.Dash;
                    FigureBuilder.BuildRectangleGeometry(placeHolder);
                    var fig = new GroupFigure(new[] { placeHolder })
                        {
                            Renderer = new GroupRenderer()
                        };
                    return fig;
                };
            else if (sender is ToolStripMenuItem)
            {
                var name = (sender as ToolStripMenuItem).Text;
                if (name.StartsWith("Regular"))
                {
                    var number = int.Parse(name.Substring(7));
                    figureCreator = () =>
                    {
                        var fig = new Figure();
                        FigureBuilder.BuildRegularGeometry(fig, number);
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
            //stub
        }

        /// <summary>
        /// Происходит перед показом главного меню, отмечается текщий базовый режим 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmEditMenu_DropDownOpening(object sender, EventArgs e)
        {
            //stub
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
            _selectionController.UpdateMarkers();
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
            if (sender.Tag != null)
            {
                var vertexCount = int.Parse(sender.Tag.ToString());
                OnLayerStartChanging("Change to Regular Geometry");
                foreach (var figure in primitives)
                    FigureBuilder.BuildRegularGeometry(figure, vertexCount);
                OnLayerChanged();
            }
            else if (sender == tsmiCyrcle)
            {
                OnLayerStartChanging("Change to Cyrcle Geometry");
                foreach (var figure in primitives)
                    FigureBuilder.BuildCircleGeometry(figure);
                OnLayerChanged();
            }
            else if (sender == tsmiEllipse)
            {
                OnLayerStartChanging("Change to Ellipse Geometry");
                foreach (var figure in primitives)
                    FigureBuilder.BuildEllipseGeometry(figure);
                OnLayerChanged();
            }
            else if (sender == tsmiRectangle)
            {
                OnLayerStartChanging("Change to Rectangle Geometry");
                foreach (var figure in primitives)
                    FigureBuilder.BuildRectangleGeometry(figure);
                OnLayerChanged();
            }
            else if (sender == tsmiSquare)
            {
                OnLayerStartChanging("Change to Square Geometry");
                foreach (var figure in primitives)
                    FigureBuilder.BuildSquareGeometry(figure);
                OnLayerChanged();
            }
            _selectionController.UpdateMarkers();
            BuildInterface();
        }

        /// <summary>
        /// Действия по корректировке размера холста по размеру содержимого слоя
        /// </summary>
        private void UpdateCanvasSize()
        {
            if (_layer == null) return;
            var size = new Size();
            foreach (var figrect in _layer.Figures.Select(figure => 
                figure.GetTransformedPath().Path.GetBounds()))
            {
                if (size.Width < figrect.Right) size.Width = (int)figrect.Right;
                if (size.Height < figrect.Bottom) size.Height = (int)figrect.Bottom;
            }

            // запас для скролирования. Что бы можно было тянуть маркеры.
            size.Width += 50;
            size.Height += 50;

            var pnlSize = panelForScroll.ClientSize;
            pbCanvas.Size = new Size(size.Width < pnlSize.Width ? pnlSize.Width : size.Width,
                                     size.Height < pnlSize.Height ? pnlSize.Height : size.Height);
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
                    if (figure.Style.FillStyle == null) continue;
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
                    if (figure.Style.FillStyle == null) continue;
                    var fillStyle = figure.Style.FillStyle.DeepClone();
                    if (fillStyle.GetType() != typeof(LinearGradientFill))
                    figure.Style.FillStyle = new LinearGradientFill
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

        private ToolStripMenuItem _effectRenderer;
        private string _fileName = string.Empty;

        private bool FileChanged { get; set; }

        private void tsmiNoneEffects_Click(object sender, EventArgs e)
        {
            _effectRenderer = (ToolStripMenuItem)sender;
            ChangeEffects(_effectRenderer);
        }

        private void ChangeEffects(ToolStripItem sender)
        {
            var exists = _selectionController.Selection.Count > 0;
            if (!exists) return;
            var list = new List<Figure>();
            tsddbEffectSwitcher.Text = @"Effect: " + sender.Text;
            var figures = _selectionController.Selection.ToList();
            if (sender == tsmiNoneEffects)
            {
                var decoratorsExists = figures.Count(figure => 
                    RendererDecorator.ContainsAnyDecorator(figure.Renderer)) > 0;
                if (decoratorsExists)
                {
                    OnLayerStartChanging("Reset Figure Effect");
                    foreach (var figure in figures)
                    {
                        figure.Renderer = RendererDecorator.GetBaseRenerer(figure.Renderer);
                        list.Add(figure);
                    }
                    OnLayerChanged();
                }
            }
            else if (sender == tsmiShadow)
            {
                if (ExistsWithoutThisDecorator(figures, typeof(ShadowRenderer)))
                {
                    OnLayerStartChanging("Shadow Figure Effect");
                    foreach (var figure in WhereContainsDecorator(figures, typeof(ShadowRenderer)))
                    {
                        if (figure.Renderer.AllowedDecorators.HasFlag(AllowedRendererDecorators.Shadow))
                            figure.Renderer = new ShadowRenderer(figure.Renderer);
                        list.Add(figure);
                    }
                    OnLayerChanged();
                }
            }
            else if (sender == tsmiGlow)
            {
                if (ExistsWithoutThisDecorator(figures, typeof(GlowRenderer)))
                {
                    OnLayerStartChanging("Glow Figure Effect");
                    foreach (var figure in WhereContainsDecorator(figures, typeof(GlowRenderer)))
                    {
                        if (figure.Renderer.AllowedDecorators.HasFlag(AllowedRendererDecorators.Glow))
                            figure.Renderer = new GlowRenderer(figure.Renderer);
                        list.Add(figure);
                    }
                    OnLayerChanged();
                }
            }
            _selectionController.UpdateMarkers();
            BuildInterface();
        }

        private static bool ExistsWithoutThisDecorator(IEnumerable<Figure> figures, Type type)
        {
            return figures.Count(figure => 
                                 !RendererDecorator.ContainsType(figure.Renderer, type)) > 0;
        }

        private static IEnumerable<Figure> WhereContainsDecorator(IEnumerable<Figure> figures, Type type)
        {
            return figures.Where(figure => 
                                 !RendererDecorator.ContainsType(figure.Renderer, type));
        }

        private void tsddbEffectSwitcher_ButtonClick(object sender, EventArgs e)
        {
            if (_effectRenderer == null)
                tsddbEffectSwitcher.ShowDropDown();
            else
                ChangeEffects(_effectRenderer);
        }

        /// <summary>
        /// Удаление выделенных фигур
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmDelete_Click(object sender, EventArgs e)
        {
            var exists = _selectionController.Selection.Count > 0;
            if (!exists) return;
            OnLayerStartChanging("Delete Selected Figures");
            foreach (var figure in _selectionController.Selection)
                _layer.Figures.Remove(figure);
            OnLayerChanged();
            _selectionController.Clear();
            BuildInterface();
        }

        /// <summary>
        /// Клонирование выделенных фигур
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmCloneFigure_Click(object sender, EventArgs e)
        {
            var exists = _selectionController.Selection.Count > 0;
            if (!exists) return;
            OnLayerStartChanging("Clone Selected Figures");
            var list = new List<Figure>();
            foreach (var fig in _selectionController.Selection.Select(figure => figure.DeepClone()))
            {
                fig.Transform.Matrix.Translate(10, 10, MatrixOrder.Append);
                list.Add(fig);
                _layer.Figures.Add(fig);
            }
            OnLayerChanged();
            _selectionController.Clear();
            foreach (var fig in list)
                _selectionController.Selection.Add(fig);
            _selectionController.UpdateMarkers();
            BuildInterface();
        }

        private void tsmSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_fileName))
            {
                if (saveEditorFileDialog.ShowDialog(this) != DialogResult.OK) return;
                SaveToFile(saveEditorFileDialog.FileName);
            }
            else
                SaveToFile(_fileName);
        }

        /// <summary>
        /// Метод записи всех фигур в слое в файл
        /// </summary>
        /// <param name="fileName"></param>
        private void SaveToFile(string fileName)
        {
            using (var stream = new MemoryStream())
            {
                Helper.SaveToStream(stream, _versionInfo);
                Helper.SaveToStream(stream, _layer.FillStyle);
                Helper.SaveToStream(stream, _layer.Figures);
                stream.Position = 0;
                Helper.Compress(stream, fileName);
            }
            _fileName = fileName;
            UndoRedoManager.Instance.ClearHistory();
            Text = _caption + @" - " + _fileName;
            BuildInterface();
        }

        /// <summary>
        /// Метод записи фигур из списка выделенных в файл
        /// </summary>
        /// <param name="fileName"></param>
        private void SaveSelection(string fileName)
        {
            if (_selectionController.Selection.Count == 0) return;
            var location = _selectionController.Selection.GetTransformedPath().Path.GetBounds().Location;
            _selectionController.Selection.Translate(-location.X, -location.Y);
            _selectionController.Selection.PushTransformToSelectedFigures();
            using (var stream = new MemoryStream())
            {
                Helper.SaveToStream(stream, _versionInfo);
                Helper.SaveToStream(stream, _selectionController.Selection.ToList());
                stream.Position = 0;
                Helper.Compress(stream, fileName);
            }
            _selectionController.Selection.Translate(location.X, location.Y);
            _selectionController.Selection.PushTransformToSelectedFigures();
        }

        private void tsmSaveAs_Click(object sender, EventArgs e)
        {
            if (saveEditorFileDialog.ShowDialog(this) != DialogResult.OK) return;
            switch (saveEditorFileDialog.FilterIndex)
            {
                case 1:
                    SaveToFile(saveEditorFileDialog.FileName);
                    break;
                case 2:
                    SaveSelection(saveEditorFileDialog.FileName);
                    break;
            }
        }

        private void LoadFromFile(string fileName)
        {
            using (var stream = new MemoryStream())
            {
                Helper.Decompress(fileName, stream);
                stream.Position = 0;
                var versionInfo = (VersionInfo)Helper.LoadFromStream(stream);
                if (versionInfo.Version != _versionInfo.Version)
                {
                    MessageBox.Show(this, @"Формат загружаемого файла не поддерживается.",
                                    @"Загрузка файла отменена",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _layer.FillStyle = (Fill)Helper.LoadFromStream(stream);
                var figures = (List<Figure>)Helper.LoadFromStream(stream);
                _layer.Figures = figures;
            }
            _fileName = fileName;
            Text = _caption + @" - " + _fileName;
            UndoRedoManager.Instance.ClearHistory();
            BuildInterface();
        }

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            if (FileChanged)
            {
                if (MessageBox.Show(this, @"Несохранённые данные будут потеряны." + Environment.NewLine + @"Открыть новый файл?",
                    @"Сохранение файла", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button3) != DialogResult.Yes) return;
            }
            if (openEditorFileDialog.ShowDialog(this) != DialogResult.OK) return;
            CreateNew();
            LoadFromFile(openEditorFileDialog.FileName);
            BuildInterface();
        }

        private void tsmCreate_Click(object sender, EventArgs e)
        {
            CreateNew();
        }

        private void CreateNew()
        {
            _fileName = string.Empty;
            FileChanged = false;
            Text = _caption;
            _selectionController.Clear();
            UndoRedoManager.Instance.ClearHistory();
            _layer.FillStyle = new Fill { IsVisible = false };
            _layer.Figures.Clear();
            BuildInterface();
        }

        private void FormSimpleEditor_Load(object sender, EventArgs e)
        {
            Text = _caption;
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormSimpleEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!FileChanged) return;
            if (MessageBox.Show(this, @"Несохранённые данные будут потеряны." + Environment.NewLine + @"Закрыть приложение?",
                                @"Завершение работы приложения", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button3) == DialogResult.Yes) return;
            e.Cancel = true;
        }

        private void tsbAlignLeft_Click(object sender, EventArgs e)
        {
            _selectionController.AlignHorizontal(FigureAlignment.Near);
            UpdateInterface();
        }

        private void tsbAlignCenter_Click(object sender, EventArgs e)
        {
            _selectionController.AlignHorizontal(FigureAlignment.Center);
            UpdateInterface();
        }

        private void tsbAlignRight_Click(object sender, EventArgs e)
        {
            _selectionController.AlignHorizontal(FigureAlignment.Far);
            UpdateInterface();
        }

        private void tsbAlignTop_Click(object sender, EventArgs e)
        {
            _selectionController.AlignVertical(FigureAlignment.Near);
            UpdateInterface();
        }

        private void tsbAlignMiddle_Click(object sender, EventArgs e)
        {
            _selectionController.AlignVertical(FigureAlignment.Center);
            UpdateInterface();
        }

        private void tsbAlignBottom_Click(object sender, EventArgs e)
        {
            _selectionController.AlignVertical(FigureAlignment.Far);
            UpdateInterface();
        }

        private void tsbSameBothSizes_Click(object sender, EventArgs e)
        {
            _selectionController.SameResize(FigureResize.Both);
            UpdateInterface();
        }

        private void tsbSameWidth_Click(object sender, EventArgs e)
        {
            _selectionController.SameResize(FigureResize.Width);
            UpdateInterface();
        }

        private void tsbSameHeight_Click(object sender, EventArgs e)
        {
            _selectionController.SameResize(FigureResize.Heigth);
            UpdateInterface();
        }

        private void tsbEvenHorizontalSpaces_Click(object sender, EventArgs e)
        {
            _selectionController.EvenSpaces(FigureArrange.Horizontal);
            UpdateInterface();
        }

        private void tsbEvenVerticalSpaces_Click(object sender, EventArgs e)
        {
            _selectionController.EvenSpaces(FigureArrange.Vertical);
            UpdateInterface();
        }

        private void ModeSelector_Click(object sender, EventArgs e)
        {
            if (sender == tsbSelectMode)
                _selectionController.EditorMode = EditorMode.Select;
            else if (sender == tsbSkewMode)
                _selectionController.EditorMode = EditorMode.Skew;
            else if (sender == tsbVertexMode)
                _selectionController.EditorMode = EditorMode.Verticies;
        }
    }
}
