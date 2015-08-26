using DMS.Domain.Fuzzy.Aggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Fuzzy
{
    public class OWG : OWA
    {
        public OWG(List<decimal> weights) : base(weights) { }

        public override decimal Calc(List<decimal> values)
        {
            values.Sort();
            values.Reverse();

            int min = Math.Min(values.Count, weights.Count);

            decimal sum = 0.0M;

            for (int i = 0; i < min; i++)
            {
                sum += (decimal)Math.Pow((double)values[i], (double)weights[i]);
            }

            return sum;
        }
    }
}