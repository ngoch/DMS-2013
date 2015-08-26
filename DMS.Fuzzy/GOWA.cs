using DMS.Domain.Fuzzy.Aggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Fuzzy
{
        public class GOWA : OWA
        {
            protected decimal alfa;

            public GOWA(List<decimal> weights, decimal alfa)
                : base(weights)
            {
                this.alfa = alfa;
            }

            public override decimal Calc(List<decimal> values)
            {
                values.Sort();
                values.Reverse();

                int min = Math.Min(values.Count, weights.Count);

                decimal sum = 0.0M;

                for (int i = 0; i < min; i++)
                {
                    sum += weights[i] * (decimal)Math.Pow((double)values[i], (double)alfa);
                }

                return (decimal)Math.Pow((double)sum,(double)(1/alfa));
            }
        }
    }