namespace SimpleEditor.Controls
{
    partial class PictureStyleEditor
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
            this.lbPicture = new System.Windows.Forms.Label();
            this.lbPictureText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbPicture
            // 
            this.lbPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbPicture.Location = new System.Drawing.Point(48, 0);
            this.lbPicture.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPicture.Name = "lbPicture";
            this.lbPicture.Size = new System.Drawing.Size(23, 22);
            this.lbPicture.TabIndex = 6;
            this.lbPicture.Click += new System.EventHandler(this.lbPicture_Click);
            // 
            // lbPictureText
            // 
            this.lbPictureText.AutoSize = true;
            this.lbPictureText.Location = new System.Drawing.Point(3, 4);
            this.lbPictureText.Name = "lbPictureText";
            this.lbPictureText.Size = new System.Drawing.Size(40, 13);
            this.lbPictureText.TabIndex = 5;
            this.lbPictureText.Text = "Picture";
            // 
            // PictureStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbPicture);
            this.Controls.Add(this.lbPictureText);
            this.Name = "PictureStyleEditor";
            this.Size = new System.Drawing.Size(82, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPicture;
        private System.Windows.Forms.Label lbPictureText;
    }
}
