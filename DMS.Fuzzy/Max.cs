using DMS.Domain.Fuzzy.Aggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Fuzzy
{
    public class Max : IAggregation
    {
        public decimal Calc(List<decimal> values)
        {
            return values.Max();
        }
    }
}