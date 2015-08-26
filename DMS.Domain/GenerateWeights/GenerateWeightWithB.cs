using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.GenerateWeights
{
    public class GenerateWeightWithB
    {
        public static List<List<double>> Method1(int weightAmountN, double alfa, List<List<double>> matrix)
        {
            List<List<double>> finalResult = new List<List<double>>(matrix.Count());
            foreach (var listA in matrix)
            {
                var listB = listA.OrderBy(t => t).ToList<double>();
                var result = new List<double>();

                for (int i = 0; i < listB.Count; i++)
                {
                    double sum = 0;
                    for (int k = 0; k < weightAmountN; k++)
                    {
                        sum += Math.Pow(listB[k], alfa);
                    }

                    result.Add(Math.Pow(listB[i], alfa) / sum);
                }
                finalResult.Add(result);
            }

            return finalResult;
        }

        public static List<List<double>> Method2(int weightAmountN, double alfa, List<List<double>> matrix)
        {
            List<List<double>> finalResult = new List<List<double>>(matrix.Count());
            foreach (var listA in matrix)
            {
                var listB = listA.OrderBy(t => t).ToList<double>();
                var result = new List<double>();

                for (int i = 0; i < listB.Count; i++)
                {
                    double sum = 0;
                    for (int k = 0; k < weightAmountN; k++)
                    {
                        sum += Math.Pow(1 / listB[k], alfa);
                    }

                    result.Add(Math.Pow(1 / listB[i], alfa) / sum);
                }
                finalResult.Add(result);
            }
            return finalResult;
        }

        public static List<List<double>> Method3(int weightAmountN, double alfa, List<List<double>> matrix)
        {
            List<List<double>> finalResult = new List<List<double>>(matrix.Count());
            foreach (var listA in matrix)
            {
                var listB = listA.OrderBy(t => t).ToList<double>();
                var result = new List<double>();

                for (int i = 0; i < listB.Count; i++)
                {
                    double sum = 0;
                    for (int k = 0; k < weightAmountN; k++)
                    {
                        sum += Math.Pow(1 - listB[k], alfa);
                    }

                    result.Add(Math.Pow(1 - listB[i], alfa) / sum);
                }
                finalResult.Add(result);
            }

            return finalResult;
        }
    }
}
