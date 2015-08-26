using DMS.Domain.Fuzzy.Aggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Fuzzy
{
    public class POWA : OWA
    {
        protected List<decimal> p;
        protected decimal beta;

        public POWA(List<decimal> weights, List<decimal> p, decimal beta)
            : base(weights)
        {
            this.p = p;
            this.beta = beta;

            if (beta <= 0 && beta >= 1)
            {
                throw new ArgumentException("Invalid Argument");
            }
        }

        public override decimal Calc(List<decimal> values)
        {
            decimal owaValue = base.Calc(values.ToList());

            decimal sum = 0.0M;

            for (int i = 0; i < values.Count; i++)
            {
                sum += (p[i] * values[i]);
            }

            return (beta * owaValue) + ((1 - beta) * sum);
        }
    }
}