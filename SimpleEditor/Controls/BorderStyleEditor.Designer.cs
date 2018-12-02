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
            this.lbWidth = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.lbDash = new System.Windows.Forms.Label();
            this.cbPattern = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // lbColor
            // 
            this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbColor.Location = new System.Drawing.Point(59, 4);
            this.lbColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(39, 17);
            this.lbColor.TabIndex = 3;
            this.lbColor.BackColorChanged += new System.EventHandler(this.cbVisible_CheckedChanged);
            this.lbColor.Click += new System.EventHandler(this.lbColor_Click);
            // 
            // cbVisible
            // 
            this.cbVisible.AutoSize = true;
            this.cbVisible.Location = new System.Drawing.Point(2, 4);
            this.cbVisible.Margin = new System.Windows.Forms.Padding(2);
            this.cbVisible.Name = "cbVisible";
            this.cbVisible.Size = new System.Drawing.Size(57, 17);
            this.cbVisible.TabIndex = 2;
            this.cbVisible.Text = "Border";
            this.cbVisible.UseVisualStyleBackColor = true;
            this.cbVisible.CheckedChanged += new System.EventHandler(this.cbVisible_CheckedChanged);
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(103, 5);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(35, 13);
            this.lbWidth.TabIndex = 4;
            this.lbWidth.Text = "Width";
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(144, 3);
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
            // lbDash
            // 
            this.lbDash.AutoSize = true;
            this.lbDash.Location = new System.Drawing.Point(190, 5);
            this.lbDash.Name = "lbDash";
            this.lbDash.Size = new System.Drawing.Size(41, 13);
            this.lbDash.TabIndex = 4;
            this.lbDash.Text = "Pattern";
            // 
            // cbPattern
            // 
            this.cbPattern.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPattern.FormattingEnabled = true;
            this.cbPattern.Location = new System.Drawing.Point(237, 2);
            this.cbPattern.Name = "cbPattern";
            this.cbPattern.Size = new System.Drawing.Size(63, 21);
            this.cbPattern.TabIndex = 6;
            this.cbPattern.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbPattern_DrawItem);
            this.cbPattern.SelectionChangeCommitted += new System.EventHandler(this.cbVisible_CheckedChanged);
            // 
            // BorderStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbPattern);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.lbDash);
            this.Controls.Add(this.lbWidth);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.cbVisible);
            this.Name = "BorderStyleEditor";
            this.Size = new System.Drawing.Size(303, 26);
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.CheckBox cbVisible;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Label lbDash;
        private System.Windows.Forms.ComboBox cbPattern;
    }
}
