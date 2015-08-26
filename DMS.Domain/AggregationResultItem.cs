using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Domain
{
    public class AggregationResultItem
    {
        public virtual int AggregationResultItemId { get; set; }
        public virtual AggregationResult AggregationResult { get; set; }

        public int AlternativeId { get; set; }
        public virtual Alternative Alternative { get; set; }

        public decimal Aggregation { get; set; }
    }
}
