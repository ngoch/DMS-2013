using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.GenerateWeights
{
    public class WeightGeneratorQuantifier
    {
        public static List<double> GenerateWeights(double alfa, int weightAmountN)
        {
            var weightList = new List<double>();
            double sum = 0;
            for (var i = 1; i <= weightAmountN; i++)
            {
                double Wi = Math.Pow((double)i / weightAmountN, alfa) - Math.Pow((double)(i - 1) / weightAmountN, alfa);
                weightList.Add(Wi);
                sum += Wi;
            }

            return weightList;
        }
    }
}
