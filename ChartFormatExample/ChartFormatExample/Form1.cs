using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using ChartExtension;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartFormatExample
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
            foreach (var style in Enum.GetValues(typeof(ChartExtensions.AxisStyle)))
            {
                listBoxAxisStyleX.Items.Add(style);
                listBoxAxisStyleY.Items.Add(style);
            }
            listBoxAxisStyleX.SelectedIndex = 0;
            listBoxAxisStyleY.SelectedIndex = 0;
        }

		private void button1_Click(object sender, EventArgs e)
		{
			Random rnd = new Random();
			int digX = rnd.Next(-5, 5);
			int digY = rnd.Next(-5, 5);
			List<double> allValX = new List<double>();
			List<double> allValY = new List<double>();

			for (int i = 0; i < 2; i++)
			{
				chart1.Series[i].Points.Clear();
				chart2.Series[i].Points.Clear();
				List<double> valX = new List<double>();
				List<double> valY = new List<double>();
				for (int j = 0; j < 20; j++)
				{
					valX.Add((rnd.Next(-10, 10) + ((double)rnd.Next(-1000, 1000)) / 1000) * Math.Pow(10, digX));
					valY.Add((rnd.Next(-10, 10) + ((double)rnd.Next(-1000, 1000)) / 1000) * Math.Pow(10, digY));
				}
				valX.Sort();
				valY.Sort();
				allValX.AddRange(valX);
				allValY.AddRange(valY);
				for (int j = 0; j < valX.Count; j++)
				{
					chart1.Series[i].Points.AddXY(valX[j], valY[j]);
					chart2.Series[i].Points.AddXY(valX[j], valY[j]);
				}
			}
		
			allValX.Sort();
			allValY.Sort();
			foreach (var x in allValX) Debug.Write($" {x},");
			Debug.WriteLine("");
			foreach (var y in allValY) Debug.Write($" {y},");
			Debug.WriteLine("");

            button2.PerformClick();
            var result = chart2.ChartAreas[0].AxisX.Minimum < allValX.Min()
                      && chart2.ChartAreas[0].AxisX.Maximum > allValX.Max()
                      && chart2.ChartAreas[0].AxisY.Minimum < allValY.Min()
                      && chart2.ChartAreas[0].AxisY.Maximum > allValY.Max();
            Debug.WriteLine(result);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var styleX = (ChartExtensions.AxisStyle)listBoxAxisStyleX.SelectedItem;
            var styleY = (ChartExtensions.AxisStyle)listBoxAxisStyleY.SelectedItem;
            var divMinX = (int)numericUpDownDivMinX.Value;
            var divMaxX = (int)numericUpDownDivMaxX.Value;
            var divMinY = (int)numericUpDownDivMinY.Value;
            var divMaxY = (int)numericUpDownDivMaxY.Value;

            ChartExtensions.FormatAll(chart2, styleX, styleY, divMinX, divMaxX, divMinY, divMaxY);
            Debug.WriteLine($"AxisX  Min:{chart2.ChartAreas[0].AxisX.Minimum}  Max:{chart2.ChartAreas[0].AxisX.Maximum} Interval:{chart2.ChartAreas[0].AxisX.Interval}");
            Debug.WriteLine($"AxisY  Min:{chart2.ChartAreas[0].AxisY.Minimum}  Max:{chart2.ChartAreas[0].AxisY.Maximum} Interval:{chart2.ChartAreas[0].AxisY.Interval}");
            ChartExtensions.Capture(chart1, Directory.GetCurrentDirectory() + "\\before.png", 3);
            ChartExtensions.Capture(chart2, Directory.GetCurrentDirectory() + "\\after.png", 3);
        }

        private void NumericUpDownDivMinX_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownDivMaxX.Minimum = numericUpDownDivMinX.Value;
        }

        private void NumericUpDownDivMinY_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownDivMaxY.Minimum = numericUpDownDivMinY.Value;
        }
    }
}
