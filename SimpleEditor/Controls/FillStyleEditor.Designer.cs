namespace SimpleEditor.Controls
{
    partial class FillStyleEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbVisible = new System.Windows.Forms.CheckBox();
            this.lbColor = new System.Windows.Forms.Label();
            this.lbOpacity = new System.Windows.Forms.Label();
            this.nudOpacity = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbVisible
            // 
            this.cbVisible.AutoSize = true;
            this.cbVisible.Location = new System.Drawing.Point(5, 19);
            this.cbVisible.Margin = new System.Windows.Forms.Padding(3, 1, 0, 0);
            this.cbVisible.Name = "cbVisible";
            this.cbVisible.Size = new System.Drawing.Size(53, 17);
            this.cbVisible.TabIndex = 0;
            this.cbVisible.Text = "Color:";
            this.cbVisible.UseVisualStyleBackColor = true;
            this.cbVisible.CheckedChanged += new System.EventHandler(this.cbVisible_CheckedChanged);
            // 
            // lbColor
            // 
            this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbColor.Location = new System.Drawing.Point(60, 19);
            this.lbColor.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(39, 17);
            this.lbColor.TabIndex = 1;
            this.lbColor.BackColorChanged += new System.EventHandler(this.cbVisible_CheckedChanged);
            this.lbColor.Click += new System.EventHandler(this.lbColor_Click);
            // 
            // lbOpacity
            // 
            this.lbOpacity.AutoSize = true;
            this.lbOpacity.Location = new System.Drawing.Point(102, 20);
            this.lbOpacity.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lbOpacity.Name = "lbOpacity";
            this.lbOpacity.Size = new System.Drawing.Size(46, 13);
            this.lbOpacity.TabIndex = 2;
            this.lbOpacity.Text = "Opacity:";
            // 
            // nudOpacity
            // 
            this.nudOpacity.Location = new System.Drawing.Point(150, 18);
            this.nudOpacity.Margin = new System.Windows.Forms.Padding(0);
            this.nudOpacity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudOpacity.Name = "nudOpacity";
            this.nudOpacity.Size = new System.Drawing.Size(40, 20);
            this.nudOpacity.TabIndex = 4;
            this.nudOpacity.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudOpacity.ValueChanged += new System.EventHandler(this.cbVisible_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.lbColor);
            this.groupBox1.Controls.Add(this.nudOpacity);
            this.groupBox1.Controls.Add(this.lbOpacity);
            this.groupBox1.Controls.Add(this.cbVisible);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(200, 52);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fill Style";
            // 
            // FillStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FillStyleEditor";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Size = new System.Drawing.Size(212, 57);
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbVisible;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Label lbOpacity;
        private System.Windows.Forms.NumericUpDown nudOpacity;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
