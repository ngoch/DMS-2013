using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Infrastructure
{
    public class SortSpecification
    {
        public string Sort { get; set; }
        public string SortBy { get; set; }

        public SortSpecification()
        {

        }

        public SortSpecification(string sortBy, string sortDirection)
        {
            SortBy = sortBy;
            Sort = sortDirection;
        }

        public bool IsValidOrApplied()
        {
            return !string.IsNullOrWhiteSpace(SortBy) && (string.IsNullOrWhiteSpace(Sort) || new string[] { "asc", "desc" }.Any(x => Sort.Equals(x, StringComparison.InvariantCultureIgnoreCase)));
        }

        public override string ToString()
        {
            return string.Join(" ", SortBy, Sort);
        }

        public bool IsAsc()
        {
            return SortBy.Equals("asc", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
