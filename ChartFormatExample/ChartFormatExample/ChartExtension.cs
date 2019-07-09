using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using static MathRoundExtension.MathEx;

namespace ChartExtension
{
    public static class ChartExtensions
    {
        /// <summary>
        /// Chart内の全てのChartAreaについて書式を整える
        /// </summary>
        /// <param name="chart">書式を整えるChart</param>
        /// <param name="styleX">X軸のスタイル 規定値：Auto</param>
        /// <param name="styleY">Y軸のスタイル 規定値：Auto</param>
        /// <param name="minDivisionX">軸の最小分割数 規定値：4</param>
        /// <param name="maxDivisionX">軸の最大分割数 規定値：11</param>
        /// <param name="minDivisionY">軸の最小分割数 規定値：4</param>
        /// <param name="maxDivisionY">軸の最大分割数 規定値：11</param>
        public static void FormatAll(Chart chart,
                                     AxisStyle styleX = AxisStyle.Auto,
                                     AxisStyle styleY = AxisStyle.Auto,
                                     int minDivisionX = 4,
                                     int maxDivisionX = 11,
                                     int minDivisionY = 4,
                                     int maxDivisionY = 11)
        {
            foreach (var ca in chart.ChartAreas)
            {
                FormatArea(ca, chart.Series, styleX, styleY, minDivisionX, maxDivisionX, minDivisionY, maxDivisionY);
            }
        }

        /// <summary>
        /// 指定されたChartAreaについて書式を整える
        /// </summary>
        /// <param name="area">書式を整えるのChartArea</param>
        /// <param name="series">ChartAreaに紐づけられたSeries</param>
        /// <param name="styleX">X軸のスタイル 規定値：Auto</param>
        /// <param name="styleY">Y軸のスタイル 規定値：Auto</param>
        /// <param name="minDivisionX">軸の最小分割数 規定値：4</param>
        /// <param name="maxDivisionX">軸の最大分割数 規定値：11</param>
        /// <param name="minDivisionY">軸の最小分割数 規定値：4</param>
        /// <param name="maxDivisionY">軸の最大分割数 規定値：11</param>
        public static void FormatArea(ChartArea area,
                                      SeriesCollection series,
                                      AxisStyle styleX = AxisStyle.Auto,
                                      AxisStyle styleY = AxisStyle.Auto,
                                      int minDivisionX = 4,
                                      int maxDivisionX = 11,
                                      int minDivisionY = 4,
                                      int maxDivisionY = 11)
        {
            var resX = new List<(double axisMin, double axisMax, double interval, double division)>();
            var resY = new List<(double axisMin, double axisMax, double interval, double division)>();
            foreach (var s in series)
            {
                if (area.Name == s.ChartArea && s.Points.Count >= 2)
                {
                    var res = Format(s.Points.FindMinByValue("X").XValue, s.Points.FindMaxByValue("X").XValue, styleX, minDivisionX, maxDivisionX);
                    if (!double.IsNaN(res.axisMin) && !double.IsNaN(res.axisMax))
                        resX.Add(res);
                    res = Format(s.Points.FindMinByValue("Y1").YValues[0], s.Points.FindMaxByValue("Y1").YValues[0], styleY, minDivisionY, maxDivisionY);
                    if (!double.IsNaN(res.axisMin) && !double.IsNaN(res.axisMax))
                        resY.Add(res);
                }
            }
            if (resX.Count != 0 && resY.Count != 0)
            {
                var res = Format(resX.Select(v => v.axisMin).Min(), resX.Select(v => v.axisMax).Max(), styleX, minDivisionX, maxDivisionX);
                area.AxisX.Maximum = res.axisMax;
                area.AxisX.Minimum = res.axisMin;
                area.AxisX.Interval = res.interval;
                res = Format(resY.Select(v => v.axisMin).Min(), resY.Select(v => v.axisMax).Max(), styleY, minDivisionY, maxDivisionY);
                area.AxisY.Maximum = res.axisMax;
                area.AxisY.Minimum = res.axisMin;
                area.AxisY.Interval = res.interval;
            }
        }

