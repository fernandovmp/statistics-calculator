using System;
using System.Collections.Generic;
using System.Linq;
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

        [TestMethod]
        public void TestPopulationStandardDeviation()
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
            double expected = 11.508149286484;

            double result = Statistics.PopulationStandardDeviation(items);

            Assert.AreEqual(expected, result, 0.000001);
        }

        [TestMethod]
        public void TestSampleVariance()
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
            double expected = 151.35714285714;

            double result = Statistics.SampleVariance(items);

            Assert.AreEqual(expected, result, 0.000001);
        }

        [TestMethod]
        public void TestPopulationVariance()
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
            double expected = 132.4375;

            double result = Statistics.PopulationVariance(items);

            Assert.AreEqual(expected, result, 0.000001);
        }

        [TestMethod]
        public void TestNormalDistribution_A()
        {
            double deviation = 5, mean = 50, comparer = 60;
            double expected = 0.9772;

            double result = Statistics.NormalDistributionDensity(comparer, deviation, mean);

            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void TestNormalDistribution_B()
        {
            double deviation = 5, mean = 50, start = 35, end = 45;
            double expected = 0.1574;

            double result = Statistics.NormalDistributionDensity(start, end, deviation, mean);

            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void TestNormalDistribution_C()
        {
            double deviation = 5, mean = 50, start = 55, end = 65;
            double expected = 0.1574;

            double result = Statistics.NormalDistributionDensity(start, end, deviation, mean);

            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void TestNormalDistribution_D()
        {
            double deviation = 5, mean = 50, start = 55;
            double expected = 0.1587;

            double result = Statistics.NormalDistributionDensity(start, deviation, mean, true);

            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void TestNormalDistribution_E()
        {
            double deviation = 5, mean = 50, start = 35, end = 62;
            double expected = 0.9905;

            double result = Statistics.NormalDistributionDensity(start, end, deviation, mean);

            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void TestNormalDistribution_F()
        {
            double deviation = 5, mean = 50, start = 40;
            double expected = 0.9772;

            double result = Statistics.NormalDistributionDensity(start, deviation, mean, true);

            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void TestNormalDistribution_G()
        {
            double deviation = 5, mean = 50, start = 40;
            double expected = 0.0228;

            double result = Statistics.NormalDistributionDensity(start, deviation, mean);

            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        public void TestBinomialOf_A()
        {
            int sample = 10, x = 5;
            float successRate = 0.5f;
            double expected = 0.246090;

            double result = Statistics.BinomialOf(x, sample, successRate);

            Assert.AreEqual(expected, result, 0.00001);
        }

        [TestMethod]
        public void TestBinomialOf_B()
        {
            int sample = 10, x = 0;
            float successRate = 0.5f;
            double expected = 0.000977;

            double result = Statistics.BinomialOf(x, sample, successRate);

            Assert.AreEqual(expected, result, 0.00001);
        }

        [TestMethod]
        public void TestBinomialOf_C()
        {
            int sample = 10, x = 10;
            float successRate = 0.5f;
            double expected = 0.000977;

            double result = Statistics.BinomialOf(x, sample, successRate);

            Assert.AreEqual(expected, result, 0.00001);
        }

        [TestMethod]
        public void TestBinomial()
        {
            int sample = 10;
            float successRate = 0.5f;
            var expected = new double[]
            {
                0.000977,
                0.009766,
                0.043945,
                0.117188,
                0.205078,
                0.246094,
                0.205078,
                0.117188,
                0.043945,
                0.009766,
                0.000977
            };

            IEnumerable<double> result = Statistics.Binomial(sample, successRate)
                                                   .Select(value => Math.Round(value, 6));
            CollectionAssert.AreEqual(expected, result.ToArray());
        }

        [TestMethod]
        public void TestBinomialWithRange_A()
        {
            int sample = 9;
            float successRate = 0.02f;
            BinomialRange binomialRange = BinomialRange.Min;
            int min = 1;
            var expected = new double[]
            {
                0.153137,
                0.012501,
                0.000595,
                1.8E-05,
                0,
                0,
                0,
                0,
                0
            };
            IEnumerable<double> result = Statistics.Binomial(sample, min, successRate, binomialRange)
                                                   .Select(value => Math.Round(value, 6));
            CollectionAssert.AreEqual(expected, result.ToArray());
        }

        [TestMethod]
        public void TestBinomialWithRange_B()
        {
            int sample = 9;
            float successRate = 0.02f;
            BinomialRange binomialRange = BinomialRange.Max;
            int max = 3;
            var expected = new double[]
            {
                0.833748,
                0.153137,
                0.012501,
                0.000595
            };
            IEnumerable<double> result = Statistics.Binomial(sample, max, successRate, binomialRange)
                                                   .Select(value => Math.Round(value, 6));
            CollectionAssert.AreEqual(expected, result.ToArray());
        }

        [TestMethod]
        public void TestBinomialWithRange_C()
        {
            int sample = 10, success = 10;
            float successRate = 0.5f;
            BinomialRange binomialRange = BinomialRange.Exact;
            var expected = new double[]
            {
                0.000977
            };

            IEnumerable<double> result = Statistics.Binomial(sample, success, successRate, binomialRange)
                                                   .Select(value => Math.Round(value, 6));
            CollectionAssert.AreEqual(expected, result.ToArray());
        }

        [TestMethod]
        public void TestPoissonOf_A()
        {
            int success = 5;
            float mean = 8;
            double expected = 0.091604;

            double result = Statistics.PoissonOf(success, mean);

            Assert.AreEqual(expected, result, 0.000001);
        }

        [TestMethod]
        public void TestPoissonOf_B()
        {
            int success = 0;
            float mean = 1.2f;
            double expected = 0.301194;

            double result = Statistics.PoissonOf(success, mean);

            Assert.AreEqual(expected, result, 0.000001);
        }

        [TestMethod]
        public void TestPoissonOf_C()
        {
            int success = 1;
            float mean = 1.2f;
            double expected = 0.361433;

            double result = Statistics.PoissonOf(success, mean);

            Assert.AreEqual(expected, result, 0.000001);
        }

        [TestMethod]
        public void TestPoissonWithRange()
        {
            int success = 1, sample = 6;
            float successRate = 0.2f;
            BinomialRange range = BinomialRange.Max;
            var expected = new double[]
            {
                0.301194,
                0.361433
            };

            IEnumerable<double> result = Statistics.Poisson(success, sample, successRate, range)
                                                   .Select(value => Math.Round(value, 6));
            CollectionAssert.AreEqual(expected, result.ToArray());
        }
    }
}
