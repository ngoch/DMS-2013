using DMS.Domain;
using DMS.Domain.Fuzzy.Aggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Fuzzy
{
    public class ASPOWA : POWA
    {
        private AggregationType type;

        public ASPOWA(List<decimal> weights, List<decimal> p, decimal beta, AggregationType type)
            : base(weights, p, beta)
        {
            this.type = type;
        }

        public override decimal Calc(List<decimal> values)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < values.Count; i++)
            {
                indexes.Add(i);
            }

            AggrerationUtil au = new AggrerationUtil();
            IEnumerable<IEnumerable<int>> permutationResult = au.Permutation<int>(indexes);

            decimal globalK = 0M;
            bool initGlobal = false;

            foreach (IEnumerable<int> e in permutationResult)
            {
                List<int> curentPermutation = e.ToList();

                List<decimal> curentPermutationP = new List<decimal>();

                foreach (int i in e)
                {
                    curentPermutationP.Add(p[i]);
                }

                // First max Aggregation
                // Result is pSigma
                List<decimal> pSigma = new List<decimal>();
                decimal lastMax = 0m;
                for (int i = 0; i < curentPermutationP.Count; i++)
                {
                    decimal curentPValue = curentPermutationP[i];
                    if (i > 0)
                    {
                        decimal max = Math.Max(curentPValue, lastMax);
                        curentPValue = max - lastMax;
                        lastMax = max;
                    }
                    else
                    {
                        lastMax = curentPValue;
                    }
                    pSigma.Add(curentPValue);
                }

                List<decimal> permValues = new List<decimal>();
                foreach (int i in e)
                {
                    permValues.Add(values[i]);
                }

                //Calculate local K
                decimal localK = 0;
                for (int i = 0; i < pSigma.Count; i++)
                {
                    localK += pSigma[i] * permValues[i];
                }

                //Ckeck initial
                if (!initGlobal)
                {
                    initGlobal = true;
                    globalK = localK;
                }

                globalK = checkASPOWAAggregationType(this.type, globalK, localK);

            }

            IAggregation aggregation = AggregationFactory.CreateWeightAggregation(AggregationType.OWA, this.weights);
            decimal owaValue = aggregation.Calc(values);

            return this.beta * owaValue + (1 - this.beta) * globalK;
        }

        private decimal checkASPOWAAggregationType(AggregationType type, decimal oldValue, decimal newValue)
        {
            decimal result = 0;
            switch (type)
            {
                case AggregationType.ASPOWA_MIN:
                    {
                        result = Math.Min(oldValue, newValue);
                        break;
                    }
                case AggregationType.ASPOWA_MAX:
                    {
                        result = Math.Max(oldValue, newValue);
                        break;
                    }
                case AggregationType.ASPOWA_MEAN:
                    {
                        result = (oldValue + newValue) / 2m;
                        break;
                    }
            }
            return result;
        }
    }
}