using DMS.Domain.Fuzzy.Aggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Fuzzy
{
    public class IOWA : InducedAggregationBase
    {

        public IOWA(List<decimal> weights) : base(weights) { }

        public override decimal calc(List<decimal> values, List<decimal> ratings)
        {
            this.ratings = ratings;
            return Calc(values);
        }

        public override decimal Calc(List<decimal> values)
        {
            List<RatingValue> ratingValues = getRatingValues(values, ratings);
            ratingValues.Sort();

            int min = Math.Min(values.Count, weights.Count);
            decimal sum = 0.0M;
            for (int i = 0; i < min; i++)
            {
                sum += ratingValues[i].Value * weights[i];
            }
            return sum;
        }
    }

}