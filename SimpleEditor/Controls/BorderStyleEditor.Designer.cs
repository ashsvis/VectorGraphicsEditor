namespace SimpleEditor.Controls
{
    partial class BorderStyleEditor
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbColor = new System.Windows.Forms.Label();
            this.cbVisible = new System.Windows.Forms.CheckBox();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.cbPattern = new System.Windows.Forms.ComboBox();
            this.lbPattern = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbOpacity = new System.Windows.Forms.Label();
            this.nudOpacity = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbColor
            // 
            this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbColor.Location = new System.Drawing.Point(59, 17);
            this.lbColor.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(39, 17);
            this.lbColor.TabIndex = 1;
            this.lbColor.BackColorChanged += new System.EventHandler(this.cbVisible_CheckedChanged);
            this.lbColor.Click += new System.EventHandler(this.lbColor_Click);
            // 
            // cbVisible
            // 
            this.cbVisible.AutoSize = true;
            this.cbVisible.Location = new System.Drawing.Point(4, 17);
            this.cbVisible.Margin = new System.Windows.Forms.Padding(3, 1, 0, 0);
            this.cbVisible.Name = "cbVisible";
            this.cbVisible.Size = new System.Drawing.Size(53, 17);
            this.cbVisible.TabIndex = 0;
            this.cbVisible.Text = "Color:";
            this.cbVisible.UseVisualStyleBackColor = true;
            this.cbVisible.CheckedChanged += new System.EventHandler(this.cbVisible_CheckedChanged);
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(44, 40);
            this.nudWidth.Margin = new System.Windows.Forms.Padding(0);
            this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(40, 20);
            this.nudWidth.TabIndex = 5;
            this.nudWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidth.ValueChanged += new System.EventHandler(this.cbVisible_CheckedChanged);
            // 
            // cbPattern
            // 
            this.cbPattern.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPattern.FormattingEnabled = true;
            this.cbPattern.Location = new System.Drawing.Point(135, 39);
            this.cbPattern.Margin = new System.Windows.Forms.Padding(0);
            this.cbPattern.Name = "cbPattern";
            this.cbPattern.Size = new System.Drawing.Size(55, 21);
            this.cbPattern.TabIndex = 7;
            this.cbPattern.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbPattern_DrawItem);
            this.cbPattern.SelectionChangeCommitted += new System.EventHandler(this.cbVisible_CheckedChanged);
            // 
            // lbPattern
            // 
            this.lbPattern.AutoSize = true;
            this.lbPattern.Location = new System.Drawing.Point(87, 42);
            this.lbPattern.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lbPattern.Name = "lbPattern";
            this.lbPattern.Size = new System.Drawing.Size(44, 13);
            this.lbPattern.TabIndex = 6;
            this.lbPattern.Text = "Pattern:";
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(4, 42);
            this.lbWidth.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(38, 13);
            this.lbWidth.TabIndex = 4;
            this.lbWidth.Text = "Width:";
            // 
            // lbOpacity
            // 
            this.lbOpacity.AutoSize = true;
            this.lbOpacity.Location = new System.Drawing.Point(102, 18);
            this.lbOpacity.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lbOpacity.Name = "lbOpacity";
            this.lbOpacity.Size = new System.Drawing.Size(46, 13);
            this.lbOpacity.TabIndex = 2;
            this.lbOpacity.Text = "Opacity:";
            // 
            // nudOpacity
            // 
            this.nudOpacity.Location = new System.Drawing.Point(150, 16);
            this.nudOpacity.Margin = new System.Windows.Forms.Padding(0);
            this.nudOpacity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudOpacity.Name = "nudOpacity";
            this.nudOpacity.Size = new System.Drawing.Size(40, 20);
            this.nudOpacity.TabIndex = 3;
            this.nudOpacity.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudOpacity.ValueChanged += new System.EventHandler(this.cbVisible_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.lbColor);
            this.groupBox1.Controls.Add(this.cbPattern);
            this.groupBox1.Controls.Add(this.lbPattern);
            this.groupBox1.Controls.Add(this.nudWidth);
            this.groupBox1.Controls.Add(this.lbWidth);
            this.groupBox1.Controls.Add(this.nudOpacity);
            this.groupBox1.Controls.Add(this.lbOpacity);
            this.groupBox1.Controls.Add(this.cbVisible);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(200, 74);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Border Style";
            // 
            // BorderStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BorderStyleEditor";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Size = new System.Drawing.Size(211, 85);
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.CheckBox cbVisible;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.ComboBox cbPattern;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbPattern;
        private System.Windows.Forms.Label lbOpacity;
        private System.Windows.Forms.NumericUpDown nudOpacity;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
