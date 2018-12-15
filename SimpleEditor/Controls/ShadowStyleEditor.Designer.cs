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
            this.lbOffset = new System.Windows.Forms.Label();
            this.nudOffsetX = new System.Windows.Forms.NumericUpDown();
            this.nudOffsetY = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetY)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudOpacity
            // 
            this.nudOpacity.Location = new System.Drawing.Point(97, 4);
            this.nudOpacity.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.nudOpacity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudOpacity.Name = "nudOpacity";
            this.nudOpacity.Size = new System.Drawing.Size(40, 20);
            this.nudOpacity.TabIndex = 8;
            this.nudOpacity.ValueChanged += new System.EventHandler(this.nudOpacity_ValueChanged);
            // 
            // lbOpacity
            // 
            this.lbOpacity.AutoSize = true;
            this.lbOpacity.Location = new System.Drawing.Point(3, 5);
            this.lbOpacity.Margin = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.lbOpacity.Name = "lbOpacity";
            this.lbOpacity.Size = new System.Drawing.Size(94, 13);
            this.lbOpacity.TabIndex = 7;
            this.lbOpacity.Text = "Shadow:   Opacity";
            // 
            // lbOffset
            // 
            this.lbOffset.AutoSize = true;
            this.lbOffset.Location = new System.Drawing.Point(137, 5);
            this.lbOffset.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lbOffset.Name = "lbOffset";
            this.lbOffset.Size = new System.Drawing.Size(35, 13);
            this.lbOffset.TabIndex = 9;
            this.lbOffset.Text = "Offset";
            // 
            // nudOffsetX
            // 
            this.nudOffsetX.Location = new System.Drawing.Point(172, 4);
            this.nudOffsetX.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.nudOffsetX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudOffsetX.Name = "nudOffsetX";
            this.nudOffsetX.Size = new System.Drawing.Size(40, 20);
            this.nudOffsetX.TabIndex = 10;
            this.nudOffsetX.ValueChanged += new System.EventHandler(this.nudOpacity_ValueChanged);
            // 
            // nudOffsetY
            // 
            this.nudOffsetY.Location = new System.Drawing.Point(212, 4);
            this.nudOffsetY.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.nudOffsetY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudOffsetY.Name = "nudOffsetY";
            this.nudOffsetY.Size = new System.Drawing.Size(40, 20);
            this.nudOffsetY.TabIndex = 10;
            this.nudOffsetY.ValueChanged += new System.EventHandler(this.nudOpacity_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lbOpacity);
            this.flowLayoutPanel1.Controls.Add(this.nudOpacity);
            this.flowLayoutPanel1.Controls.Add(this.lbOffset);
            this.flowLayoutPanel1.Controls.Add(this.nudOffsetX);
            this.flowLayoutPanel1.Controls.Add(this.nudOffsetY);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(258, 25);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // ShadowStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ShadowStyleEditor";
            this.Size = new System.Drawing.Size(261, 26);
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetY)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudOpacity;
        private System.Windows.Forms.Label lbOpacity;
        private System.Windows.Forms.Label lbOffset;
        private System.Windows.Forms.NumericUpDown nudOffsetX;
        private System.Windows.Forms.NumericUpDown nudOffsetY;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
