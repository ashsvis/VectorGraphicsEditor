namespace SimpleEditor.Controls
{
    partial class WedgeStyleEditor
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
            this.nudStartAngle = new System.Windows.Forms.NumericUpDown();
            this.lbStartAngle = new System.Windows.Forms.Label();
            this.lbSweepAngle = new System.Windows.Forms.Label();
            this.nudSweepAngle = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSweepAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.nudSweepAngle);
            this.groupBox1.Controls.Add(this.lbSweepAngle);
            this.groupBox1.Controls.Add(this.nudStartAngle);
            this.groupBox1.Controls.Add(this.lbStartAngle);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(224, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "`";
            this.groupBox1.Text = "Wedge Style";
            // 
            // nudStartAngle
            // 
            this.nudStartAngle.Location = new System.Drawing.Point(60, 18);
            this.nudStartAngle.Margin = new System.Windows.Forms.Padding(0);
            this.nudStartAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudStartAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudStartAngle.Name = "nudStartAngle";
            this.nudStartAngle.Size = new System.Drawing.Size(40, 20);
            this.nudStartAngle.TabIndex = 6;
            this.nudStartAngle.ValueChanged += new System.EventHandler(this.nudStartAngle_ValueChanged);
            // 
            // lbStartAngle
            // 
            this.lbStartAngle.AutoSize = true;
            this.lbStartAngle.Location = new System.Drawing.Point(1, 20);
            this.lbStartAngle.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lbStartAngle.Name = "lbStartAngle";
            this.lbStartAngle.Size = new System.Drawing.Size(59, 13);
            this.lbStartAngle.TabIndex = 5;
            this.lbStartAngle.Text = "StartAngle:";
            // 
            // lbSweepAngle
            // 
            this.lbSweepAngle.AutoSize = true;
            this.lbSweepAngle.Location = new System.Drawing.Point(103, 20);
            this.lbSweepAngle.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lbSweepAngle.Name = "lbSweepAngle";
            this.lbSweepAngle.Size = new System.Drawing.Size(70, 13);
            this.lbSweepAngle.TabIndex = 5;
            this.lbSweepAngle.Text = "SweepAngle:";
            // 
            // nudSweepAngle
            // 
            this.nudSweepAngle.Location = new System.Drawing.Point(173, 18);
            this.nudSweepAngle.Margin = new System.Windows.Forms.Padding(0);
            this.nudSweepAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudSweepAngle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSweepAngle.Name = "nudSweepAngle";
            this.nudSweepAngle.Size = new System.Drawing.Size(40, 20);
            this.nudSweepAngle.TabIndex = 6;
            this.nudSweepAngle.Value = new decimal(new int[] {
            270,
            0,
            0,
            0});
            this.nudSweepAngle.ValueChanged += new System.EventHandler(this.nudStartAngle_ValueChanged);
            // 
            // WedgeStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "WedgeStyleEditor";
            this.Size = new System.Drawing.Size(230, 55);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSweepAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudStartAngle;
        private System.Windows.Forms.Label lbStartAngle;
        private System.Windows.Forms.NumericUpDown nudSweepAngle;
        private System.Windows.Forms.Label lbSweepAngle;
    }
}
