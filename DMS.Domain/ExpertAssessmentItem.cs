using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Domain
{
    public class ExpertAssessmentItem
    {
        public int ExpertId { get; set; }
        public virtual User Expert { get; set; }
        public virtual int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual ExpertAssessment Assessment { get; set; }
        public virtual int AlternativeId { get; set; }
        public virtual Alternative Alternative { get; set; }
        public virtual int FactorId { get; set; }
        public virtual Factor Factor { get; set; }

        public decimal? Points { get; set; }
    }
}
