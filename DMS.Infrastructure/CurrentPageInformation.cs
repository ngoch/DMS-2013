using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Infrastructure
{
    public class CurrentPageInformation
    {
        public int PageSize { get; set; }
        public int Page { get; set; }

        public CurrentPageInformation()
        {

        }

        public CurrentPageInformation(int pageSize, int page)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
