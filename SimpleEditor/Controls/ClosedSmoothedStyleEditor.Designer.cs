namespace SimpleEditor.Controls
{
    partial class ClosedSmoothedStyleEditor
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
            this.cbIsClosed = new System.Windows.Forms.CheckBox();
            this.cbIsSmoothed = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbIsClosed
            // 
            this.cbIsClosed.AutoSize = true;
            this.cbIsClosed.Location = new System.Drawing.Point(3, 1);
            this.cbIsClosed.Margin = new System.Windows.Forms.Padding(3, 1, 0, 0);
            this.cbIsClosed.Name = "cbIsClosed";
            this.cbIsClosed.Size = new System.Drawing.Size(66, 17);
            this.cbIsClosed.TabIndex = 1;
            this.cbIsClosed.Text = "IsClosed";
            this.cbIsClosed.UseVisualStyleBackColor = true;
            this.cbIsClosed.CheckedChanged += new System.EventHandler(this.cbIsClosed_CheckedChanged);
            // 
            // cbIsSmoothed
            // 
            this.cbIsSmoothed.AutoSize = true;
            this.cbIsSmoothed.Location = new System.Drawing.Point(69, 1);
            this.cbIsSmoothed.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.cbIsSmoothed.Name = "cbIsSmoothed";
            this.cbIsSmoothed.Size = new System.Drawing.Size(82, 17);
            this.cbIsSmoothed.TabIndex = 1;
            this.cbIsSmoothed.Text = "IsSmoothed";
            this.cbIsSmoothed.UseVisualStyleBackColor = true;
            this.cbIsSmoothed.CheckedChanged += new System.EventHandler(this.cbIsClosed_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.cbIsClosed);
            this.flowLayoutPanel1.Controls.Add(this.cbIsSmoothed);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(151, 23);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // ClosedSmoothedStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClosedSmoothedStyleEditor";
            this.Size = new System.Drawing.Size(155, 26);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbIsClosed;
        private System.Windows.Forms.CheckBox cbIsSmoothed;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
