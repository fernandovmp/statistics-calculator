using System.Collections.Generic;
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

        [TestMethod]
        public void TestMean()
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
            double expected = 22.25;

            double result = Statistics.Mean(items);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMedian()
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
            double expected = 23;

            double result = Statistics.Median(items);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMode()
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
            List<double> expected = new List<double>
            {
                23
            };

            List<double> result = Statistics.Mode(items);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMode_B()
        {
            double[] items = new double[]
            {
                2,
                2,
                3,
                7,
                8,
                8,
                8,
                9,
                10
            };
            List<double> expected = new List<double>
            {
                8
            };

            List<double> result = Statistics.Mode(items);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMode_C()
        {
            double[] items = new double[]
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10
            };
            List<double> expected = new List<double>();

            List<double> result = Statistics.Mode(items);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMode_D()
        {
            double[] items = new double[]
            {
                2,
                2,
                4,
                4,
                4,
                5,
                6,
                7,
                8,
                8,
                8,
                9
            };
            List<double> expected = new List<double>
            {
                4,
                8
            };

            List<double> result = Statistics.Mode(items);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSampleStandardDeviation()
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
            double expected = 12.302729081677;

            double result = Statistics.SampleStandardDeviation(items);

            Assert.AreEqual(expected, result, 0.000001);
        }
    }
}
