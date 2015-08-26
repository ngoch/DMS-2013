using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.Web.Host.Models
{
    public class ProjectTableRowModel : TableRowViewModelBase
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int AllAssessments { get; set; }
        public int ConfirmedAssessments { get; set; }

        public override int RowId
        {
            get { return ProjectId; }
        }
    }
}