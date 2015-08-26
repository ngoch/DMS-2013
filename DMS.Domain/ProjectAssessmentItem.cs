using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Domain
{
    public class ProjectAssessmentItem
    {
        public int ProjectId { get; set; }
        public virtual ProjectAssessment ProjectAssessment { get; set; }
        public int AlternativeId { get; set; }
        public virtual Alternative Alternative { get; set; }
        public int FactorId { get; set; }
        public virtual Factor Factor { get; set; }

        public decimal Points { get; set; }
    }
}
