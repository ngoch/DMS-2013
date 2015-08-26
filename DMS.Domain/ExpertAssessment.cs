using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Domain
{
    public class ExpertAssessment
    {
        public virtual int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual int ExpertId { get; set; }
        public virtual User Expert { get; set; }
        public virtual ICollection<ExpertAssessmentItem> Items { get; set; }
        public virtual ExpertAssessmentMethod? Method { get; set; }
        public bool Confirmed { get; set; }

        public virtual ICollection<TestAssessmentQuestionWithAnswer> Questions { get; set; }

        public void GenerateQuestions()
        {
            List<TestAssessmentQuestionWithAnswer> result = new List<TestAssessmentQuestionWithAnswer>();
            foreach (var alternative in Project.Alternatives)
            {
                result.AddRange(Project.AssesmentQuestionGenerationItems.Select(items => new TestAssessmentQuestionWithAnswer()
                {
                    Alfa = items.Alfa,
                    Alternative = alternative
                }));
            }

            Questions = result.OrderBy(item => item.Alternative.AlternativeId).ThenBy(item => Guid.NewGuid()).Select((item, index) =>
            {
                item.Index = index;
                return item;
            }).ToList();
        }
    }
}
