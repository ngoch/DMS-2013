using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Repositories
{
    public class AggregationResultConfiguration : EntityTypeConfiguration<AggregationResult>
    {
        public AggregationResultConfiguration()
        {
            HasOptional(ass => ass.Weight).WithMany();
            HasRequired(ass => ass.Project).WithMany(project => project.AggregationResults).WillCascadeOnDelete(false);
            HasMany(ass => ass.Items).WithRequired(item => item.AggregationResult);
        }
    }
}
