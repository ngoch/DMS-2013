using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace DMS.Infrastructure
{
    public interface IPagedData<out T>
    {
        IEnumerable<T> Data { get; }
        DataPagingInformation Pager { get; set; }
    }
}
