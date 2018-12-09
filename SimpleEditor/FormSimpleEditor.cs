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

namespace SimpleEditor
{
    public partial class FormSimpleEditor : Form
    {
        string _caption;
        VersionInfo _versionInfo;

        Layer _layer;
        readonly SelectionController _selectionController;
        readonly UndoRedoController _undoRedoController;

        public FormSimpleEditor()
        {
            InitializeComponent();
            _versionInfo = new VersionInfo { Version = 1 };
            _caption = string.Format("Simple Vector Graphics Editor (ver 0.{0})", _versionInfo.Version);


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
            tsbArrow_Click(tsbArrow, new EventArgs());            
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
            tsbUndo.Enabled = tsmUndo.Enabled = FileChanged = UndoRedoManager.Instance.CanUndo;
            tsbRedo.Enabled = tsmRedo.Enabled = UndoRedoManager.Instance.CanRedo;
            tsbSave.Enabled = tsmSave.Enabled = FileChanged;
            tsslEditorMode.Text = string.Format("Mode: {0}", _selectionController.EditorMode);
            tsbImage.Enabled = _selectionController.EditorMode == EditorMode.Select;
            var exists = _selectionController.Selection.ForAll(f => f.Geometry as PrimitiveGeometry != null);
            tsddbGeometySwitcher.Enabled = exists;
            tsddbFillBrushSwitcher.Enabled = tsddbEffectSwitcher.Enabled =
                tsbBringToFront.Enabled = tsbSendToBack.Enabled =  _selectionController.Selection.Count > 0;

            tsbGroup.Enabled = _selectionController.Selection.Count > 1;
            tsbUngroup.Enabled = _selectionController.Selection.OfType<GroupFigure>().Count() > 0;


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
            var bmp = new Bitmap(pbCanvas.Width, pbCanvas.Height);
            using (var graphics = Graphics.FromImage(bmp))
            {
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                #region Предлагаю

                if (_layer.FillStyle.IsVisible)
                {
                    using (var brush = _layer.FillStyle.GetBrush(null))
                    {
                        graphics.FillRectangle(brush, pbCanvas.ClientRectangle);
                    }  
                }
                //graphics.Clear(Color.WhiteSmoke);

                #endregion

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
            foreach (var btn in tsbImage.Items.OfType<ToolStripButton>())
                btn.Checked = false;
            ((ToolStripButton)sender).Checked = true;

            if (!tsbArrow.Checked)
                _selectionController.Clear();

            Func<Figure> figureCreator = null;

            if (tsbPolyline.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildPolylineGeometry(fig);
                    return fig;
                };
            else if (tsbRect.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    if (ModifierKeys.HasFlag(Keys.Shift))
                        FigureBuilder.BuildSquareGeometry(fig);
                    else
                        FigureBuilder.BuildRectangleGeometry(fig);
                    return fig;
                };
            else if (tsbEllipse.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    if (ModifierKeys.HasFlag(Keys.Shift))
                        FigureBuilder.BuildCircleGeometry(fig);
                    else
                        FigureBuilder.BuildEllipseGeometry(fig);
                    return fig;
                };
            else if (tsbRegular4.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildRegularGeometry(fig, 4);
                    return fig;
                };
            else if (tsbRegular8.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildRegularGeometry(fig, 8);
                    return fig;
                };
            else if (tsbText.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    //new FigureBuilder().BuildTextGeometry(fig, "Текст");
                    FigureBuilder.BuildTextRenderGeometry(fig, "Текст");
                    return fig;
                };
            else if (tsbPicture.Checked)
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildImageRenderGeometry(fig, null);
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

        public bool FileChanged { get; private set; }

        private void tsmiNoneEffects_Click(object sender, EventArgs e)
        {
            _effectRenderer = (ToolStripMenuItem)sender;
            ChangeEffects(_effectRenderer);
        }

        private void tsmiShadow_Click(object sender, EventArgs e)
        {
            _effectRenderer = (ToolStripMenuItem)sender;
            ChangeEffects(_effectRenderer);
        }

        private void tsmiGlow_Click(object sender, EventArgs e)
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
                OnLayerStartChanging("Reset Figure Effect");
                foreach (var figure in figures.Where(f => 
                    f.Renderer.GetType() != typeof(Renderer)))
                {
                    figure.Renderer = new Renderer();
                    list.Add(figure);
                }
                OnLayerChanged();
            }
            else if (sender == tsmiShadow)
            {
                OnLayerStartChanging("Shadow Figure Effect");
                foreach (var figure in figures.Where(f => 
                    f.Renderer.GetType() != typeof(ShadowRenderer)))
                {
                    figure.Renderer = new ShadowRenderer();
                    list.Add(figure);
                }
                OnLayerChanged();
            }
            else if (sender == tsmiGlow)
            {
                OnLayerStartChanging("Glow Figure Effect");
                foreach (var figure in figures.Where(f =>
                    f.Renderer.GetType() != typeof(GlowRenderer)))
                {
                    figure.Renderer = new GlowRenderer();
                    list.Add(figure);
                }
                OnLayerChanged();
            }
            _selectionController.UpdateMarkers();
            BuildInterface();
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
            foreach (var figure in _selectionController.Selection)
            {
                var fig = figure.DeepClone();
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
        /// Метод записи фигур в файл
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveToFile(string fileName)
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
            Text = _caption + " - " + _fileName;
            BuildInterface();
        }

        private void tsmSaveAs_Click(object sender, EventArgs e)
        {
            if (saveEditorFileDialog.ShowDialog(this) != DialogResult.OK) return;
            SaveToFile(saveEditorFileDialog.FileName);
        }

        private void LoadFromFile(string fileName)
        {
            using (var stream = new MemoryStream())
            {
                Helper.Decompress(fileName, stream);
                stream.Position = 0;
                var versionInfo = (VersionInfo)Helper.LoadFromStream(stream);
                if (versionInfo.Version > _versionInfo.Version)
                {
                    MessageBox.Show(this, "Формат загружаемого файла не поддерживается.", "Загрузка файла отменена", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _layer.FillStyle = (Fill)Helper.LoadFromStream(stream);
                var figures = (List<Figure>)Helper.LoadFromStream(stream);
                _layer.Figures = figures;
            }
            _fileName = fileName;
            Text = _caption + " - " + _fileName;
            UndoRedoManager.Instance.ClearHistory();
            BuildInterface();
        }

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            if (FileChanged)
            {
                if (MessageBox.Show(this, "Несохранённые данные будут потеряны.\nОткрыть новый файл?",
                    "Сохранение файла", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
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
            if (FileChanged)
            {
                if (MessageBox.Show(this, "Несохранённые данные будут потеряны.\nЗакрыть приложение?",
                    "Завершение работы приложения", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }

        }
    }
}
