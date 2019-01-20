namespace SimpleEditor.EditorLayersInterface
{
    partial class FormLayersProperty
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvLayers = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLinksCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVisible = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPrint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chActived = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLocking = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCreateLayer = new System.Windows.Forms.Button();
            this.btnDeleteLayer = new System.Windows.Forms.Button();
            this.btnRenameLayer = new System.Windows.Forms.Button();
            this.cboxRemoveUnusedLayers = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvLayers
            // 
            this.lvLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chLinksCount,
            this.chVisible,
            this.chPrint,
            this.chActived,
            this.chLocking});
            this.lvLayers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvLayers.HideSelection = false;
            this.lvLayers.LabelWrap = false;
            this.lvLayers.Location = new System.Drawing.Point(13, 13);
            this.lvLayers.MultiSelect = false;
            this.lvLayers.Name = "lvLayers";
            this.lvLayers.OwnerDraw = true;
            this.lvLayers.Size = new System.Drawing.Size(451, 258);
            this.lvLayers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvLayers.TabIndex = 0;
            this.lvLayers.UseCompatibleStateImageBehavior = false;
            this.lvLayers.View = System.Windows.Forms.View.Details;
            this.lvLayers.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvLayers_DrawColumnHeader);
            this.lvLayers.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvLayers_DrawItem);
            this.lvLayers.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvLayers_DrawSubItem);
            this.lvLayers.SelectedIndexChanged += new System.EventHandler(this.lvLayers_SelectedIndexChanged);
            this.lvLayers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvLayers_MouseDown);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 150;
            // 
            // chLinksCount
            // 
            this.chLinksCount.Text = "#";
            this.chLinksCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chLinksCount.Width = 40;
            // 
            // chVisible
            // 
            this.chVisible.Text = "Visible";
            this.chVisible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chPrint
            // 
            this.chPrint.Text = "Print";
            this.chPrint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chActived
            // 
            this.chActived.Text = "Actived";
            this.chActived.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chLocking
            // 
            this.chLocking.Text = "Locking";
            this.chLocking.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCreateLayer
            // 
            this.btnCreateLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateLayer.Location = new System.Drawing.Point(13, 284);
            this.btnCreateLayer.Name = "btnCreateLayer";
            this.btnCreateLayer.Size = new System.Drawing.Size(86, 26);
            this.btnCreateLayer.TabIndex = 1;
            this.btnCreateLayer.Text = "Create...";
            this.btnCreateLayer.UseVisualStyleBackColor = true;
            this.btnCreateLayer.Click += new System.EventHandler(this.btnCreateLayer_Click);
            // 
            // btnDeleteLayer
            // 
            this.btnDeleteLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteLayer.Enabled = false;
            this.btnDeleteLayer.Location = new System.Drawing.Point(105, 284);
            this.btnDeleteLayer.Name = "btnDeleteLayer";
            this.btnDeleteLayer.Size = new System.Drawing.Size(86, 26);
            this.btnDeleteLayer.TabIndex = 2;
            this.btnDeleteLayer.Text = "Delete";
            this.btnDeleteLayer.UseVisualStyleBackColor = true;
            this.btnDeleteLayer.Click += new System.EventHandler(this.btnDeleteLayer_Click);
            // 
            // btnRenameLayer
            // 
            this.btnRenameLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRenameLayer.Enabled = false;
            this.btnRenameLayer.Location = new System.Drawing.Point(197, 284);
            this.btnRenameLayer.Name = "btnRenameLayer";
            this.btnRenameLayer.Size = new System.Drawing.Size(86, 26);
            this.btnRenameLayer.TabIndex = 3;
            this.btnRenameLayer.Text = "Rename...";
            this.btnRenameLayer.UseVisualStyleBackColor = true;
            this.btnRenameLayer.Click += new System.EventHandler(this.btnRenameLayer_Click);
            // 
            // cboxRemoveUnusedLayers
            // 
            this.cboxRemoveUnusedLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxRemoveUnusedLayers.AutoSize = true;
            this.cboxRemoveUnusedLayers.Location = new System.Drawing.Point(300, 289);
            this.cboxRemoveUnusedLayers.Name = "cboxRemoveUnusedLayers";
            this.cboxRemoveUnusedLayers.Size = new System.Drawing.Size(144, 19);
            this.cboxRemoveUnusedLayers.TabIndex = 4;
            this.cboxRemoveUnusedLayers.Text = "Remove unused layers";
            this.cboxRemoveUnusedLayers.UseVisualStyleBackColor = true;
            this.cboxRemoveUnusedLayers.CheckedChanged += new System.EventHandler(this.cboxRemoveUnusedLayers_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(286, 330);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 26);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(378, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 26);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(185, 330);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(86, 26);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // FormLayersProperty
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(476, 364);
            this.Controls.Add(this.cboxRemoveUnusedLayers);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnRenameLayer);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnDeleteLayer);
            this.Controls.Add(this.btnCreateLayer);
            this.Controls.Add(this.lvLayers);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLayersProperty";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Property layers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvLayers;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chLinksCount;
        private System.Windows.Forms.ColumnHeader chVisible;
        private System.Windows.Forms.ColumnHeader chPrint;
        private System.Windows.Forms.ColumnHeader chActived;
        private System.Windows.Forms.ColumnHeader chLocking;
        private System.Windows.Forms.Button btnCreateLayer;
        private System.Windows.Forms.Button btnDeleteLayer;
        private System.Windows.Forms.Button btnRenameLayer;
        private System.Windows.Forms.CheckBox cboxRemoveUnusedLayers;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
    }
}