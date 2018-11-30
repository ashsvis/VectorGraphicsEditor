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
            this.cmsCanvasPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miPasteFromBufferSplitter = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDefaultSelectMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSkewSelectMode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRotate180 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.tsmFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmDefaultSelectMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSkewSelectMode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmRotate180 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFigures = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripFile = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsFigurePopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNodeSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.miAddFigureNode = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteFigureNode = new System.Windows.Forms.ToolStripMenuItem();
            this.miEndChangeNodes = new System.Windows.Forms.ToolStripMenuItem();
            this.miStrokeSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiTransformsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiTransforms = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFiguresFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFiguresFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslEditorMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslRibbonRect = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.tsbArrow = new System.Windows.Forms.ToolStripButton();
            this.tsbPolyline = new System.Windows.Forms.ToolStripButton();
            this.tsbPolygon = new System.Windows.Forms.ToolStripButton();
            this.tsbRect = new System.Windows.Forms.ToolStripButton();
            this.tsbSquare = new System.Windows.Forms.ToolStripButton();
            this.tsbEllipse = new System.Windows.Forms.ToolStripButton();
            this.tsbCircle = new System.Windows.Forms.ToolStripButton();
            this.tsbRegular4 = new System.Windows.Forms.ToolStripButton();
            this.tsbRegular8 = new System.Windows.Forms.ToolStripButton();
            this.tsbRegular16 = new System.Windows.Forms.ToolStripButton();
            this.tsbRegular24 = new System.Windows.Forms.ToolStripButton();
            this.tsbRegular32 = new System.Windows.Forms.ToolStripButton();
            this.tsbText = new System.Windows.Forms.ToolStripButton();
            this.tsmCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVerticiesSelectMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBringToFront = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSendToBack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFlipX = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFlipY = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRotate90Ccw = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRotate90Cw = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUngroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbCut = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.tsbUndo = new System.Windows.Forms.ToolStripButton();
            this.tsbRedo = new System.Windows.Forms.ToolStripButton();
            this.tsbHelp = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVerticiesSelectMode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBringToFront = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSendToBack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFlipX = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFlipY = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRotate90Ccw = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRotate90Cw = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUngroup = new System.Windows.Forms.ToolStripMenuItem();
            this.miCutPopup = new System.Windows.Forms.ToolStripMenuItem();
            this.miCopyPopup = new System.Windows.Forms.ToolStripMenuItem();
            this.miBeginChangeNodes = new System.Windows.Forms.ToolStripMenuItem();
            this.miStroke = new System.Windows.Forms.ToolStripMenuItem();
            this.miFill = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.miUngroupFigures = new System.Windows.Forms.ToolStripMenuItem();
            this.miBringToFront = new System.Windows.Forms.ToolStripMenuItem();
            this.miSendToBack = new System.Windows.Forms.ToolStripMenuItem();
            this.miTurnLeft90 = new System.Windows.Forms.ToolStripMenuItem();
            this.miTurnRight90 = new System.Windows.Forms.ToolStripMenuItem();
            this.miFlipVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.miFlipHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.panelForScroll.SuspendLayout();
            this.cmsCanvasPopup.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.tsFigures.SuspendLayout();
            this.toolStripFile.SuspendLayout();
            this.cmsFigurePopup.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // tsmSelectAll
            // 
            this.tsmSelectAll.Enabled = false;
            this.tsmSelectAll.Name = "tsmSelectAll";
            this.tsmSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmSelectAll.Size = new System.Drawing.Size(162, 22);
            this.tsmSelectAll.Text = "Select &all";
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
            this.panelForScroll.Location = new System.Drawing.Point(0, 0);
            this.panelForScroll.Name = "panelForScroll";
            this.panelForScroll.Size = new System.Drawing.Size(857, 444);
            this.panelForScroll.TabIndex = 7;
            // 
            // cmsCanvasPopup
            // 
            this.cmsCanvasPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.miPasteFromBufferSplitter,
            this.tsmiDefaultSelectMode,
            this.tsmiSkewSelectMode,
            this.tsmiVerticiesSelectMode,
            this.toolStripMenuItem10,
            this.tsmiBringToFront,
            this.tsmiSendToBack,
            this.toolStripMenuItem4,
            this.tsmiFlipX,
            this.tsmiFlipY,
            this.toolStripMenuItem5,
            this.tsmiRotate90Ccw,
            this.tsmiRotate90Cw,
            this.tsmiRotate180,
            this.toolStripMenuItem12,
            this.tsmiGroup,
            this.tsmiUngroup});
            this.cmsCanvasPopup.Name = "cmsBkgPopup";
            this.cmsCanvasPopup.Size = new System.Drawing.Size(159, 320);
            this.cmsCanvasPopup.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCanvasPopup_Opening);
            // 
            // miPasteFromBufferSplitter
            // 
            this.miPasteFromBufferSplitter.Name = "miPasteFromBufferSplitter";
            this.miPasteFromBufferSplitter.Size = new System.Drawing.Size(155, 6);
            this.miPasteFromBufferSplitter.Visible = false;
            // 
            // tsmiDefaultSelectMode
            // 
            this.tsmiDefaultSelectMode.Name = "tsmiDefaultSelectMode";
            this.tsmiDefaultSelectMode.Size = new System.Drawing.Size(158, 22);
            this.tsmiDefaultSelectMode.Text = "Selection";
            this.tsmiDefaultSelectMode.Click += new System.EventHandler(this.tsmDefaultSelectMode_Click);
            // 
            // tsmiSkewSelectMode
            // 
            this.tsmiSkewSelectMode.Name = "tsmiSkewSelectMode";
            this.tsmiSkewSelectMode.Size = new System.Drawing.Size(158, 22);
            this.tsmiSkewSelectMode.Text = "Skew";
            this.tsmiSkewSelectMode.Click += new System.EventHandler(this.tsmiSkewSelectMode_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(155, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(155, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(155, 6);
            // 
            // tsmiRotate180
            // 
            this.tsmiRotate180.Name = "tsmiRotate180";
            this.tsmiRotate180.Size = new System.Drawing.Size(158, 22);
            this.tsmiRotate180.Text = "Rotate at 180°";
            this.tsmiRotate180.Click += new System.EventHandler(this.tsmiRotate180_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(155, 6);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFileMenu,
            this.tsmEditMenu});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(888, 24);
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
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // tsmSaveAs
            // 
            this.tsmSaveAs.Name = "tsmSaveAs";
            this.tsmSaveAs.Size = new System.Drawing.Size(146, 22);
            this.tsmSaveAs.Text = "Save &as...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(146, 22);
            this.tsmExit.Text = "E&xit";
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
            this.tsmSelectAll,
            this.toolStripMenuItem2,
            this.tsmDefaultSelectMode,
            this.tsmSkewSelectMode,
            this.tsmVerticiesSelectMode,
            this.toolStripMenuItem11,
            this.tsmBringToFront,
            this.tsmSendToBack,
            this.toolStripMenuItem8,
            this.tsmFlipX,
            this.tsmFlipY,
            this.toolStripMenuItem9,
            this.tsmRotate90Ccw,
            this.tsmRotate90Cw,
            this.tsmRotate180,
            this.toolStripMenuItem13,
            this.tsmGroup,
            this.tsmUngroup});
            this.tsmEditMenu.Name = "tsmEditMenu";
            this.tsmEditMenu.Size = new System.Drawing.Size(39, 20);
            this.tsmEditMenu.Text = "&Edit";
            this.tsmEditMenu.DropDownOpening += new System.EventHandler(this.tsmEditMenu_DropDownOpening);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(159, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(159, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(159, 6);
            // 
            // tsmDefaultSelectMode
            // 
            this.tsmDefaultSelectMode.Name = "tsmDefaultSelectMode";
            this.tsmDefaultSelectMode.Size = new System.Drawing.Size(162, 22);
            this.tsmDefaultSelectMode.Text = "Selection";
            this.tsmDefaultSelectMode.Click += new System.EventHandler(this.tsmDefaultSelectMode_Click);
            // 
            // tsmSkewSelectMode
            // 
            this.tsmSkewSelectMode.Name = "tsmSkewSelectMode";
            this.tsmSkewSelectMode.Size = new System.Drawing.Size(162, 22);
            this.tsmSkewSelectMode.Text = "Skew";
            this.tsmSkewSelectMode.Click += new System.EventHandler(this.tsmiSkewSelectMode_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(159, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(159, 6);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(159, 6);
            // 
            // tsmRotate180
            // 
            this.tsmRotate180.Name = "tsmRotate180";
            this.tsmRotate180.Size = new System.Drawing.Size(162, 22);
            this.tsmRotate180.Text = "Rotate at 180°";
            this.tsmRotate180.Click += new System.EventHandler(this.tsmiRotate180_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(159, 6);
            // 
            // tsFigures
            // 
            this.tsFigures.Dock = System.Windows.Forms.DockStyle.None;
            this.tsFigures.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsFigures.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbArrow,
            this.tsbPolyline,
            this.tsbPolygon,
            this.tsbRect,
            this.tsbSquare,
            this.tsbEllipse,
            this.tsbCircle,
            this.toolStripSeparator8,
            this.tsbRegular4,
            this.tsbRegular8,
            this.tsbRegular16,
            this.tsbRegular24,
            this.tsbRegular32,
            this.toolStripSeparator5,
            this.tsbText});
            this.tsFigures.Location = new System.Drawing.Point(0, 0);
            this.tsFigures.Name = "tsFigures";
            this.tsFigures.Padding = new System.Windows.Forms.Padding(0);
            this.tsFigures.Size = new System.Drawing.Size(31, 444);
            this.tsFigures.Stretch = true;
            this.tsFigures.TabIndex = 8;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(30, 6);
            // 
            // toolStripFile
            // 
            this.toolStripFile.Dock = System.Windows.Forms.DockStyle.None;
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
            this.toolStripFile.Size = new System.Drawing.Size(888, 25);
            this.toolStripFile.Stretch = true;
            this.toolStripFile.TabIndex = 1;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(231, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(231, 6);
            this.toolStripMenuItem3.Visible = false;
            // 
            // cmsFigurePopup
            // 
            this.cmsFigurePopup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmsFigurePopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.cmsFigurePopup.Name = "cmsFigPopup";
            this.cmsFigurePopup.Size = new System.Drawing.Size(235, 320);
            // 
            // tsmiNodeSeparator
            // 
            this.tsmiNodeSeparator.Name = "tsmiNodeSeparator";
            this.tsmiNodeSeparator.Size = new System.Drawing.Size(231, 6);
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
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelForScroll);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(857, 444);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.tsFigures);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(888, 515);
            this.toolStripContainer1.TabIndex = 5;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStripMain);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripFile);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslEditorMode,
            this.tsslRibbonRect});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(888, 22);
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
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(30, 6);
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pbCanvas.ContextMenuStrip = this.cmsCanvasPopup;
            this.pbCanvas.Location = new System.Drawing.Point(0, 0);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Padding = new System.Windows.Forms.Padding(4);
            this.pbCanvas.Size = new System.Drawing.Size(882, 498);
            this.pbCanvas.TabIndex = 6;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            this.pbCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseDown);
            this.pbCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseMove);
            this.pbCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbCanvas_MouseUp);
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
            this.tsbArrow.Size = new System.Drawing.Size(30, 20);
            this.tsbArrow.Text = "Выбор фигур";
            this.tsbArrow.Click += new System.EventHandler(this.tsbArrow_Click);
            // 
            // tsbPolyline
            // 
            this.tsbPolyline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPolyline.Image = global::SimpleEditor.Properties.Resources.poliline;
            this.tsbPolyline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPolyline.Name = "tsbPolyline";
            this.tsbPolyline.Size = new System.Drawing.Size(30, 20);
            this.tsbPolyline.Text = "Линия";
            this.tsbPolyline.ToolTipText = "Линия";
            this.tsbPolyline.Click += new System.EventHandler(this.tsbArrow_Click);
            // 
            // tsbPolygon
            // 
            this.tsbPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPolygon.Image = global::SimpleEditor.Properties.Resources.poligon;
            this.tsbPolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPolygon.Name = "tsbPolygon";
            this.tsbPolygon.Size = new System.Drawing.Size(30, 20);
            this.tsbPolygon.Text = "Полигон";
            this.tsbPolygon.ToolTipText = "Полигон";
            this.tsbPolygon.Click += new System.EventHandler(this.tsbArrow_Click);
            // 
            // tsbRect
            // 
            this.tsbRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRect.Image = global::SimpleEditor.Properties.Resources.rect;
            this.tsbRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRect.Name = "tsbRect";
            this.tsbRect.Size = new System.Drawing.Size(30, 20);
            this.tsbRect.Text = "Прямоугольник";
            this.tsbRect.Click += new System.EventHandler(this.tsbArrow_Click);
            // 
            // tsbSquare
            // 
            this.tsbSquare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSquare.Image = global::SimpleEditor.Properties.Resources.square;
            this.tsbSquare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSquare.Name = "tsbSquare";
            this.tsbSquare.Size = new System.Drawing.Size(30, 20);
            this.tsbSquare.Text = "Квадрат";
            this.tsbSquare.Click += new System.EventHandler(this.tsbArrow_Click);
            // 
            // tsbEllipse
            // 
            this.tsbEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEllipse.Image = global::SimpleEditor.Properties.Resources.ellipse;
            this.tsbEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEllipse.Name = "tsbEllipse";
            this.tsbEllipse.Size = new System.Drawing.Size(30, 20);
            this.tsbEllipse.Text = "Эллипс";
            this.tsbEllipse.Click += new System.EventHandler(this.tsbArrow_Click);
            // 
            // tsbCircle
            // 
            this.tsbCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCircle.Image = global::SimpleEditor.Properties.Resources.circle;
            this.tsbCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCircle.Name = "tsbCircle";
            this.tsbCircle.Size = new System.Drawing.Size(30, 20);
            this.tsbCircle.Text = "Круг";
            this.tsbCircle.Click += new System.EventHandler(this.tsbArrow_Click);
            // 
            // tsbRegular4
            // 
            this.tsbRegular4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRegular4.Image = global::SimpleEditor.Properties.Resources.regular4;
            this.tsbRegular4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRegular4.Name = "tsbRegular4";
            this.tsbRegular4.Size = new System.Drawing.Size(30, 20);
            this.tsbRegular4.Text = "Regular 4";
            this.tsbRegular4.Click += new System.EventHandler(this.tsbArrow_Click);
            // 
            // tsbRegular8
            // 
            this.tsbRegular8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRegular8.Image = global::SimpleEditor.Properties.Resources.regular8;
            this.tsbRegular8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRegular8.Name = "tsbRegular8";
            this.tsbRegular8.Size = new System.Drawing.Size(30, 20);
            this.tsbRegular8.Text = "Regular 8";
            this.tsbRegular8.Click += new System.EventHandler(this.tsbArrow_Click);
            // 
            // tsbRegular16
            // 
            this.tsbRegular16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRegular16.Image = global::SimpleEditor.Properties.Resources.regular16;
            this.tsbRegular16.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRegular16.Name = "tsbRegular16";
            this.tsbRegular16.Size = new System.Drawing.Size(30, 20);
            this.tsbRegular16.Text = "Regular 16";
            this.tsbRegular16.Click += new System.EventHandler(this.tsbArrow_Click);
            // 
            // tsbRegular24
            // 
            this.tsbRegular24.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRegular24.Image = global::SimpleEditor.Properties.Resources.regular24;
            this.tsbRegular24.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRegular24.Name = "tsbRegular24";
            this.tsbRegular24.Size = new System.Drawing.Size(30, 20);
            this.tsbRegular24.Text = "Regular 24";
            this.tsbRegular24.Click += new System.EventHandler(this.tsbArrow_Click);
            // 
            // tsbRegular32
            // 
            this.tsbRegular32.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRegular32.Image = global::SimpleEditor.Properties.Resources.regular32;
            this.tsbRegular32.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRegular32.Name = "tsbRegular32";
            this.tsbRegular32.Size = new System.Drawing.Size(30, 20);
            this.tsbRegular32.Text = "Regular 32";
            this.tsbRegular32.Click += new System.EventHandler(this.tsbArrow_Click);
            // 
            // tsbText
            // 
            this.tsbText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbText.Image = global::SimpleEditor.Properties.Resources.text;
            this.tsbText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbText.Name = "tsbText";
            this.tsbText.Size = new System.Drawing.Size(30, 20);
            this.tsbText.Text = "Текст";
            this.tsbText.Click += new System.EventHandler(this.tsbArrow_Click);
            // 
            // tsmCreate
            // 
            this.tsmCreate.Image = ((System.Drawing.Image)(resources.GetObject("tsmCreate.Image")));
            this.tsmCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmCreate.Name = "tsmCreate";
            this.tsmCreate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmCreate.Size = new System.Drawing.Size(146, 22);
            this.tsmCreate.Text = "&New";
            // 
            // tsmOpen
            // 
            this.tsmOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsmOpen.Image")));
            this.tsmOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmOpen.Size = new System.Drawing.Size(146, 22);
            this.tsmOpen.Text = "&Open";
            // 
            // tsmSave
            // 
            this.tsmSave.Enabled = false;
            this.tsmSave.Image = ((System.Drawing.Image)(resources.GetObject("tsmSave.Image")));
            this.tsmSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmSave.Size = new System.Drawing.Size(146, 22);
            this.tsmSave.Text = "&Save";
            // 
            // tsmPrint
            // 
            this.tsmPrint.Enabled = false;
            this.tsmPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsmPrint.Image")));
            this.tsmPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmPrint.Name = "tsmPrint";
            this.tsmPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsmPrint.Size = new System.Drawing.Size(146, 22);
            this.tsmPrint.Text = "&Print";
            // 
            // tsmPreview
            // 
            this.tsmPreview.Enabled = false;
            this.tsmPreview.Image = ((System.Drawing.Image)(resources.GetObject("tsmPreview.Image")));
            this.tsmPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmPreview.Name = "tsmPreview";
            this.tsmPreview.Size = new System.Drawing.Size(146, 22);
            this.tsmPreview.Text = "Pre&view";
            // 
            // tsmUndo
            // 
            this.tsmUndo.Enabled = false;
            this.tsmUndo.Image = global::SimpleEditor.Properties.Resources.undo;
            this.tsmUndo.Name = "tsmUndo";
            this.tsmUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.tsmUndo.Size = new System.Drawing.Size(162, 22);
            this.tsmUndo.Text = "&Undo";
            this.tsmUndo.Click += new System.EventHandler(this.tsmUndo_Click);
            // 
            // tsmRedo
            // 
            this.tsmRedo.Enabled = false;
            this.tsmRedo.Image = global::SimpleEditor.Properties.Resources.redo;
            this.tsmRedo.Name = "tsmRedo";
            this.tsmRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.tsmRedo.Size = new System.Drawing.Size(162, 22);
            this.tsmRedo.Text = "&Redo";
            this.tsmRedo.Click += new System.EventHandler(this.tsmRedo_Click);
            // 
            // tsmCut
            // 
            this.tsmCut.Enabled = false;
            this.tsmCut.Image = ((System.Drawing.Image)(resources.GetObject("tsmCut.Image")));
            this.tsmCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmCut.Name = "tsmCut";
            this.tsmCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmCut.Size = new System.Drawing.Size(162, 22);
            this.tsmCut.Text = "Cu&t";
            // 
            // tsmCopy
            // 
            this.tsmCopy.Enabled = false;
            this.tsmCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsmCopy.Image")));
            this.tsmCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmCopy.Name = "tsmCopy";
            this.tsmCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmCopy.Size = new System.Drawing.Size(162, 22);
            this.tsmCopy.Text = "&Copy";
            // 
            // tsmPaste
            // 
            this.tsmPaste.Enabled = false;
            this.tsmPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsmPaste.Image")));
            this.tsmPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmPaste.Name = "tsmPaste";
            this.tsmPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmPaste.Size = new System.Drawing.Size(162, 22);
            this.tsmPaste.Text = "&Paste";
            // 
            // tsmVerticiesSelectMode
            // 
            this.tsmVerticiesSelectMode.Image = global::SimpleEditor.Properties.Resources.startnodechanging;
            this.tsmVerticiesSelectMode.Name = "tsmVerticiesSelectMode";
            this.tsmVerticiesSelectMode.Size = new System.Drawing.Size(162, 22);
            this.tsmVerticiesSelectMode.Text = "Edit Verticies";
            this.tsmVerticiesSelectMode.Click += new System.EventHandler(this.tsmVerticiesSelectMode_Click);
            // 
            // tsmBringToFront
            // 
            this.tsmBringToFront.Image = global::SimpleEditor.Properties.Resources.bringtofront;
            this.tsmBringToFront.Name = "tsmBringToFront";
            this.tsmBringToFront.Size = new System.Drawing.Size(162, 22);
            this.tsmBringToFront.Text = "BringToFront";
            this.tsmBringToFront.Click += new System.EventHandler(this.tsmiBringToFront_Click);
            // 
            // tsmSendToBack
            // 
            this.tsmSendToBack.Image = global::SimpleEditor.Properties.Resources.sendtoback;
            this.tsmSendToBack.Name = "tsmSendToBack";
            this.tsmSendToBack.Size = new System.Drawing.Size(162, 22);
            this.tsmSendToBack.Text = "SendToBack";
            this.tsmSendToBack.Click += new System.EventHandler(this.tsmiSendToBack_Click);
            // 
            // tsmFlipX
            // 
            this.tsmFlipX.Image = global::SimpleEditor.Properties.Resources.flipleftright;
            this.tsmFlipX.Name = "tsmFlipX";
            this.tsmFlipX.Size = new System.Drawing.Size(162, 22);
            this.tsmFlipX.Text = "FlipX";
            this.tsmFlipX.Click += new System.EventHandler(this.tsmiFlipX_Click);
            // 
            // tsmFlipY
            // 
            this.tsmFlipY.Image = global::SimpleEditor.Properties.Resources.flipupdown;
            this.tsmFlipY.Name = "tsmFlipY";
            this.tsmFlipY.Size = new System.Drawing.Size(162, 22);
            this.tsmFlipY.Text = "FlipY";
            this.tsmFlipY.Click += new System.EventHandler(this.tsmiFlipY_Click);
            // 
            // tsmRotate90Ccw
            // 
            this.tsmRotate90Ccw.Image = global::SimpleEditor.Properties.Resources.rotateleft;
            this.tsmRotate90Ccw.Name = "tsmRotate90Ccw";
            this.tsmRotate90Ccw.Size = new System.Drawing.Size(162, 22);
            this.tsmRotate90Ccw.Text = "Rotate 90° CCW";
            this.tsmRotate90Ccw.Click += new System.EventHandler(this.tsmiRotate90Ccw_Click);
            // 
            // tsmRotate90Cw
            // 
            this.tsmRotate90Cw.Image = global::SimpleEditor.Properties.Resources.rotateright;
            this.tsmRotate90Cw.Name = "tsmRotate90Cw";
            this.tsmRotate90Cw.Size = new System.Drawing.Size(162, 22);
            this.tsmRotate90Cw.Text = "Rotate  90° CW";
            this.tsmRotate90Cw.Click += new System.EventHandler(this.tsmiRotate90Cw_Click);
            // 
            // tsmGroup
            // 
            this.tsmGroup.Image = global::SimpleEditor.Properties.Resources.grouping;
            this.tsmGroup.Name = "tsmGroup";
            this.tsmGroup.Size = new System.Drawing.Size(162, 22);
            this.tsmGroup.Text = "Group";
            this.tsmGroup.Click += new System.EventHandler(this.tsmiGroup_Click);
            // 
            // tsmUngroup
            // 
            this.tsmUngroup.Image = global::SimpleEditor.Properties.Resources.ungrouping;
            this.tsmUngroup.Name = "tsmUngroup";
            this.tsmUngroup.Size = new System.Drawing.Size(162, 22);
            this.tsmUngroup.Text = "Ungroup";
            this.tsmUngroup.Click += new System.EventHandler(this.tsmiUngroup_Click);
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
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbOpen.Text = "&Открыть";
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
            // tsbUndo
            // 
            this.tsbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUndo.Enabled = false;
            this.tsbUndo.Image = global::SimpleEditor.Properties.Resources.undo;
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
            this.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Size = new System.Drawing.Size(23, 22);
            this.tsbHelp.Text = "Спр&авка";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::SimpleEditor.Properties.Resources.insert;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem1.Text = "Paste";
            this.toolStripMenuItem1.Visible = false;
            // 
            // tsmiVerticiesSelectMode
            // 
            this.tsmiVerticiesSelectMode.Image = global::SimpleEditor.Properties.Resources.startnodechanging;
            this.tsmiVerticiesSelectMode.Name = "tsmiVerticiesSelectMode";
            this.tsmiVerticiesSelectMode.Size = new System.Drawing.Size(158, 22);
            this.tsmiVerticiesSelectMode.Text = "Edit Verticies";
            this.tsmiVerticiesSelectMode.Click += new System.EventHandler(this.tsmVerticiesSelectMode_Click);
            // 
            // tsmiBringToFront
            // 
            this.tsmiBringToFront.Image = global::SimpleEditor.Properties.Resources.bringtofront;
            this.tsmiBringToFront.Name = "tsmiBringToFront";
            this.tsmiBringToFront.Size = new System.Drawing.Size(158, 22);
            this.tsmiBringToFront.Text = "BringToFront";
            this.tsmiBringToFront.Click += new System.EventHandler(this.tsmiBringToFront_Click);
            // 
            // tsmiSendToBack
            // 
            this.tsmiSendToBack.Image = global::SimpleEditor.Properties.Resources.sendtoback;
            this.tsmiSendToBack.Name = "tsmiSendToBack";
            this.tsmiSendToBack.Size = new System.Drawing.Size(158, 22);
            this.tsmiSendToBack.Text = "SendToBack";
            this.tsmiSendToBack.Click += new System.EventHandler(this.tsmiSendToBack_Click);
            // 
            // tsmiFlipX
            // 
            this.tsmiFlipX.Image = global::SimpleEditor.Properties.Resources.flipleftright;
            this.tsmiFlipX.Name = "tsmiFlipX";
            this.tsmiFlipX.Size = new System.Drawing.Size(158, 22);
            this.tsmiFlipX.Text = "FlipX";
            this.tsmiFlipX.Click += new System.EventHandler(this.tsmiFlipX_Click);
            // 
            // tsmiFlipY
            // 
            this.tsmiFlipY.Image = global::SimpleEditor.Properties.Resources.flipupdown;
            this.tsmiFlipY.Name = "tsmiFlipY";
            this.tsmiFlipY.Size = new System.Drawing.Size(158, 22);
            this.tsmiFlipY.Text = "FlipY";
            this.tsmiFlipY.Click += new System.EventHandler(this.tsmiFlipY_Click);
            // 
            // tsmiRotate90Ccw
            // 
            this.tsmiRotate90Ccw.Image = global::SimpleEditor.Properties.Resources.rotateleft;
            this.tsmiRotate90Ccw.Name = "tsmiRotate90Ccw";
            this.tsmiRotate90Ccw.Size = new System.Drawing.Size(158, 22);
            this.tsmiRotate90Ccw.Text = "Rotate 90° CCW";
            this.tsmiRotate90Ccw.Click += new System.EventHandler(this.tsmiRotate90Ccw_Click);
            // 
            // tsmiRotate90Cw
            // 
            this.tsmiRotate90Cw.Image = global::SimpleEditor.Properties.Resources.rotateright;
            this.tsmiRotate90Cw.Name = "tsmiRotate90Cw";
            this.tsmiRotate90Cw.Size = new System.Drawing.Size(158, 22);
            this.tsmiRotate90Cw.Text = "Rotate  90° CW";
            this.tsmiRotate90Cw.Click += new System.EventHandler(this.tsmiRotate90Cw_Click);
            // 
            // tsmiGroup
            // 
            this.tsmiGroup.Image = global::SimpleEditor.Properties.Resources.grouping;
            this.tsmiGroup.Name = "tsmiGroup";
            this.tsmiGroup.Size = new System.Drawing.Size(158, 22);
            this.tsmiGroup.Text = "Group";
            this.tsmiGroup.Click += new System.EventHandler(this.tsmiGroup_Click);
            // 
            // tsmiUngroup
            // 
            this.tsmiUngroup.Image = global::SimpleEditor.Properties.Resources.ungrouping;
            this.tsmiUngroup.Name = "tsmiUngroup";
            this.tsmiUngroup.Size = new System.Drawing.Size(158, 22);
            this.tsmiUngroup.Text = "Ungroup";
            this.tsmiUngroup.Click += new System.EventHandler(this.tsmiUngroup_Click);
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
            // miBeginChangeNodes
            // 
            this.miBeginChangeNodes.Image = global::SimpleEditor.Properties.Resources.startnodechanging;
            this.miBeginChangeNodes.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.miBeginChangeNodes.Name = "miBeginChangeNodes";
            this.miBeginChangeNodes.Size = new System.Drawing.Size(234, 22);
            this.miBeginChangeNodes.Text = "Начать изменение узлов";
            this.miBeginChangeNodes.Visible = false;
            // 
            // miStroke
            // 
            this.miStroke.Image = global::SimpleEditor.Properties.Resources.penprops;
            this.miStroke.Name = "miStroke";
            this.miStroke.Size = new System.Drawing.Size(234, 22);
            this.miStroke.Text = "Карандаш...";
            // 
            // miFill
            // 
            this.miFill.Image = global::SimpleEditor.Properties.Resources.brushprops;
            this.miFill.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.miFill.Name = "miFill";
            this.miFill.Size = new System.Drawing.Size(234, 22);
            this.miFill.Text = "Кисть...";
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
            // FormSimpleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 515);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Name = "FormSimpleEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "FormSimpleEditor";
            this.panelForScroll.ResumeLayout(false);
            this.cmsCanvasPopup.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tsFigures.ResumeLayout(false);
            this.tsFigures.PerformLayout();
            this.toolStripFile.ResumeLayout(false);
            this.toolStripFile.PerformLayout();
            this.cmsFigurePopup.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
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
        private System.Windows.Forms.ContextMenuStrip cmsFigurePopup;
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
        private System.Windows.Forms.SaveFileDialog saveFiguresFileDialog;
        private System.Windows.Forms.OpenFileDialog openFiguresFileDialog;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslRibbonRect;
        private System.Windows.Forms.ToolStripStatusLabel tsslEditorMode;
        private System.Windows.Forms.ContextMenuStrip cmsCanvasPopup;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator miPasteFromBufferSplitter;
        private System.Windows.Forms.ToolStripMenuItem tsmiDefaultSelectMode;
        private System.Windows.Forms.ToolStripMenuItem tsmiSkewSelectMode;
        private System.Windows.Forms.ToolStripMenuItem tsmiVerticiesSelectMode;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmDefaultSelectMode;
        private System.Windows.Forms.ToolStripMenuItem tsmSkewSelectMode;
        private System.Windows.Forms.ToolStripMenuItem tsmVerticiesSelectMode;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tsmiFlipX;
        private System.Windows.Forms.ToolStripMenuItem tsmiFlipY;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem tsmiRotate90Cw;
        private System.Windows.Forms.ToolStripMenuItem tsmiRotate90Ccw;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem tsmFlipX;
        private System.Windows.Forms.ToolStripMenuItem tsmFlipY;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem tsmRotate90Cw;
        private System.Windows.Forms.ToolStripMenuItem tsmRotate90Ccw;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbText;
        private System.Windows.Forms.ToolStripMenuItem tsmiRotate180;
        private System.Windows.Forms.ToolStripMenuItem tsmRotate180;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem tsmiBringToFront;
        private System.Windows.Forms.ToolStripMenuItem tsmiSendToBack;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem tsmBringToFront;
        private System.Windows.Forms.ToolStripMenuItem tsmSendToBack;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem tsmiGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmiUngroup;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem tsmGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmUngroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tsbRegular8;
        private System.Windows.Forms.ToolStripButton tsbRegular16;
        private System.Windows.Forms.ToolStripButton tsbRegular24;
        private System.Windows.Forms.ToolStripButton tsbRegular32;
        private System.Windows.Forms.ToolStripButton tsbRegular4;
    }
}

