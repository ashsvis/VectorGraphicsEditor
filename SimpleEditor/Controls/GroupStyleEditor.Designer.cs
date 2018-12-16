namespace SimpleEditor.Controls
{
    partial class GroupStyleEditor
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
            this.lbGroupSelectionText = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadPicture = new System.Windows.Forms.Button();
            this.lbJoin = new System.Windows.Forms.Label();
            this.cbJoin = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbGroupSelectionText
            // 
            this.lbGroupSelectionText.AutoSize = true;
            this.lbGroupSelectionText.Location = new System.Drawing.Point(3, 3);
            this.lbGroupSelectionText.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbGroupSelectionText.Name = "lbGroupSelectionText";
            this.lbGroupSelectionText.Size = new System.Drawing.Size(51, 13);
            this.lbGroupSelectionText.TabIndex = 5;
            this.lbGroupSelectionText.Text = "Selection";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lbGroupSelectionText);
            this.flowLayoutPanel1.Controls.Add(this.btnLoadPicture);
            this.flowLayoutPanel1.Controls.Add(this.lbJoin);
            this.flowLayoutPanel1.Controls.Add(this.cbJoin);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(245, 22);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btnLoadPicture
            // 
            this.btnLoadPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoadPicture.Location = new System.Drawing.Point(57, 0);
            this.btnLoadPicture.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoadPicture.Name = "btnLoadPicture";
            this.btnLoadPicture.Size = new System.Drawing.Size(51, 21);
            this.btnLoadPicture.TabIndex = 6;
            this.btnLoadPicture.Text = "Load...";
            this.btnLoadPicture.UseVisualStyleBackColor = true;
            this.btnLoadPicture.Click += new System.EventHandler(this.lbPicture_Click);
            // 
            // lbJoin
            // 
            this.lbJoin.AutoSize = true;
            this.lbJoin.Location = new System.Drawing.Point(111, 3);
            this.lbJoin.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbJoin.Name = "lbJoin";
            this.lbJoin.Size = new System.Drawing.Size(29, 13);
            this.lbJoin.TabIndex = 7;
            this.lbJoin.Text = "Join:";
            // 
            // cbJoin
            // 
            this.cbJoin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJoin.FormattingEnabled = true;
            this.cbJoin.Items.AddRange(new object[] {
            "None",
            "Intersect",
            "Union",
            "Xor",
            "Exclude",
            "Complement"});
            this.cbJoin.Location = new System.Drawing.Point(143, 0);
            this.cbJoin.Margin = new System.Windows.Forms.Padding(0);
            this.cbJoin.Name = "cbJoin";
            this.cbJoin.Size = new System.Drawing.Size(102, 21);
            this.cbJoin.TabIndex = 8;
            this.cbJoin.SelectionChangeCommitted += new System.EventHandler(this.cbJoin_SelectionChangeCommitted);
            // 
            // GroupStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GroupStyleEditor";
            this.Size = new System.Drawing.Size(266, 30);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbGroupSelectionText;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnLoadPicture;
        private System.Windows.Forms.Label lbJoin;
        private System.Windows.Forms.ComboBox cbJoin;
    }
}
