using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace DMS.Domain.Repositories
{
    public class ExpertAssessmentConfiguration : EntityTypeConfiguration<ExpertAssessment>
    {
        public ExpertAssessmentConfiguration()
        {
            HasKey(assessment => new { assessment.ExpertId, assessment.ProjectId });
            HasRequired(assessment => assessment.Project).WithMany(project => project.Assessments).HasForeignKey(assessment => assessment.ProjectId);
            HasRequired(assessment => assessment.Expert).WithMany(expert => expert.Assesments).HasForeignKey(assessment => assessment.ExpertId);
        }
    }
}
