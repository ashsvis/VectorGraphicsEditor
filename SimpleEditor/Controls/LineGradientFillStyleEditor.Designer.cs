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
            this.lbAngle = new System.Windows.Forms.Label();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbGradient
            // 
            this.lbGradient.AutoSize = true;
            this.lbGradient.Location = new System.Drawing.Point(3, 4);
            this.lbGradient.Name = "lbGradient";
            this.lbGradient.Size = new System.Drawing.Size(47, 13);
            this.lbGradient.TabIndex = 4;
            this.lbGradient.Text = "Gradient";
            // 
            // lbGradientColor
            // 
            this.lbGradientColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbGradientColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbGradientColor.Location = new System.Drawing.Point(50, 3);
            this.lbGradientColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbGradientColor.Name = "lbGradientColor";
            this.lbGradientColor.Size = new System.Drawing.Size(39, 17);
            this.lbGradientColor.TabIndex = 3;
            this.lbGradientColor.BackColorChanged += new System.EventHandler(this.lbGradientColor_BackColorChanged);
            this.lbGradientColor.Click += new System.EventHandler(this.lbGradientColor_Click);
            // 
            // lbAngle
            // 
            this.lbAngle.AutoSize = true;
            this.lbAngle.Location = new System.Drawing.Point(94, 4);
            this.lbAngle.Name = "lbAngle";
            this.lbAngle.Size = new System.Drawing.Size(49, 13);
            this.lbAngle.TabIndex = 5;
            this.lbAngle.Text = "Direction";
            // 
            // cbDirection
            // 
            this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbDirection.FormattingEnabled = true;
            this.cbDirection.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical",
            "ForwardDiagonal",
            "BackwardDiagonal"});
            this.cbDirection.Location = new System.Drawing.Point(149, 0);
            this.cbDirection.Name = "cbDirection";
            this.cbDirection.Size = new System.Drawing.Size(125, 21);
            this.cbDirection.TabIndex = 8;
            this.cbDirection.SelectionChangeCommitted += new System.EventHandler(this.cbDirection_SelectionChangeCommitted);
            // 
            // LineGradientFillStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.cbDirection);
            this.Controls.Add(this.lbAngle);
            this.Controls.Add(this.lbGradient);
            this.Controls.Add(this.lbGradientColor);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LineGradientFillStyleEditor";
            this.Size = new System.Drawing.Size(277, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbGradient;
        private System.Windows.Forms.Label lbGradientColor;
        private System.Windows.Forms.Label lbAngle;
        private System.Windows.Forms.ComboBox cbDirection;
    }
}
