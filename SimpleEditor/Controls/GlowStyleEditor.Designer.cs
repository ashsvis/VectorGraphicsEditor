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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbGlowText = new System.Windows.Forms.Label();
            this.lbColor = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.lbGlowText);
            this.flowLayoutPanel1.Controls.Add(this.lbColor);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(112, 21);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lbGlowText
            // 
            this.lbGlowText.AutoSize = true;
            this.lbGlowText.Location = new System.Drawing.Point(3, 5);
            this.lbGlowText.Margin = new System.Windows.Forms.Padding(3, 2, 0, 0);
            this.lbGlowText.Name = "lbGlowText";
            this.lbGlowText.Size = new System.Drawing.Size(64, 13);
            this.lbGlowText.TabIndex = 8;
            this.lbGlowText.Text = "Glow:  Color";
            // 
            // lbColor
            // 
            this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbColor.Location = new System.Drawing.Point(67, 4);
            this.lbColor.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(39, 17);
            this.lbColor.TabIndex = 9;
            this.lbColor.BackColorChanged += new System.EventHandler(this.lbColor_BackColorChanged);
            this.lbColor.Click += new System.EventHandler(this.lbColor_Click);
            // 
            // GlowStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "GlowStyleEditor";
            this.Size = new System.Drawing.Size(114, 26);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbGlowText;
        private System.Windows.Forms.Label lbColor;
    }
}
