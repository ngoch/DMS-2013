using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Domain
{
    public class PsychometricQuestionWithAnswer
    {
        public int PsychometricQuestionWithAnswerId { get; set; }
        public virtual PsychometricQuestion Question { get; set; }
        public virtual ICollection<PsychometricQuestionPossibleAnswer> SelectedAnswers { get; set; }
        public virtual int Index { get; set; }
        public virtual double? Points { get; set; }

        public void SetPoints()
        {
            Points = SelectedAnswers.Average(answer => answer.Points);
        }
    }
}
