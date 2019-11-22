using System;
using System.Collections.Generic;
using System.Collections;

namespace StatisticsCore
{
    public enum BinomialRange { Exact, Max, Min };
    public static class Statistics
    {
        private static readonly int[] _factorials = new int[]
        {
            1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800
        };

        private static int GetFactorial(int n)
        {
            if (n <= 10)
                return _factorials[n];
            int factorial = 1;
            for (int i = n; i > 10; i--)
            {
                factorial *= n;
            }
            return factorial * _factorials[10];
        }

        private static double SumOfItems(int power, params double[] items)
        {
            double sum = 0;
            foreach (var item in items)
            {
                sum += Math.Pow(item, power);
            }
            return sum;
        }
        public static double SumOfItems(params double[] items)
        {
            return SumOfItems(1, items);
        }

        public static double SumOfSquareOfItems(params double[] items)
        {
            return SumOfItems(2, items);
        }

        public static double Mean(params double[] items)
        {
            return SumOfItems(items) / items.Length;
        }

        public static double Median(params double[] items)
        {
            if (items.Length == 0) return double.NaN;
            List<double> sortedItems = new List<double>(items);
            sortedItems.Sort((a, b) => (int)(a - b));
            int position = sortedItems.Count / 2;
            return sortedItems.Count % 2 == 0 ? 
                (sortedItems[position - 1] + sortedItems[position]) / 2 : sortedItems[position];
        }

        public static List<double> Mode(params double[] items)
        {
            List<double> sortedItems = new List<double>(items);
            sortedItems.Sort((a, b) => (int)(a - b));
            Dictionary<double, int> frequency = new Dictionary<double, int>();
            int less = int.MaxValue;
            int most = 0;
            List<double> mode = new List<double>();

            foreach (var item in sortedItems)
            {
                if(frequency.ContainsKey(item))
                {
                    frequency[item]++;
                    continue;
                }
                frequency.Add(item, 1);
            }
            foreach (var item in frequency)
            {
                if(item.Value > most)
                {
                    most = item.Value;
                    mode.Clear();
                    mode.Add(item.Key);
                }
                else if(item.Value == most)
                {
                    mode.Add(item.Key);
                }
                if(item.Value < less)
                {
                    less = item.Value;
                }
            }

            return most != less ? mode : new List<double>();
        }

        public static double SampleStandardDeviation(params double[] items)
        {
            if(items.Length < 2)
            {
                throw new ArgumentException("items lenght must be greater or equal to 2");
            }
            double mean = Mean(items);
            for (int i = 0; i < items.Length; i++)
            {
                items[i] -= mean;
            }
            double sum = SumOfSquareOfItems(items);
            return Math.Sqrt(sum / (items.Length - 1));
        }

        public static double PopulationStandardDeviation(params double[] items)
        {
            double mean = Mean(items);
            for (int i = 0; i < items.Length; i++)
            {
                items[i] -= mean;
            }
            double sum = SumOfSquareOfItems(items);
            return Math.Sqrt(sum / items.Length);
        }

        public static double SampleVariance(params double[] items)
        {
            if (items.Length < 2)
            {
                throw new ArgumentException("items lenght must be greater or equal to 2");
            }
            double mean = Mean(items);
            for (int i = 0; i < items.Length; i++)
            {
                items[i] -= mean;
            }
            double sum = SumOfSquareOfItems(items);
            return sum / (items.Length - 1);
        }

        public static double PopulationVariance(params double[] items)
        {
            if (items.Length < 2)
            {
                throw new ArgumentException("items lenght must be greater or equal to 2");
            }
            double mean = Mean(items);
            for (int i = 0; i < items.Length; i++)
            {
                items[i] -= mean;
            }
            double sum = SumOfSquareOfItems(items);
            return sum / items.Length;
        }

        public static double NormalDistributionDensity(double comparer, double deviation, double mean)
        {
            double p = 0.3275911;
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;

            double z = (comparer - mean) / deviation;
            int sign = z < 0.0 ? -1 : 1;

            double x = Math.Abs(z) / Math.Sqrt(2.0);
            double t = 1.0 / (1.0 + p * x);
            double erf = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return 0.5 * (1.0 + sign * erf);
        }

        public static double NormalDistributionDensity(double start, double end, double deviation, double mean)
        {
            double z1 = (start - mean) / deviation;
            double z2 = (end - mean) / deviation;
            double range1 = NormalDistributionDensity(start, deviation, mean);
            double range2 = NormalDistributionDensity(end, deviation, mean);
            if (z1 <= 0 && z2 <= 0 || z1 >= 0 && z2 >= 0)
            {
                return Math.Abs(range1 - range2);
            }
            return (0.5 - range1) + (range2 - 0.5);
        }

        public static double NormalDistributionDensity(double start, double deviation, double mean, 
            bool isGreaterThan = false)
        {
            if (!isGreaterThan) return NormalDistributionDensity(start, deviation, mean);

            double range = NormalDistributionDensity(start, deviation, mean);
            return 1 - range;
        }

        private static double BinomialOf(int value, int sample, int sampleFactorial, float successRate) =>
            sampleFactorial / (GetFactorial(value) * GetFactorial(sample - value)) 
                    * Math.Pow(successRate, value) * Math.Pow(1 - successRate, sample - value);

        private static IEnumerable<double> Binomial(int sample, int startRange, int endRange, float successRate)
        {
            int sampleFactorial = GetFactorial(sample);
            for (int i = startRange; i <= endRange; i++)
            {
                yield return BinomialOf(i, sample, sampleFactorial, successRate);
            }
        }

        public static IEnumerable<double> Binomial(int sample, float successRate) =>
            Binomial(sample, 0, sample, successRate);

        public static IEnumerable<double> Binomial(int sample, int success, float successRate, BinomialRange range)
        {
            switch (range)
            {
                case BinomialRange.Max:
                    return Binomial(sample, 0, success, successRate);
                case BinomialRange.Min:
                    return Binomial(sample, success, sample, successRate);
                default:
                    return Binomial(sample, success, success, successRate);
            }
        }

        public static double BinomialOf(int success, int sample, float successRate) => 
            BinomialOf(success, sample, GetFactorial(sample), successRate);

        public static double PoissonOf(int success, float mean) =>
            Math.Pow(mean, success) * Math.Exp(-mean) / GetFactorial(success);

        private static IEnumerable<double> Poisson(int sample, int startRange, int endRange, float successRate)
        {
            float mean = sample * successRate;
            for (int i = startRange; i <= endRange; i++)
            {
                yield return PoissonOf(i,  mean);
            }
        }

        public static IEnumerable<double> Poisson(int success, int sample, float successRate, BinomialRange range)
        {
            switch (range)
            {
                case BinomialRange.Max:
                    return Poisson(sample, 0, success, successRate);
                case BinomialRange.Min:
                    return Poisson(sample, success, sample, successRate);
                default:
                    return Poisson(sample, success, success, successRate);
            }
        }
    }
}
