namespace SimpleEditor
{
    partial class FormSimpleEditor
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSimpleEditor));
            this.tsmSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.panelForScroll = new System.Windows.Forms.Panel();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.tsmFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.tsbRedo = new System.Windows.Forms.ToolStripButton();
            this.tsbEllipse = new System.Windows.Forms.ToolStripButton();
            this.tsbUndo = new System.Windows.Forms.ToolStripButton();
            this.tsbCircle = new System.Windows.Forms.ToolStripButton();
            this.tsbSquare = new System.Windows.Forms.ToolStripButton();
            this.tsbRect = new System.Windows.Forms.ToolStripButton();
            this.tsbPolygon = new System.Windows.Forms.ToolStripButton();
            this.tsbPolyline = new System.Windows.Forms.ToolStripButton();
            this.tsbArrow = new System.Windows.Forms.ToolStripButton();
            this.tsFigures = new System.Windows.Forms.ToolStrip();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripFile = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCut = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbHelp = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.miUngroupFigures = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.miFill = new System.Windows.Forms.ToolStripMenuItem();
            this.miStroke = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFigPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCutPopup = new System.Windows.Forms.ToolStripMenuItem();
            this.miCopyPopup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNodeSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.miBeginChangeNodes = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddFigureNode = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteFigureNode = new System.Windows.Forms.ToolStripMenuItem();
            this.miEndChangeNodes = new System.Windows.Forms.ToolStripMenuItem();
            this.miStrokeSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.miBringToFront = new System.Windows.Forms.ToolStripMenuItem();
            this.miSendToBack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTransformsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiTransforms = new System.Windows.Forms.ToolStripMenuItem();
            this.miTurnLeft90 = new System.Windows.Forms.ToolStripMenuItem();
            this.miTurnRight90 = new System.Windows.Forms.ToolStripMenuItem();
            this.miFlipVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.miFlipHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBkgPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miPasteFromBuffer = new System.Windows.Forms.ToolStripMenuItem();
            this.timerFormUpdate = new System.Windows.Forms.Timer(this.components);
            this.saveFiguresFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFiguresFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panelForScroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.tsFigures.SuspendLayout();
            this.toolStripFile.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.cmsFigPopup.SuspendLayout();
            this.cmsBkgPopup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmSelectAll
            // 
            this.tsmSelectAll.Enabled = false;
            this.tsmSelectAll.Name = "tsmSelectAll";
            this.tsmSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmSelectAll.Size = new System.Drawing.Size(209, 22);
            this.tsmSelectAll.Text = "Выделить &все";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // panelForScroll
            // 
            this.panelForScroll.AutoScroll = true;
            this.panelForScroll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForScroll.Controls.Add(this.pbCanvas);
            this.panelForScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForScroll.Location = new System.Drawing.Point(26, 52);
            this.panelForScroll.Name = "panelForScroll";
            this.panelForScroll.Size = new System.Drawing.Size(831, 434);
            this.panelForScroll.TabIndex = 7;
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pbCanvas.Location = new System.Drawing.Point(0, 0);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Padding = new System.Windows.Forms.Padding(4);
            this.pbCanvas.Size = new System.Drawing.Size(826, 428);
            this.pbCanvas.TabIndex = 6;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            this.pbCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseDown);
            this.pbCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseMove);
            this.pbCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseUp);
            // 
            // menuStripMain
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.menuStripMain, 2);
            this.menuStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFileMenu,
            this.tsmEditMenu});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(115, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // tsmFileMenu
            // 
            this.tsmFileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCreate,
            this.tsmOpen,
            this.toolStripSeparator,
            this.tsmSave,
            this.tsmSaveAs,
            this.toolStripSeparator1,
            this.tsmPrint,
            this.tsmPreview,
            this.toolStripSeparator2,
            this.tsmExit});
            this.tsmFileMenu.Name = "tsmFileMenu";
            this.tsmFileMenu.Size = new System.Drawing.Size(48, 20);
            this.tsmFileMenu.Text = "&Файл";
            // 
            // tsmCreate
            // 
            this.tsmCreate.Image = ((System.Drawing.Image)(resources.GetObject("tsmCreate.Image")));
            this.tsmCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmCreate.Name = "tsmCreate";
            this.tsmCreate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmCreate.Size = new System.Drawing.Size(233, 22);
            this.tsmCreate.Text = "&Создать";
            // 
            // tsmOpen
            // 
            this.tsmOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsmOpen.Image")));
            this.tsmOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmOpen.Size = new System.Drawing.Size(233, 22);
            this.tsmOpen.Text = "&Открыть";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(230, 6);
            // 
            // tsmSave
            // 
            this.tsmSave.Enabled = false;
            this.tsmSave.Image = ((System.Drawing.Image)(resources.GetObject("tsmSave.Image")));
            this.tsmSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmSave.Size = new System.Drawing.Size(233, 22);
            this.tsmSave.Text = "&Сохранить";
            // 
            // tsmSaveAs
            // 
            this.tsmSaveAs.Name = "tsmSaveAs";
            this.tsmSaveAs.Size = new System.Drawing.Size(233, 22);
            this.tsmSaveAs.Text = "Сохранить &как";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
            // 
            // tsmPrint
            // 
            this.tsmPrint.Enabled = false;
            this.tsmPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsmPrint.Image")));
            this.tsmPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmPrint.Name = "tsmPrint";
            this.tsmPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsmPrint.Size = new System.Drawing.Size(233, 22);
            this.tsmPrint.Text = "&Печать";
            // 
            // tsmPreview
            // 
            this.tsmPreview.Enabled = false;
            this.tsmPreview.Image = ((System.Drawing.Image)(resources.GetObject("tsmPreview.Image")));
            this.tsmPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmPreview.Name = "tsmPreview";
            this.tsmPreview.Size = new System.Drawing.Size(233, 22);
            this.tsmPreview.Text = "Предварительный про&смотр";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(230, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(233, 22);
            this.tsmExit.Text = "Вы&ход";
            // 
            // tsmEditMenu
            // 
            this.tsmEditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmUndo,
            this.tsmRedo,
            this.toolStripSeparator3,
            this.tsmCut,
            this.tsmCopy,
            this.tsmPaste,
            this.toolStripSeparator4,
            this.tsmSelectAll});
            this.tsmEditMenu.Name = "tsmEditMenu";
            this.tsmEditMenu.Size = new System.Drawing.Size(59, 20);
            this.tsmEditMenu.Text = "&Правка";
            // 
            // tsmUndo
            // 
            this.tsmUndo.Enabled = false;
            this.tsmUndo.Image = global::SimpleEditor.Properties.Resources.undo;
            this.tsmUndo.Name = "tsmUndo";
            this.tsmUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.tsmUndo.Size = new System.Drawing.Size(209, 22);
            this.tsmUndo.Text = "&Отмена действия";
            // 
            // tsmRedo
            // 
            this.tsmRedo.Enabled = false;
            this.tsmRedo.Image = global::SimpleEditor.Properties.Resources.redo;
            this.tsmRedo.Name = "tsmRedo";
            this.tsmRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.tsmRedo.Size = new System.Drawing.Size(209, 22);
            this.tsmRedo.Text = "&Отмена отмены";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(206, 6);
            // 
            // tsmCut
            // 
            this.tsmCut.Enabled = false;
            this.tsmCut.Image = ((System.Drawing.Image)(resources.GetObject("tsmCut.Image")));
            this.tsmCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmCut.Name = "tsmCut";
            this.tsmCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmCut.Size = new System.Drawing.Size(209, 22);
            this.tsmCut.Text = "Вырезат&ь";
            // 
            // tsmCopy
            // 
            this.tsmCopy.Enabled = false;
            this.tsmCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsmCopy.Image")));
            this.tsmCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmCopy.Name = "tsmCopy";
            this.tsmCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmCopy.Size = new System.Drawing.Size(209, 22);
            this.tsmCopy.Text = "&Копировать";
            // 
            // tsmPaste
            // 
            this.tsmPaste.Enabled = false;
            this.tsmPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsmPaste.Image")));
            this.tsmPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmPaste.Name = "tsmPaste";
            this.tsmPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmPaste.Size = new System.Drawing.Size(209, 22);
            this.tsmPaste.Text = "Вст&авка";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(206, 6);
            // 
            // statusStripMain
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStripMain, 2);
            this.statusStripMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStripMain.Location = new System.Drawing.Point(0, 489);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(860, 22);
            this.statusStripMain.TabIndex = 0;
            // 
            // tsbRedo
            // 
            this.tsbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRedo.Enabled = false;
            this.tsbRedo.Image = global::SimpleEditor.Properties.Resources.redo;
            this.tsbRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRedo.Name = "tsbRedo";
            this.tsbRedo.Size = new System.Drawing.Size(23, 22);
            this.tsbRedo.Text = "Вернуть";
            // 
            // tsbEllipse
            // 
            this.tsbEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEllipse.Image = global::SimpleEditor.Properties.Resources.ellipse;
            this.tsbEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEllipse.Name = "tsbEllipse";
            this.tsbEllipse.Size = new System.Drawing.Size(22, 20);
            this.tsbEllipse.Text = "Эллипс";
            // 
            // tsbUndo
            // 
            this.tsbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUndo.Enabled = false;
            this.tsbUndo.Image = global::SimpleEditor.Properties.Resources.undo;
            this.tsbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUndo.Name = "tsbUndo";
            this.tsbUndo.Size = new System.Drawing.Size(23, 22);
            this.tsbUndo.Text = "Отменить";
            // 
            // tsbCircle
            // 
            this.tsbCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCircle.Image = global::SimpleEditor.Properties.Resources.square;
            this.tsbCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCircle.Name = "tsbCircle";
            this.tsbCircle.Size = new System.Drawing.Size(22, 20);
            this.tsbCircle.Text = "Круг";
            // 
            // tsbSquare
            // 
            this.tsbSquare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSquare.Image = global::SimpleEditor.Properties.Resources.square;
            this.tsbSquare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSquare.Name = "tsbSquare";
            this.tsbSquare.Size = new System.Drawing.Size(22, 20);
            this.tsbSquare.Text = "Квадрат";
            // 
            // tsbRect
            // 
            this.tsbRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRect.Image = global::SimpleEditor.Properties.Resources.rect;
            this.tsbRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRect.Name = "tsbRect";
            this.tsbRect.Size = new System.Drawing.Size(22, 20);
            this.tsbRect.Text = "Прямоугольник";
            // 
            // tsbPolygon
            // 
            this.tsbPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPolygon.Image = global::SimpleEditor.Properties.Resources.poligon;
            this.tsbPolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPolygon.Name = "tsbPolygon";
            this.tsbPolygon.Size = new System.Drawing.Size(22, 20);
            this.tsbPolygon.Text = "Полигон";
            this.tsbPolygon.ToolTipText = "Полигон";
            // 
            // tsbPolyline
            // 
            this.tsbPolyline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPolyline.Image = global::SimpleEditor.Properties.Resources.poliline;
            this.tsbPolyline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPolyline.Name = "tsbPolyline";
            this.tsbPolyline.Size = new System.Drawing.Size(22, 20);
            this.tsbPolyline.Text = "Линия";
            this.tsbPolyline.ToolTipText = "Линия";
            // 
            // tsbArrow
            // 
            this.tsbArrow.Checked = true;
            this.tsbArrow.CheckOnClick = true;
            this.tsbArrow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbArrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbArrow.Image = global::SimpleEditor.Properties.Resources.arrow;
            this.tsbArrow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbArrow.Name = "tsbArrow";
            this.tsbArrow.Size = new System.Drawing.Size(22, 20);
            this.tsbArrow.Text = "Выбор фигур";
            // 
            // tsFigures
            // 
            this.tsFigures.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsFigures.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsFigures.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbArrow,
            this.tsbPolyline,
            this.tsbPolygon,
            this.tsbRect,
            this.tsbSquare,
            this.tsbEllipse,
            this.tsbCircle});
            this.tsFigures.Location = new System.Drawing.Point(0, 49);
            this.tsFigures.Name = "tsFigures";
            this.tsFigures.Padding = new System.Windows.Forms.Padding(0);
            this.tsFigures.Size = new System.Drawing.Size(23, 440);
            this.tsFigures.TabIndex = 8;
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Enabled = false;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(23, 22);
            this.tsbPrint.Text = "&Печать";
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "&Сохранить";
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbOpen.Text = "&Открыть";
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(23, 22);
            this.tsbNew.Text = "&Создать";
            // 
            // toolStripFile
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStripFile, 2);
            this.toolStripFile.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripFile.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbOpen,
            this.tsbSave,
            this.tsbPrint,
            this.toolStripSeparator6,
            this.tsbCut,
            this.tsbCopy,
            this.tsbPaste,
            this.toolStripSeparator7,
            this.tsbUndo,
            this.tsbRedo,
            this.toolStripSeparator9,
            this.tsbHelp});
            this.toolStripFile.Location = new System.Drawing.Point(0, 24);
            this.toolStripFile.Name = "toolStripFile";
            this.toolStripFile.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.toolStripFile.Size = new System.Drawing.Size(255, 25);
            this.toolStripFile.TabIndex = 1;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCut
            // 
            this.tsbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCut.Enabled = false;
            this.tsbCut.Image = ((System.Drawing.Image)(resources.GetObject("tsbCut.Image")));
            this.tsbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCut.Name = "tsbCut";
            this.tsbCut.Size = new System.Drawing.Size(23, 22);
            this.tsbCut.Text = "В&ырезать";
            // 
            // tsbCopy
            // 
            this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCopy.Enabled = false;
            this.tsbCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopy.Image")));
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(23, 22);
            this.tsbCopy.Text = "&Копировать";
            // 
            // tsbPaste
            // 
            this.tsbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPaste.Enabled = false;
            this.tsbPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsbPaste.Image")));
            this.tsbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Size = new System.Drawing.Size(23, 22);
            this.tsbPaste.Text = "Вст&авка";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbHelp
            // 
            this.tsbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbHelp.Enabled = false;
            this.tsbHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsbHelp.Image")));
            this.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Size = new System.Drawing.Size(23, 22);
            this.tsbHelp.Text = "Спр&авка";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStripFile, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelForScroll, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.menuStripMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusStripMain, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tsFigures, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(860, 511);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(231, 6);
            // 
            // miUngroupFigures
            // 
            this.miUngroupFigures.Enabled = false;
            this.miUngroupFigures.Image = global::SimpleEditor.Properties.Resources.ungrouping;
            this.miUngroupFigures.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.miUngroupFigures.Name = "miUngroupFigures";
            this.miUngroupFigures.Size = new System.Drawing.Size(234, 22);
            this.miUngroupFigures.Text = "Разруппировать";
            this.miUngroupFigures.Visible = false;
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Enabled = false;
            this.toolStripMenuItem6.Image = global::SimpleEditor.Properties.Resources.grouping;
            this.toolStripMenuItem6.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(234, 22);
            this.toolStripMenuItem6.Text = "Группировать";
            this.toolStripMenuItem6.Visible = false;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(231, 6);
            this.toolStripMenuItem3.Visible = false;
            // 
            // miFill
            // 
            this.miFill.Image = global::SimpleEditor.Properties.Resources.brush;
            this.miFill.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.miFill.Name = "miFill";
            this.miFill.Size = new System.Drawing.Size(234, 22);
            this.miFill.Text = "Кисть...";
            // 
            // miStroke
            // 
            this.miStroke.Image = global::SimpleEditor.Properties.Resources.pen;
            this.miStroke.Name = "miStroke";
            this.miStroke.Size = new System.Drawing.Size(234, 22);
            this.miStroke.Text = "Карандаш...";
            // 
            // cmsFigPopup
            // 
            this.cmsFigPopup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmsFigPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCutPopup,
            this.miCopyPopup,
            this.tsmiNodeSeparator,
            this.miBeginChangeNodes,
            this.miAddFigureNode,
            this.miDeleteFigureNode,
            this.miEndChangeNodes,
            this.miStrokeSeparator,
            this.miStroke,
            this.miFill,
            this.toolStripMenuItem3,
            this.toolStripMenuItem6,
            this.miUngroupFigures,
            this.toolStripMenuItem7,
            this.miBringToFront,
            this.miSendToBack,
            this.tsmiTransformsSeparator,
            this.tsmiTransforms});
            this.cmsFigPopup.Name = "cmsFigPopup";
            this.cmsFigPopup.Size = new System.Drawing.Size(235, 320);
            // 
            // miCutPopup
            // 
            this.miCutPopup.Image = global::SimpleEditor.Properties.Resources.cut;
            this.miCutPopup.Name = "miCutPopup";
            this.miCutPopup.Size = new System.Drawing.Size(234, 22);
            this.miCutPopup.Text = "Вырезать";
            // 
            // miCopyPopup
            // 
            this.miCopyPopup.Image = global::SimpleEditor.Properties.Resources.copy;
            this.miCopyPopup.Name = "miCopyPopup";
            this.miCopyPopup.Size = new System.Drawing.Size(234, 22);
            this.miCopyPopup.Text = "Копировать";
            // 
            // tsmiNodeSeparator
            // 
            this.tsmiNodeSeparator.Name = "tsmiNodeSeparator";
            this.tsmiNodeSeparator.Size = new System.Drawing.Size(231, 6);
            // 
            // miBeginChangeNodes
            // 
            this.miBeginChangeNodes.Image = global::SimpleEditor.Properties.Resources.startnodechanging;
            this.miBeginChangeNodes.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.miBeginChangeNodes.Name = "miBeginChangeNodes";
            this.miBeginChangeNodes.Size = new System.Drawing.Size(234, 22);
            this.miBeginChangeNodes.Text = "Начать изменение узлов";
            this.miBeginChangeNodes.Visible = false;
            // 
            // miAddFigureNode
            // 
            this.miAddFigureNode.Name = "miAddFigureNode";
            this.miAddFigureNode.Size = new System.Drawing.Size(234, 22);
            this.miAddFigureNode.Text = "Добавить узел";
            // 
            // miDeleteFigureNode
            // 
            this.miDeleteFigureNode.Name = "miDeleteFigureNode";
            this.miDeleteFigureNode.Size = new System.Drawing.Size(234, 22);
            this.miDeleteFigureNode.Text = "Удалить узел";
            // 
            // miEndChangeNodes
            // 
            this.miEndChangeNodes.Name = "miEndChangeNodes";
            this.miEndChangeNodes.Size = new System.Drawing.Size(234, 22);
            this.miEndChangeNodes.Text = "Завершить изменение узлов";
            this.miEndChangeNodes.Visible = false;
            // 
            // miStrokeSeparator
            // 
            this.miStrokeSeparator.Name = "miStrokeSeparator";
            this.miStrokeSeparator.Size = new System.Drawing.Size(231, 6);
            // 
            // miBringToFront
            // 
            this.miBringToFront.Image = global::SimpleEditor.Properties.Resources.bringtofront;
            this.miBringToFront.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.miBringToFront.Name = "miBringToFront";
            this.miBringToFront.Size = new System.Drawing.Size(234, 22);
            this.miBringToFront.Text = "Выдвинуть вперёд";
            // 
            // miSendToBack
            // 
            this.miSendToBack.Image = global::SimpleEditor.Properties.Resources.sendtoback;
            this.miSendToBack.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.miSendToBack.Name = "miSendToBack";
            this.miSendToBack.Size = new System.Drawing.Size(234, 22);
            this.miSendToBack.Text = "Поместить назад";
            // 
            // tsmiTransformsSeparator
            // 
            this.tsmiTransformsSeparator.Name = "tsmiTransformsSeparator";
            this.tsmiTransformsSeparator.Size = new System.Drawing.Size(231, 6);
            // 
            // tsmiTransforms
            // 
            this.tsmiTransforms.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miTurnLeft90,
            this.miTurnRight90,
            this.miFlipVertical,
            this.miFlipHorizontal});
            this.tsmiTransforms.Name = "tsmiTransforms";
            this.tsmiTransforms.Size = new System.Drawing.Size(234, 22);
            this.tsmiTransforms.Text = "Трансформации";
            // 
            // miTurnLeft90
            // 
            this.miTurnLeft90.Image = global::SimpleEditor.Properties.Resources.rotateleft;
            this.miTurnLeft90.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.miTurnLeft90.Name = "miTurnLeft90";
            this.miTurnLeft90.Size = new System.Drawing.Size(212, 22);
            this.miTurnLeft90.Text = "Повернуть влево";
            // 
            // miTurnRight90
            // 
            this.miTurnRight90.Image = global::SimpleEditor.Properties.Resources.rotateright;
            this.miTurnRight90.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.miTurnRight90.Name = "miTurnRight90";
            this.miTurnRight90.Size = new System.Drawing.Size(212, 22);
            this.miTurnRight90.Text = "Повернуть вправо";
            // 
            // miFlipVertical
            // 
            this.miFlipVertical.Image = global::SimpleEditor.Properties.Resources.flipleftright;
            this.miFlipVertical.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.miFlipVertical.Name = "miFlipVertical";
            this.miFlipVertical.Size = new System.Drawing.Size(212, 22);
            this.miFlipVertical.Text = "Отразить слева направо";
            // 
            // miFlipHorizontal
            // 
            this.miFlipHorizontal.Image = global::SimpleEditor.Properties.Resources.flipupdown;
            this.miFlipHorizontal.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.miFlipHorizontal.Name = "miFlipHorizontal";
            this.miFlipHorizontal.Size = new System.Drawing.Size(212, 22);
            this.miFlipHorizontal.Text = "Отразить сверху вниз";
            // 
            // cmsBkgPopup
            // 
            this.cmsBkgPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPasteFromBuffer});
            this.cmsBkgPopup.Name = "cmsBkgPopup";
            this.cmsBkgPopup.Size = new System.Drawing.Size(123, 26);
            // 
            // miPasteFromBuffer
            // 
            this.miPasteFromBuffer.Enabled = false;
            this.miPasteFromBuffer.Image = global::SimpleEditor.Properties.Resources.insert;
            this.miPasteFromBuffer.Name = "miPasteFromBuffer";
            this.miPasteFromBuffer.Size = new System.Drawing.Size(122, 22);
            this.miPasteFromBuffer.Text = "Вставить";
            // 
            // timerFormUpdate
            // 
            this.timerFormUpdate.Enabled = true;
            this.timerFormUpdate.Interval = 300;
            // 
            // saveFiguresFileDialog
            // 
            this.saveFiguresFileDialog.DefaultExt = "pic";
            this.saveFiguresFileDialog.FileName = "example";
            this.saveFiguresFileDialog.Filter = "*.pic|*.pic";
            // 
            // openFiguresFileDialog
            // 
            this.openFiguresFileDialog.DefaultExt = "pic";
            this.openFiguresFileDialog.FileName = "example";
            this.openFiguresFileDialog.Filter = "*.pic|*.pic";
            // 
            // FormSimpleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Name = "FormSimpleEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "FormSimpleEditor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormSimpleEditor_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormSimpleEditor_KeyUp);
            this.panelForScroll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tsFigures.ResumeLayout(false);
            this.tsFigures.PerformLayout();
            this.toolStripFile.ResumeLayout(false);
            this.toolStripFile.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.cmsFigPopup.ResumeLayout(false);
            this.cmsBkgPopup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.Panel panelForScroll;
        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStripFile;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbCut;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsbUndo;
        private System.Windows.Forms.ToolStripButton tsbRedo;
        private System.Windows.Forms.ToolStripButton tsbHelp;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStrip tsFigures;
        private System.Windows.Forms.ToolStripButton tsbArrow;
        private System.Windows.Forms.ToolStripButton tsbPolyline;
        private System.Windows.Forms.ToolStripButton tsbPolygon;
        private System.Windows.Forms.ToolStripButton tsbRect;
        private System.Windows.Forms.ToolStripButton tsbSquare;
        private System.Windows.Forms.ToolStripButton tsbEllipse;
        private System.Windows.Forms.ToolStripButton tsbCircle;
        private System.Windows.Forms.ToolStripMenuItem tsmFileMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmCreate;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem tsmSave;
        private System.Windows.Forms.ToolStripMenuItem tsmSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmEditMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmUndo;
        private System.Windows.Forms.ToolStripMenuItem tsmRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmCut;
        private System.Windows.Forms.ToolStripMenuItem tsmCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem miUngroupFigures;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem miFill;
        private System.Windows.Forms.ToolStripMenuItem miStroke;
        private System.Windows.Forms.ContextMenuStrip cmsFigPopup;
        private System.Windows.Forms.ToolStripMenuItem miCutPopup;
        private System.Windows.Forms.ToolStripMenuItem miCopyPopup;
        private System.Windows.Forms.ToolStripSeparator tsmiNodeSeparator;
        private System.Windows.Forms.ToolStripMenuItem miBeginChangeNodes;
        private System.Windows.Forms.ToolStripMenuItem miAddFigureNode;
        private System.Windows.Forms.ToolStripMenuItem miDeleteFigureNode;
        private System.Windows.Forms.ToolStripMenuItem miEndChangeNodes;
        private System.Windows.Forms.ToolStripSeparator miStrokeSeparator;
        private System.Windows.Forms.ToolStripMenuItem miBringToFront;
        private System.Windows.Forms.ToolStripMenuItem miSendToBack;
        private System.Windows.Forms.ToolStripSeparator tsmiTransformsSeparator;
        private System.Windows.Forms.ToolStripMenuItem tsmiTransforms;
        private System.Windows.Forms.ToolStripMenuItem miTurnLeft90;
        private System.Windows.Forms.ToolStripMenuItem miTurnRight90;
        private System.Windows.Forms.ToolStripMenuItem miFlipVertical;
        private System.Windows.Forms.ToolStripMenuItem miFlipHorizontal;
        private System.Windows.Forms.ContextMenuStrip cmsBkgPopup;
        private System.Windows.Forms.ToolStripMenuItem miPasteFromBuffer;
        private System.Windows.Forms.Timer timerFormUpdate;
        private System.Windows.Forms.SaveFileDialog saveFiguresFileDialog;
        private System.Windows.Forms.OpenFileDialog openFiguresFileDialog;
    }
}

