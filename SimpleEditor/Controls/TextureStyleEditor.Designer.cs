namespace SimpleEditor.Controls
{
    partial class TextureStyleEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbWrap = new System.Windows.Forms.ComboBox();
            this.nudScale = new System.Windows.Forms.NumericUpDown();
            this.lbScale = new System.Windows.Forms.Label();
            this.lbWrap = new System.Windows.Forms.Label();
            this.btnLoadPicture = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScale)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.cbWrap);
            this.groupBox1.Controls.Add(this.nudScale);
            this.groupBox1.Controls.Add(this.lbScale);
            this.groupBox1.Controls.Add(this.lbWrap);
            this.groupBox1.Controls.Add(this.btnLoadPicture);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(200, 78);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Texture Style";
            // 
            // cbWrap
            // 
            this.cbWrap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWrap.Enabled = false;
            this.cbWrap.FormattingEnabled = true;
            this.cbWrap.Location = new System.Drawing.Point(44, 17);
            this.cbWrap.Margin = new System.Windows.Forms.Padding(0);
            this.cbWrap.Name = "cbWrap";
            this.cbWrap.Size = new System.Drawing.Size(79, 21);
            this.cbWrap.TabIndex = 0;
            this.cbWrap.SelectionChangeCommitted += new System.EventHandler(this.nudScale_ValueChanged);
            // 
            // nudScale
            // 
            this.nudScale.DecimalPlaces = 2;
            this.nudScale.Enabled = false;
            this.nudScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudScale.Location = new System.Drawing.Point(44, 44);
            this.nudScale.Margin = new System.Windows.Forms.Padding(0);
            this.nudScale.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudScale.Name = "nudScale";
            this.nudScale.Size = new System.Drawing.Size(45, 20);
            this.nudScale.TabIndex = 1;
            this.nudScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudScale.ValueChanged += new System.EventHandler(this.nudScale_ValueChanged);
            // 
            // lbScale
            // 
            this.lbScale.AutoSize = true;
            this.lbScale.Enabled = false;
            this.lbScale.Location = new System.Drawing.Point(7, 47);
            this.lbScale.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lbScale.Name = "lbScale";
            this.lbScale.Size = new System.Drawing.Size(37, 13);
            this.lbScale.TabIndex = 8;
            this.lbScale.Text = "Scale:";
            // 
            // lbWrap
            // 
            this.lbWrap.AutoSize = true;
            this.lbWrap.Enabled = false;
            this.lbWrap.Location = new System.Drawing.Point(8, 20);
            this.lbWrap.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lbWrap.Name = "lbWrap";
            this.lbWrap.Size = new System.Drawing.Size(36, 13);
            this.lbWrap.TabIndex = 10;
            this.lbWrap.Text = "Wrap:";
            // 
            // btnLoadPicture
            // 
            this.btnLoadPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoadPicture.Location = new System.Drawing.Point(133, 17);
            this.btnLoadPicture.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoadPicture.Name = "btnLoadPicture";
            this.btnLoadPicture.Size = new System.Drawing.Size(57, 21);
            this.btnLoadPicture.TabIndex = 2;
            this.btnLoadPicture.Text = "Load...";
            this.btnLoadPicture.UseVisualStyleBackColor = true;
            this.btnLoadPicture.Click += new System.EventHandler(this.btnLoadPicture_Click);
            // 
            // TextureStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "TextureStyleEditor";
            this.Size = new System.Drawing.Size(211, 85);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoadPicture;
        private System.Windows.Forms.ComboBox cbWrap;
        private System.Windows.Forms.NumericUpDown nudScale;
        private System.Windows.Forms.Label lbScale;
        private System.Windows.Forms.Label lbWrap;
    }
}
