using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChartExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static MathRoundExtension.MathEx;

namespace ChartExtension.Tests
{
    [TestClass()]
    public class ChartExtensionsTests
    {
        [TestMethod()]
        public void FindOptimizedValueTest()
        {
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int dig = rnd.Next(-5, 5);
                double val1 = (rnd.Next(-10, 10) + ((double)rnd.Next(-1000, 1000)) / 1000) * Math.Pow(10, dig);
                dig = rnd.Next(-5, 5);
                double val2 = (rnd.Next(-10, 10) + ((double)rnd.Next(-1000, 1000)) / 1000) * Math.Pow(10, dig);
                double min = val1 < val2 ? val1 : val2;
                double max = val1 > val2 ? val1 : val2;
                var res = ChartExtensions.FindOptimizedValue(min, max);
                Assert.IsTrue(res.axisMin <= min && max <= res.axisMax && !double.IsNaN(res.interval)
                            , $"input  => min:{min} max:{max}{Environment.NewLine}"
                            + $"output => min:{res.axisMin} max:{res.axisMax} interval:{res.interval}");
            }
        }

        [TestMethod()]
        public void FindOptimizedValueTest2()
        {
            double min = -0.003048;
            double max = -0.002323;
            var res = ChartExtensions.FindOptimizedValue(min, max);
                Assert.IsTrue(res.axisMin <= min && max <= res.axisMax && !double.IsNaN(res.interval)
                            , $"{Environment.NewLine}"
                            + $"input  => min:{min} max:{max}{Environment.NewLine}"
                            + $"output => min:{res.axisMin} max:{res.axisMax} interval:{res.interval}");
        }
    }
}