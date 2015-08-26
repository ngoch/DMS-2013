using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Repositories
{
    public class ProjectAssessmentItemConfiguration : EntityTypeConfiguration<ProjectAssessmentItem>
    {
        public ProjectAssessmentItemConfiguration()
        {
            HasKey(item => new { item.ProjectId, item.AlternativeId, item.FactorId });
            HasRequired(item => item.Alternative).WithMany().HasForeignKey(item => item.AlternativeId);
            HasRequired(item => item.Factor).WithMany().HasForeignKey(item => item.FactorId).WillCascadeOnDelete(false);
            HasRequired(item => item.ProjectAssessment).WithMany().HasForeignKey(item => new { item.ProjectId }).WillCascadeOnDelete(false);
        }
    }
}
