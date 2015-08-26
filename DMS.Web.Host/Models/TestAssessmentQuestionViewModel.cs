using DMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.Web.Host.Models
{
    public class TestAssessmentQuestionViewModel
    {
        public string QuestionText { get; set; }
        public IList<Factor> AllFactors { get; set; }
        public List<int> ChosenFactors { get; set; }
    }
}