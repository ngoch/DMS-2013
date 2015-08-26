using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace DMS.Domain.Repositories
{
    public class ExpertAssessmentItemConfiguration : EntityTypeConfiguration<ExpertAssessmentItem>
    {
        public ExpertAssessmentItemConfiguration()
        {
            HasKey(item => new { item.ExpertId, item.ProjectId, item.FactorId, item.AlternativeId });
            HasRequired(item => item.Assessment).WithMany(assessment => assessment.Items).HasForeignKey(item => new { item.ExpertId, item.ProjectId });
            HasRequired(item => item.Alternative).WithMany().HasForeignKey(item => item.AlternativeId);
            HasRequired(item => item.Factor).WithMany().HasForeignKey(item => item.FactorId).WillCascadeOnDelete(false);
            HasRequired(item => item.Expert).WithMany().HasForeignKey(item => new { item.ExpertId }).WillCascadeOnDelete(false);
            HasRequired(item => item.Project).WithMany().HasForeignKey(item => new { item.ProjectId }).WillCascadeOnDelete(false);
        }
    }
}
