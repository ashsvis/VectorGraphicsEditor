namespace SimpleEditor.Controls
{
    partial class LineGradientFillStyleEditor
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
            this.lbGradient = new System.Windows.Forms.Label();
            this.lbGradientColor = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbGradient
            // 
            this.lbGradient.AutoSize = true;
            this.lbGradient.Location = new System.Drawing.Point(0, 1);
            this.lbGradient.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbGradient.Name = "lbGradient";
            this.lbGradient.Size = new System.Drawing.Size(50, 13);
            this.lbGradient.TabIndex = 4;
            this.lbGradient.Text = "Gradient:";
            // 
            // lbGradientColor
            // 
            this.lbGradientColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbGradientColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbGradientColor.Location = new System.Drawing.Point(50, 1);
            this.lbGradientColor.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbGradientColor.Name = "lbGradientColor";
            this.lbGradientColor.Size = new System.Drawing.Size(39, 17);
            this.lbGradientColor.TabIndex = 3;
            this.lbGradientColor.BackColorChanged += new System.EventHandler(this.lbGradientColor_BackColorChanged);
            this.lbGradientColor.Click += new System.EventHandler(this.lbGradientColor_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.lbGradient);
            this.flowLayoutPanel1.Controls.Add(this.lbGradientColor);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(93, 21);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // LineGradientFillStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LineGradientFillStyleEditor";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Size = new System.Drawing.Size(96, 27);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbGradient;
        private System.Windows.Forms.Label lbGradientColor;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
