namespace SimpleEditor.Controls
{
    partial class LayerStyleEditor
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
            this.lbColor = new System.Windows.Forms.Label();
            this.cbVisible = new System.Windows.Forms.CheckBox();
            this.lbOpacity = new System.Windows.Forms.Label();
            this.nudOpacity = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbColor
            // 
            this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbColor.Location = new System.Drawing.Point(72, 19);
            this.lbColor.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(26, 17);
            this.lbColor.TabIndex = 3;
            this.lbColor.BackColorChanged += new System.EventHandler(this.cbVisible_CheckedChanged);
            this.lbColor.Click += new System.EventHandler(this.lbColor_Click);
            // 
            // cbVisible
            // 
            this.cbVisible.AutoSize = true;
            this.cbVisible.Location = new System.Drawing.Point(5, 19);
            this.cbVisible.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.cbVisible.Name = "cbVisible";
            this.cbVisible.Size = new System.Drawing.Size(68, 17);
            this.cbVisible.TabIndex = 2;
            this.cbVisible.Text = "Fill Color:";
            this.cbVisible.UseVisualStyleBackColor = true;
            this.cbVisible.CheckedChanged += new System.EventHandler(this.cbVisible_CheckedChanged);
            // 
            // lbOpacity
            // 
            this.lbOpacity.AutoSize = true;
            this.lbOpacity.Location = new System.Drawing.Point(102, 20);
            this.lbOpacity.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lbOpacity.Name = "lbOpacity";
            this.lbOpacity.Size = new System.Drawing.Size(46, 13);
            this.lbOpacity.TabIndex = 5;
            this.lbOpacity.Text = "Opacity:";
            // 
            // nudOpacity
            // 
            this.nudOpacity.Location = new System.Drawing.Point(150, 18);
            this.nudOpacity.Margin = new System.Windows.Forms.Padding(0);
            this.nudOpacity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudOpacity.Name = "nudOpacity";
            this.nudOpacity.Size = new System.Drawing.Size(40, 20);
            this.nudOpacity.TabIndex = 6;
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
            this.groupBox1.Controls.Add(this.cbVisible);
            this.groupBox1.Controls.Add(this.nudOpacity);
            this.groupBox1.Controls.Add(this.lbOpacity);
            this.groupBox1.Location = new System.Drawing.Point(1, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(200, 52);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Layer Style";
            // 
            // LayerStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LayerStyleEditor";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Size = new System.Drawing.Size(209, 60);
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.CheckBox cbVisible;
        private System.Windows.Forms.Label lbOpacity;
        private System.Windows.Forms.NumericUpDown nudOpacity;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
