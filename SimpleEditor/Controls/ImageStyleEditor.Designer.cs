namespace SimpleEditor.Controls
{
    partial class ImageStyleEditor
    {
        /// <summary> 
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbImageText = new System.Windows.Forms.Label();
            this.lbImage = new System.Windows.Forms.Label();
            this.cbStretch = new System.Windows.Forms.CheckBox();
            this.cbTile = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbImageText
            // 
            this.lbImageText.AutoSize = true;
            this.lbImageText.Location = new System.Drawing.Point(3, 3);
            this.lbImageText.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lbImageText.Name = "lbImageText";
            this.lbImageText.Size = new System.Drawing.Size(36, 13);
            this.lbImageText.TabIndex = 0;
            this.lbImageText.Text = "Image";
            // 
            // lbImage
            // 
            this.lbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbImage.Location = new System.Drawing.Point(39, 1);
            this.lbImage.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbImage.Name = "lbImage";
            this.lbImage.Size = new System.Drawing.Size(23, 22);
            this.lbImage.TabIndex = 3;
            this.lbImage.Click += new System.EventHandler(this.lbImage_Click);
            // 
            // cbStretch
            // 
            this.cbStretch.AutoSize = true;
            this.cbStretch.Enabled = false;
            this.cbStretch.Location = new System.Drawing.Point(65, 3);
            this.cbStretch.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.cbStretch.Name = "cbStretch";
            this.cbStretch.Size = new System.Drawing.Size(60, 17);
            this.cbStretch.TabIndex = 4;
            this.cbStretch.Text = "Stretch";
            this.cbStretch.UseVisualStyleBackColor = true;
            this.cbStretch.CheckedChanged += new System.EventHandler(this.cbStretch_CheckedChanged);
            // 
            // cbTile
            // 
            this.cbTile.AutoSize = true;
            this.cbTile.Enabled = false;
            this.cbTile.Location = new System.Drawing.Point(125, 3);
            this.cbTile.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.cbTile.Name = "cbTile";
            this.cbTile.Size = new System.Drawing.Size(43, 17);
            this.cbTile.TabIndex = 4;
            this.cbTile.Text = "Tile";
            this.cbTile.UseVisualStyleBackColor = true;
            this.cbTile.CheckedChanged += new System.EventHandler(this.cbStretch_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.lbImageText);
            this.flowLayoutPanel1.Controls.Add(this.lbImage);
            this.flowLayoutPanel1.Controls.Add(this.cbStretch);
            this.flowLayoutPanel1.Controls.Add(this.cbTile);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(171, 25);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // ImageStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ImageStyleEditor";
            this.Size = new System.Drawing.Size(177, 26);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbImageText;
        private System.Windows.Forms.Label lbImage;
        private System.Windows.Forms.CheckBox cbStretch;
        private System.Windows.Forms.CheckBox cbTile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
