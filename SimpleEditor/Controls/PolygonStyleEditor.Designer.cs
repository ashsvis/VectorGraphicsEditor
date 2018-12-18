namespace SimpleEditor.Controls
{
    partial class PolygonStyleEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbIsClosed
            // 
            this.cbIsClosed.AutoSize = true;
            this.cbIsClosed.Location = new System.Drawing.Point(4, 18);
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
            this.cbIsSmoothed.Location = new System.Drawing.Point(70, 18);
            this.cbIsSmoothed.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.cbIsSmoothed.Name = "cbIsSmoothed";
            this.cbIsSmoothed.Size = new System.Drawing.Size(82, 17);
            this.cbIsSmoothed.TabIndex = 1;
            this.cbIsSmoothed.Text = "IsSmoothed";
            this.cbIsSmoothed.UseVisualStyleBackColor = true;
            this.cbIsSmoothed.CheckedChanged += new System.EventHandler(this.cbIsClosed_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.cbIsSmoothed);
            this.groupBox1.Controls.Add(this.cbIsClosed);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(157, 49);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Polygon Style";
            // 
            // ClosedSmoothedStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClosedSmoothedStyleEditor";
            this.Size = new System.Drawing.Size(167, 55);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbIsClosed;
        private System.Windows.Forms.CheckBox cbIsSmoothed;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