        public enum AxisStyle
        {
            Auto, ZeroToMax, MinToZero, MinToMax, Symmetry
        }

        /// <summary>
        /// 最小値・最大値よりAxisStyleに基づいて軸に適用する最小値・最大値を決定する
        /// </summary>
        /// <param name="min">表示したい最小の値</param>
        /// <param name="max">表示したい最大の値</param>
        /// <param name="style">軸のスタイル 規定値：Auto</param>
        /// <param name="minDivision">軸の最小分割数 規定値：4</param>
        /// <param name="maxDivision">軸の最大分割数 規定値：11</param>
        /// <returns>axisMin:軸に設定する最小値 axisMax:軸に設定する最大値 interval:軸のインターバル division:チャートエリアの分割数</returns>
        public static (double axisMin, double axisMax, double interval, double division) Format(double min, double max, AxisStyle style = AxisStyle.Auto, int minDivision = 4, int maxDivision = 11)
        {
            double resultMin, resultMax, interval, division;
            if (double.IsNaN(min)) min = 0;
            if (double.IsNaN(max)) max = 0;
            if (min == 0 && max == 0) return (Double.NaN, Double.NaN, Double.NaN, 1);
            if (min == max) return (max, max, Double.NaN, 1);
            if (min > max)
            {
                double swap = min;
                min = max;
                max = swap;
            }

            var res = FindOptimizedValue(min, max, minDivision, maxDivision);
            resultMin = res.axisMin;
            resultMax = res.axisMax;
            interval = res.interval;
            division = res.division;
            if (style == AxisStyle.Auto)
            {
                if (resultMin <= 0 && 0 <= resultMax)
                    style = AxisStyle.MinToMax;
                else if (resultMax <= 0 && resultMax - resultMin > -resultMax)
                    style = AxisStyle.MinToZero;
                else if (resultMin >= 0 && resultMax - resultMin > resultMin)
                    style = AxisStyle.ZeroToMax;
                else
                    style = AxisStyle.MinToMax;
            }
            switch (style)
            {
                case AxisStyle.ZeroToMax:
                    resultMin = 0;
                    break;

                case AxisStyle.MinToZero:
                    resultMax = 0;
                    break;

                case AxisStyle.Symmetry:
                    if (Math.Abs(resultMin) <= Math.Abs(resultMax))
                        resultMin = -resultMax;
                    else
                        resultMax = -resultMin;
                    division = ((maxDivision + minDivision) % 2 == 0) ? ((maxDivision + minDivision) / 2) : ((maxDivision + minDivision + 1) / 2);
                    interval = resultMax / division * 2;
                    break;
            }
            if (resultMin == double.MinValue || resultMin == double.MaxValue)
                resultMin = double.NaN;
            if (resultMax == double.MinValue || resultMax == double.MaxValue)
                resultMax = double.NaN;
            if (interval == double.MaxValue || interval == double.MinValue || interval == 0)
            {
                interval = double.NaN;
                division = 1;
            }
            else
            {
                interval = Round(interval, 4);
            }
            return (resultMin, resultMax, interval, division);
        }
        // key:Min/Maxの数値先頭2桁  value:分割数
        static Dictionary<int, List<int>> divs = new Dictionary<int, List<int>>(){{ 10 ,new List<int>(){10, 5, 4, 2, 1}},
                                                                                  { 12 ,new List<int>(){ 6, 4, 3, 2, 1}},
                                                                                  { 15 ,new List<int>(){ 5, 3, 1}},
                                                                                  { 16 ,new List<int>(){ 8, 4, 2, 1}},
                                                                                  { 18 ,new List<int>(){ 9, 6, 3, 2, 1}},
                                                                                  { 20 ,new List<int>(){10, 5, 4, 2, 1}},
                                                                                  { 25 ,new List<int>(){10, 5, 2, 1}},
                                                                                  { 30 ,new List<int>(){10, 6, 5, 3, 2, 1}},
                                                                                  { 40 ,new List<int>(){10, 8, 4, 2, 1}},
                                                                                  { 50 ,new List<int>(){10, 5, 2, 1}},
                                                                                  { 60 ,new List<int>(){10, 6, 5, 4, 3, 2, 1}},
                                                                                  { 80 ,new List<int>(){10, 8, 4, 2, 1}},
                                                                                  { 90 ,new List<int>(){10, 9, 3, 2, 1}},
                                                                                  {100 ,new List<int>(){10, 5, 4, 2, 1}}};

