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
            this.cbFontSize = new System.Windows.Forms.ComboBox();
            this.cbFontName = new System.Windows.Forms.ComboBox();
            this.btnRightAllign = new System.Windows.Forms.Button();
            this.btnCenterAllign = new System.Windows.Forms.Button();
            this.btnLeftAllign = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbText
            // 
            this.lbText.AutoEllipsis = true;
            this.lbText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbText.Location = new System.Drawing.Point(136, 1);
            this.lbText.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(45, 24);
            this.lbText.TabIndex = 5;
            this.lbText.Text = "Текст";
            this.lbText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbText.TextChanged += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            this.lbText.Click += new System.EventHandler(this.lbText_Click);
            // 
            // cbFontSize
            // 
            this.cbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbFontSize.FormattingEnabled = true;
            this.cbFontSize.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72"});
            this.cbFontSize.Location = new System.Drawing.Point(91, 1);
            this.cbFontSize.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.cbFontSize.Name = "cbFontSize";
            this.cbFontSize.Size = new System.Drawing.Size(45, 21);
            this.cbFontSize.TabIndex = 4;
            this.cbFontSize.SelectionChangeCommitted += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            // 
            // cbFontName
            // 
            this.cbFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbFontName.FormattingEnabled = true;
            this.cbFontName.Location = new System.Drawing.Point(3, 1);
            this.cbFontName.Margin = new System.Windows.Forms.Padding(3, 1, 0, 0);
            this.cbFontName.Name = "cbFontName";
            this.cbFontName.Size = new System.Drawing.Size(88, 21);
            this.cbFontName.TabIndex = 3;
            this.cbFontName.SelectionChangeCommitted += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            // 
            // btnRightAllign
            // 
            this.btnRightAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRightAllign.Image = global::SimpleEditor.Properties.Resources.alignright;
            this.btnRightAllign.Location = new System.Drawing.Point(231, 1);
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
            this.btnCenterAllign.Location = new System.Drawing.Point(207, 1);
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
            this.btnLeftAllign.Location = new System.Drawing.Point(183, 1);
            this.btnLeftAllign.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.btnLeftAllign.Name = "btnLeftAllign";
            this.btnLeftAllign.Size = new System.Drawing.Size(24, 22);
            this.btnLeftAllign.TabIndex = 8;
            this.btnLeftAllign.UseVisualStyleBackColor = true;
            this.btnLeftAllign.Click += new System.EventHandler(this.btnLeftAllign_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cbFontName);
            this.flowLayoutPanel1.Controls.Add(this.cbFontSize);
            this.flowLayoutPanel1.Controls.Add(this.lbText);
            this.flowLayoutPanel1.Controls.Add(this.btnLeftAllign);
            this.flowLayoutPanel1.Controls.Add(this.btnCenterAllign);
            this.flowLayoutPanel1.Controls.Add(this.btnRightAllign);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(260, 25);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // TextStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TextStyleEditor";
            this.Size = new System.Drawing.Size(265, 25);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.ComboBox cbFontSize;
        private System.Windows.Forms.ComboBox cbFontName;
        private System.Windows.Forms.Button btnRightAllign;
        private System.Windows.Forms.Button btnCenterAllign;
        private System.Windows.Forms.Button btnLeftAllign;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
