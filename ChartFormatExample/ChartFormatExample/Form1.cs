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
			ChartExtensions.FormatAll(chart2, 0, 0, 8, 11);
			//ChartExtensions.FormatAll(chart2, ChartExtensions.AxisStyle.MinToMax, ChartExtensions.AxisStyle.MinToMax, 4, 8);
			//ChartExtensions.FormatAll(chart2, ChartExtensions.AxisStyle.ZeroToMax, ChartExtensions.AxisStyle.ZeroToMax , 4, 8);
			//ChartExtensions.FormatAll(chart2, ChartExtensions.AxisStyle.MinToZero, ChartExtensions.AxisStyle.MinToZero, 4, 8);
			//ChartExtensions.FormatAll(chart2, ChartExtensions.AxisStyle.Symmetry, ChartExtensions.AxisStyle.Symmetry, 4, 8);
			Debug.WriteLine($"AxisX  Min:{chart2.ChartAreas[0].AxisX.Minimum}  Max:{chart2.ChartAreas[0].AxisX.Maximum} Interval:{chart2.ChartAreas[0].AxisX.Interval}");
			Debug.WriteLine($"AxisY  Min:{chart2.ChartAreas[0].AxisY.Minimum}  Max:{chart2.ChartAreas[0].AxisY.Maximum} Interval:{chart2.ChartAreas[0].AxisY.Interval}");
			ChartExtensions.Capture(chart1, Directory.GetCurrentDirectory() + "\\before.png", 3);
			ChartExtensions.Capture(chart2, Directory.GetCurrentDirectory() + "\\after.png", 3);
		}
	}
}
