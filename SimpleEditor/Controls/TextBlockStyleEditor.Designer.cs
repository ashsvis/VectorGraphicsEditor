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
            this.cbFontSize = new System.Windows.Forms.ComboBox();
            this.lbText = new System.Windows.Forms.Label();
            this.btnTopLeftAllign = new System.Windows.Forms.Button();
            this.btnTopCenterAllign = new System.Windows.Forms.Button();
            this.btnTopRightAllign = new System.Windows.Forms.Button();
            this.btnMiddleLeftAllign = new System.Windows.Forms.Button();
            this.btnMiddleCenterAllign = new System.Windows.Forms.Button();
            this.btnMiddleRightAllign = new System.Windows.Forms.Button();
            this.btnBottomLeftAllign = new System.Windows.Forms.Button();
            this.btnBottomCenterAllign = new System.Windows.Forms.Button();
            this.btnBottomRightAllign = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.cbFontName.TabIndex = 0;
            this.cbFontName.SelectionChangeCommitted += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
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
            this.cbFontSize.TabIndex = 1;
            this.cbFontSize.SelectionChangeCommitted += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
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
            this.lbText.Size = new System.Drawing.Size(44, 22);
            this.lbText.TabIndex = 2;
            this.lbText.Text = "Текст";
            this.lbText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbText.TextAlignChanged += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            this.lbText.TextChanged += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            this.lbText.Click += new System.EventHandler(this.lbText_Click);
            this.lbText.Paint += new System.Windows.Forms.PaintEventHandler(this.lbText_Paint);
            // 
            // btnTopLeftAllign
            // 
            this.btnTopLeftAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTopLeftAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnTopLeftAllign.Image")));
            this.btnTopLeftAllign.Location = new System.Drawing.Point(182, 1);
            this.btnTopLeftAllign.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.btnTopLeftAllign.Name = "btnTopLeftAllign";
            this.btnTopLeftAllign.Size = new System.Drawing.Size(24, 22);
            this.btnTopLeftAllign.TabIndex = 3;
            this.btnTopLeftAllign.UseVisualStyleBackColor = true;
            this.btnTopLeftAllign.Click += new System.EventHandler(this.btnTopLeftAllign_Click);
            // 
            // btnTopCenterAllign
            // 
            this.btnTopCenterAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTopCenterAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnTopCenterAllign.Image")));
            this.btnTopCenterAllign.Location = new System.Drawing.Point(206, 1);
            this.btnTopCenterAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnTopCenterAllign.Name = "btnTopCenterAllign";
            this.btnTopCenterAllign.Size = new System.Drawing.Size(24, 22);
            this.btnTopCenterAllign.TabIndex = 3;
            this.btnTopCenterAllign.UseVisualStyleBackColor = true;
            this.btnTopCenterAllign.Click += new System.EventHandler(this.btnTopCenterAllign_Click);
            // 
            // btnTopRightAllign
            // 
            this.btnTopRightAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTopRightAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnTopRightAllign.Image")));
            this.btnTopRightAllign.Location = new System.Drawing.Point(230, 1);
            this.btnTopRightAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnTopRightAllign.Name = "btnTopRightAllign";
            this.btnTopRightAllign.Size = new System.Drawing.Size(24, 22);
            this.btnTopRightAllign.TabIndex = 3;
            this.btnTopRightAllign.UseVisualStyleBackColor = true;
            this.btnTopRightAllign.Click += new System.EventHandler(this.btnTopRightAllign_Click);
            // 
            // btnMiddleLeftAllign
            // 
            this.btnMiddleLeftAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMiddleLeftAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnMiddleLeftAllign.Image")));
            this.btnMiddleLeftAllign.Location = new System.Drawing.Point(256, 1);
            this.btnMiddleLeftAllign.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.btnMiddleLeftAllign.Name = "btnMiddleLeftAllign";
            this.btnMiddleLeftAllign.Size = new System.Drawing.Size(24, 22);
            this.btnMiddleLeftAllign.TabIndex = 3;
            this.btnMiddleLeftAllign.UseVisualStyleBackColor = true;
            this.btnMiddleLeftAllign.Click += new System.EventHandler(this.btnMiddleLeftAllign_Click);
            // 
            // btnMiddleCenterAllign
            // 
            this.btnMiddleCenterAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMiddleCenterAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnMiddleCenterAllign.Image")));
            this.btnMiddleCenterAllign.Location = new System.Drawing.Point(280, 1);
            this.btnMiddleCenterAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnMiddleCenterAllign.Name = "btnMiddleCenterAllign";
            this.btnMiddleCenterAllign.Size = new System.Drawing.Size(24, 22);
            this.btnMiddleCenterAllign.TabIndex = 3;
            this.btnMiddleCenterAllign.UseVisualStyleBackColor = true;
            this.btnMiddleCenterAllign.Click += new System.EventHandler(this.btnMiddleCenterAllign_Click);
            // 
            // btnMiddleRightAllign
            // 
            this.btnMiddleRightAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMiddleRightAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnMiddleRightAllign.Image")));
            this.btnMiddleRightAllign.Location = new System.Drawing.Point(304, 1);
            this.btnMiddleRightAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnMiddleRightAllign.Name = "btnMiddleRightAllign";
            this.btnMiddleRightAllign.Size = new System.Drawing.Size(24, 22);
            this.btnMiddleRightAllign.TabIndex = 3;
            this.btnMiddleRightAllign.UseVisualStyleBackColor = true;
            this.btnMiddleRightAllign.Click += new System.EventHandler(this.btnMiddleRightAllign_Click);
            // 
            // btnBottomLeftAllign
            // 
            this.btnBottomLeftAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBottomLeftAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnBottomLeftAllign.Image")));
            this.btnBottomLeftAllign.Location = new System.Drawing.Point(330, 1);
            this.btnBottomLeftAllign.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.btnBottomLeftAllign.Name = "btnBottomLeftAllign";
            this.btnBottomLeftAllign.Size = new System.Drawing.Size(24, 22);
            this.btnBottomLeftAllign.TabIndex = 3;
            this.btnBottomLeftAllign.UseVisualStyleBackColor = true;
            this.btnBottomLeftAllign.Click += new System.EventHandler(this.btnBottomLeftAllign_Click);
            // 
            // btnBottomCenterAllign
            // 
            this.btnBottomCenterAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBottomCenterAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnBottomCenterAllign.Image")));
            this.btnBottomCenterAllign.Location = new System.Drawing.Point(354, 1);
            this.btnBottomCenterAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnBottomCenterAllign.Name = "btnBottomCenterAllign";
            this.btnBottomCenterAllign.Size = new System.Drawing.Size(24, 22);
            this.btnBottomCenterAllign.TabIndex = 3;
            this.btnBottomCenterAllign.UseVisualStyleBackColor = true;
            this.btnBottomCenterAllign.Click += new System.EventHandler(this.btnBottomCenterAllign_Click);
            // 
            // btnBottomRightAllign
            // 
            this.btnBottomRightAllign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBottomRightAllign.Image = ((System.Drawing.Image)(resources.GetObject("btnBottomRightAllign.Image")));
            this.btnBottomRightAllign.Location = new System.Drawing.Point(378, 1);
            this.btnBottomRightAllign.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnBottomRightAllign.Name = "btnBottomRightAllign";
            this.btnBottomRightAllign.Size = new System.Drawing.Size(24, 22);
            this.btnBottomRightAllign.TabIndex = 3;
            this.btnBottomRightAllign.UseVisualStyleBackColor = true;
            this.btnBottomRightAllign.Click += new System.EventHandler(this.btnBottomRightAllign_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.cbFontName);
            this.flowLayoutPanel1.Controls.Add(this.cbFontSize);
            this.flowLayoutPanel1.Controls.Add(this.lbText);
            this.flowLayoutPanel1.Controls.Add(this.btnTopLeftAllign);
            this.flowLayoutPanel1.Controls.Add(this.btnTopCenterAllign);
            this.flowLayoutPanel1.Controls.Add(this.btnTopRightAllign);
            this.flowLayoutPanel1.Controls.Add(this.btnMiddleLeftAllign);
            this.flowLayoutPanel1.Controls.Add(this.btnMiddleCenterAllign);
            this.flowLayoutPanel1.Controls.Add(this.btnMiddleRightAllign);
            this.flowLayoutPanel1.Controls.Add(this.btnBottomLeftAllign);
            this.flowLayoutPanel1.Controls.Add(this.btnBottomCenterAllign);
            this.flowLayoutPanel1.Controls.Add(this.btnBottomRightAllign);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(402, 26);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // TextBlockStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TextBlockStyleEditor";
            this.Size = new System.Drawing.Size(403, 34);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFontName;
        private System.Windows.Forms.ComboBox cbFontSize;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.Button btnTopLeftAllign;
        private System.Windows.Forms.Button btnTopCenterAllign;
        private System.Windows.Forms.Button btnTopRightAllign;
        private System.Windows.Forms.Button btnMiddleLeftAllign;
        private System.Windows.Forms.Button btnMiddleCenterAllign;
        private System.Windows.Forms.Button btnMiddleRightAllign;
        private System.Windows.Forms.Button btnBottomLeftAllign;
        private System.Windows.Forms.Button btnBottomCenterAllign;
        private System.Windows.Forms.Button btnBottomRightAllign;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
