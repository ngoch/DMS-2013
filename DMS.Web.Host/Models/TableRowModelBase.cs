using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.Web.Host.Models
{
    public abstract class TableRowViewModelBase
    {
        public abstract int RowId { get; }
    }
}