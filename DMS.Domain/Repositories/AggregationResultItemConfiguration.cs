using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Repositories
{
    public class AggregationResultItemConfiguration : EntityTypeConfiguration<AggregationResultItem>
    {
        public AggregationResultItemConfiguration()
        {
            HasRequired(item => item.Alternative).WithMany().HasForeignKey(item => item.AlternativeId).WillCascadeOnDelete(false);
            HasRequired(item => item.AggregationResult).WithMany().WillCascadeOnDelete(true);
        }
    }
}
