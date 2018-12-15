namespace SimpleEditor.Controls
{
    partial class TextBlockStyleEditor
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
            this.cbFontName = new System.Windows.Forms.ComboBox();
            this.lbText = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLeftAllign = new System.Windows.Forms.Button();
            this.btnCenterAllign = new System.Windows.Forms.Button();
            this.btnRightAllign = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbFontName
            // 
            this.cbFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbFontName.FormattingEnabled = true;
            this.cbFontName.Location = new System.Drawing.Point(47, 1);
            this.cbFontName.Margin = new System.Windows.Forms.Padding(3, 1, 0, 0);
            this.cbFontName.Name = "cbFontName";
            this.cbFontName.Size = new System.Drawing.Size(88, 21);
            this.cbFontName.TabIndex = 0;
            this.cbFontName.SelectionChangeCommitted += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            // 
            // lbText
            // 
            this.lbText.AutoEllipsis = true;
            this.lbText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbText.Location = new System.Drawing.Point(0, 1);
            this.lbText.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(44, 22);
            this.lbText.TabIndex = 2;
            this.lbText.Text = "Текст";
            this.lbText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbText.TextAlignChanged += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            this.lbText.TextChanged += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            this.lbText.Click += new System.EventHandler(this.lbText_Click);
            this.lbText.Paint += new System.Windows.Forms.PaintEventHandler(this.lbText_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.lbText);
            this.flowLayoutPanel1.Controls.Add(this.cbFontName);
            this.flowLayoutPanel1.Controls.Add(this.btnLeftAllign);
            this.flowLayoutPanel1.Controls.Add(this.btnCenterAllign);
            this.flowLayoutPanel1.Controls.Add(this.btnRightAllign);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(214, 26);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btnLeftAllign
            // 
            this.btnLeftAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLeftAllign.Image = global::SimpleEditor.Properties.Resources.alignleft;
            this.btnLeftAllign.Location = new System.Drawing.Point(137, 1);
            this.btnLeftAllign.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.btnLeftAllign.Name = "btnLeftAllign";
            this.btnLeftAllign.Size = new System.Drawing.Size(24, 22);
            this.btnLeftAllign.TabIndex = 11;
            this.btnLeftAllign.UseVisualStyleBackColor = true;
            this.btnLeftAllign.Click += new System.EventHandler(this.btnLeftAllign_Click);
            // 
            // btnCenterAllign
            // 
            this.btnCenterAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCenterAllign.Image = global::SimpleEditor.Properties.Resources.aligncenter;
            this.btnCenterAllign.Location = new System.Drawing.Point(161, 1);
            this.btnCenterAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnCenterAllign.Name = "btnCenterAllign";
            this.btnCenterAllign.Size = new System.Drawing.Size(24, 22);
            this.btnCenterAllign.TabIndex = 10;
            this.btnCenterAllign.UseVisualStyleBackColor = true;
            this.btnCenterAllign.Click += new System.EventHandler(this.btnCenterAllign_Click);
            // 
            // btnRightAllign
            // 
            this.btnRightAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRightAllign.Image = global::SimpleEditor.Properties.Resources.alignright;
            this.btnRightAllign.Location = new System.Drawing.Point(185, 1);
            this.btnRightAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnRightAllign.Name = "btnRightAllign";
            this.btnRightAllign.Size = new System.Drawing.Size(24, 22);
            this.btnRightAllign.TabIndex = 9;
            this.btnRightAllign.UseVisualStyleBackColor = true;
            this.btnRightAllign.Click += new System.EventHandler(this.btnRightAllign_Click);
            // 
            // TextBlockStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TextBlockStyleEditor";
            this.Size = new System.Drawing.Size(218, 32);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFontName;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnLeftAllign;
        private System.Windows.Forms.Button btnCenterAllign;
        private System.Windows.Forms.Button btnRightAllign;
    }
}
