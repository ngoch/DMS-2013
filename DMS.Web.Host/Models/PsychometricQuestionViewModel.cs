using DMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.Web.Host.Models
{
    public class PsychometricQuestionViewModel
    {
        public string QuestionText { get; set; }
        public IList<PsychometricQuestionPossibleAnswer> AllAnswers { get; set; }
        public List<int> SelectedAnswers { get; set; }
    }
}