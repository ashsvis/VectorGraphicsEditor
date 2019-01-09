namespace SimpleEditor.Controls
{
    partial class GlowStyleEditor
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
            this.lbGlowText = new System.Windows.Forms.Label();
            this.lbColor = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbGlowText
            // 
            this.lbGlowText.AutoSize = true;
            this.lbGlowText.Location = new System.Drawing.Point(4, 19);
            this.lbGlowText.Margin = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.lbGlowText.Name = "lbGlowText";
            this.lbGlowText.Size = new System.Drawing.Size(34, 13);
            this.lbGlowText.TabIndex = 8;
            this.lbGlowText.Text = "Color:";
            // 
            // lbColor
            // 
            this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbColor.Location = new System.Drawing.Point(40, 18);
            this.lbColor.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(39, 17);
            this.lbColor.TabIndex = 9;
            this.lbColor.BackColorChanged += new System.EventHandler(this.lbColor_BackColorChanged);
            this.lbColor.Click += new System.EventHandler(this.lbColor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.lbColor);
            this.groupBox1.Controls.Add(this.lbGlowText);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(90, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Glow Style";
            // 
            // GlowStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GlowStyleEditor";
            this.Size = new System.Drawing.Size(97, 56);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbGlowText;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
