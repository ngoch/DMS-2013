using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Domain
{
    public class PsychometricQuestionPossibleAnswer
    {
        public int PsychometricQuestionPossibleAnswerId { get; set; }
        public string AnswerText { get; set; }
        public int Index { get; set; }
        public int Points { get; set; }

        public PsychometricQuestion Question { get; set; }
    }
}
