namespace SimpleEditor.Controls
{
    partial class HatchStyleEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbHatch = new System.Windows.Forms.ComboBox();
            this.lbHatchColor = new System.Windows.Forms.Label();
            this.lbHatch = new System.Windows.Forms.Label();
            this.lbGradient = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.cbHatch);
            this.groupBox1.Controls.Add(this.lbHatchColor);
            this.groupBox1.Controls.Add(this.lbHatch);
            this.groupBox1.Controls.Add(this.lbGradient);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(198, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hatch Style";
            // 
            // cbHatch
            // 
            this.cbHatch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbHatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHatch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbHatch.FormattingEnabled = true;
            this.cbHatch.Location = new System.Drawing.Point(121, 16);
            this.cbHatch.Name = "cbHatch";
            this.cbHatch.Size = new System.Drawing.Size(64, 21);
            this.cbHatch.TabIndex = 7;
            this.cbHatch.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbHatch_DrawItem);
            this.cbHatch.SelectionChangeCommitted += new System.EventHandler(this.cbHatch_SelectionChangeCommitted);
            // 
            // lbHatchColor
            // 
            this.lbHatchColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbHatchColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbHatchColor.Location = new System.Drawing.Point(40, 18);
            this.lbHatchColor.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbHatchColor.Name = "lbHatchColor";
            this.lbHatchColor.Size = new System.Drawing.Size(39, 17);
            this.lbHatchColor.TabIndex = 5;
            this.lbHatchColor.BackColorChanged += new System.EventHandler(this.lbGradientColor_BackColorChanged);
            this.lbHatchColor.Click += new System.EventHandler(this.lbHatchColor_Click);
            // 
            // lbHatch
            // 
            this.lbHatch.AutoSize = true;
            this.lbHatch.Location = new System.Drawing.Point(79, 19);
            this.lbHatch.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbHatch.Name = "lbHatch";
            this.lbHatch.Size = new System.Drawing.Size(39, 13);
            this.lbHatch.TabIndex = 6;
            this.lbHatch.Text = "Hatch:";
            // 
            // lbGradient
            // 
            this.lbGradient.AutoSize = true;
            this.lbGradient.Location = new System.Drawing.Point(4, 19);
            this.lbGradient.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbGradient.Name = "lbGradient";
            this.lbGradient.Size = new System.Drawing.Size(34, 13);
            this.lbGradient.TabIndex = 6;
            this.lbGradient.Text = "Color:";
            // 
            // HatchFillStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Name = "HatchFillStyleEditor";
            this.Size = new System.Drawing.Size(200, 56);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbHatchColor;
        private System.Windows.Forms.Label lbGradient;
        private System.Windows.Forms.Label lbHatch;
        private System.Windows.Forms.ComboBox cbHatch;
    }
}
