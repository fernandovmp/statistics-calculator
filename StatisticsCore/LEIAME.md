# A classe Statistics
Contém as funções de cálculos estatísticos. A classe está definida em `./Statistics.cs`.

Para usar a classe é necessário referênciar o projeto StatisticsCore e no código importar a namespace StatisticsCore.
```C#
using StatisticsCore;
```

# Conteúdo
 - [Métodos](#métodos)
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
   
 - [Exemplos](#exemplos)
   - [Exemplo Sum Of Items e Sum Of Square Of Items](#exemplo-sum-of-items-e-sum-of-square-of-items)
   - [Exemplo Mean, Median e Mode](#exemplo-mean-median-e-mode)
   - [Exemplo Deviation e Variance](#exemplo-deviation-e-variance)
   - [Exemplo Normal Distribution Density](#exemplo-normal-distribution-density)
   - [Exemplo Binomial](#exemplo-binomial)

## Métodos

- ## SumOfItems
  ```C#
  public static double SumOfItems(params double[] items)
  ```
  Realiza a soma de todos os itens
- ## SumOfSquareOfItems
  ```C#
  public static double SumOfSquareOfItems(params double[] items)
  ```
  Realiza a soma dos quadrados de todos os itens
- ## Mean
  ```C#
  public static double Mean(params double[] items)
  ```
  Calcula a media dos valores.
- ## Median
  ```C#
  public static double Median(params double[] items)
  ```
  Calcula a mediana da amostra.
- ## Mode
  ```C#
  public static List<double> Mode(params double[] items)
  ```
  Calcula a moda da amostra (valores que mais repetem).
- ## SampleStandardDeviation
  ```C#
  public static double SampleStandardDeviation(params double[] items)
  ```
  Calcula o desvio padrão da amostra.
- ## PopulationStandardDeviation
  ```C#
  public static double PopulationStandardDeviation(params double[] items)
  ```
  Calcula o desvio padrão da população.
- ## SampleVariance
  ```C#
  public static double SampleVariance(params double[] items)
  ```
  Calcula a variância da amostra.
- ## PopulationVariance
  ```C#
  public static double PopulationVariance(params double[] items)
  ```
  Calcula a variância da população.
- ## NormalDistributionDensity
  ```C#
  public static double NormalDistributionDensity(double comparer, double deviation, double mean)
  ```
  Calcula a estimativa da porcentagem dos itens que são menores ou iguais ao valor de _comparer_
  ```C#
  public static double NormalDistributionDensity(double comparer, double deviation, double mean, bool isGreaterThan)
  ```
  Calcula a estimativa da porcentagem dos itens que são maiores ou iguais ao valor de _comparer_ quando _isGreaterThan_ é _true_
  ```C#
  public static double NormalDistributionDensity(double start, double end, double deviation, double mean)
  ```
   Calcula a estimativa da porcentagem dos itens que estão entre _start_ e _end_
   
   ## Binomial
  ```C#
  public static double BinomialOf(int success, int sample, float successRate)
  ```
  Calcula a chance de um evento ocorrer um número de vezes em uma amostra com uma determinda chance de sucesso
  
  ```C#
  public static IEnumerable<double> Binomial(int sample, float successRate)
  ```
  Calcula a chance de cada evento ocorrer em uma amostra com uma determinda chance de sucesso
  
  ```C#
  public static IEnumerable<double> Binomial(int sample, int success, float successRate, BinomialRange range)
  ```
  Calcula a chance de um intervalo de eventos ocorrerem em uma amostra com uma chance determinada de sucesso. O intervalo pode ser **Min** para 'no mínimo o valor da variável _success_', **Max** para 'no máximo o valor da variável _success_' ou **Exact** para exatamente valor da variável _success_.

# Exemplos
## Exemplo Sum Of Items e Sum Of Square Of Items
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
## Exemplo Mean, Median e Mode
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
## Exemplo Deviation e Variance
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

## Exemplo Normal Distribution Density
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

## Exemplo Binomial

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
