using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Domain
{
    public class AggregationResult
    {
        public int AggregationResultId { get; set; }
        public virtual int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual AggregationType AggregationType { get; set; }
        public virtual WeightGenerationResult Weight { get; set; }
        public virtual ICollection<AggregationResultItem> Items { get; set; }
        public virtual decimal? Lambda { get; set; }

        public string GetAggregationText()
        {
            if (!Items.Any())
            {
                return string.Empty;
            }

            if (Items.Count == 1)
            {
                return string.Empty;
            }

            var itemList = Items.OrderByDescending(x => x.Aggregation).ToList();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < itemList.Count - 1; i++)
            {
                var first = itemList[i];
                var second = itemList[i + 1];

                result.AppendFormat("{0} {1} ", first.Alternative, GetOperand(first, second));
            }

            result.Append(itemList.Last().Alternative.ToString());

            return result.ToString();
        }

        private string GetOperand(AggregationResultItem first, AggregationResultItem second)
        {
            if (first.Aggregation > second.Aggregation)
            {
                return ">";
            }
            else if (first.Aggregation == second.Aggregation)
            {
                return "=";
            }
            else return "<";
        }
    }
}
