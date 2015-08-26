using DMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.Web.Host.Models
{
    public class AssessmentDetailsViewModel
    {
        public virtual int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual IList<ExpertAssessmentItem> Items { get; set; }
        public virtual ExpertAssessmentMethod? Method { get; set; }
        public bool Confirmed { get; set; }

        public bool HasAssessment()
        {
            return Items != null && Items.Any();
        }
    }
}