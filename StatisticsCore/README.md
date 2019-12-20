# The Statistics class
Contains methods to do statistics calculus. The class are defined in `./Statistics.cs`.

To use this class set a reference to StatisticsCore project and import the StatisticsCore namespace to your code.
```C#
using StatisticsCore;
```

#### Leia em [português](./LEIAME.md)

# Table of Content
 - [Methods](#methods)
   - [Sum Of Items](#sumofitems)
   - [Sum Of Square Of Items](#sumofsquareofitems)
   - [Mean](#mean)
   - [Median](#median)
   - [Mode](#mode)
   - [Sample Standard Deviation](#samplestandarddeviation)
   - [Population Standard Deviation](#populationstandarddeviation)
   - [Sample Variance](#samplevariance)
   - [Population Variance](#populationvariance)
   - [Normal Distribution Density](#normaldistributiondensity)
   - [Binomial](#binomial)
   - [Linear Regression](#linear-regression)
   
 - [Examples](#examples)
   - [Sum Of Items and Sum Of Square Of Items Example](#sum-of-items-and-sum-of-square-of-items-example)
   - [Mean, Median and Mode Example](#mean-median-and-mode-example)
   - [Deviation and Variance Example](#deviation-and-variance-example)
   - [Normal Distribution Density Example](#normal-distribution-density-example)
   - [Binomial Example](#binomial-example)
   - [Linear Regression Example](#linear-regression-example)

# Methods

- ## SumOfItems
  ```C#
  public static double SumOfItems(params double[] items)
  ```
  Return the sum of all items
- ## SumOfSquareOfItems
  ```C#
  public static double SumOfSquareOfItems(params double[] items)
  ```
  Return the sum of square of all items
- ## Mean
  ```C#
  public static double Mean(params double[] items)
  ```
  Return the mean of the sample
- ## Median
  ```C#
  public static double Median(params double[] items)
  ```
  Return the median of the sample
- ## Mode
  ```C#
  public static List<double> Mode(params double[] items)
  ```
  Return the mode of the sample (most frequent values)
- ## SampleStandardDeviation
  ```C#
  public static double SampleStandardDeviation(params double[] items)
  ```
  Return the sample standard deviation.
- ## PopulationStandardDeviation
  ```C#
  public static double PopulationStandardDeviation(params double[] items)
  ```
  Return the population standard deviation.
- ## SampleVariance
  ```C#
  public static double SampleVariance(params double[] items)
  ```
  Return the sample variance.
- ## PopulationVariance
  ```C#
  public static double PopulationVariance(params double[] items)
  ```
  Return the population variance.
- ## NormalDistributionDensity
  ```C#
  public static double NormalDistributionDensity(double comparer, double deviation, double mean)
  ```
  Return the estimate density of items that are less than or equal the comparer value
  ```C#
  public static double NormalDistributionDensity(double comparer, double deviation, double mean, bool isGreaterThan)
  ```
  Return the estimate density of items that are greater than or equal the comparer value when isGreaterThan is true
  ```C#
  public static double NormalDistributionDensity(double start, double end, double deviation, double mean)
  ```
  Return the estimate density of items that are between the start and end values
  
  ## Binomial
  ```C#
  public static double BinomialOf(int success, int sample, float successRate)
  ```
  Calculates the chance of an event occurs a number of time in a sample with a specific success rate
  
  ```C#
  public static IEnumerable<double> Binomial(int sample, float successRate)
  ```
  Calculates the chance of each event occurs in a sample with a specific success rate
  
  ```C#
  public static IEnumerable<double> Binomial(int sample, int success, float successRate, BinomialRange range)
  ```
  Calculates the chance of each event in a range occurs in a sample with a specific success rate. The range can be **Min** for at least the success variable value, **Max** for at maximun success variable value or the **Exact** success variable value 
  
  ## Linear Regression
  
  ```C#
  public static double LinearCorrelationCoefficient(int sampleSize, double sumOfX, double sumOfY, 
            double sumOfXY, double sumOfSquareOfX, double sumOfSquareOfY)
  ```
  Calculates the linear correlaltion coefficient
  
  ```C#
  public static double LinearCorrelationCoefficient(IEnumerable<KeyValuePair<double, double>> sample)
  ```
  Calculates the linear correlaltion coefficient of a pair value sample
  
  ```C#
  public static void LinearRegression(IEnumerable<KeyValuePair<double, double>> sample, 
            out double correlationCoeficient, out double angularCoefficient, out double linearCoefficient)
  ```
  Calculates the correlation, angular and linear coefficients of a value pair sample 
  
# Examples
## Sum Of Items and Sum Of Square Of Items Example
```C#
using System;
using StatisticsCore;
  
namespace StatisticsExample
{
    public class SumOfSquareAndSumOfItemsExample 
    {
        public static void Main() 
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
            double result = Statistics.SumOfItems(items);
            double squareResult = Statistics.SumOfSquareOfItems(items);
            Console.WriteLine("Sum of items: {0}", result);
            Console.WriteLine("Sum of square of items: {0}", squareResult);
              
        }
    }
}
  
/*Output:
Sum of items: 178
Sum of square of items: 5020
*/
```
## Mean, Median and Mode Example
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using StatisticsCore;
  
namespace StatisticsExample
{
  public class MeanMedianModeExample 
  {
      public static void Main() 
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
            double mean = Statistics.Mean(items);
            double median = Statistics.Median(items);
            List<double> mode = Statistics.Mode(items);
            IEnumerable<string> modeString = mode.Select(i => i.ToString());
            Console.WriteLine("Mean: {0}", mean);
            Console.WriteLine("median: {0}", median);
            Console.WriteLine("mode: {0}", string.Join(",", modeString.ToArray()));
              
        }
    }
}
    
/*Output:
Mean: 22.25
Median: 23
Mode: 23
*/
```
## Deviation and Variance Example
```C#
using System;
using StatisticsCore;
  
namespace StatisticsExample
{
    public class DeviationAndVarianceExample 
    {
        public static void Main() 
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
            double sampleStandardDeviation = Statistics.SampleStandardDeviation(items);
            double populationStandardDeviation = Statistics.PopulationStandardDeviation(items);
            double sampleVariance = Statistics.SampleVariance(items);
            double populationVariance = Statistics.PopulationVariance(items);
            Console.WriteLine("Sample Standard Deviation: {0}", sampleStandardDeviation);
            Console.WriteLine("Population Standard Deviation: {0}", populationStandardDeviation);
            Console.WriteLine("Sample Variance: {0}", sampleVariance);
            Console.WriteLine("Population Variance: {0}", populationVariance);
              
        }
    }
}
  
/*Output:
Sample Standard Deviation: 12.3027290816771
Population Standard Deviation: 11.5081492864839
Sample Variance: 151.357142857143
Population Variance: 132.4375
*/
```

## Normal Distribution Density Example
```C#
using System;
using StatisticsCore;

namespace StatisticsExample
{
    public class NormalDistributionDensityExample
    {
        public static void Main(string[] args)
        {
            double deviation = 5, mean = 50, start = 60;
            double result = Statistics.NormalDistributionDensity(start, deviation, mean);
            Console.WriteLine("The density of items that are less or equals to {0} is {1:P2}", start, result);

            deviation = 5;
            mean = 50;
            start = 35;
            double end = 45;
            result = Statistics.NormalDistributionDensity(start, end, deviation, mean);
            Console.WriteLine("The density of items that are between {0} and {1} is {2:P2}", start, end, result);

            deviation = 5;
            mean = 50;
            start = 40;
            result = Statistics.NormalDistributionDensity(start, deviation, mean, true);
            Console.WriteLine("The density of items that are greater or equals to {0} is {1:P2}", start, result);
        }
    }
}

/* Output:
   The density of items that are less or equals to 60 is 97.72%
   The density of items that are between 35 and 45 is 15.73%
   The density of items that are greater or equals to 40 is 97.72%
*/
```

## Binomial Example

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using StatisticsCore;

namespace StatisticsExample
{
    public class BinomialExample
    {
        internal static void Main(string[] args)
        {
            int sample = 9;
            float successRate = 0.02f;
            BinomialRange binomialRange = BinomialRange.Min;
            int min = 1;
            IEnumerable<double> result = Statistics.Binomial(sample, min, successRate, binomialRange);
            double totalChance = 0;
            foreach (double chance in result)
            {
                totalChance += chance;
            }
            
            Console.WriteLine("Chance of at least 1 item match the condition: {0:P2}", totalChance);
            Console.WriteLine("Chance for each amount of success:");
            for (int i = 0; i < result.Count(); i++)
            {
                Console.WriteLine("P[X = {0}] = {1:P2}", i + 1, result.ElementAt(i));
            }
        }
    }
}
/* Output
    Chance of at least 1 item match the condition: 16.63%
    Chance for each amount of success:
    P[X = 1] = 15.31%
    P[X = 2] = 1.25%
    P[X = 3] = 0.06%
    P[X = 4] = 0.00%
    P[X = 5] = 0.00%
    P[X = 6] = 0.00%
    P[X = 7] = 0.00%
    P[X = 8] = 0.00%
    P[X = 9] = 0.00%
*/
```

## Linear Regression Example
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using StatisticsCore;

namespace StatisticsExample
{
    public class LinearRegressionExample
    {
        internal static void Example()
        {
            KeyValuePair<double, double>[] sample = new KeyValuePair<double, double>[] 
            {
                KeyValuePair.Create<double, double>(5, 6),
                KeyValuePair.Create<double, double>(8, 9),
                KeyValuePair.Create<double, double>(7, 8),
                KeyValuePair.Create<double, double>(10, 10),
                KeyValuePair.Create<double, double>(6, 5),
                KeyValuePair.Create<double, double>(7, 7),
                KeyValuePair.Create<double, double>(9, 8),
                KeyValuePair.Create<double, double>(3, 4),
                KeyValuePair.Create<double, double>(8, 6),
                KeyValuePair.Create<double, double>(2, 2)
            };
            
            double correlationCoefficient, angularCoefficient, linearCoefficient;
            
            Statistics.LinearRegression(sample, out correlationCoefficient, out angularCoefficient, out linearCoefficient);
            
            Console.WriteLine("Linear correlation coefficient = {0:F4}", correlationCoefficient);
            Console.WriteLine("y = {0:F2}x + {1:F2}", angularCoefficient, linearCoefficient);
            
        }
    }
}
/*
Output:
    Linear correlation coefficient = 0.9112
    y = 0.86x + 0.89
*/
```
