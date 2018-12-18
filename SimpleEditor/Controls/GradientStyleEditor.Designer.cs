namespace SimpleEditor.Controls
{
    partial class GradientStyleEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbGradient
            // 
            this.lbGradient.AutoSize = true;
            this.lbGradient.Location = new System.Drawing.Point(4, 19);
            this.lbGradient.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbGradient.Name = "lbGradient";
            this.lbGradient.Size = new System.Drawing.Size(34, 13);
            this.lbGradient.TabIndex = 4;
            this.lbGradient.Text = "Color:";
            // 
            // lbGradientColor
            // 
            this.lbGradientColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbGradientColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbGradientColor.Location = new System.Drawing.Point(40, 18);
            this.lbGradientColor.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbGradientColor.Name = "lbGradientColor";
            this.lbGradientColor.Size = new System.Drawing.Size(39, 17);
            this.lbGradientColor.TabIndex = 3;
            this.lbGradientColor.BackColorChanged += new System.EventHandler(this.lbGradientColor_BackColorChanged);
            this.lbGradientColor.Click += new System.EventHandler(this.lbGradientColor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.lbGradientColor);
            this.groupBox1.Controls.Add(this.lbGradient);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(90, 50);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gradient Style";
            // 
            // LineGradientFillStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LineGradientFillStyleEditor";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Size = new System.Drawing.Size(97, 56);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbGradient;
        private System.Windows.Forms.Label lbGradientColor;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
