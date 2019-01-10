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
using System.Text;
using EditorModel.Common;
using System.IO;

namespace SimpleEditor
{
    public partial class FormSimpleEditor : Form
    {
        readonly string _caption;
        readonly VersionInfo _versionInfo;

        Layer _layer;
        SelectionController _selectionController;
        UndoRedoController _undoRedoController;

        public FormSimpleEditor()
        {
            InitializeComponent();
            _versionInfo = new VersionInfo();
            _caption = string.Format("Simple Vector Graphics Editor (Ver {0:0.0})", 
                (decimal)_versionInfo.Version / 10);

            ConnectEditors();

            _layer = new Layer();
            ConnectMethods();

        }

        private void ConnectEditors()
        {
            pnTools.Controls.Clear();
            var editors = new [] 
            {
                typeof(LayerStyleEditor),
                typeof(FillStyleEditor),
                typeof(BorderStyleEditor),
                typeof(ShadowStyleEditor),
                typeof(GlowStyleEditor),
                typeof(GradientStyleEditor),
                typeof(HatchStyleEditor),
                typeof(TextureStyleEditor),
                typeof(PolygonStyleEditor),
                typeof(BezierStyleEditor),
                typeof(TextStyleEditor),
                typeof(TextBlockStyleEditor),
                typeof(ImageStyleEditor),
                typeof(GroupStyleEditor),
                typeof(WedgeStyleEditor),
            };
            foreach (var typeName in editors)
            {
                var uc = (UserControl)Activator.CreateInstance(typeName);
                var figEditor = uc as IEditor<Selection>;
                if (figEditor != null)
                {
                    figEditor.StartChanging += pnStyle_StartChanging;
                    figEditor.Changed += pnStyle_Changed;
                }
                var lyaerEditor = uc as IEditor<LayerSelectionInfo>;
                if (lyaerEditor != null)
                {
                    lyaerEditor.StartChanging += pnStyle_StartChanging;
                    lyaerEditor.Changed += pnStyle_Changed;
                }
                pnTools.Controls.Add(uc);
            }
        }

        private void ConnectMethods()
        {
            _undoRedoController = new UndoRedoController(_layer);
            _selectionController = new SelectionController(_layer);

            // подключение обработчиков событий для контроллера выбора
            _selectionController.SelectedFigureChanged += BuildInterface;
            _selectionController.SelectedTransformChanging += UpdateInterface;
            _selectionController.SelectedTransformChanged += UpdateInterface;
            _selectionController.SelectedRangeChanging += _selectionController_SelectedRangeChanging;
            _selectionController.EditorModeChanged += _ => UpdateInterface();
            _selectionController.LayerStartChanging += () => 
                                      OnLayerStartChanging(_selectionController.EditorMode.ToString());
            _selectionController.LayerChanged += OnLayerChanged;
            _selectionController.ResetFigureCreator += _selectionController_ResetCreateFigureSelector;
        }

        private void _selectionController_ResetCreateFigureSelector()
        {
            tsbArrow.Enabled = false;
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
            UpdateFiguresTree();
        }

        private void UpdateFiguresTree()
        {
            var first = _selectionController.Selection.FirstOrDefault();
            tvFigures.BeginUpdate();
            try
            {
                tvFigures.AfterSelect -= tvFigures_AfterSelect;
                tvFigures.Nodes.Clear();
                foreach (var fig in _layer.Figures.ToList().AsEnumerable().Reverse())
                {
                    var fignode = new FigureTreeNode(fig.Geometry.ToString()) { Figure = fig };
                    tvFigures.Nodes.Add(fignode);
                    if (fig == first)
                        tvFigures.SelectedNode = fignode;
                    var group = fig as GroupFigure;
                    if (group != null) ExpandGroup(group, fignode, first);
                }
            }
            finally
            {
                tvFigures.EndUpdate();
                tvFigures.AfterSelect += tvFigures_AfterSelect;
            }
        }

