using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Infrastructure
{
    public class PagedData<T> : IPagedData<T>
    {
        public IEnumerable<T> Data { get; set; }
        public DataPagingInformation Pager { get; set; }
        public IDictionary<string, string> SortFields { get; set; }

        public PagedData()
        {

        }

        public PagedData(IEnumerable<T> data, int pageSize, int page)
        {
            Data = data;
            Pager = new DataPagingInformation(pageSize, page);
        }
    }
}