        public static (double axisMin, double axisMax, double interval, double division) FindOptimizedValue(double min, double max, int minDivision = 4, int maxDivision = 11)
        {
            int unitDigit = 0, unitSign, head;
            double divisiton = 0;
            double axisMin = 0, axisMax = 0, interval = double.NaN;
            if (Math.Abs(min) < Math.Abs(max))
            {
                unitDigit = Digit(max) - 1;
                unitSign = Math.Sign(max);

                if (Digit(TrimUp(max, 2)) != Digit(max))
                    head = HeadValue(max, 2);
                else
                    head = HeadValue(TrimUp(max, 2), 2);

                {
                    int i = 0;
                    while (head > divs.Keys.ToArray()[i]) ++i;
                    head = divs.Keys.ToArray()[i];
                }

                axisMax = head * Math.Pow(10, unitDigit) * unitSign;
                if (HeadValue(axisMax) == 1)
                    unitDigit = Digit(axisMax) - 1;
                else
                    unitDigit = Digit(axisMax);

                double tmpLeast = double.MinValue;
                double tmp, tmpInterval, tmpDivision;
                foreach (var d in divs[head])
                {
                    tmpInterval = Math.Abs(axisMax / d);
                    if (Math.Sign(min) == Math.Sign(axisMax))
                    {
                        while (axisMax - min < tmpInterval) tmpInterval /= 10;
                        tmp = axisMax;
                    }
                    else
                    {
                        tmp = 0;
                    }
                    while (min < tmp) tmp -= tmpInterval;
                    tmpDivision = (axisMax - tmp) / tmpInterval;
                    if (tmpLeast < tmp && minDivision <= tmpDivision && tmpDivision <= maxDivision)
                    {
                        tmpLeast = tmp;
                        interval = tmpInterval;
                        divisiton = tmpDivision;
                    }
                }
                axisMin = tmpLeast;
            }
            else
            {
                unitDigit = Digit(min) - 1;
                unitSign = Math.Sign(min);

                if (Digit(TrimUp(min, 2)) != Digit(min))
                    head = HeadValue(min, 2);
                else
                    head = HeadValue(TrimUp(min, 2), 2);

                {
                    int i = 0;
                    while (head > divs.Keys.ToArray()[i]) ++i;
                    head = divs.Keys.ToArray()[i];
                }

                axisMin = head * Math.Pow(10, unitDigit) * unitSign;
                if (HeadValue(axisMin) == 1)
                    unitDigit = Digit(axisMin) - 1;
                else
                    unitDigit = Digit(axisMin);

                double tmpMost = double.MaxValue;
                double tmp, tmpInterval, tmpDivision;
                foreach (var d in divs[head])
                {
                    tmpInterval = Math.Abs(axisMin / d);
                    if (Math.Sign(axisMin) == Math.Sign(max))
                    {
                        while (max - axisMin < tmpInterval) tmpInterval /= 10;
                        tmp = axisMin;
                    }
                    else
                    {
                        tmp = 0;
                    }

                    while (tmp < max) tmp += tmpInterval;
                    tmpDivision = (tmp - axisMin) / tmpInterval;
                    if (tmp < tmpMost && minDivision <= tmpDivision && tmpDivision <= maxDivision)
                    {
                        tmpMost = tmp;
                        interval = tmpInterval;
                        divisiton = (tmp - axisMin) / tmpInterval;
                    }
                }
                axisMax = tmpMost;
            }
            return (axisMin, axisMax, interval, divisiton);
        }

