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
            this.chLashing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGluing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCreateLayer = new System.Windows.Forms.Button();
            this.btnDeleteLayer = new System.Windows.Forms.Button();
            this.btnRenameLayer = new System.Windows.Forms.Button();
            this.cboxRemoveUnusedLayers = new System.Windows.Forms.CheckBox();
            this.lbColorText = new System.Windows.Forms.Label();
            this.lbColor = new System.Windows.Forms.Label();
            this.nudOpacity = new System.Windows.Forms.NumericUpDown();
            this.lbOpacity = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).BeginInit();
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
            this.chLocking,
            this.chLashing,
            this.chGluing,
            this.chColor});
            this.lvLayers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvLayers.HideSelection = false;
            this.lvLayers.LabelWrap = false;
            this.lvLayers.Location = new System.Drawing.Point(13, 13);
            this.lvLayers.MultiSelect = false;
            this.lvLayers.Name = "lvLayers";
            this.lvLayers.OwnerDraw = true;
            this.lvLayers.Size = new System.Drawing.Size(632, 252);
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
            // chLashing
            // 
            this.chLashing.Text = "Lashing";
            this.chLashing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chGluing
            // 
            this.chGluing.Text = "Gluing";
            this.chGluing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chColor
            // 
            this.chColor.Text = "Color";
            this.chColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCreateLayer
            // 
            this.btnCreateLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateLayer.Location = new System.Drawing.Point(13, 272);
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
            this.btnDeleteLayer.Location = new System.Drawing.Point(105, 272);
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
            this.btnRenameLayer.Location = new System.Drawing.Point(197, 272);
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
            this.cboxRemoveUnusedLayers.Location = new System.Drawing.Point(13, 302);
            this.cboxRemoveUnusedLayers.Name = "cboxRemoveUnusedLayers";
            this.cboxRemoveUnusedLayers.Size = new System.Drawing.Size(144, 19);
            this.cboxRemoveUnusedLayers.TabIndex = 4;
            this.cboxRemoveUnusedLayers.Text = "Remove unused layers";
            this.cboxRemoveUnusedLayers.UseVisualStyleBackColor = true;
            this.cboxRemoveUnusedLayers.CheckedChanged += new System.EventHandler(this.cboxRemoveUnusedLayers_CheckedChanged);
            // 
            // lbColorText
            // 
            this.lbColorText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbColorText.AutoSize = true;
            this.lbColorText.Location = new System.Drawing.Point(430, 278);
            this.lbColorText.Name = "lbColorText";
            this.lbColorText.Size = new System.Drawing.Size(68, 15);
            this.lbColorText.TabIndex = 3;
            this.lbColorText.Text = "Layer color:";
            // 
            // lbColor
            // 
            this.lbColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbColor.Enabled = false;
            this.lbColor.Location = new System.Drawing.Point(501, 277);
            this.lbColor.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(39, 17);
            this.lbColor.TabIndex = 4;
            // 
            // nudOpacity
            // 
            this.nudOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudOpacity.Enabled = false;
            this.nudOpacity.Location = new System.Drawing.Point(605, 276);
            this.nudOpacity.Margin = new System.Windows.Forms.Padding(0);
            this.nudOpacity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudOpacity.Name = "nudOpacity";
            this.nudOpacity.Size = new System.Drawing.Size(40, 23);
            this.nudOpacity.TabIndex = 5;
            this.nudOpacity.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // lbOpacity
            // 
            this.lbOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOpacity.AutoSize = true;
            this.lbOpacity.Location = new System.Drawing.Point(552, 278);
            this.lbOpacity.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lbOpacity.Name = "lbOpacity";
            this.lbOpacity.Size = new System.Drawing.Size(51, 15);
            this.lbOpacity.TabIndex = 5;
            this.lbOpacity.Text = "Opacity:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(467, 324);
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
            this.btnCancel.Location = new System.Drawing.Point(559, 324);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 26);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(366, 324);
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
            this.ClientSize = new System.Drawing.Size(657, 358);
            this.Controls.Add(this.nudOpacity);
            this.Controls.Add(this.lbOpacity);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.lbColorText);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).EndInit();
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
        private System.Windows.Forms.ColumnHeader chLashing;
        private System.Windows.Forms.ColumnHeader chGluing;
        private System.Windows.Forms.ColumnHeader chColor;
        private System.Windows.Forms.Button btnCreateLayer;
        private System.Windows.Forms.Button btnDeleteLayer;
        private System.Windows.Forms.Button btnRenameLayer;
        private System.Windows.Forms.CheckBox cboxRemoveUnusedLayers;
        private System.Windows.Forms.Label lbColorText;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.NumericUpDown nudOpacity;
        private System.Windows.Forms.Label lbOpacity;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
    }
}