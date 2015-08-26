using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Repositories
{
    public class WeightGenerationResultConfiguration : EntityTypeConfiguration<WeightGenerationResult>
    {
        public WeightGenerationResultConfiguration()
        {
            HasRequired(ass => ass.Project).WithMany(project => project.WeightGenerationResults);
            HasMany(ass => ass.Items).WithRequired(item => item.WeightGenerationResult).HasForeignKey(item => new { item.WeightGenerationResultId });
            Property(x => x.Alfa).HasPrecision(18, 4);
        }
    }
}
