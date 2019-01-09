namespace SimpleEditor.Controls
{
    partial class BezierStyleEditor
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
            this.nudFlatness = new System.Windows.Forms.NumericUpDown();
            this.cbIsFlatten = new System.Windows.Forms.CheckBox();
            this.cbIsClosed = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlatness)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.nudFlatness);
            this.groupBox1.Controls.Add(this.cbIsFlatten);
            this.groupBox1.Controls.Add(this.cbIsClosed);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(200, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bezier Style";
            // 
            // nudFlatness
            // 
            this.nudFlatness.DecimalPlaces = 2;
            this.nudFlatness.Enabled = false;
            this.nudFlatness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudFlatness.Location = new System.Drawing.Point(142, 17);
            this.nudFlatness.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this.nudFlatness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudFlatness.Name = "nudFlatness";
            this.nudFlatness.Size = new System.Drawing.Size(47, 20);
            this.nudFlatness.TabIndex = 2;
            this.nudFlatness.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nudFlatness.ValueChanged += new System.EventHandler(this.cbIsClosed_CheckedChanged);
            // 
            // cbIsFlatten
            // 
            this.cbIsFlatten.AutoSize = true;
            this.cbIsFlatten.Location = new System.Drawing.Point(73, 18);
            this.cbIsFlatten.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.cbIsFlatten.Name = "cbIsFlatten";
            this.cbIsFlatten.Size = new System.Drawing.Size(66, 17);
            this.cbIsFlatten.TabIndex = 1;
            this.cbIsFlatten.Text = "IsFlatten";
            this.cbIsFlatten.UseVisualStyleBackColor = true;
            this.cbIsFlatten.CheckedChanged += new System.EventHandler(this.cbIsFlatten_CheckedChanged);
            // 
            // cbIsClosed
            // 
            this.cbIsClosed.AutoSize = true;
            this.cbIsClosed.Location = new System.Drawing.Point(4, 18);
            this.cbIsClosed.Margin = new System.Windows.Forms.Padding(3, 1, 0, 0);
            this.cbIsClosed.Name = "cbIsClosed";
            this.cbIsClosed.Size = new System.Drawing.Size(66, 17);
            this.cbIsClosed.TabIndex = 1;
            this.cbIsClosed.Text = "IsClosed";
            this.cbIsClosed.UseVisualStyleBackColor = true;
            this.cbIsClosed.CheckedChanged += new System.EventHandler(this.cbIsClosed_CheckedChanged);
            // 
            // BezierStyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BezierStyleEditor";
            this.Size = new System.Drawing.Size(216, 64);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlatness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbIsFlatten;
        private System.Windows.Forms.CheckBox cbIsClosed;
        private System.Windows.Forms.NumericUpDown nudFlatness;
    }
}
