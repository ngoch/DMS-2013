using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Fuzzy.Aggregation
{
    public class OWA : IAggregation
    {
        protected List<decimal> weights;

        public OWA(List<decimal> weights)
        {
            this.weights = weights;

            decimal sum = weights.Sum();

            decimal diff = Math.Abs(1.0M - sum);
            //if (diff > 0.0001M)
            if (diff > 0.1M)
            {
                throw new ArgumentException(String.Format("sum(weights) must be 1.0 (was: {0}, {1})", sum, diff));
            }
        }

        public virtual decimal Calc(List<decimal> values)
        {

            values.Sort();
            values.Reverse();

            int min = Math.Min(values.Count, weights.Count);

            decimal sum = 0.0M;

            for (int i = 0; i < min; i++)
            {
                sum += values[i] * weights[i];
            }

            return sum;
        }

        /* 
         * Calculate the orness of this OWA operator.
           To get the andness use it's definition: <code>decimal andness = 1.0 - orness();</code>
           returns the orness [0, 1] 
        */
        public decimal orness()
        {
            decimal n = weights.Count;
            decimal s = 0.0M;
            for (int i = 0; i < n; i++)
            {
                s = (n - (i + 1)) * weights[i];
            }
            return s / (n - 1.0M);
        }

        /**
         * The dual of orness. See {@link #orness()}
         * @return
         */
        public decimal andness()
        {
            return 1.0M - orness();
        }

        /**
         * Calculate the relative dispersion (entropy) of the OWA operator.
         *
         * @return the dispersion [0, ln n]
         */
        public decimal dispersion()
        {
            decimal n = weights.Count;
            decimal s = 0.0M;

            foreach (decimal w in weights)
                if (w > 0.0M)
                {
                    s += w * (decimal)Math.Log((double)(1.0M / w));
                }

            return s / (decimal)Math.Log((double)n);
        }


        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < weights.Count; i++)
            {
                sb.Append(" " + weights[i]);
            }
            return "OWA{" +
                    "weights=" + sb.ToString() +
                    '}';
        }


    }
}