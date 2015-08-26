using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain
{
    public class PsychometricQuestion
    {
        public int PsychometricQuestionId { get; set; }
        public string Body { get; set; }
        public virtual ICollection<PsychometricQuestionPossibleAnswer> Answers { get; set; }
    }
}
