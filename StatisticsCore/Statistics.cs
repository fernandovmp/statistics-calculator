using System;
using System.Collections.Generic;
using System.Collections;

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
    }
}