        private void ExpandGroup(GroupFigure group, FigureTreeNode node, Figure firstInSelected)
        {
            foreach (var fig in group.Figures.ToList().AsEnumerable().Reverse())
            {
                var fignode = new FigureTreeNode(fig.Geometry.ToString()) { Figure = fig, Group = group };
                node.Nodes.Add(fignode);
                if (fig == firstInSelected)
                    tvFigures.SelectedNode = fignode;
                var childgroup = fig as GroupFigure;
                if (childgroup != null) ExpandGroup(childgroup, fignode, firstInSelected);
            }
        }

        private void tvFigures_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _selectionController.Selection.Clear();
            if (e.Node != null)
            {
                var fignode = e.Node as FigureTreeNode;
                if (fignode == null) return;
                if (fignode.Group == null)
                {
                    _selectionController.Selection.Add(fignode.Figure);
                    _selectionController.UpdateMarkers();
                }
                else
                {
                    _selectionController.UpdateMarkers();
                    _selectionController.Selection.Add(fignode.Figure);
                }
                BuildInterface();
            }
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
            UpdateFiguresTree();
            UpdateInterface();
        }

        private void UpdateInterface()
        {
            tsbPolyline.Enabled = tsbRect.Enabled = tsbRomb.Enabled = 
                tsbText.Enabled = tsbPicture.Enabled = _selectionController.EditorMode == EditorMode.Select;

            tsbSelectMode.Checked = _selectionController.EditorMode == EditorMode.Select;
            tsbSkewMode.Checked = _selectionController.EditorMode == EditorMode.Skew;
            tsbVertexMode.Checked = _selectionController.EditorMode == EditorMode.Verticies;

            var changedUndo = FileChanged != UndoRedoManager.Instance.CanUndo;
            tsbUndo.Enabled = tsmUndo.Enabled = FileChanged = UndoRedoManager.Instance.CanUndo;
            var changedRedo = tsbRedo.Enabled != UndoRedoManager.Instance.CanRedo;
            tsbRedo.Enabled = tsmRedo.Enabled = UndoRedoManager.Instance.CanRedo;
            tsbSave.Enabled = tsmSave.Enabled = FileChanged;
            tsslEditorMode.Text = string.Format("Mode: {0}", _selectionController.EditorMode);
            var exists = _selectionController.Selection.ForAll(f => 
                                 f.Geometry is PrimitiveGeometry && f.Renderer is DefaultRenderer);
            tsddbGeometySwitcher.Enabled = exists;
            tsddbFillBrushSwitcher.Enabled = tsddbEffectSwitcher.Enabled =  tsbBringToFront.Enabled = tsbSendToBack.Enabled =
                 tsbFlipX.Enabled = tsbFlipY.Enabled = tsbRotate90Ccw.Enabled = tsbRotate90Cw.Enabled = tsbRotate180.Enabled =
                    tsbCopy.Enabled = tsmCopy.Enabled = tsbCut.Enabled = tsmCut.Enabled = _selectionController.Selection.Count > 0;

            tsbGroup.Enabled = tsbAlignLeft.Enabled = tsbAlignCenter.Enabled = tsbAlignRight.Enabled =
                 tsbAlignTop.Enabled = tsbAlignMiddle.Enabled = tsbAlignBottom.Enabled = _selectionController.Selection.Count > 1;
            tsbEvenHorizontalSpaces.Enabled = tsbEvenVerticalSpaces.Enabled = _selectionController.Selection.Count > 2;
            tsbUngroup.Enabled = _selectionController.Selection.OfType<GroupFigure>().Any();

            tsbSameWidth.Enabled = tsbSameHeight.Enabled = tsbSameBothSizes.Enabled =
                         _selectionController.Selection.Count(SelectionHelper.IsNotSkewAndRotated) > 1;

            tsbConvertToPath.Enabled = _selectionController.Selection.Count(fig => 
                        fig.Geometry.AllowedOperations.HasFlag(AllowedOperations.Pathed)) > 0;

            if (changedUndo || changedRedo)
                UpdateFiguresTree();

            try
            {
                cbScaleFactor.SelectedIndexChanged -= cbScaleFactor_SelectedIndexChanged;
                cbScaleFactor.Text = string.Format("{0}%", _selectionController.ScaleFactor * 100);
            }
            finally
            {
                cbScaleFactor.SelectedIndexChanged += cbScaleFactor_SelectedIndexChanged;
            }

            pbCanvas.Invalidate();
        }

