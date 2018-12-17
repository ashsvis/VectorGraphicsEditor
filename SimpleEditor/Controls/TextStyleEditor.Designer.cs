namespace SimpleEditor.Controls
{
    partial class TextStyleEditor
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
            this.lbText = new System.Windows.Forms.Label();
            this.cbFontName = new System.Windows.Forms.ComboBox();
            this.btnRightAllign = new System.Windows.Forms.Button();
            this.btnCenterAllign = new System.Windows.Forms.Button();
            this.btnLeftAllign = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTextUnderline = new System.Windows.Forms.Button();
            this.btnTextItalic = new System.Windows.Forms.Button();
            this.btnTextBold = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbText
            // 
            this.lbText.AutoEllipsis = true;
            this.lbText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbText.Location = new System.Drawing.Point(6, 16);
            this.lbText.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(51, 22);
            this.lbText.TabIndex = 5;
            this.lbText.Text = "Текст";
            this.lbText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbText.TextChanged += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            this.lbText.Click += new System.EventHandler(this.lbText_Click);
            // 
            // cbFontName
            // 
            this.cbFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbFontName.FormattingEnabled = true;
            this.cbFontName.Location = new System.Drawing.Point(60, 17);
            this.cbFontName.Margin = new System.Windows.Forms.Padding(3, 1, 0, 0);
            this.cbFontName.Name = "cbFontName";
            this.cbFontName.Size = new System.Drawing.Size(129, 21);
            this.cbFontName.TabIndex = 3;
            this.cbFontName.SelectionChangeCommitted += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            // 
            // btnRightAllign
            // 
            this.btnRightAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRightAllign.Image = global::SimpleEditor.Properties.Resources.alignright;
            this.btnRightAllign.Location = new System.Drawing.Point(156, 45);
            this.btnRightAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnRightAllign.Name = "btnRightAllign";
            this.btnRightAllign.Size = new System.Drawing.Size(24, 22);
            this.btnRightAllign.TabIndex = 6;
            this.btnRightAllign.UseVisualStyleBackColor = true;
            this.btnRightAllign.Click += new System.EventHandler(this.btnRightAllign_Click);
            // 
            // btnCenterAllign
            // 
            this.btnCenterAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCenterAllign.Image = global::SimpleEditor.Properties.Resources.aligncenter;
            this.btnCenterAllign.Location = new System.Drawing.Point(130, 45);
            this.btnCenterAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnCenterAllign.Name = "btnCenterAllign";
            this.btnCenterAllign.Size = new System.Drawing.Size(24, 22);
            this.btnCenterAllign.TabIndex = 7;
            this.btnCenterAllign.UseVisualStyleBackColor = true;
            this.btnCenterAllign.Click += new System.EventHandler(this.btnCenterAllign_Click);
            // 
            // btnLeftAllign
            // 
            this.btnLeftAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLeftAllign.Image = global::SimpleEditor.Properties.Resources.alignleft;
            this.btnLeftAllign.Location = new System.Drawing.Point(104, 45);
            this.btnLeftAllign.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.btnLeftAllign.Name = "btnLeftAllign";
            this.btnLeftAllign.Size = new System.Drawing.Size(24, 22);
            this.btnLeftAllign.TabIndex = 8;
            this.btnLeftAllign.UseVisualStyleBackColor = true;
            this.btnLeftAllign.Click += new System.EventHandler(this.btnLeftAllign_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.btnTextUnderline);
            this.groupBox1.Controls.Add(this.btnTextItalic);
            this.groupBox1.Controls.Add(this.btnTextBold);
            this.groupBox1.Controls.Add(this.btnRightAllign);
            this.groupBox1.Controls.Add(this.btnCenterAllign);
            this.groupBox1.Controls.Add(this.btnLeftAllign);
            this.groupBox1.Controls.Add(this.lbText);
            this.groupBox1.Controls.Add(this.cbFontName);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(200, 81);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text Style";
            // 
            // btnTextUnderline
            // 
            this.btnTextUnderline.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTextUnderline.Image = global::SimpleEditor.Properties.Resources.underline;
            this.btnTextUnderline.Location = new System.Drawing.Point(63, 45);
            this.btnTextUnderline.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnTextUnderline.Name = "btnTextUnderline";
            this.btnTextUnderline.Size = new System.Drawing.Size(24, 22);
            this.btnTextUnderline.TabIndex = 12;
            this.btnTextUnderline.UseVisualStyleBackColor = true;
            this.btnTextUnderline.Click += new System.EventHandler(this.btnTextUnderline_Click);
            // 
            // btnTextItalic
            // 
            this.btnTextItalic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTextItalic.Image = global::SimpleEditor.Properties.Resources.italic;
            this.btnTextItalic.Location = new System.Drawing.Point(37, 45);
            this.btnTextItalic.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnTextItalic.Name = "btnTextItalic";
            this.btnTextItalic.Size = new System.Drawing.Size(24, 22);
            this.btnTextItalic.TabIndex = 13;
            this.btnTextItalic.UseVisualStyleBackColor = true;
            this.btnTextItalic.Click += new System.EventHandler(this.btnTextItalic_Click);
            // 
            // btnTextBold
            // 
            this.btnTextBold.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTextBold.Image = global::SimpleEditor.Properties.Resources.bold;
            this.btnTextBold.Location = new System.Drawing.Point(11, 45);
            this.btnTextBold.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.btnTextBold.Name = "btnTextBold";
            this.btnTextBold.Size = new System.Drawing.Size(24, 22);
            this.btnTextBold.TabIndex = 14;
            this.btnTextBold.UseVisualStyleBackColor = true;
            this.btnTextBold.Click += new System.EventHandler(this.btnTextBold_Click);
            // 
            // TextStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TextStyleEditor";
            this.Size = new System.Drawing.Size(210, 88);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.ComboBox cbFontName;
        private System.Windows.Forms.Button btnRightAllign;
        private System.Windows.Forms.Button btnCenterAllign;
        private System.Windows.Forms.Button btnLeftAllign;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTextUnderline;
        private System.Windows.Forms.Button btnTextItalic;
        private System.Windows.Forms.Button btnTextBold;
    }
}
