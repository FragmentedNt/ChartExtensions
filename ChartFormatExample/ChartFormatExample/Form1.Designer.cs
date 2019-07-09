namespace ChartFormatExample
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title8 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title7 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button2 = new System.Windows.Forms.Button();
            this.listBoxAxisStyleX = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownDivMinX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDivMinY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxAxisStyleY = new System.Windows.Forms.ListBox();
            this.numericUpDownDivMaxY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDivMaxX = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDivMinX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDivMinY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDivMaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDivMaxX)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chart2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(403, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(394, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Draw with RNG";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart1
            // 
            chartArea8.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea8);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(3, 79);
            this.chart1.Name = "chart1";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series15.Name = "Series1";
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series16.Name = "Series2";
            this.chart1.Series.Add(series15);
            this.chart1.Series.Add(series16);
            this.chart1.Size = new System.Drawing.Size(394, 368);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            title8.Name = "Title1";
            title8.Text = "整形前";
            this.chart1.Titles.Add(title8);
            // 
            // chart2
            // 
            chartArea7.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea7);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart2.Location = new System.Drawing.Point(403, 79);
            this.chart2.Name = "chart2";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.Name = "Series1";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series14.Name = "Series2";
            this.chart2.Series.Add(series13);
            this.chart2.Series.Add(series14);
            this.chart2.Size = new System.Drawing.Size(394, 368);
            this.chart2.TabIndex = 3;
            this.chart2.Text = "chart2";
            title7.Name = "Title1";
            title7.Text = "整形後";
            this.chart2.Titles.Add(title7);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(403, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(394, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Retry";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // listBoxAxisStyleX
            // 
            this.listBoxAxisStyleX.FormattingEnabled = true;
            this.listBoxAxisStyleX.ItemHeight = 12;
            this.listBoxAxisStyleX.Location = new System.Drawing.Point(3, 3);
            this.listBoxAxisStyleX.Name = "listBoxAxisStyleX";
            this.listBoxAxisStyleX.Size = new System.Drawing.Size(110, 64);
            this.listBoxAxisStyleX.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numericUpDownDivMaxY);
            this.panel1.Controls.Add(this.numericUpDownDivMaxX);
            this.panel1.Controls.Add(this.listBoxAxisStyleY);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericUpDownDivMinY);
            this.panel1.Controls.Add(this.numericUpDownDivMinX);
            this.panel1.Controls.Add(this.listBoxAxisStyleX);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(394, 70);
            this.panel1.TabIndex = 5;
            // 
            // numericUpDownDivMinX
            // 
            this.numericUpDownDivMinX.Location = new System.Drawing.Point(294, 21);
            this.numericUpDownDivMinX.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownDivMinX.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownDivMinX.Name = "numericUpDownDivMinX";
            this.numericUpDownDivMinX.Size = new System.Drawing.Size(34, 19);
            this.numericUpDownDivMinX.TabIndex = 5;
            this.numericUpDownDivMinX.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownDivMinX.ValueChanged += new System.EventHandler(this.NumericUpDownDivMinX_ValueChanged);
            // 
            // numericUpDownDivMinY
            // 
            this.numericUpDownDivMinY.Location = new System.Drawing.Point(294, 46);
            this.numericUpDownDivMinY.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownDivMinY.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownDivMinY.Name = "numericUpDownDivMinY";
            this.numericUpDownDivMinY.Size = new System.Drawing.Size(34, 19);
            this.numericUpDownDivMinY.TabIndex = 6;
            this.numericUpDownDivMinY.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownDivMinY.ValueChanged += new System.EventHandler(this.NumericUpDownDivMinY_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Division X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Division Y";
            // 
            // listBoxAxisStyleY
            // 
            this.listBoxAxisStyleY.FormattingEnabled = true;
            this.listBoxAxisStyleY.ItemHeight = 12;
            this.listBoxAxisStyleY.Location = new System.Drawing.Point(119, 3);
            this.listBoxAxisStyleY.Name = "listBoxAxisStyleY";
            this.listBoxAxisStyleY.Size = new System.Drawing.Size(110, 64);
            this.listBoxAxisStyleY.TabIndex = 9;
            // 
            // numericUpDownDivMaxY
            // 
            this.numericUpDownDivMaxY.Location = new System.Drawing.Point(357, 46);
            this.numericUpDownDivMaxY.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownDivMaxY.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownDivMaxY.Name = "numericUpDownDivMaxY";
            this.numericUpDownDivMaxY.Size = new System.Drawing.Size(34, 19);
            this.numericUpDownDivMaxY.TabIndex = 11;
            this.numericUpDownDivMaxY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownDivMaxX
            // 
            this.numericUpDownDivMaxX.Location = new System.Drawing.Point(357, 21);
            this.numericUpDownDivMaxX.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownDivMaxX.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownDivMaxX.Name = "numericUpDownDivMaxX";
            this.numericUpDownDivMaxX.Size = new System.Drawing.Size(34, 19);
            this.numericUpDownDivMaxX.TabIndex = 10;
            this.numericUpDownDivMaxX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "～";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "～";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "Min";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(355, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "Max";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDivMinX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDivMinY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDivMaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDivMaxX)).EndInit();
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBoxAxisStyleX;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownDivMinY;
        private System.Windows.Forms.NumericUpDown numericUpDownDivMinX;
        private System.Windows.Forms.ListBox listBoxAxisStyleY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownDivMaxY;
        private System.Windows.Forms.NumericUpDown numericUpDownDivMaxX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

