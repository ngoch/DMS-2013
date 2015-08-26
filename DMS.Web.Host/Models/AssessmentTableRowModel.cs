using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.Web.Host.Models
{
    public class AssessmentTableRowModel : TableRowViewModelBase
    {
        public virtual int ProjectId { get; set; }
        public virtual int ExpertId { get; set; }
        public string ProjectName { get; set; }

        public override int RowId
        {
            get { throw new NotImplementedException(); }
        }
    }
}