using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Repositories
{
    public class PsychometricQuestionWithAnswerConfiguration : EntityTypeConfiguration<PsychometricQuestionWithAnswer>
    {
        public PsychometricQuestionWithAnswerConfiguration()
        {
            HasMany(x => x.SelectedAnswers).WithMany();
        }
    }
}
