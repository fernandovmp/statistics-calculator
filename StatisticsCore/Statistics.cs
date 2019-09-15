using System;

namespace StatisticsCore
{
    public static class Statistics
    {
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
    }
}
