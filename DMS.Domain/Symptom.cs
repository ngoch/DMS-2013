using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain
{
    public class Factor
    {
        public int FactorId { get; set; }
        public string FactorName { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public virtual ICollection<TestAssessmentQuestionWithAnswer> Intervals { get; set; }

        public override string ToString()
        {
            return FactorName;
        }
    }
}
