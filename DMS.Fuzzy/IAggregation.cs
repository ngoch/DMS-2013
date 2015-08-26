using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Fuzzy.Aggregation
{
    public interface IAggregation
    {
        decimal Calc(List<decimal> values);
    }
}
