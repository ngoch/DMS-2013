using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Domain
{
    public class AssessmentQuestionGenerationItem
    {
        public int AssesmentQuestionGenerationItemId { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public double Alfa { get; set; }
    }
}
