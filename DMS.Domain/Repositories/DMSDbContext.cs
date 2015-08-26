using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Repositories
{
    public class DMSDbContext : DbContext
    {
        public DbSet<Alternative> Alternatives { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<TestAssessmentQuestionWithAnswer> Intervals { get; set; }
        public DbSet<PsychometricQuestion> PsychoQuestions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ExpertAssessmentItemConfiguration());
            modelBuilder.Configurations.Add(new ExpertAssessmentConfiguration());
            modelBuilder.Configurations.Add(new AssessmentQuestionGenerationItemConfiguration());
            modelBuilder.Configurations.Add(new ProjectAssessmentConfiguration());
            modelBuilder.Configurations.Add(new ProjectAssessmentItemConfiguration());
            modelBuilder.Configurations.Add(new WeightGenerationResultConfiguration());
            //modelBuilder.Configurations.Add(new AlternativeBoundWeightGenerationResultItemConfiguration());
            modelBuilder.Configurations.Add(new WeightGenerationResultItemConfiguration());
            modelBuilder.Configurations.Add(new AggregationResultConfiguration());
            modelBuilder.Configurations.Add(new AggregationResultItemConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
