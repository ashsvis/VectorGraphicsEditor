namespace SimpleEditor.Controls
{
    partial class TextStyleEditor
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
            this.cbFontSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbFontName
            // 
            this.cbFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontName.FormattingEnabled = true;
            this.cbFontName.Location = new System.Drawing.Point(3, 2);
            this.cbFontName.Name = "cbFontName";
            this.cbFontName.Size = new System.Drawing.Size(88, 21);
            this.cbFontName.TabIndex = 0;
            this.cbFontName.SelectionChangeCommitted += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            // 
            // cbFontSize
            // 
            this.cbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cbFontSize.Location = new System.Drawing.Point(97, 2);
            this.cbFontSize.Name = "cbFontSize";
            this.cbFontSize.Size = new System.Drawing.Size(45, 21);
            this.cbFontSize.TabIndex = 1;
            this.cbFontSize.SelectionChangeCommitted += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Text";
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(182, 2);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(165, 20);
            this.tbText.TabIndex = 3;
            this.tbText.TextChanged += new System.EventHandler(this.cbFontName_SelectionChangeCommitted);
            // 
            // TextStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFontSize);
            this.Controls.Add(this.cbFontName);
            this.Name = "TextStyleEditor";
            this.Size = new System.Drawing.Size(353, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFontName;
        private System.Windows.Forms.ComboBox cbFontSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbText;
    }
}