        private void timerCheckClipboard_Tick(object sender, EventArgs e)
        {
            tsbPaste.Enabled = tsmPaste.Enabled = tsmiPaste.Enabled = _selectionController.CanPasteFromClipboard;
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
                    angle = Helper.GetAngle(figure.Transform);
                    var size = Helper.GetSize(figure.Transform);
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
            _selectionController.OnMouseMove(e.Location, ModifierKeys);
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

            var scaleFactor = _selectionController.ScaleFactor;
            graphics.ScaleTransform(scaleFactor, scaleFactor);

            if (_layer.FillStyle.IsVisible)
                using (var brush = _layer.FillStyle.GetBrush(null))
                    graphics.FillRectangle(brush, pbCanvas.ClientRectangle);

            // отрисовка созданных фигур
            foreach (var fig in _layer.Figures)
            {
                fig.Renderer.Render(graphics, fig);
            }

            // отрисовка выделения
            _selectionController.Selection.Renderer.Render(graphics,
                                                           _selectionController.Selection);
            // отрисовка маркеров
            foreach (var marker in _selectionController.Markers)
            {
                marker.Transform.Matrix.Scale(1 / scaleFactor, 1 / scaleFactor);
                marker.Renderer.Render(graphics, marker);
                marker.Transform.Matrix.Scale(scaleFactor, scaleFactor);
            }
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
            Cursor figureCreatorCursor = CursorFactory.GetCursor(UserCursor.SelectByRibbonRect);
            if (sender == tsbArrow)
            {
                figureCreatorCursor = Cursors.Default;
                Cursor = Cursors.Default;
                tsbArrow.Enabled = false;

                _selectionController.CreateFigureCursor = figureCreatorCursor;
                _selectionController.CreateFigureRequest = figureCreator;
                return;
            }
            tsbArrow.Enabled = true;
            if (sender == tsbPolyline || sender == btnPolyline)
            {
                figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreatePolyline);
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildPolyGeometry(fig, false);
                    return fig;
                };
            }
            else if (sender == btnBezier)
            {
                figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreatePolyline);
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildBezierGeometry(fig, new PointF[] { }, new byte[] { });
                    return fig;
                };
            }
            else if (sender == btnRectangle || sender == tsbRect)
            {
                figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreateRect);
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildRectangleGeometry(fig);
                    return fig;
                };
            }
            else if (sender == btnSquare)
            {
                figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreateSquare);
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildSquareGeometry(fig);
                    return fig;
                };
            }
            else if (sender == btnEllipse)
            {
                figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreateEllipse);
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildEllipseGeometry(fig);
                    return fig;
                };
            }
            else if (sender == btnCircle)
            {
                figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreateCircle);
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildCircleGeometry(fig);
                    return fig;
                };
            }
            else if (sender == btnArc)
            {
                figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreateCircle);
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildWedgeGeometry(fig, WedgeKind.Arc);
                    return fig;
                };
            }
            else if (sender == btnSegment)
            {
                figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreateCircle);
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildWedgeGeometry(fig, WedgeKind.Chord);
                    return fig;
                };
            }
            else if (sender == btnPie)
            {
                figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreateCircle);
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildWedgeGeometry(fig, WedgeKind.Pie);
                    return fig;
                };
            }
            else if (sender == tsbRomb || sender == btnRegular4)
            {
                figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreateRect);
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildRegularGeometry(fig, 4);
                    return fig;
                };
            }
            else if (sender == tsbText || sender == btnTextBlock)
            {
                figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreateBlockText);
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildTextRenderGeometry(fig, "TextBlock");
                    return fig;
                };
            }
            else if (sender == btnText)
            {
                figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreateText);
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildTextGeometry(fig, "Text");
                    return fig;
                };
            }
            else if (sender == btnTextOnBezier)
            {
                figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreateBlockText);
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildBezierTextGeometry(fig, "The quick brown fox jumps over the lazy dog.");
                    return fig;
                };
            }
            else if (sender == tsbPicture || sender == btnInsertImage)
            {
                figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreateImage);
                figureCreator = () =>
                {
                    var fig = new Figure();
                    FigureBuilder.BuildImageRenderGeometry(fig, null);
                    return fig;
                };
            }
            else if (sender == btnLoadGroup)
            {
                figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreatePicture);
                figureCreator = () =>
                {
                    var fig = new GroupFigure();
                    return fig;
                };
            }
            else if (sender is ToolStripMenuItem)
            {
                var name = (sender as ToolStripMenuItem).Text;
                if (name.StartsWith("Regular"))
                {
                    figureCreatorCursor = Cursor = CursorFactory.GetCursor(UserCursor.CreateRect);
                    var number = int.Parse(name.Substring(7));
                    figureCreator = () =>
                    {
                        var fig = new Figure();
                        FigureBuilder.BuildRegularGeometry(fig, number);
                        return fig;
                    };
                }
            }

            _selectionController.CreateFigureCursor = figureCreatorCursor;
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
            var primitives = _selectionController.Selection.Where(f => 
                                f.Geometry is PrimitiveGeometry && f.Renderer is DefaultRenderer).ToList();
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
            UpdateFiguresTree();
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

            var sf = _selectionController.ScaleFactor;
            size = new Size((int)(size.Width * sf), (int)(size.Height * sf));

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
            tsddbFillBrushSwitcher.Text = @"Fill: " + sender.Text;
            var figures = _selectionController.Selection.ToList();
            if (sender == tsmiSolidBrush)
            {
                var decoratorsExists = figures.Count(figure =>
                    FillDecorator.ContainsAnyDecorator(figure.Style.FillStyle)) > 0;
                if (decoratorsExists)
                {
                    OnLayerStartChanging("Reset Figure Fill");
                    foreach (var figure in figures)
                    {
                        if (figure.Style.FillStyle == null) continue;
                        figure.Style.FillStyle = FillDecorator.GetBaseFill(figure.Style.FillStyle);
                    }
                    OnLayerChanged();
                }
            }
            else if (sender == tsmiLinearGradientBrush)
            {
                if (FillDecorator.ExistsWithoutThisDecorator(figures, typeof(LinearGradientFill)))
                {
                    OnLayerStartChanging("Change Line Gradient Fill Brush");
                    foreach (var figure in FillDecorator.WhereContainsDecorator(figures, typeof(LinearGradientFill)))
                    {
                        if (figure.Style.FillStyle == null) continue;
                        if (figure.Style.FillStyle.AllowedDecorators.HasFlag(AllowedFillDecorators.LinearGradient))
                            figure.Style.FillStyle = new LinearGradientFill(figure.Style.FillStyle);
                        else
                        {
                            var baseFill = FillDecorator.GetBaseFill(figure.Style.FillStyle);
                            if (baseFill.AllowedDecorators.HasFlag(AllowedFillDecorators.LinearGradient))
                                figure.Style.FillStyle = new LinearGradientFill(FillDecorator.GetBaseFill(figure.Style.FillStyle));
                        }
                    }
                    OnLayerChanged();
                }
            }
            else if (sender == tsmiRadialGradientBrush)
            {
                if (FillDecorator.ExistsWithoutThisDecorator(figures, typeof(RadialGradientFill)))
                {
                    OnLayerStartChanging("Change Radial Gradient Fill Brush");
                    foreach (var figure in FillDecorator.WhereContainsDecorator(figures, typeof(RadialGradientFill)))
                    {
                        if (figure.Style.FillStyle == null) continue;
                        if (figure.Style.FillStyle.AllowedDecorators.HasFlag(AllowedFillDecorators.RadialGradient))
                            figure.Style.FillStyle = new RadialGradientFill(figure.Style.FillStyle);
                        else
                        {
                            var baseFill = FillDecorator.GetBaseFill(figure.Style.FillStyle);
                            if (baseFill.AllowedDecorators.HasFlag(AllowedFillDecorators.RadialGradient))
                                figure.Style.FillStyle = new RadialGradientFill(FillDecorator.GetBaseFill(figure.Style.FillStyle));
                        }
                    }
                    OnLayerChanged();
                }
            }
            else if (sender == tsmiHatchBrush)
            {
                if (FillDecorator.ExistsWithoutThisDecorator(figures, typeof(HatchFill)))
                {
                    OnLayerStartChanging("Change Hatch Fill Brush");
                    foreach (var figure in FillDecorator.WhereContainsDecorator(figures, typeof(HatchFill)))
                    {
                        if (figure.Style.FillStyle == null) continue;
                        if (figure.Style.FillStyle.AllowedDecorators.HasFlag(AllowedFillDecorators.Hatch))
                            figure.Style.FillStyle = new HatchFill(figure.Style.FillStyle);
                        else
                        {
                            var baseFill = FillDecorator.GetBaseFill(figure.Style.FillStyle);
                            if (baseFill.AllowedDecorators.HasFlag(AllowedFillDecorators.Hatch))
                                figure.Style.FillStyle = new HatchFill(FillDecorator.GetBaseFill(figure.Style.FillStyle));
                        }
                    }
                    OnLayerChanged();
                }
            }
            else if (sender == tsmiTextureBrush)
            {
                if (FillDecorator.ExistsWithoutThisDecorator(figures, typeof(TextureFill)))
                {
                    OnLayerStartChanging("Change Texture Fill Brush");
                    foreach (var figure in FillDecorator.WhereContainsDecorator(figures, typeof(TextureFill)))
                    {
                        if (figure.Style.FillStyle == null) continue;
                        if (figure.Style.FillStyle.AllowedDecorators.HasFlag(AllowedFillDecorators.Texture))
                            figure.Style.FillStyle = new TextureFill(figure.Style.FillStyle);
                        else
                        {
                            var baseFill = FillDecorator.GetBaseFill(figure.Style.FillStyle);
                            if (baseFill.AllowedDecorators.HasFlag(AllowedFillDecorators.Texture))
                                figure.Style.FillStyle = new TextureFill(FillDecorator.GetBaseFill(figure.Style.FillStyle));
                        }
                    }
                    OnLayerChanged();
                }
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
                        figure.Renderer = RendererDecorator.GetBaseRenderer(figure.Renderer);
                    OnLayerChanged();
                }
            }
            else if (sender == tsmiShadow)
            {
                if (RendererDecorator.ExistsWithoutThisDecorator(figures, typeof(ShadowRendererDecorator)))
                {
                    OnLayerStartChanging("Shadow Figure Effect");
                    foreach (var figure in RendererDecorator.WhereContainsDecorator(figures, typeof(ShadowRendererDecorator)))
                    {
                        if (figure.Renderer.AllowedDecorators.HasFlag(AllowedRendererDecorators.Shadow))
                            figure.Renderer = new ShadowRendererDecorator(figure.Renderer);
                    }
                    OnLayerChanged();
                }
            }
            else if (sender == tsmiGlow)
            {
                if (RendererDecorator.ExistsWithoutThisDecorator(figures, typeof(GlowRendererDecorator)))
                {
                    OnLayerStartChanging("Glow Figure Effect");
                    foreach (var figure in RendererDecorator.WhereContainsDecorator(figures, typeof(GlowRendererDecorator)))
                    {
                        if (figure.Renderer.AllowedDecorators.HasFlag(AllowedRendererDecorators.Glow))
                            figure.Renderer = new GlowRendererDecorator(figure.Renderer);
                    }
                    OnLayerChanged();
                }
            }
            else if (sender == tsmiTextBlock)
            {
                if (!figures.Any(f => f.Geometry is TextGeometry) &&
                    RendererDecorator.ExistsWithoutThisDecorator(figures, typeof(TextBlockDecorator)))
                {
                    OnLayerStartChanging("Block Text Figure Effect");
                    foreach (var figure in RendererDecorator.WhereContainsDecorator(figures, typeof(TextBlockDecorator)))
                    {
                        if (figure.Renderer.AllowedDecorators.HasFlag(AllowedRendererDecorators.TextBlock))
                            figure.Renderer = new TextBlockDecorator(figure.Renderer, "Text Block", new Padding(10));
                    }
                    OnLayerChanged();
                }
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
        private void tsmDuplicateFigure_Click(object sender, EventArgs e)
        {
            var exists = _selectionController.Selection.Count > 0;
            if (!exists) return;
            OnLayerStartChanging("Duplicate Selected Figures");
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
                _fileName = saveEditorFileDialog.FileName;
            }
            SaverLoader.SaveToFile(_fileName, _layer);
            UndoRedoManager.Instance.ClearHistory();
            Text = _caption + @" - " + _fileName;
            BuildInterface();
        }

        private void tsmSaveAs_Click(object sender, EventArgs e)
        {
            if (saveEditorFileDialog.ShowDialog(this) != DialogResult.OK) return;
            switch (saveEditorFileDialog.FilterIndex)
            {
                case 1:
                    _fileName = saveEditorFileDialog.FileName;
                    SaverLoader.SaveToFile(_fileName, _layer);
                    UndoRedoManager.Instance.ClearHistory();
                    Text = _caption + @" - " + _fileName;
                    BuildInterface();
                    break;
                case 2:
                    ExportImport.ExportToSvg(saveEditorFileDialog.FileName, _layer);
                    break;
                default:
                    ExportImport.SaveToImage(saveEditorFileDialog.FileName, _layer);
                    break;
            }
        }

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            if (FileChanged)
            {
                var result = MessageBox.Show(this, @"В документе есть несохранённые данные." + Environment.NewLine +
                    @"Желаете их сохранить?", @"Открытие другого документа",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.Yes)
                    tsmSave.PerformClick();
            }
            if (openEditorFileDialog.ShowDialog(this) != DialogResult.OK) return;
            CreateNew();
            _fileName = openEditorFileDialog.FileName;
            _layer = SaverLoader.LoadFromFile(_fileName);
            ConnectMethods();
            Text = _caption + @" - " + _fileName;
            UndoRedoManager.Instance.ClearHistory();
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
            _layer.FillStyle = new DefaultFill { IsVisible = false };
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
            var result = MessageBox.Show(this, @"В документе есть несохранённые данные." + Environment.NewLine +
                @"Желаете их сохранить?", @"Завершение работы приложения",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
            if (result == DialogResult.Yes)
                tsmSave.PerformClick();
            else if (result == DialogResult.Cancel)
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

        private void tsbConvertToPath_Click(object sender, EventArgs e)
        {
            _selectionController.ConvertToPath();
            UpdateFiguresTree();
            UpdateInterface();
        }

        private void tsmPaste_Click(object sender, EventArgs e)
        {
            if (!_selectionController.CanPasteFromClipboard) return;
            _selectionController.PasteFromClipboardAndSelected();
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            _selectionController.CopySelectedToClipboard();
        }

        private void tsbCut_Click(object sender, EventArgs e)
        {
            _selectionController.CutSelectedToClipboard();
        }

        /// <summary>
        /// Проверка возможности вставки файла
        /// можно вставить только один файл перечисленных расширений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelForScroll_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                var allowed = new[] { ".png", ".bmp", ".jpg", ".jpeg", ".gif" };
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1 && allowed.Contains(Path.GetExtension(files[0]).ToLower()))
                    e.Effect = DragDropEffects.All;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Вставка графического файла в поле редактора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelForScroll_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length != 1) return;
            var figure = new Figure();
            var image = (Bitmap)Image.FromFile(files[0]);
            FigureBuilder.BuildImageRenderGeometry(figure, image);
            var point = panelForScroll.PointToClient(new Point(e.X, e.Y));
            var width = image.Width;
            var height = image.Height;
            var m = new Matrix();
            m.Translate(point.X + width / 2f, point.Y + height / 2f);
            m.Scale(width, height);
            figure.Transform.Matrix = m;
            OnLayerStartChanging("Insert Image By File Drag&Drop");
            _layer.Figures.Add(figure);
            OnLayerChanged();
            _selectionController.Clear();
            _selectionController.Selection.Add(figure);
            _selectionController.UpdateMarkers();
            UpdateInterface();
        }

        private void cbScaleFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pst = float.Parse(cbScaleFactor.Text.TrimEnd('%'));
            _selectionController.Clear();
            _selectionController.ScaleFactor = pst / 100f;
            UpdateCanvasSize();
            UpdateInterface();
        }
    }
}
