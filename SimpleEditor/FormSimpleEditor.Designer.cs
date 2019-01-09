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
            this.cmsCanvasPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDuplicateFigure = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tsmDuplicateFigure = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripFile = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCut = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUndo = new System.Windows.Forms.ToolStripButton();
            this.tsbRedo = new System.Windows.Forms.ToolStripButton();
            this.tsbHelp = new System.Windows.Forms.ToolStripButton();
            this.saveEditorFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openEditorFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslEditorMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslRibbonRect = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnTools = new System.Windows.Forms.FlowLayoutPanel();
            this.tsbCreateTools = new System.Windows.Forms.ToolStrip();
            this.tsbSelectMode = new System.Windows.Forms.ToolStripButton();
            this.tsbSkewMode = new System.Windows.Forms.ToolStripButton();
            this.tsbVertexMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbArrow = new System.Windows.Forms.ToolStripButton();
            this.tsbPolyline = new System.Windows.Forms.ToolStripSplitButton();
            this.btnPolyline = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBezier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRect = new System.Windows.Forms.ToolStripSplitButton();
            this.btnRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSquare = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEllipse = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCircle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnArc = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSegment = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPie = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRomb = new System.Windows.Forms.ToolStripSplitButton();
            this.btnRegular3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegular4 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegular5 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegular6 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegular7 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegular8 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegular9 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegular10 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbText = new System.Windows.Forms.ToolStripSplitButton();
            this.btnTextBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.btnText = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbPicture = new System.Windows.Forms.ToolStripSplitButton();
            this.btnInsertImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsArrange = new System.Windows.Forms.ToolStrip();
            this.tsddbGeometySwitcher = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmiCyrcle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEllipse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegularTriangle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSquare = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRomb = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegular5gon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegular6gon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegular7gon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegular8gon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegular9gon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegular10gon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddbFillBrushSwitcher = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmiSolidBrush = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLinearGradientBrush = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRadialGradientBrush = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHatchBrush = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTextureBrush = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddbEffectSwitcher = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmiNoneEffects = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShadow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGlow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTextBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.lbZoom = new System.Windows.Forms.ToolStripLabel();
            this.cbScaleFactor = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBringToFront = new System.Windows.Forms.ToolStripButton();
            this.tsbSendToBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbGroup = new System.Windows.Forms.ToolStripButton();
            this.tsbUngroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFlipX = new System.Windows.Forms.ToolStripButton();
            this.tsbFlipY = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRotate90Ccw = new System.Windows.Forms.ToolStripButton();
            this.tsbRotate90Cw = new System.Windows.Forms.ToolStripButton();
            this.tsbRotate180 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAlignLeft = new System.Windows.Forms.ToolStripButton();
            this.tsbAlignCenter = new System.Windows.Forms.ToolStripButton();
            this.tsbAlignRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAlignTop = new System.Windows.Forms.ToolStripButton();
            this.tsbAlignMiddle = new System.Windows.Forms.ToolStripButton();
            this.tsbAlignBottom = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSameWidth = new System.Windows.Forms.ToolStripButton();
            this.tsbSameHeight = new System.Windows.Forms.ToolStripButton();
            this.tsbSameBothSizes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEvenHorizontalSpaces = new System.Windows.Forms.ToolStripButton();
            this.tsbEvenVerticalSpaces = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLock = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbConvertToPath = new System.Windows.Forms.ToolStripButton();
            this.timerCheckClipboard = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelForScroll = new System.Windows.Forms.Panel();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tvFigures = new System.Windows.Forms.TreeView();
            this.btnTextOnBezier = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCanvasPopup.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.toolStripFile.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tsbCreateTools.SuspendLayout();
            this.tsArrange.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelForScroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmSelectAll
            // 
            this.tsmSelectAll.Enabled = false;
            this.tsmSelectAll.Name = "tsmSelectAll";
            this.tsmSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmSelectAll.Size = new System.Drawing.Size(166, 26);
            this.tsmSelectAll.Text = "Select &all";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // cmsCanvasPopup
            // 
            this.cmsCanvasPopup.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsCanvasPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDuplicateFigure,
            this.tsmiPaste,
            this.tsmiDelete});
            this.cmsCanvasPopup.Name = "cmsBkgPopup";
            this.cmsCanvasPopup.Size = new System.Drawing.Size(148, 82);
            this.cmsCanvasPopup.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCanvasPopup_Opening);
            // 
            // tsmiDuplicateFigure
            // 
            this.tsmiDuplicateFigure.Image = global::SimpleEditor.Properties.Resources.double1;
            this.tsmiDuplicateFigure.Name = "tsmiDuplicateFigure";
            this.tsmiDuplicateFigure.Size = new System.Drawing.Size(147, 26);
            this.tsmiDuplicateFigure.Text = "Duplicate";
            this.tsmiDuplicateFigure.Click += new System.EventHandler(this.tsmDuplicateFigure_Click);
            // 
            // tsmiPaste
            // 
            this.tsmiPaste.Enabled = false;
            this.tsmiPaste.Image = global::SimpleEditor.Properties.Resources.insert;
            this.tsmiPaste.Name = "tsmiPaste";
            this.tsmiPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmiPaste.Size = new System.Drawing.Size(147, 26);
            this.tsmiPaste.Text = "Paste";
            this.tsmiPaste.Click += new System.EventHandler(this.tsmPaste_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Image = global::SimpleEditor.Properties.Resources.delete;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmiDelete.Size = new System.Drawing.Size(147, 26);
            this.tsmiDelete.Text = "Delete";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFileMenu,
            this.tsmEditMenu});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(84, 24);
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
            this.tsmFileMenu.Size = new System.Drawing.Size(37, 20);
            this.tsmFileMenu.Text = "&File";
            // 
            // tsmCreate
            // 
            this.tsmCreate.Image = ((System.Drawing.Image)(resources.GetObject("tsmCreate.Image")));
            this.tsmCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmCreate.Name = "tsmCreate";
            this.tsmCreate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmCreate.Size = new System.Drawing.Size(150, 26);
            this.tsmCreate.Text = "&New";
            this.tsmCreate.Click += new System.EventHandler(this.tsmCreate_Click);
            // 
            // tsmOpen
            // 
            this.tsmOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsmOpen.Image")));
            this.tsmOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmOpen.Size = new System.Drawing.Size(150, 26);
            this.tsmOpen.Text = "&Open";
            this.tsmOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(147, 6);
            // 
            // tsmSave
            // 
            this.tsmSave.Enabled = false;
            this.tsmSave.Image = ((System.Drawing.Image)(resources.GetObject("tsmSave.Image")));
            this.tsmSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmSave.Size = new System.Drawing.Size(150, 26);
            this.tsmSave.Text = "&Save";
            this.tsmSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // tsmSaveAs
            // 
            this.tsmSaveAs.Name = "tsmSaveAs";
            this.tsmSaveAs.Size = new System.Drawing.Size(150, 26);
            this.tsmSaveAs.Text = "Save &as...";
            this.tsmSaveAs.Click += new System.EventHandler(this.tsmSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(147, 6);
            // 
            // tsmPrint
            // 
            this.tsmPrint.Enabled = false;
            this.tsmPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsmPrint.Image")));
            this.tsmPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmPrint.Name = "tsmPrint";
            this.tsmPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsmPrint.Size = new System.Drawing.Size(150, 26);
            this.tsmPrint.Text = "&Print";
            // 
            // tsmPreview
            // 
            this.tsmPreview.Enabled = false;
            this.tsmPreview.Image = ((System.Drawing.Image)(resources.GetObject("tsmPreview.Image")));
            this.tsmPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmPreview.Name = "tsmPreview";
            this.tsmPreview.Size = new System.Drawing.Size(150, 26);
            this.tsmPreview.Text = "Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(147, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(150, 26);
            this.tsmExit.Text = "E&xit";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // tsmEditMenu
            // 
            this.tsmEditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmUndo,
            this.tsmRedo,
            this.toolStripSeparator3,
            this.tsmDuplicateFigure,
            this.tsmCut,
            this.tsmCopy,
            this.tsmPaste,
            this.tsmDelete,
            this.toolStripSeparator4,
            this.tsmSelectAll});
            this.tsmEditMenu.Name = "tsmEditMenu";
            this.tsmEditMenu.Size = new System.Drawing.Size(39, 20);
            this.tsmEditMenu.Text = "&Edit";
            this.tsmEditMenu.DropDownOpening += new System.EventHandler(this.tsmEditMenu_DropDownOpening);
            // 
            // tsmUndo
            // 
            this.tsmUndo.Enabled = false;
            this.tsmUndo.Image = global::SimpleEditor.Properties.Resources.undo;
            this.tsmUndo.Name = "tsmUndo";
            this.tsmUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.tsmUndo.Size = new System.Drawing.Size(166, 26);
            this.tsmUndo.Text = "&Undo";
            this.tsmUndo.Click += new System.EventHandler(this.tsmUndo_Click);
            // 
            // tsmRedo
            // 
            this.tsmRedo.Enabled = false;
            this.tsmRedo.Image = global::SimpleEditor.Properties.Resources.redo;
            this.tsmRedo.Name = "tsmRedo";
            this.tsmRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.tsmRedo.Size = new System.Drawing.Size(166, 26);
            this.tsmRedo.Text = "&Redo";
            this.tsmRedo.Click += new System.EventHandler(this.tsmRedo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(163, 6);
            // 
            // tsmDuplicateFigure
            // 
            this.tsmDuplicateFigure.Image = global::SimpleEditor.Properties.Resources.double1;
            this.tsmDuplicateFigure.Name = "tsmDuplicateFigure";
            this.tsmDuplicateFigure.Size = new System.Drawing.Size(166, 26);
            this.tsmDuplicateFigure.Text = "Duplicate";
            this.tsmDuplicateFigure.Click += new System.EventHandler(this.tsmDuplicateFigure_Click);
            // 
            // tsmCut
            // 
            this.tsmCut.Enabled = false;
            this.tsmCut.Image = ((System.Drawing.Image)(resources.GetObject("tsmCut.Image")));
            this.tsmCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmCut.Name = "tsmCut";
            this.tsmCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmCut.Size = new System.Drawing.Size(166, 26);
            this.tsmCut.Text = "Cu&t";
            this.tsmCut.Click += new System.EventHandler(this.tsbCut_Click);
            // 
            // tsmCopy
            // 
            this.tsmCopy.Enabled = false;
            this.tsmCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsmCopy.Image")));
            this.tsmCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmCopy.Name = "tsmCopy";
            this.tsmCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmCopy.Size = new System.Drawing.Size(166, 26);
            this.tsmCopy.Text = "&Copy";
            this.tsmCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // tsmPaste
            // 
            this.tsmPaste.Enabled = false;
            this.tsmPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsmPaste.Image")));
            this.tsmPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmPaste.Name = "tsmPaste";
            this.tsmPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmPaste.Size = new System.Drawing.Size(166, 26);
            this.tsmPaste.Text = "&Paste";
            this.tsmPaste.Click += new System.EventHandler(this.tsmPaste_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Image = global::SimpleEditor.Properties.Resources.delete;
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmDelete.Size = new System.Drawing.Size(166, 26);
            this.tsmDelete.Text = "Delete";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(163, 6);
            // 
            // toolStripFile
            // 
            this.toolStripFile.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripFile.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFile.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.toolStripFile.Padding = new System.Windows.Forms.Padding(0);
            this.toolStripFile.Size = new System.Drawing.Size(250, 25);
            this.toolStripFile.TabIndex = 1;
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = global::SimpleEditor.Properties.Resources.newpage;
            this.tsbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(23, 22);
            this.tsbNew.Text = "&Создать";
            this.tsbNew.Click += new System.EventHandler(this.tsmCreate_Click);
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = global::SimpleEditor.Properties.Resources.openfolder;
            this.tsbOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbOpen.Text = "&Открыть";
            this.tsbOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = global::SimpleEditor.Properties.Resources.save;
            this.tsbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "&Сохранить";
            this.tsbSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Enabled = false;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(23, 22);
            this.tsbPrint.Text = "&Печать";
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
            this.tsbCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCut.Name = "tsbCut";
            this.tsbCut.Size = new System.Drawing.Size(23, 22);
            this.tsbCut.Text = "В&ырезать";
            this.tsbCut.Click += new System.EventHandler(this.tsbCut_Click);
            // 
            // tsbCopy
            // 
            this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCopy.Enabled = false;
            this.tsbCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopy.Image")));
            this.tsbCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(23, 22);
            this.tsbCopy.Text = "&Копировать";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // tsbPaste
            // 
            this.tsbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPaste.Enabled = false;
            this.tsbPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsbPaste.Image")));
            this.tsbPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Size = new System.Drawing.Size(23, 22);
            this.tsbPaste.Text = "Вст&авка";
            this.tsbPaste.Click += new System.EventHandler(this.tsmPaste_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbUndo
            // 
            this.tsbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUndo.Enabled = false;
            this.tsbUndo.Image = global::SimpleEditor.Properties.Resources.undo;
            this.tsbUndo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUndo.Name = "tsbUndo";
            this.tsbUndo.Size = new System.Drawing.Size(23, 22);
            this.tsbUndo.Text = "Отменить";
            this.tsbUndo.Click += new System.EventHandler(this.tsmUndo_Click);
            // 
            // tsbRedo
            // 
            this.tsbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRedo.Enabled = false;
            this.tsbRedo.Image = global::SimpleEditor.Properties.Resources.redo;
            this.tsbRedo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRedo.Name = "tsbRedo";
            this.tsbRedo.Size = new System.Drawing.Size(23, 22);
            this.tsbRedo.Text = "Вернуть";
            this.tsbRedo.Click += new System.EventHandler(this.tsmRedo_Click);
            // 
            // tsbHelp
            // 
            this.tsbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbHelp.Enabled = false;
            this.tsbHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsbHelp.Image")));
            this.tsbHelp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Size = new System.Drawing.Size(23, 22);
            this.tsbHelp.Text = "Спр&авка";
            // 
            // saveEditorFileDialog
            // 
            this.saveEditorFileDialog.DefaultExt = "vge";
            this.saveEditorFileDialog.Filter = "Файл редактора (*.vge)|*.vge|Файлы (*.svg)|*.svg|Файлы (*.png)|*.png|Файлы (*.jpg" +
    ")|*.jpg|Файлы (*.emf)|*.emf|Файлы (*.gif)|*.gif|Файлы (*.ico)|*.ico|Файлы (*.tif" +
    ")|*.tif|Файлы (*.bmp)|*.bmp";
            // 
            // openEditorFileDialog
            // 
            this.openEditorFileDialog.DefaultExt = "vge";
            this.openEditorFileDialog.Filter = "Файл редактора (*.vge)|*.vge";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslEditorMode,
            this.tsslRibbonRect});
            this.statusStrip1.Location = new System.Drawing.Point(0, 521);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1080, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // tsslEditorMode
            // 
            this.tsslEditorMode.Name = "tsslEditorMode";
            this.tsslEditorMode.Size = new System.Drawing.Size(75, 17);
            this.tsslEditorMode.Text = "Mode: Select";
            // 
            // tsslRibbonRect
            // 
            this.tsslRibbonRect.Name = "tsslRibbonRect";
            this.tsslRibbonRect.Size = new System.Drawing.Size(15, 17);
            this.tsslRibbonRect.Text = "{}";
            // 
            // pnTools
            // 
            this.pnTools.AutoScroll = true;
            this.pnTools.AutoSize = true;
            this.pnTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTools.Location = new System.Drawing.Point(0, 0);
            this.pnTools.MinimumSize = new System.Drawing.Size(0, 45);
            this.pnTools.Name = "pnTools";
            this.pnTools.Size = new System.Drawing.Size(275, 216);
            this.pnTools.TabIndex = 7;
            // 
            // tsbCreateTools
            // 
            this.tsbCreateTools.Dock = System.Windows.Forms.DockStyle.None;
            this.tsbCreateTools.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsbCreateTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsbCreateTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSelectMode,
            this.tsbSkewMode,
            this.tsbVertexMode,
            this.toolStripSeparator8,
            this.tsbArrow,
            this.tsbPolyline,
            this.tsbRect,
            this.tsbRomb,
            this.tsbText,
            this.tsbPicture});
            this.tsbCreateTools.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsbCreateTools.Location = new System.Drawing.Point(0, 0);
            this.tsbCreateTools.Name = "tsbCreateTools";
            this.tsbCreateTools.Padding = new System.Windows.Forms.Padding(0);
            this.tsbCreateTools.Size = new System.Drawing.Size(32, 234);
            this.tsbCreateTools.Stretch = true;
            this.tsbCreateTools.TabIndex = 8;
            // 
            // tsbSelectMode
            // 
            this.tsbSelectMode.Checked = true;
            this.tsbSelectMode.CheckOnClick = true;
            this.tsbSelectMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbSelectMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelectMode.Image = global::SimpleEditor.Properties.Resources.arrow;
            this.tsbSelectMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelectMode.Name = "tsbSelectMode";
            this.tsbSelectMode.Size = new System.Drawing.Size(31, 20);
            this.tsbSelectMode.Text = "Select Mode";
            this.tsbSelectMode.Click += new System.EventHandler(this.ModeSelector_Click);
            // 
            // tsbSkewMode
            // 
            this.tsbSkewMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSkewMode.Image = global::SimpleEditor.Properties.Resources.skewmode;
            this.tsbSkewMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSkewMode.Name = "tsbSkewMode";
            this.tsbSkewMode.Size = new System.Drawing.Size(31, 20);
            this.tsbSkewMode.Text = "Skew Mode";
            this.tsbSkewMode.Click += new System.EventHandler(this.ModeSelector_Click);
            // 
            // tsbVertexMode
            // 
            this.tsbVertexMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbVertexMode.Image = global::SimpleEditor.Properties.Resources.startnodechanging;
            this.tsbVertexMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVertexMode.Name = "tsbVertexMode";
            this.tsbVertexMode.Size = new System.Drawing.Size(31, 20);
            this.tsbVertexMode.Text = "Vertex Mode";
            this.tsbVertexMode.Click += new System.EventHandler(this.ModeSelector_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(31, 6);
            // 
            // tsbArrow
            // 
            this.tsbArrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbArrow.Enabled = false;
            this.tsbArrow.Image = global::SimpleEditor.Properties.Resources.arrow;
            this.tsbArrow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbArrow.Name = "tsbArrow";
            this.tsbArrow.Size = new System.Drawing.Size(31, 20);
            this.tsbArrow.Text = "Arrow";
            this.tsbArrow.ToolTipText = "Cancel Create Figure";
            this.tsbArrow.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // tsbPolyline
            // 
            this.tsbPolyline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPolyline.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPolyline,
            this.btnBezier});
            this.tsbPolyline.Image = global::SimpleEditor.Properties.Resources.polyline;
            this.tsbPolyline.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPolyline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPolyline.Name = "tsbPolyline";
            this.tsbPolyline.Size = new System.Drawing.Size(31, 20);
            this.tsbPolyline.Text = "Polyline";
            this.tsbPolyline.ToolTipText = "Create Poly Geometry";
            this.tsbPolyline.ButtonClick += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnPolyline
            // 
            this.btnPolyline.Image = global::SimpleEditor.Properties.Resources.polyline;
            this.btnPolyline.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPolyline.Name = "btnPolyline";
            this.btnPolyline.Size = new System.Drawing.Size(116, 22);
            this.btnPolyline.Text = "Polyline";
            this.btnPolyline.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnBezier
            // 
            this.btnBezier.Image = global::SimpleEditor.Properties.Resources.bezier;
            this.btnBezier.Name = "btnBezier";
            this.btnBezier.Size = new System.Drawing.Size(116, 22);
            this.btnBezier.Text = "Bezier";
            this.btnBezier.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // tsbRect
            // 
            this.tsbRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRectangle,
            this.btnSquare,
            this.btnEllipse,
            this.btnCircle,
            this.toolStripMenuItem1,
            this.btnArc,
            this.btnSegment,
            this.btnPie});
            this.tsbRect.Image = global::SimpleEditor.Properties.Resources.rect;
            this.tsbRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRect.Name = "tsbRect";
            this.tsbRect.Size = new System.Drawing.Size(31, 20);
            this.tsbRect.Text = "Rectangle";
            this.tsbRect.ToolTipText = "Create Primitive Geometry";
            this.tsbRect.ButtonClick += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.Image = global::SimpleEditor.Properties.Resources.rect;
            this.btnRectangle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(126, 22);
            this.btnRectangle.Text = "Rectangle";
            this.btnRectangle.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnSquare
            // 
            this.btnSquare.Image = global::SimpleEditor.Properties.Resources.square;
            this.btnSquare.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSquare.Name = "btnSquare";
            this.btnSquare.Size = new System.Drawing.Size(126, 22);
            this.btnSquare.Text = "Square";
            this.btnSquare.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.Image = global::SimpleEditor.Properties.Resources.ellipse;
            this.btnEllipse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(126, 22);
            this.btnEllipse.Text = "Ellipse";
            this.btnEllipse.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Image = global::SimpleEditor.Properties.Resources.circle;
            this.btnCircle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(126, 22);
            this.btnCircle.Text = "Circle";
            this.btnCircle.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(123, 6);
            // 
            // btnArc
            // 
            this.btnArc.Image = global::SimpleEditor.Properties.Resources.arc;
            this.btnArc.Name = "btnArc";
            this.btnArc.Size = new System.Drawing.Size(126, 22);
            this.btnArc.Text = "Arc";
            this.btnArc.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnSegment
            // 
            this.btnSegment.Image = global::SimpleEditor.Properties.Resources.chord;
            this.btnSegment.Name = "btnSegment";
            this.btnSegment.Size = new System.Drawing.Size(126, 22);
            this.btnSegment.Text = "Chord";
            this.btnSegment.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnPie
            // 
            this.btnPie.Image = global::SimpleEditor.Properties.Resources.wedge;
            this.btnPie.Name = "btnPie";
            this.btnPie.Size = new System.Drawing.Size(126, 22);
            this.btnPie.Text = "Pie";
            this.btnPie.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // tsbRomb
            // 
            this.tsbRomb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRomb.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRegular3,
            this.btnRegular4,
            this.btnRegular5,
            this.btnRegular6,
            this.btnRegular7,
            this.btnRegular8,
            this.btnRegular9,
            this.btnRegular10});
            this.tsbRomb.Image = global::SimpleEditor.Properties.Resources.romb;
            this.tsbRomb.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRomb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRomb.Name = "tsbRomb";
            this.tsbRomb.Size = new System.Drawing.Size(31, 20);
            this.tsbRomb.Text = "Romb";
            this.tsbRomb.ToolTipText = "Create Regular Geometry";
            this.tsbRomb.ButtonClick += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnRegular3
            // 
            this.btnRegular3.Image = global::SimpleEditor.Properties.Resources.triangle;
            this.btnRegular3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRegular3.Name = "btnRegular3";
            this.btnRegular3.Size = new System.Drawing.Size(126, 22);
            this.btnRegular3.Text = "Regular3";
            this.btnRegular3.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnRegular4
            // 
            this.btnRegular4.Image = global::SimpleEditor.Properties.Resources.romb;
            this.btnRegular4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRegular4.Name = "btnRegular4";
            this.btnRegular4.Size = new System.Drawing.Size(126, 22);
            this.btnRegular4.Text = "Regular4";
            this.btnRegular4.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnRegular5
            // 
            this.btnRegular5.Name = "btnRegular5";
            this.btnRegular5.Size = new System.Drawing.Size(126, 22);
            this.btnRegular5.Text = "Regular5";
            this.btnRegular5.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnRegular6
            // 
            this.btnRegular6.Image = global::SimpleEditor.Properties.Resources.regular6;
            this.btnRegular6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRegular6.Name = "btnRegular6";
            this.btnRegular6.Size = new System.Drawing.Size(126, 22);
            this.btnRegular6.Text = "Regular6";
            this.btnRegular6.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnRegular7
            // 
            this.btnRegular7.Name = "btnRegular7";
            this.btnRegular7.Size = new System.Drawing.Size(126, 22);
            this.btnRegular7.Text = "Regular7";
            this.btnRegular7.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnRegular8
            // 
            this.btnRegular8.Image = global::SimpleEditor.Properties.Resources.regular8;
            this.btnRegular8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRegular8.Name = "btnRegular8";
            this.btnRegular8.Size = new System.Drawing.Size(126, 22);
            this.btnRegular8.Text = "Regular8";
            this.btnRegular8.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnRegular9
            // 
            this.btnRegular9.Name = "btnRegular9";
            this.btnRegular9.Size = new System.Drawing.Size(126, 22);
            this.btnRegular9.Text = "Regular9";
            this.btnRegular9.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnRegular10
            // 
            this.btnRegular10.Name = "btnRegular10";
            this.btnRegular10.Size = new System.Drawing.Size(126, 22);
            this.btnRegular10.Text = "Regular10";
            this.btnRegular10.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // tsbText
            // 
            this.tsbText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbText.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTextBlock,
            this.btnText,
            this.btnTextOnBezier});
            this.tsbText.Image = global::SimpleEditor.Properties.Resources.text;
            this.tsbText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbText.Name = "tsbText";
            this.tsbText.Size = new System.Drawing.Size(31, 20);
            this.tsbText.Text = "Text Block";
            this.tsbText.ToolTipText = "Create TextBlock & Text Geometry";
            this.tsbText.ButtonClick += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnTextBlock
            // 
            this.btnTextBlock.Image = global::SimpleEditor.Properties.Resources.text;
            this.btnTextBlock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTextBlock.Name = "btnTextBlock";
            this.btnTextBlock.Size = new System.Drawing.Size(180, 22);
            this.btnTextBlock.Text = "Text Block";
            this.btnTextBlock.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnText
            // 
            this.btnText.Image = global::SimpleEditor.Properties.Resources.textline;
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(180, 22);
            this.btnText.Text = "Text";
            this.btnText.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // tsbPicture
            // 
            this.tsbPicture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPicture.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInsertImage,
            this.btnLoadGroup});
            this.tsbPicture.Image = global::SimpleEditor.Properties.Resources.picture;
            this.tsbPicture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPicture.Name = "tsbPicture";
            this.tsbPicture.Size = new System.Drawing.Size(31, 20);
            this.tsbPicture.Text = "Image";
            this.tsbPicture.ToolTipText = "Insert Image & Picture";
            this.tsbPicture.ButtonClick += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnInsertImage
            // 
            this.btnInsertImage.Image = global::SimpleEditor.Properties.Resources.picture;
            this.btnInsertImage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnInsertImage.Name = "btnInsertImage";
            this.btnInsertImage.Size = new System.Drawing.Size(158, 22);
            this.btnInsertImage.Text = "Image";
            this.btnInsertImage.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // btnLoadGroup
            // 
            this.btnLoadGroup.Image = global::SimpleEditor.Properties.Resources.subpicture;
            this.btnLoadGroup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLoadGroup.Name = "btnLoadGroup";
            this.btnLoadGroup.Size = new System.Drawing.Size(158, 22);
            this.btnLoadGroup.Text = "Selection Group";
            this.btnLoadGroup.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // tsArrange
            // 
            this.tsArrange.Dock = System.Windows.Forms.DockStyle.None;
            this.tsArrange.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsArrange.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsArrange.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbGeometySwitcher,
            this.toolStripSeparator5,
            this.tsddbFillBrushSwitcher,
            this.toolStripSeparator16,
            this.tsddbEffectSwitcher,
            this.toolStripSeparator19,
            this.lbZoom,
            this.cbScaleFactor,
            this.toolStripSeparator18,
            this.tsbBringToFront,
            this.tsbSendToBack,
            this.toolStripSeparator10,
            this.tsbGroup,
            this.tsbUngroup,
            this.toolStripSeparator11,
            this.tsbFlipX,
            this.tsbFlipY,
            this.toolStripSeparator15,
            this.tsbRotate90Ccw,
            this.tsbRotate90Cw,
            this.tsbRotate180,
            this.toolStripSeparator20,
            this.tsbAlignLeft,
            this.tsbAlignCenter,
            this.tsbAlignRight,
            this.toolStripSeparator12,
            this.tsbAlignTop,
            this.tsbAlignMiddle,
            this.tsbAlignBottom,
            this.toolStripSeparator13,
            this.tsbSameWidth,
            this.tsbSameHeight,
            this.tsbSameBothSizes,
            this.toolStripSeparator14,
            this.tsbEvenHorizontalSpaces,
            this.tsbEvenVerticalSpaces,
            this.toolStripSeparator21,
            this.tsbLock,
            this.toolStripSeparator17,
            this.tsbConvertToPath});
            this.tsArrange.Location = new System.Drawing.Point(0, 49);
            this.tsArrange.Name = "tsArrange";
            this.tsArrange.Size = new System.Drawing.Size(986, 31);
            this.tsArrange.TabIndex = 2;
            // 
            // tsddbGeometySwitcher
            // 
            this.tsddbGeometySwitcher.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbGeometySwitcher.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCyrcle,
            this.tsmiEllipse,
            this.tsmiRectangle,
            this.tsmiRegularTriangle,
            this.tsmiSquare,
            this.tsmiRomb,
            this.tsmiRegular5gon,
            this.tsmiRegular6gon,
            this.tsmiRegular7gon,
            this.tsmiRegular8gon,
            this.tsmiRegular9gon,
            this.tsmiRegular10gon});
            this.tsddbGeometySwitcher.Image = ((System.Drawing.Image)(resources.GetObject("tsddbGeometySwitcher.Image")));
            this.tsddbGeometySwitcher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbGeometySwitcher.Name = "tsddbGeometySwitcher";
            this.tsddbGeometySwitcher.Size = new System.Drawing.Size(112, 28);
            this.tsddbGeometySwitcher.Text = "Geometry: Select";
            this.tsddbGeometySwitcher.ButtonClick += new System.EventHandler(this.tsddbGeometySwitcher_ButtonClick);
            // 
            // tsmiCyrcle
            // 
            this.tsmiCyrcle.Name = "tsmiCyrcle";
            this.tsmiCyrcle.Size = new System.Drawing.Size(159, 22);
            this.tsmiCyrcle.Text = "Cyrcle";
            this.tsmiCyrcle.Click += new System.EventHandler(this.tsmiPrimitiveGeometry_Click);
            // 
            // tsmiEllipse
            // 
            this.tsmiEllipse.Name = "tsmiEllipse";
            this.tsmiEllipse.Size = new System.Drawing.Size(159, 22);
            this.tsmiEllipse.Text = "Ellipse";
            this.tsmiEllipse.Click += new System.EventHandler(this.tsmiPrimitiveGeometry_Click);
            // 
            // tsmiRectangle
            // 
            this.tsmiRectangle.Name = "tsmiRectangle";
            this.tsmiRectangle.Size = new System.Drawing.Size(159, 22);
            this.tsmiRectangle.Text = "Rectangle";
            this.tsmiRectangle.Click += new System.EventHandler(this.tsmiPrimitiveGeometry_Click);
            // 
            // tsmiRegularTriangle
            // 
            this.tsmiRegularTriangle.Name = "tsmiRegularTriangle";
            this.tsmiRegularTriangle.Size = new System.Drawing.Size(159, 22);
            this.tsmiRegularTriangle.Tag = "3";
            this.tsmiRegularTriangle.Text = "Regular Triangle";
            this.tsmiRegularTriangle.Click += new System.EventHandler(this.tsmiPrimitiveGeometry_Click);
            // 
            // tsmiSquare
            // 
            this.tsmiSquare.Name = "tsmiSquare";
            this.tsmiSquare.Size = new System.Drawing.Size(159, 22);
            this.tsmiSquare.Text = "Square";
            this.tsmiSquare.Click += new System.EventHandler(this.tsmiPrimitiveGeometry_Click);
            // 
            // tsmiRomb
            // 
            this.tsmiRomb.Name = "tsmiRomb";
            this.tsmiRomb.Size = new System.Drawing.Size(159, 22);
            this.tsmiRomb.Tag = "4";
            this.tsmiRomb.Text = "Romb";
            this.tsmiRomb.Click += new System.EventHandler(this.tsmiPrimitiveGeometry_Click);
            // 
            // tsmiRegular5gon
            // 
            this.tsmiRegular5gon.Name = "tsmiRegular5gon";
            this.tsmiRegular5gon.Size = new System.Drawing.Size(159, 22);
            this.tsmiRegular5gon.Tag = "5";
            this.tsmiRegular5gon.Text = "Regular 5-gon";
            this.tsmiRegular5gon.Click += new System.EventHandler(this.tsmiPrimitiveGeometry_Click);
            // 
            // tsmiRegular6gon
            // 
            this.tsmiRegular6gon.Name = "tsmiRegular6gon";
            this.tsmiRegular6gon.Size = new System.Drawing.Size(159, 22);
            this.tsmiRegular6gon.Tag = "6";
            this.tsmiRegular6gon.Text = "Regular 6-gon";
            this.tsmiRegular6gon.Click += new System.EventHandler(this.tsmiPrimitiveGeometry_Click);
            // 
            // tsmiRegular7gon
            // 
            this.tsmiRegular7gon.Name = "tsmiRegular7gon";
            this.tsmiRegular7gon.Size = new System.Drawing.Size(159, 22);
            this.tsmiRegular7gon.Tag = "7";
            this.tsmiRegular7gon.Text = "Regular 7-gon";
            this.tsmiRegular7gon.Click += new System.EventHandler(this.tsmiPrimitiveGeometry_Click);
            // 
            // tsmiRegular8gon
            // 
            this.tsmiRegular8gon.Name = "tsmiRegular8gon";
            this.tsmiRegular8gon.Size = new System.Drawing.Size(159, 22);
            this.tsmiRegular8gon.Tag = "8";
            this.tsmiRegular8gon.Text = "Regular 8-gon";
            this.tsmiRegular8gon.Click += new System.EventHandler(this.tsmiPrimitiveGeometry_Click);
            // 
            // tsmiRegular9gon
            // 
            this.tsmiRegular9gon.Name = "tsmiRegular9gon";
            this.tsmiRegular9gon.Size = new System.Drawing.Size(159, 22);
            this.tsmiRegular9gon.Tag = "9";
            this.tsmiRegular9gon.Text = "Regular 9-gon";
            this.tsmiRegular9gon.Click += new System.EventHandler(this.tsmiPrimitiveGeometry_Click);
            // 
            // tsmiRegular10gon
            // 
            this.tsmiRegular10gon.Name = "tsmiRegular10gon";
            this.tsmiRegular10gon.Size = new System.Drawing.Size(159, 22);
            this.tsmiRegular10gon.Tag = "10";
            this.tsmiRegular10gon.Text = "Regular 10-gon";
            this.tsmiRegular10gon.Click += new System.EventHandler(this.tsmiPrimitiveGeometry_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // tsddbFillBrushSwitcher
            // 
            this.tsddbFillBrushSwitcher.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbFillBrushSwitcher.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSolidBrush,
            this.tsmiLinearGradientBrush,
            this.tsmiRadialGradientBrush,
            this.tsmiHatchBrush,
            this.tsmiTextureBrush});
            this.tsddbFillBrushSwitcher.Image = ((System.Drawing.Image)(resources.GetObject("tsddbFillBrushSwitcher.Image")));
            this.tsddbFillBrushSwitcher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbFillBrushSwitcher.Name = "tsddbFillBrushSwitcher";
            this.tsddbFillBrushSwitcher.Size = new System.Drawing.Size(75, 28);
            this.tsddbFillBrushSwitcher.Text = "Fill: Select";
            this.tsddbFillBrushSwitcher.ButtonClick += new System.EventHandler(this.tsddbFillBrushSwitcher_Click);
            // 
            // tsmiSolidBrush
            // 
            this.tsmiSolidBrush.Name = "tsmiSolidBrush";
            this.tsmiSolidBrush.Size = new System.Drawing.Size(181, 22);
            this.tsmiSolidBrush.Text = "SolidBrush";
            this.tsmiSolidBrush.Click += new System.EventHandler(this.tsmiSolidBrush_Click);
            // 
            // tsmiLinearGradientBrush
            // 
            this.tsmiLinearGradientBrush.Name = "tsmiLinearGradientBrush";
            this.tsmiLinearGradientBrush.Size = new System.Drawing.Size(181, 22);
            this.tsmiLinearGradientBrush.Text = "LinearGradientBrush";
            this.tsmiLinearGradientBrush.Click += new System.EventHandler(this.tsmiSolidBrush_Click);
            // 
            // tsmiRadialGradientBrush
            // 
            this.tsmiRadialGradientBrush.Name = "tsmiRadialGradientBrush";
            this.tsmiRadialGradientBrush.Size = new System.Drawing.Size(181, 22);
            this.tsmiRadialGradientBrush.Text = "RadialGradientBrush";
            this.tsmiRadialGradientBrush.Click += new System.EventHandler(this.tsmiSolidBrush_Click);
            // 
            // tsmiHatchBrush
            // 
            this.tsmiHatchBrush.Name = "tsmiHatchBrush";
            this.tsmiHatchBrush.Size = new System.Drawing.Size(181, 22);
            this.tsmiHatchBrush.Text = "HatchBrush";
            this.tsmiHatchBrush.Click += new System.EventHandler(this.tsmiSolidBrush_Click);
            // 
            // tsmiTextureBrush
            // 
            this.tsmiTextureBrush.Name = "tsmiTextureBrush";
            this.tsmiTextureBrush.Size = new System.Drawing.Size(181, 22);
            this.tsmiTextureBrush.Text = "TextureBrush";
            this.tsmiTextureBrush.Click += new System.EventHandler(this.tsmiSolidBrush_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 31);
            // 
            // tsddbEffectSwitcher
            // 
            this.tsddbEffectSwitcher.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbEffectSwitcher.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNoneEffects,
            this.tsmiShadow,
            this.tsmiGlow,
            this.tsmiTextBlock});
            this.tsddbEffectSwitcher.Image = ((System.Drawing.Image)(resources.GetObject("tsddbEffectSwitcher.Image")));
            this.tsddbEffectSwitcher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbEffectSwitcher.Name = "tsddbEffectSwitcher";
            this.tsddbEffectSwitcher.Size = new System.Drawing.Size(88, 28);
            this.tsddbEffectSwitcher.Text = "Effect: None";
            this.tsddbEffectSwitcher.ButtonClick += new System.EventHandler(this.tsddbEffectSwitcher_ButtonClick);
            // 
            // tsmiNoneEffects
            // 
            this.tsmiNoneEffects.Name = "tsmiNoneEffects";
            this.tsmiNoneEffects.Size = new System.Drawing.Size(124, 22);
            this.tsmiNoneEffects.Text = "None";
            this.tsmiNoneEffects.Click += new System.EventHandler(this.tsmiNoneEffects_Click);
            // 
            // tsmiShadow
            // 
            this.tsmiShadow.Name = "tsmiShadow";
            this.tsmiShadow.Size = new System.Drawing.Size(124, 22);
            this.tsmiShadow.Text = "Shadow";
            this.tsmiShadow.Click += new System.EventHandler(this.tsmiNoneEffects_Click);
            // 
            // tsmiGlow
            // 
            this.tsmiGlow.Name = "tsmiGlow";
            this.tsmiGlow.Size = new System.Drawing.Size(124, 22);
            this.tsmiGlow.Text = "Glow";
            this.tsmiGlow.Click += new System.EventHandler(this.tsmiNoneEffects_Click);
            // 
            // tsmiTextBlock
            // 
            this.tsmiTextBlock.Name = "tsmiTextBlock";
            this.tsmiTextBlock.Size = new System.Drawing.Size(124, 22);
            this.tsmiTextBlock.Text = "TextBlock";
            this.tsmiTextBlock.Click += new System.EventHandler(this.tsmiNoneEffects_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 31);
            // 
            // lbZoom
            // 
            this.lbZoom.Name = "lbZoom";
            this.lbZoom.Size = new System.Drawing.Size(42, 28);
            this.lbZoom.Text = "Zoom:";
            // 
            // cbScaleFactor
            // 
            this.cbScaleFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScaleFactor.Items.AddRange(new object[] {
            "10%",
            "25%",
            "50%",
            "75%",
            "100%",
            "125%",
            "150%",
            "200%",
            "300%",
            "400%",
            "600%",
            "800%"});
            this.cbScaleFactor.Name = "cbScaleFactor";
            this.cbScaleFactor.Size = new System.Drawing.Size(75, 31);
            this.cbScaleFactor.SelectedIndexChanged += new System.EventHandler(this.cbScaleFactor_SelectedIndexChanged);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbBringToFront
            // 
            this.tsbBringToFront.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBringToFront.Image = global::SimpleEditor.Properties.Resources.bringtofront;
            this.tsbBringToFront.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbBringToFront.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBringToFront.Name = "tsbBringToFront";
            this.tsbBringToFront.Size = new System.Drawing.Size(23, 28);
            this.tsbBringToFront.Text = "Выдвинуть вперёд";
            this.tsbBringToFront.Click += new System.EventHandler(this.tsmiBringToFront_Click);
            // 
            // tsbSendToBack
            // 
            this.tsbSendToBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSendToBack.Image = global::SimpleEditor.Properties.Resources.sendtoback;
            this.tsbSendToBack.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSendToBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSendToBack.Name = "tsbSendToBack";
            this.tsbSendToBack.Size = new System.Drawing.Size(23, 28);
            this.tsbSendToBack.Text = "Поместить назад";
            this.tsbSendToBack.Click += new System.EventHandler(this.tsmiSendToBack_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbGroup
            // 
            this.tsbGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGroup.Image = global::SimpleEditor.Properties.Resources.grouping;
            this.tsbGroup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGroup.Name = "tsbGroup";
            this.tsbGroup.Size = new System.Drawing.Size(23, 28);
            this.tsbGroup.Text = "Группировать";
            this.tsbGroup.Click += new System.EventHandler(this.tsmiGroup_Click);
            // 
            // tsbUngroup
            // 
            this.tsbUngroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUngroup.Image = global::SimpleEditor.Properties.Resources.ungrouping;
            this.tsbUngroup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbUngroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUngroup.Name = "tsbUngroup";
            this.tsbUngroup.Size = new System.Drawing.Size(23, 28);
            this.tsbUngroup.Text = "Разгруппировать";
            this.tsbUngroup.Click += new System.EventHandler(this.tsmiUngroup_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbFlipX
            // 
            this.tsbFlipX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFlipX.Image = global::SimpleEditor.Properties.Resources.flipleftright;
            this.tsbFlipX.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFlipX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFlipX.Name = "tsbFlipX";
            this.tsbFlipX.Size = new System.Drawing.Size(23, 28);
            this.tsbFlipX.Text = "Flip X";
            this.tsbFlipX.Click += new System.EventHandler(this.tsmiFlipX_Click);
            // 
            // tsbFlipY
            // 
            this.tsbFlipY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFlipY.Image = global::SimpleEditor.Properties.Resources.flipupdown;
            this.tsbFlipY.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFlipY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFlipY.Name = "tsbFlipY";
            this.tsbFlipY.Size = new System.Drawing.Size(23, 28);
            this.tsbFlipY.Text = "Flip Y";
            this.tsbFlipY.Click += new System.EventHandler(this.tsmiFlipY_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbRotate90Ccw
            // 
            this.tsbRotate90Ccw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRotate90Ccw.Image = global::SimpleEditor.Properties.Resources.rotateleft;
            this.tsbRotate90Ccw.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRotate90Ccw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRotate90Ccw.Name = "tsbRotate90Ccw";
            this.tsbRotate90Ccw.Size = new System.Drawing.Size(23, 28);
            this.tsbRotate90Ccw.Text = "Rotate 90° CCW";
            this.tsbRotate90Ccw.Click += new System.EventHandler(this.tsmiRotate90Ccw_Click);
            // 
            // tsbRotate90Cw
            // 
            this.tsbRotate90Cw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRotate90Cw.Image = global::SimpleEditor.Properties.Resources.rotateright;
            this.tsbRotate90Cw.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRotate90Cw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRotate90Cw.Name = "tsbRotate90Cw";
            this.tsbRotate90Cw.Size = new System.Drawing.Size(23, 28);
            this.tsbRotate90Cw.Text = "Rotate 90° CCW";
            this.tsbRotate90Cw.Click += new System.EventHandler(this.tsmiRotate90Cw_Click);
            // 
            // tsbRotate180
            // 
            this.tsbRotate180.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRotate180.Image = global::SimpleEditor.Properties.Resources.rotate180;
            this.tsbRotate180.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRotate180.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRotate180.Name = "tsbRotate180";
            this.tsbRotate180.Size = new System.Drawing.Size(23, 28);
            this.tsbRotate180.Text = "Rotate at 180°";
            this.tsbRotate180.Click += new System.EventHandler(this.tsmiRotate180_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbAlignLeft
            // 
            this.tsbAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAlignLeft.Image = global::SimpleEditor.Properties.Resources.alignleft1;
            this.tsbAlignLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAlignLeft.Name = "tsbAlignLeft";
            this.tsbAlignLeft.Size = new System.Drawing.Size(23, 28);
            this.tsbAlignLeft.Text = "Выровнять по левой стороне";
            this.tsbAlignLeft.Click += new System.EventHandler(this.tsbAlignLeft_Click);
            // 
            // tsbAlignCenter
            // 
            this.tsbAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAlignCenter.Image = global::SimpleEditor.Properties.Resources.aligncenter1;
            this.tsbAlignCenter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAlignCenter.Name = "tsbAlignCenter";
            this.tsbAlignCenter.Size = new System.Drawing.Size(23, 28);
            this.tsbAlignCenter.Text = "Центрировать по вертикали";
            this.tsbAlignCenter.Click += new System.EventHandler(this.tsbAlignCenter_Click);
            // 
            // tsbAlignRight
            // 
            this.tsbAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAlignRight.Image = global::SimpleEditor.Properties.Resources.alignright1;
            this.tsbAlignRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAlignRight.Name = "tsbAlignRight";
            this.tsbAlignRight.Size = new System.Drawing.Size(23, 28);
            this.tsbAlignRight.Text = "Выровнять по правой стороне";
            this.tsbAlignRight.Click += new System.EventHandler(this.tsbAlignRight_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbAlignTop
            // 
            this.tsbAlignTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAlignTop.Image = global::SimpleEditor.Properties.Resources.aligntop;
            this.tsbAlignTop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAlignTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAlignTop.Name = "tsbAlignTop";
            this.tsbAlignTop.Size = new System.Drawing.Size(23, 28);
            this.tsbAlignTop.Text = "Выровнять по верхней стороне";
            this.tsbAlignTop.Click += new System.EventHandler(this.tsbAlignTop_Click);
            // 
            // tsbAlignMiddle
            // 
            this.tsbAlignMiddle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAlignMiddle.Image = global::SimpleEditor.Properties.Resources.alignmiddle;
            this.tsbAlignMiddle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAlignMiddle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAlignMiddle.Name = "tsbAlignMiddle";
            this.tsbAlignMiddle.Size = new System.Drawing.Size(23, 28);
            this.tsbAlignMiddle.Text = "Центрировать по горизонтали";
            this.tsbAlignMiddle.Click += new System.EventHandler(this.tsbAlignMiddle_Click);
            // 
            // tsbAlignBottom
            // 
            this.tsbAlignBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAlignBottom.Image = global::SimpleEditor.Properties.Resources.alignbottom;
            this.tsbAlignBottom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAlignBottom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAlignBottom.Name = "tsbAlignBottom";
            this.tsbAlignBottom.Size = new System.Drawing.Size(23, 28);
            this.tsbAlignBottom.Text = "Выровнять по нижней стороне";
            this.tsbAlignBottom.Click += new System.EventHandler(this.tsbAlignBottom_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbSameWidth
            // 
            this.tsbSameWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSameWidth.Image = global::SimpleEditor.Properties.Resources.samewidth;
            this.tsbSameWidth.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSameWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSameWidth.Name = "tsbSameWidth";
            this.tsbSameWidth.Size = new System.Drawing.Size(23, 28);
            this.tsbSameWidth.Text = "Сделать одинаковой ширину";
            this.tsbSameWidth.Click += new System.EventHandler(this.tsbSameWidth_Click);
            // 
            // tsbSameHeight
            // 
            this.tsbSameHeight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSameHeight.Image = global::SimpleEditor.Properties.Resources.sameheight;
            this.tsbSameHeight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSameHeight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSameHeight.Name = "tsbSameHeight";
            this.tsbSameHeight.Size = new System.Drawing.Size(23, 28);
            this.tsbSameHeight.Text = "Сделать одинаковой высоту";
            this.tsbSameHeight.Click += new System.EventHandler(this.tsbSameHeight_Click);
            // 
            // tsbSameBothSizes
            // 
            this.tsbSameBothSizes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSameBothSizes.Image = global::SimpleEditor.Properties.Resources.sameboth;
            this.tsbSameBothSizes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSameBothSizes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSameBothSizes.Name = "tsbSameBothSizes";
            this.tsbSameBothSizes.Size = new System.Drawing.Size(23, 28);
            this.tsbSameBothSizes.Text = "Сделать одинаковыми оба размера";
            this.tsbSameBothSizes.Click += new System.EventHandler(this.tsbSameBothSizes_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbEvenHorizontalSpaces
            // 
            this.tsbEvenHorizontalSpaces.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEvenHorizontalSpaces.Image = global::SimpleEditor.Properties.Resources.evhor;
            this.tsbEvenHorizontalSpaces.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEvenHorizontalSpaces.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEvenHorizontalSpaces.Name = "tsbEvenHorizontalSpaces";
            this.tsbEvenHorizontalSpaces.Size = new System.Drawing.Size(23, 28);
            this.tsbEvenHorizontalSpaces.Text = "Выровнять горизонтальные промежутки";
            this.tsbEvenHorizontalSpaces.Click += new System.EventHandler(this.tsbEvenHorizontalSpaces_Click);
            // 
            // tsbEvenVerticalSpaces
            // 
            this.tsbEvenVerticalSpaces.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEvenVerticalSpaces.Image = global::SimpleEditor.Properties.Resources.evver;
            this.tsbEvenVerticalSpaces.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEvenVerticalSpaces.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEvenVerticalSpaces.Name = "tsbEvenVerticalSpaces";
            this.tsbEvenVerticalSpaces.Size = new System.Drawing.Size(23, 28);
            this.tsbEvenVerticalSpaces.Text = "Выровнять вертикальные промежутки";
            this.tsbEvenVerticalSpaces.Click += new System.EventHandler(this.tsbEvenVerticalSpaces_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbLock
            // 
            this.tsbLock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLock.Enabled = false;
            this.tsbLock.Image = global::SimpleEditor.Properties.Resources.lockpos;
            this.tsbLock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLock.Name = "tsbLock";
            this.tsbLock.Size = new System.Drawing.Size(23, 28);
            this.tsbLock.Text = "Lock (unlock) move figures";
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbConvertToPath
            // 
            this.tsbConvertToPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbConvertToPath.Enabled = false;
            this.tsbConvertToPath.Image = global::SimpleEditor.Properties.Resources.converttopath;
            this.tsbConvertToPath.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbConvertToPath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConvertToPath.Name = "tsbConvertToPath";
            this.tsbConvertToPath.Size = new System.Drawing.Size(28, 28);
            this.tsbConvertToPath.Text = "Convert To Path";
            this.tsbConvertToPath.Click += new System.EventHandler(this.tsbConvertToPath_Click);
            // 
            // timerCheckClipboard
            // 
            this.timerCheckClipboard.Enabled = true;
            this.timerCheckClipboard.Interval = 300;
            this.timerCheckClipboard.Tick += new System.EventHandler(this.timerCheckClipboard_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tsArrange, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolStripFile, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.menuStripMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1080, 543);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tsbCreateTools, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.splitContainer1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 84);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1074, 434);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(35, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelForScroll);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1036, 428);
            this.splitContainer1.SplitterDistance = 757;
            this.splitContainer1.TabIndex = 9;
            // 
            // panelForScroll
            // 
            this.panelForScroll.AllowDrop = true;
            this.panelForScroll.AutoScroll = true;
            this.panelForScroll.BackColor = System.Drawing.Color.Transparent;
            this.panelForScroll.BackgroundImage = global::SimpleEditor.Properties.Resources.transparent1;
            this.panelForScroll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForScroll.Controls.Add(this.pbCanvas);
            this.panelForScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForScroll.Location = new System.Drawing.Point(0, 0);
            this.panelForScroll.Name = "panelForScroll";
            this.panelForScroll.Size = new System.Drawing.Size(757, 428);
            this.panelForScroll.TabIndex = 7;
            this.panelForScroll.SizeChanged += new System.EventHandler(this.panelForScroll_SizeChanged);
            this.panelForScroll.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelForScroll_DragDrop);
            this.panelForScroll.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelForScroll_DragEnter);
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.Color.Transparent;
            this.pbCanvas.ContextMenuStrip = this.cmsCanvasPopup;
            this.pbCanvas.Location = new System.Drawing.Point(0, 0);
            this.pbCanvas.Margin = new System.Windows.Forms.Padding(0);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(739, 289);
            this.pbCanvas.TabIndex = 6;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            this.pbCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseDown);
            this.pbCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseMove);
            this.pbCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseUp);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvFigures);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pnTools);
            this.splitContainer2.Size = new System.Drawing.Size(275, 428);
            this.splitContainer2.SplitterDistance = 208;
            this.splitContainer2.TabIndex = 0;
            // 
            // tvFigures
            // 
            this.tvFigures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFigures.FullRowSelect = true;
            this.tvFigures.HideSelection = false;
            this.tvFigures.Location = new System.Drawing.Point(0, 0);
            this.tvFigures.Name = "tvFigures";
            this.tvFigures.ShowNodeToolTips = true;
            this.tvFigures.Size = new System.Drawing.Size(275, 208);
            this.tvFigures.TabIndex = 0;
            this.tvFigures.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFigures_AfterSelect);
            // 
            // btnTextOnBezier
            // 
            this.btnTextOnBezier.Image = global::SimpleEditor.Properties.Resources.beziertext;
            this.btnTextOnBezier.Name = "btnTextOnBezier";
            this.btnTextOnBezier.Size = new System.Drawing.Size(180, 22);
            this.btnTextOnBezier.Text = "Text on bezier";
            this.btnTextOnBezier.Click += new System.EventHandler(this.btnCreateFigure_Click);
            // 
            // FormSimpleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 543);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Name = "FormSimpleEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Simple Vector Graphics Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSimpleEditor_FormClosing);
            this.Load += new System.EventHandler(this.FormSimpleEditor_Load);
            this.cmsCanvasPopup.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.toolStripFile.ResumeLayout(false);
            this.toolStripFile.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tsbCreateTools.ResumeLayout(false);
            this.tsbCreateTools.PerformLayout();
            this.tsArrange.ResumeLayout(false);
            this.tsArrange.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelForScroll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.Panel panelForScroll;
        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.MenuStrip menuStripMain;
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
        private System.Windows.Forms.SaveFileDialog saveEditorFileDialog;
        private System.Windows.Forms.OpenFileDialog openEditorFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslRibbonRect;
        private System.Windows.Forms.ToolStripStatusLabel tsslEditorMode;
        private System.Windows.Forms.ContextMenuStrip cmsCanvasPopup;
        private System.Windows.Forms.ToolStripMenuItem tsmiPaste;
        private System.Windows.Forms.FlowLayoutPanel pnTools;
        private System.Windows.Forms.ToolStrip tsArrange;
        private System.Windows.Forms.ToolStripButton tsbBringToFront;
        private System.Windows.Forms.ToolStripButton tsbSendToBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton tsbGroup;
        private System.Windows.Forms.ToolStripButton tsbUngroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton tsbAlignLeft;
        private System.Windows.Forms.ToolStripButton tsbAlignCenter;
        private System.Windows.Forms.ToolStripButton tsbAlignRight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton tsbAlignTop;
        private System.Windows.Forms.ToolStripButton tsbAlignMiddle;
        private System.Windows.Forms.ToolStripButton tsbAlignBottom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton tsbSameWidth;
        private System.Windows.Forms.ToolStripButton tsbSameHeight;
        private System.Windows.Forms.ToolStripButton tsbSameBothSizes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton tsbEvenHorizontalSpaces;
        private System.Windows.Forms.ToolStripButton tsbEvenVerticalSpaces;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripButton tsbLock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripSplitButton tsddbGeometySwitcher;
        private System.Windows.Forms.ToolStripMenuItem tsmiCyrcle;
        private System.Windows.Forms.ToolStripMenuItem tsmiRectangle;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegularTriangle;
        private System.Windows.Forms.ToolStripMenuItem tsmiSquare;
        private System.Windows.Forms.ToolStripMenuItem tsmiRomb;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegular5gon;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegular6gon;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegular7gon;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegular8gon;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegular9gon;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegular10gon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSplitButton tsddbFillBrushSwitcher;
        private System.Windows.Forms.ToolStripMenuItem tsmiSolidBrush;
        private System.Windows.Forms.ToolStripMenuItem tsmiLinearGradientBrush;
        private System.Windows.Forms.ToolStripMenuItem tsmiEllipse;
        private System.Windows.Forms.ToolStripSplitButton tsddbEffectSwitcher;
        private System.Windows.Forms.ToolStripMenuItem tsmiNoneEffects;
        private System.Windows.Forms.ToolStripMenuItem tsmiShadow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiDuplicateFigure;
        private System.Windows.Forms.ToolStripMenuItem tsmDuplicateFigure;
        private System.Windows.Forms.ToolStripMenuItem tsmiGlow;
        private System.Windows.Forms.ToolStripButton tsbFlipX;
        private System.Windows.Forms.ToolStripButton tsbFlipY;
        private System.Windows.Forms.ToolStripButton tsbRotate90Ccw;
        private System.Windows.Forms.ToolStripButton tsbRotate90Cw;
        private System.Windows.Forms.ToolStripButton tsbRotate180;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStrip tsbCreateTools;
        private System.Windows.Forms.ToolStripButton tsbSelectMode;
        private System.Windows.Forms.ToolStripSplitButton tsbRect;
        private System.Windows.Forms.ToolStripMenuItem btnRectangle;
        private System.Windows.Forms.ToolStripMenuItem btnSquare;
        private System.Windows.Forms.ToolStripMenuItem btnEllipse;
        private System.Windows.Forms.ToolStripMenuItem btnCircle;
        private System.Windows.Forms.ToolStripSplitButton tsbRomb;
        private System.Windows.Forms.ToolStripMenuItem btnRegular3;
        private System.Windows.Forms.ToolStripMenuItem btnRegular4;
        private System.Windows.Forms.ToolStripMenuItem btnRegular5;
        private System.Windows.Forms.ToolStripMenuItem btnRegular6;
        private System.Windows.Forms.ToolStripMenuItem btnRegular7;
        private System.Windows.Forms.ToolStripMenuItem btnRegular8;
        private System.Windows.Forms.ToolStripMenuItem btnRegular9;
        private System.Windows.Forms.ToolStripMenuItem btnRegular10;
        private System.Windows.Forms.ToolStripSplitButton tsbText;
        private System.Windows.Forms.ToolStripMenuItem btnTextBlock;
        private System.Windows.Forms.ToolStripButton tsbSkewMode;
        private System.Windows.Forms.ToolStripButton tsbVertexMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSplitButton tsbPolyline;
        private System.Windows.Forms.ToolStripMenuItem btnPolyline;
        private System.Windows.Forms.ToolStripSplitButton tsbPicture;
        private System.Windows.Forms.ToolStripMenuItem btnInsertImage;
        private System.Windows.Forms.ToolStripMenuItem btnLoadGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton tsbConvertToPath;
        private System.Windows.Forms.Timer timerCheckClipboard;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tvFigures;
        private System.Windows.Forms.ToolStripButton tsbArrow;
        private System.Windows.Forms.ToolStripMenuItem btnText;
        private System.Windows.Forms.ToolStripMenuItem tsmiHatchBrush;
        private System.Windows.Forms.ToolStripMenuItem tsmiRadialGradientBrush;
        private System.Windows.Forms.ToolStripMenuItem btnSegment;
        private System.Windows.Forms.ToolStripMenuItem btnPie;
        private System.Windows.Forms.ToolStripMenuItem btnArc;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiTextBlock;
        private System.Windows.Forms.ToolStripComboBox cbScaleFactor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripLabel lbZoom;
        private System.Windows.Forms.ToolStripMenuItem btnBezier;
        private System.Windows.Forms.ToolStripMenuItem tsmiTextureBrush;
        private System.Windows.Forms.ToolStripMenuItem btnTextOnBezier;
    }
}

