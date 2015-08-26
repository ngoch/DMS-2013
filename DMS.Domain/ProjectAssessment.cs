using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Domain
{
    public class ProjectAssessment
    {
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<ProjectAssessmentItem> Items { get; set; }

        public List<List<decimal>> ToMatrix()
        {
            var result = ToMatrixInternal().ToList();

            return result;
            /*return grouped.Select(group => group.ToList().Select(value => value.Select(y => Convert.ToDouble(y.Points)).ToList()).ToList()).ToList();*/

            //return grouped.Select(group => group.Select(value => value.ToList().Select(x=> x.;
        }

        private List<List<decimal>> ToMatrixInternal()
        {
            var grouped = Items.OrderBy(item => item.AlternativeId).GroupBy(x => x.AlternativeId);

            return grouped.Select(y => y.Select(x => x.Points).ToList()).ToList();
        }
    }
}
