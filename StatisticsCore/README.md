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
   
 - [Examples](#examples)
   - [Sum Of Items and Sum Of Square Of Items Example](#sum-of-items-and-sum-of-square-of-items-example)
   - [Mean, Median and Mode Example](#mean-median-and-mode-example)
   - [Deviation and Variance Example](#deviation-and-variance-example)
   - [Normal Distribution Density Example](#normal-distribution-density-example)

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
