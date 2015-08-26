using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Repositories
{
    public class ProjectAssessmentConfiguration : EntityTypeConfiguration<ProjectAssessment>
    {
        public ProjectAssessmentConfiguration()
        {
            HasKey(ass => ass.ProjectId);
            HasRequired(ass => ass.Project).WithOptional(project => project.FinalAssessment);
            HasMany(ass => ass.Items).WithRequired(item => item.ProjectAssessment).HasForeignKey(item => item.ProjectId);
        }
    }
}
