using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Repositories
{
    public class PsychometricQuestionRepository : RepositoryBase<PsychometricQuestion>, IPsychometricQuestionRepository
    {
        public PsychometricQuestionRepository(DMSDbContext dbContext)
            : base(dbContext)
        { }
    }
}
