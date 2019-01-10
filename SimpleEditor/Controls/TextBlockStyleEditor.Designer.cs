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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextBlockStyleEditor));
            this.cbFontName = new System.Windows.Forms.ComboBox();
            this.lbText = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbWrap = new System.Windows.Forms.CheckBox();
            this.nudBottom = new System.Windows.Forms.NumericUpDown();
            this.nudRight = new System.Windows.Forms.NumericUpDown();
            this.nudLeft = new System.Windows.Forms.NumericUpDown();
            this.nudTop = new System.Windows.Forms.NumericUpDown();
            this.cbFontSize = new System.Windows.Forms.ComboBox();
            this.btnBottomRightAllign = new System.Windows.Forms.Button();
            this.btnMiddleRightAllign = new System.Windows.Forms.Button();
            this.btnTextUnderline = new System.Windows.Forms.Button();
            this.btnTopRightAllign = new System.Windows.Forms.Button();
            this.btnBottomCenterAllign = new System.Windows.Forms.Button();
            this.btnMiddleCenterAllign = new System.Windows.Forms.Button();
            this.btnTextItalic = new System.Windows.Forms.Button();
            this.btnTopCenterAllign = new System.Windows.Forms.Button();
            this.btnBottomLeftAllign = new System.Windows.Forms.Button();
            this.btnTextBold = new System.Windows.Forms.Button();
            this.btnMiddleLeftAllign = new System.Windows.Forms.Button();
            this.btnTopLeftAllign = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFontName
            // 
            this.cbFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbFontName.FormattingEnabled = true;
            this.cbFontName.Location = new System.Drawing.Point(10, 15);
            this.cbFontName.Margin = new System.Windows.Forms.Padding(3, 1, 0, 0);
            this.cbFontName.Name = "cbFontName";
            this.cbFontName.Size = new System.Drawing.Size(107, 21);
            this.cbFontName.TabIndex = 0;
            this.cbFontName.SelectionChangeCommitted += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            // 
            // lbText
            // 
            this.lbText.AutoEllipsis = true;
            this.lbText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbText.Location = new System.Drawing.Point(93, 38);
            this.lbText.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(50, 27);
            this.lbText.TabIndex = 2;
            this.lbText.Text = "Текст";
            this.lbText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbText.TextAlignChanged += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            this.lbText.TextChanged += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            this.lbText.Click += new System.EventHandler(this.lbText_Click);
            this.lbText.Paint += new System.Windows.Forms.PaintEventHandler(this.lbText_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.cbWrap);
            this.groupBox1.Controls.Add(this.nudBottom);
            this.groupBox1.Controls.Add(this.nudRight);
            this.groupBox1.Controls.Add(this.nudLeft);
            this.groupBox1.Controls.Add(this.nudTop);
            this.groupBox1.Controls.Add(this.cbFontSize);
            this.groupBox1.Controls.Add(this.btnBottomRightAllign);
            this.groupBox1.Controls.Add(this.btnMiddleRightAllign);
            this.groupBox1.Controls.Add(this.btnTextUnderline);
            this.groupBox1.Controls.Add(this.btnTopRightAllign);
            this.groupBox1.Controls.Add(this.btnBottomCenterAllign);
            this.groupBox1.Controls.Add(this.btnMiddleCenterAllign);
            this.groupBox1.Controls.Add(this.btnTextItalic);
            this.groupBox1.Controls.Add(this.btnTopCenterAllign);
            this.groupBox1.Controls.Add(this.btnBottomLeftAllign);
            this.groupBox1.Controls.Add(this.btnTextBold);
            this.groupBox1.Controls.Add(this.btnMiddleLeftAllign);
            this.groupBox1.Controls.Add(this.btnTopLeftAllign);
            this.groupBox1.Controls.Add(this.cbFontName);
            this.groupBox1.Controls.Add(this.lbText);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(205, 151);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text Block Style";
            // 
            // cbWrap
            // 
            this.cbWrap.AutoSize = true;
            this.cbWrap.Location = new System.Drawing.Point(149, 45);
            this.cbWrap.Name = "cbWrap";
            this.cbWrap.Size = new System.Drawing.Size(52, 17);
            this.cbWrap.TabIndex = 14;
            this.cbWrap.Text = "Wrap";
            this.cbWrap.UseVisualStyleBackColor = true;
            this.cbWrap.CheckedChanged += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            // 
            // nudBottom
            // 
            this.nudBottom.Location = new System.Drawing.Point(130, 114);
            this.nudBottom.Name = "nudBottom";
            this.nudBottom.Size = new System.Drawing.Size(39, 20);
            this.nudBottom.TabIndex = 13;
            this.nudBottom.ValueChanged += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            // 
            // nudRight
            // 
            this.nudRight.Location = new System.Drawing.Point(156, 91);
            this.nudRight.Name = "nudRight";
            this.nudRight.Size = new System.Drawing.Size(39, 20);
            this.nudRight.TabIndex = 13;
            this.nudRight.ValueChanged += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            // 
            // nudLeft
            // 
            this.nudLeft.Location = new System.Drawing.Point(93, 91);
            this.nudLeft.Name = "nudLeft";
            this.nudLeft.Size = new System.Drawing.Size(39, 20);
            this.nudLeft.TabIndex = 13;
            this.nudLeft.ValueChanged += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            // 
            // nudTop
            // 
            this.nudTop.Location = new System.Drawing.Point(130, 68);
            this.nudTop.Name = "nudTop";
            this.nudTop.Size = new System.Drawing.Size(39, 20);
            this.nudTop.TabIndex = 13;
            this.nudTop.ValueChanged += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
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
            this.cbFontSize.Location = new System.Drawing.Point(10, 39);
            this.cbFontSize.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.cbFontSize.Name = "cbFontSize";
            this.cbFontSize.Size = new System.Drawing.Size(76, 21);
            this.cbFontSize.TabIndex = 12;
            this.cbFontSize.SelectionChangeCommitted += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            // 
            // btnBottomRightAllign
            // 
            this.btnBottomRightAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBottomRightAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnBottomRightAllign.Image")));
            this.btnBottomRightAllign.Location = new System.Drawing.Point(62, 112);
            this.btnBottomRightAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnBottomRightAllign.Name = "btnBottomRightAllign";
            this.btnBottomRightAllign.Size = new System.Drawing.Size(24, 22);
            this.btnBottomRightAllign.TabIndex = 9;
            this.btnBottomRightAllign.UseVisualStyleBackColor = true;
            this.btnBottomRightAllign.Click += new System.EventHandler(this.btnBottomRightAllignClick);
            // 
            // btnMiddleRightAllign
            // 
            this.btnMiddleRightAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMiddleRightAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnMiddleRightAllign.Image")));
            this.btnMiddleRightAllign.Location = new System.Drawing.Point(62, 89);
            this.btnMiddleRightAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnMiddleRightAllign.Name = "btnMiddleRightAllign";
            this.btnMiddleRightAllign.Size = new System.Drawing.Size(24, 22);
            this.btnMiddleRightAllign.TabIndex = 9;
            this.btnMiddleRightAllign.UseVisualStyleBackColor = true;
            this.btnMiddleRightAllign.Click += new System.EventHandler(this.btnMiddleRightAllignClick);
            // 
            // btnTextUnderline
            // 
            this.btnTextUnderline.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTextUnderline.Image = global::SimpleEditor.Properties.Resources.underline;
            this.btnTextUnderline.Location = new System.Drawing.Point(171, 15);
            this.btnTextUnderline.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnTextUnderline.Name = "btnTextUnderline";
            this.btnTextUnderline.Size = new System.Drawing.Size(24, 22);
            this.btnTextUnderline.TabIndex = 9;
            this.btnTextUnderline.UseVisualStyleBackColor = true;
            this.btnTextUnderline.Click += new System.EventHandler(this.btnTextUnderline_Click);
            // 
            // btnTopRightAllign
            // 
            this.btnTopRightAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTopRightAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnTopRightAllign.Image")));
            this.btnTopRightAllign.Location = new System.Drawing.Point(62, 66);
            this.btnTopRightAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnTopRightAllign.Name = "btnTopRightAllign";
            this.btnTopRightAllign.Size = new System.Drawing.Size(24, 22);
            this.btnTopRightAllign.TabIndex = 9;
            this.btnTopRightAllign.UseVisualStyleBackColor = true;
            this.btnTopRightAllign.Click += new System.EventHandler(this.btnTopRightAllignClick);
            // 
            // btnBottomCenterAllign
            // 
            this.btnBottomCenterAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBottomCenterAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnBottomCenterAllign.Image")));
            this.btnBottomCenterAllign.Location = new System.Drawing.Point(36, 112);
            this.btnBottomCenterAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnBottomCenterAllign.Name = "btnBottomCenterAllign";
            this.btnBottomCenterAllign.Size = new System.Drawing.Size(24, 22);
            this.btnBottomCenterAllign.TabIndex = 10;
            this.btnBottomCenterAllign.UseVisualStyleBackColor = true;
            this.btnBottomCenterAllign.Click += new System.EventHandler(this.btnBottomCenterAllignClick);
            // 
            // btnMiddleCenterAllign
            // 
            this.btnMiddleCenterAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMiddleCenterAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnMiddleCenterAllign.Image")));
            this.btnMiddleCenterAllign.Location = new System.Drawing.Point(36, 89);
            this.btnMiddleCenterAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnMiddleCenterAllign.Name = "btnMiddleCenterAllign";
            this.btnMiddleCenterAllign.Size = new System.Drawing.Size(24, 22);
            this.btnMiddleCenterAllign.TabIndex = 10;
            this.btnMiddleCenterAllign.UseVisualStyleBackColor = true;
            this.btnMiddleCenterAllign.Click += new System.EventHandler(this.btnMiddleCenterAllignClick);
            // 
            // btnTextItalic
            // 
            this.btnTextItalic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTextItalic.Image = global::SimpleEditor.Properties.Resources.italic;
            this.btnTextItalic.Location = new System.Drawing.Point(145, 15);
            this.btnTextItalic.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnTextItalic.Name = "btnTextItalic";
            this.btnTextItalic.Size = new System.Drawing.Size(24, 22);
            this.btnTextItalic.TabIndex = 10;
            this.btnTextItalic.UseVisualStyleBackColor = true;
            this.btnTextItalic.Click += new System.EventHandler(this.btnTextItalic_Click);
            // 
            // btnTopCenterAllign
            // 
            this.btnTopCenterAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTopCenterAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnTopCenterAllign.Image")));
            this.btnTopCenterAllign.Location = new System.Drawing.Point(36, 66);
            this.btnTopCenterAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnTopCenterAllign.Name = "btnTopCenterAllign";
            this.btnTopCenterAllign.Size = new System.Drawing.Size(24, 22);
            this.btnTopCenterAllign.TabIndex = 10;
            this.btnTopCenterAllign.UseVisualStyleBackColor = true;
            this.btnTopCenterAllign.Click += new System.EventHandler(this.btnTopCenterAllignClick);
            // 
            // btnBottomLeftAllign
            // 
            this.btnBottomLeftAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBottomLeftAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnBottomLeftAllign.Image")));
            this.btnBottomLeftAllign.Location = new System.Drawing.Point(10, 112);
            this.btnBottomLeftAllign.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.btnBottomLeftAllign.Name = "btnBottomLeftAllign";
            this.btnBottomLeftAllign.Size = new System.Drawing.Size(24, 22);
            this.btnBottomLeftAllign.TabIndex = 11;
            this.btnBottomLeftAllign.UseVisualStyleBackColor = true;
            this.btnBottomLeftAllign.Click += new System.EventHandler(this.btnBottomLeftAllignClick);
            // 
            // btnTextBold
            // 
            this.btnTextBold.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTextBold.Image = global::SimpleEditor.Properties.Resources.bold;
            this.btnTextBold.Location = new System.Drawing.Point(119, 15);
            this.btnTextBold.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.btnTextBold.Name = "btnTextBold";
            this.btnTextBold.Size = new System.Drawing.Size(24, 22);
            this.btnTextBold.TabIndex = 11;
            this.btnTextBold.UseVisualStyleBackColor = true;
            this.btnTextBold.Click += new System.EventHandler(this.btnTextBold_Click);
            // 
            // btnMiddleLeftAllign
            // 
            this.btnMiddleLeftAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMiddleLeftAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnMiddleLeftAllign.Image")));
            this.btnMiddleLeftAllign.Location = new System.Drawing.Point(10, 89);
            this.btnMiddleLeftAllign.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.btnMiddleLeftAllign.Name = "btnMiddleLeftAllign";
            this.btnMiddleLeftAllign.Size = new System.Drawing.Size(24, 22);
            this.btnMiddleLeftAllign.TabIndex = 11;
            this.btnMiddleLeftAllign.UseVisualStyleBackColor = true;
            this.btnMiddleLeftAllign.Click += new System.EventHandler(this.btnMiddleLeftAllignClick);
            // 
            // btnTopLeftAllign
            // 
            this.btnTopLeftAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTopLeftAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnTopLeftAllign.Image")));
            this.btnTopLeftAllign.Location = new System.Drawing.Point(10, 66);
            this.btnTopLeftAllign.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.btnTopLeftAllign.Name = "btnTopLeftAllign";
            this.btnTopLeftAllign.Size = new System.Drawing.Size(24, 22);
            this.btnTopLeftAllign.TabIndex = 11;
            this.btnTopLeftAllign.UseVisualStyleBackColor = true;
            this.btnTopLeftAllign.Click += new System.EventHandler(this.btnTopLeftAllignClick);
            // 
            // TextBlockStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TextBlockStyleEditor";
            this.Size = new System.Drawing.Size(212, 155);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFontName;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.Button btnTopLeftAllign;
        private System.Windows.Forms.Button btnTopCenterAllign;
        private System.Windows.Forms.Button btnTopRightAllign;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBottomRightAllign;
        private System.Windows.Forms.Button btnMiddleRightAllign;
        private System.Windows.Forms.Button btnBottomCenterAllign;
        private System.Windows.Forms.Button btnMiddleCenterAllign;
        private System.Windows.Forms.Button btnBottomLeftAllign;
        private System.Windows.Forms.Button btnMiddleLeftAllign;
        private System.Windows.Forms.ComboBox cbFontSize;
        private System.Windows.Forms.Button btnTextUnderline;
        private System.Windows.Forms.Button btnTextItalic;
        private System.Windows.Forms.Button btnTextBold;
        private System.Windows.Forms.NumericUpDown nudBottom;
        private System.Windows.Forms.NumericUpDown nudRight;
        private System.Windows.Forms.NumericUpDown nudLeft;
        private System.Windows.Forms.NumericUpDown nudTop;
        private System.Windows.Forms.CheckBox cbWrap;
    }
}
