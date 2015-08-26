using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Repositories
{
    public class AssessmentQuestionGenerationItemConfiguration : EntityTypeConfiguration<AssessmentQuestionGenerationItem>
    {
        public AssessmentQuestionGenerationItemConfiguration()
        {
            HasKey(item => new { item.ProjectId, item.AssesmentQuestionGenerationItemId });
            Property(item => item.AssesmentQuestionGenerationItemId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(item => item.Project).WithMany(project => project.AssesmentQuestionGenerationItems).HasForeignKey(item => item.ProjectId);
        }
    }
}
