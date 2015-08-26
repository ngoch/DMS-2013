using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Repositories
{
    public class WeightGenerationResultItemConfiguration : EntityTypeConfiguration<WeightGenerationResultItem>
    {
        public WeightGenerationResultItemConfiguration()
        {
            HasRequired(item => item.WeightGenerationResult).WithMany().HasForeignKey(item => new { item.WeightGenerationResultId }).WillCascadeOnDelete(false);
            HasRequired(item => item.Alternative).WithMany().HasForeignKey(item => item.AlternativeId).WillCascadeOnDelete(false);
            HasRequired(item => item.Factor).WithMany().HasForeignKey(item => item.FactorId).WillCascadeOnDelete(false);
            Property(x => x.Weight).HasPrecision(18, 4);
            Property(x => x.Rating).HasPrecision(18, 4);
            Property(x => x.Possibility).HasPrecision(18, 4);
            Property(x => x.Probability).HasPrecision(18, 4);
        }
    }
}
