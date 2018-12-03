namespace SimpleEditor.Controls
{
    partial class IsClosedEditor
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
            this.SuspendLayout();
            // 
            // cbIsClosed
            // 
            this.cbIsClosed.AutoSize = true;
            this.cbIsClosed.Location = new System.Drawing.Point(2, 2);
            this.cbIsClosed.Margin = new System.Windows.Forms.Padding(2);
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
            this.cbIsSmoothed.Location = new System.Drawing.Point(71, 2);
            this.cbIsSmoothed.Margin = new System.Windows.Forms.Padding(2);
            this.cbIsSmoothed.Name = "cbIsSmoothed";
            this.cbIsSmoothed.Size = new System.Drawing.Size(82, 17);
            this.cbIsSmoothed.TabIndex = 1;
            this.cbIsSmoothed.Text = "IsSmoothed";
            this.cbIsSmoothed.UseVisualStyleBackColor = true;
            this.cbIsSmoothed.CheckedChanged += new System.EventHandler(this.cbIsClosed_CheckedChanged);
            // 
            // IsClosedEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbIsSmoothed);
            this.Controls.Add(this.cbIsClosed);
            this.Name = "IsClosedEditor";
            this.Size = new System.Drawing.Size(154, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbIsClosed;
        private System.Windows.Forms.CheckBox cbIsSmoothed;
    }
}
