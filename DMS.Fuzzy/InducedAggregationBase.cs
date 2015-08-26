using DMS.Domain.Fuzzy.Aggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Fuzzy
{
        public abstract class InducedAggregationBase : OWA
        {
            protected List<decimal> ratings;

            protected List<RatingValue> ratingValues;

            public List<decimal> Ratings
            {
                get { return ratings; }
                set { ratings = value; }
            }

            public InducedAggregationBase(List<decimal> weights) : base(weights) { }

            public abstract decimal calc(List<decimal> values, List<decimal> ratings);

            protected List<RatingValue> getRatingValues(List<decimal> values, List<decimal> ratings)
            {
                List<RatingValue> ratingValues = new List<RatingValue>();
                for (int i = 0; i < Math.Min(values.Count, ratings.Count); i++)
                {
                    RatingValue rv = new RatingValue();
                    rv.Rating = ratings[i];
                    rv.Value = values[i];
                    ratingValues.Add(rv);
                }
                return ratingValues;
            }
        }

        public class RatingValue : IComparable
        {
            decimal rating;

            decimal value;

            public decimal Rating
            {
                get { return rating; }
                set { rating = value; }
            }
            public decimal Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            public int CompareTo(object obj)
            {
                if (obj is RatingValue)
                {
                    RatingValue i = (RatingValue)obj;
                    return i.rating.CompareTo(this.rating);
                }

                return 0;
            }
        }
    }