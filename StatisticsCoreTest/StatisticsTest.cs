using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatisticsCore;

namespace StatisticsCoreTest
{
    [TestClass]
    public class StatisticsTest
    {
        [TestMethod]
        public void TestSumOfItems()
        {
            double[] items = new double[]
            {
                10,
                2,
                38,
                23,
                38,
                23,
                21,
                23
            };
            double expected = 178;

            double result = Statistics.SumOfItems(items);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSumOfSquareOfItems()
        {
            double[] items = new double[]
            {
                10,
                2,
                38,
                23,
                38,
                23,
                21,
                23
            };
            double expected = 5020;

            double result = Statistics.SumOfSquareOfItems(items);

            Assert.AreEqual(expected, result);
        }
    }
}
