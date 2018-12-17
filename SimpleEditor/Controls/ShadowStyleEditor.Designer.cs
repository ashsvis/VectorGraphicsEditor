namespace SimpleEditor.Controls
{
    partial class ShadowStyleEditor
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
            this.nudOpacity = new System.Windows.Forms.NumericUpDown();
            this.lbOpacity = new System.Windows.Forms.Label();
            this.lbOffsetX = new System.Windows.Forms.Label();
            this.nudOffsetX = new System.Windows.Forms.NumericUpDown();
            this.nudOffsetY = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbColor = new System.Windows.Forms.Label();
            this.lbGlowText = new System.Windows.Forms.Label();
            this.lbOffsetY = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetY)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudOpacity
            // 
            this.nudOpacity.Location = new System.Drawing.Point(148, 16);
            this.nudOpacity.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.nudOpacity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudOpacity.Name = "nudOpacity";
            this.nudOpacity.Size = new System.Drawing.Size(40, 20);
            this.nudOpacity.TabIndex = 8;
            this.nudOpacity.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudOpacity.ValueChanged += new System.EventHandler(this.nudOpacity_ValueChanged);
            // 
            // lbOpacity
            // 
            this.lbOpacity.AutoSize = true;
            this.lbOpacity.Location = new System.Drawing.Point(102, 19);
            this.lbOpacity.Margin = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.lbOpacity.Name = "lbOpacity";
            this.lbOpacity.Size = new System.Drawing.Size(46, 13);
            this.lbOpacity.TabIndex = 7;
            this.lbOpacity.Text = "Opacity:";
            // 
            // lbOffsetX
            // 
            this.lbOffsetX.AutoSize = true;
            this.lbOffsetX.Location = new System.Drawing.Point(4, 41);
            this.lbOffsetX.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lbOffsetX.Name = "lbOffsetX";
            this.lbOffsetX.Size = new System.Drawing.Size(48, 13);
            this.lbOffsetX.TabIndex = 9;
            this.lbOffsetX.Text = "Offset X:";
            // 
            // nudOffsetX
            // 
            this.nudOffsetX.Location = new System.Drawing.Point(64, 39);
            this.nudOffsetX.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.nudOffsetX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudOffsetX.Name = "nudOffsetX";
            this.nudOffsetX.Size = new System.Drawing.Size(40, 20);
            this.nudOffsetX.TabIndex = 10;
            this.nudOffsetX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudOffsetX.ValueChanged += new System.EventHandler(this.nudOpacity_ValueChanged);
            // 
            // nudOffsetY
            // 
            this.nudOffsetY.Location = new System.Drawing.Point(148, 39);
            this.nudOffsetY.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.nudOffsetY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudOffsetY.Name = "nudOffsetY";
            this.nudOffsetY.Size = new System.Drawing.Size(40, 20);
            this.nudOffsetY.TabIndex = 10;
            this.nudOffsetY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudOffsetY.ValueChanged += new System.EventHandler(this.nudOpacity_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.lbColor);
            this.groupBox1.Controls.Add(this.lbGlowText);
            this.groupBox1.Controls.Add(this.nudOffsetY);
            this.groupBox1.Controls.Add(this.nudOffsetX);
            this.groupBox1.Controls.Add(this.lbOffsetY);
            this.groupBox1.Controls.Add(this.lbOffsetX);
            this.groupBox1.Controls.Add(this.nudOpacity);
            this.groupBox1.Controls.Add(this.lbOpacity);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(200, 73);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shadow Style";
            // 
            // lbColor
            // 
            this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbColor.Location = new System.Drawing.Point(58, 18);
            this.lbColor.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(39, 17);
            this.lbColor.TabIndex = 12;
            this.lbColor.BackColorChanged += new System.EventHandler(this.nudOpacity_ValueChanged);
            this.lbColor.Click += new System.EventHandler(this.lbColor_Click);
            // 
            // lbGlowText
            // 
            this.lbGlowText.AutoSize = true;
            this.lbGlowText.Location = new System.Drawing.Point(18, 19);
            this.lbGlowText.Margin = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.lbGlowText.Name = "lbGlowText";
            this.lbGlowText.Size = new System.Drawing.Size(34, 13);
            this.lbGlowText.TabIndex = 11;
            this.lbGlowText.Text = "Color:";
            // 
            // lbOffsetY
            // 
            this.lbOffsetY.AutoSize = true;
            this.lbOffsetY.Location = new System.Drawing.Point(122, 41);
            this.lbOffsetY.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lbOffsetY.Name = "lbOffsetY";
            this.lbOffsetY.Size = new System.Drawing.Size(17, 13);
            this.lbOffsetY.TabIndex = 9;
            this.lbOffsetY.Text = "Y:";
            // 
            // ShadowStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ShadowStyleEditor";
            this.Size = new System.Drawing.Size(212, 80);
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetY)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudOpacity;
        private System.Windows.Forms.Label lbOpacity;
        private System.Windows.Forms.Label lbOffsetX;
        private System.Windows.Forms.NumericUpDown nudOffsetX;
        private System.Windows.Forms.NumericUpDown nudOffsetY;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Label lbGlowText;
        private System.Windows.Forms.Label lbOffsetY;
    }
}
