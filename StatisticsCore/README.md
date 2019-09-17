# A classe Statistics
Contém as funções de cálculos estatísticos e pode ser encontrada em `./Statistics.cs`.

Para usar a classe é necessário referênciar o projeto StatisticsCore e no código importar a namespace StatisticsCore.
```C#
using StatisticsCore;
```

## Funções

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
  ```C#
  using System;
  using System.Collections.Generics;
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
