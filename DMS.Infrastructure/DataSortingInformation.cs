using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Infrastructure
{
    public class DataSortingInformation
    {
        public SortSpecification SortSpecification { get; set; }
        public IDictionary<string, string> SortFields { get; set; }

        public Func<string, string> SortByFieldLink { get; set; }
        public Func<string, string> SortOrderLink { get; set; }

        public DataSortingInformation(SortSpecification sort, IDictionary<string, string> sortFields)
        {
            this.SortFields = sortFields;
            this.SortSpecification = sort;
        }
    }
}
