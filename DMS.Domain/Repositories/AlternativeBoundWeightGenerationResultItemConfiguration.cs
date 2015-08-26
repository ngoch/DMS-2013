using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Repositories
{
    //public class AlternativeBoundWeightGenerationResultItemConfiguration : EntityTypeConfiguration<AlternativeBoundWeightGenerationResultItem>
    //{
    //    public AlternativeBoundWeightGenerationResultItemConfiguration()
    //    {
    //        HasRequired(item => item.Alternative).WithMany().HasForeignKey(item => item.AlternativeId);
    //        HasRequired(item => item.Factor).WithMany().HasForeignKey(item => item.FactorId).WillCascadeOnDelete(false);
    //        HasRequired(item => item.WeightGenerationResult).WithMany().HasForeignKey(item => new { item.WeightGenerationResultId }).WillCascadeOnDelete(false);
    //    }
    //}
}
