namespace SimpleEditor.Controls
{
    partial class ArrowStyleEditor
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
            this.cbColor = new System.Windows.Forms.CheckBox();
            this.cbPosition = new System.Windows.Forms.ComboBox();
            this.lbColor = new System.Windows.Forms.Label();
            this.lbHatch = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.cbColor);
            this.groupBox1.Controls.Add(this.cbPosition);
            this.groupBox1.Controls.Add(this.lbColor);
            this.groupBox1.Controls.Add(this.lbHatch);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(223, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arrow Style";
            // 
            // cbColor
            // 
            this.cbColor.AutoSize = true;
            this.cbColor.Location = new System.Drawing.Point(4, 18);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(50, 17);
            this.cbColor.TabIndex = 8;
            this.cbColor.Text = "Color";
            this.cbColor.UseVisualStyleBackColor = true;
            this.cbColor.CheckedChanged += new System.EventHandler(this.cbColor_CheckedChanged);
            // 
            // cbPosition
            // 
            this.cbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPosition.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbPosition.FormattingEnabled = true;
            this.cbPosition.Items.AddRange(new object[] {
            "End",
            "Start",
            "Both"});
            this.cbPosition.Location = new System.Drawing.Point(156, 17);
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Size = new System.Drawing.Size(56, 21);
            this.cbPosition.TabIndex = 7;
            this.cbPosition.SelectionChangeCommitted += new System.EventHandler(this.cbColor_CheckedChanged);
            // 
            // lbColor
            // 
            this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbColor.Location = new System.Drawing.Point(57, 18);
            this.lbColor.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(39, 17);
            this.lbColor.TabIndex = 5;
            this.lbColor.BackColorChanged += new System.EventHandler(this.cbColor_CheckedChanged);
            this.lbColor.Click += new System.EventHandler(this.lbColor_Click);
            // 
            // lbHatch
            // 
            this.lbHatch.AutoSize = true;
            this.lbHatch.Location = new System.Drawing.Point(106, 20);
            this.lbHatch.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbHatch.Name = "lbHatch";
            this.lbHatch.Size = new System.Drawing.Size(47, 13);
            this.lbHatch.TabIndex = 6;
            this.lbHatch.Text = "Position:";
            // 
            // ArrowStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ArrowStyleEditor";
            this.Size = new System.Drawing.Size(229, 56);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbPosition;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Label lbHatch;
        private System.Windows.Forms.CheckBox cbColor;
    }
}
