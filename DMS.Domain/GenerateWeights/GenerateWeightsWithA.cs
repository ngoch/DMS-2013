using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Domain.GenerateWeights
{
    public static class GenerateWeightWithA
    {
        public static List<List<decimal>> GenerateWeight(decimal alfa, List<List<decimal>> matrixA, WeightGenerationMethod generationMethod)
        {
            var result = new List<List<decimal>>();
            switch (generationMethod)
            {
                case WeightGenerationMethod.Method1:
                    result = MethodUniversal(alfa, matrixA, (val) => { return val; });
                    break;
                case WeightGenerationMethod.Method2:
                    result = MethodUniversal(alfa, matrixA, (val) => { return 1.0M / val; });
                    break;
                case WeightGenerationMethod.Method3:
                    result = MethodUniversal(alfa, matrixA, (val) => { return 1.0M - val; });
                    break;
            }
            return result;
        }

        private static List<List<decimal>> MethodUniversal(decimal alfa, List<List<decimal>> matrixA, Func<decimal, decimal> func)
        {
            var result = new List<List<decimal>>();

            for (int i = 0; i < matrixA.Count; i++)
            {
                var orderedList = matrixA[i].OrderBy(t => t).ToList<decimal>();

                decimal sum = orderedList.Sum(t => Convert.ToDecimal(Math.Pow(Convert.ToDouble(func(t)), Convert.ToDouble(alfa))));


                var listTemp = new List<decimal>();
                for (int j = 0; j < orderedList.Count; j++)
                {
                    listTemp.Add(Convert.ToDecimal(Math.Pow(Convert.ToDouble(func(orderedList[j])), Convert.ToDouble(alfa))) / sum);
                }

                result.Add(listTemp);
            }

            return result;
        }
    }
}