        /// <summary>
        /// 指定されたChartオブジェクトを拡大し指定のファイル名で画像として保存
        /// </summary>
        /// <param name="chart">キャプチャを行うChartオブジェクト</param>
        /// <param name="fullPath">保存ファイル名のフルパス</param>
        /// <param name="zoomFactor">拡大率 規定値：3</param>
        /// <param name="imageFormat">拡張子 規定値：.png</param>
        public static void Capture(Chart chart, string fullPath, int zoomFactor = 3, ChartImageFormat imageFormat = ChartImageFormat.Png)
        {
            var docking = chart.Dock;
            chart.Dock = DockStyle.None;
            chart.Width *= zoomFactor;
            chart.Height *= zoomFactor;
            var fonts = new Queue<(Font origin, Font zoom)>();

            foreach (var ca in chart.ChartAreas)
            {
                fonts.Enqueue(FontZooming(ca.AxisX.TitleFont, zoomFactor));
                ca.AxisX.TitleFont = fonts.Last().zoom;
                fonts.Enqueue(FontZooming(ca.AxisY.TitleFont, zoomFactor));
                ca.AxisY.TitleFont = fonts.Last().zoom;
                fonts.Enqueue(FontZooming(ca.AxisX.LabelStyle.Font, zoomFactor));
                ca.AxisX.LabelStyle.Font = fonts.Last().zoom;
                fonts.Enqueue(FontZooming(ca.AxisY.LabelStyle.Font, zoomFactor));
                ca.AxisY.LabelStyle.Font = fonts.Last().zoom;
            }
            foreach (var s in chart.Series)
                s.BorderWidth *= zoomFactor;
            foreach (var l in chart.Legends)
            {
                fonts.Enqueue(FontZooming(l.Font, zoomFactor));
                l.Font = fonts.Last().zoom;
            }
            foreach (var t in chart.Titles)
            {
                fonts.Enqueue(FontZooming(t.Font, zoomFactor));
                t.Font = fonts.Last().zoom;
            }
            foreach (var a in chart.Annotations.Where(a => a.AnnotationType == "Text").Select(a => ((TextAnnotation)a)).ToArray())
            {
                fonts.Enqueue(FontZooming(a.Font, zoomFactor));
                a.Font = fonts.Last().zoom;
            }

            try
            {
                chart.SaveImage(fullPath, imageFormat);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            foreach (var ca in chart.ChartAreas)
            {
                ca.AxisX.TitleFont = fonts.Dequeue().origin;
                ca.AxisY.TitleFont = fonts.Dequeue().origin;
                ca.AxisX.LabelStyle.Font = fonts.Dequeue().origin;
                ca.AxisY.LabelStyle.Font = fonts.Dequeue().origin;
            }
            foreach (var s in chart.Series)
                s.BorderWidth /= zoomFactor;
            foreach (var l in chart.Legends)
                l.Font = fonts.Dequeue().origin;
            foreach (var t in chart.Titles)
                t.Font = fonts.Dequeue().origin;
            foreach (var a in chart.Annotations.Where(a => a.AnnotationType == "Text").Select(a => ((TextAnnotation)a)).ToArray())
                a.Font = fonts.Dequeue().origin;
            chart.Width /= zoomFactor;
            chart.Height /= zoomFactor;
            chart.Dock = docking;
        }

        private static (Font origin, Font zoom) FontZooming(Font origin, double zoomFactor)
        {
            return (origin, new Font(origin.OriginalFontName, (float)Math.Ceiling(origin.Size * zoomFactor)));
            //return (origin, new Font(origin.OriginalFontName, (float)Math.Ceiling(origin.Size * Math.Sqrt(zoomFactor))));
        }
    }
}
