using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public virtual IList<Alternative> Alternatives { get; set; }
        public virtual IList<Factor> Factors { get; set; }
        public virtual ICollection<User> Experts { get; set; }
        public virtual ICollection<ExpertAssessment> Assessments { get; set; }
        /// <summary>
        /// M
        /// </summary>
        public int AssessmentQuestionCount { get; set; }
        public virtual ICollection<AssessmentQuestionGenerationItem> AssesmentQuestionGenerationItems { get; set; }
        public virtual ProjectAssessment FinalAssessment { get; set; }
        public virtual ICollection<WeightGenerationResult> WeightGenerationResults { get; set; }

        public virtual ICollection<AggregationResult> AggregationResults { get; set; }

        public virtual ICollection<PsychometricQuestionWithAnswer> PsychometricQuestionnaire { get; set; }
        public double? PsychometricQuestionnairePoints { get; set; }

        public void CalcAndSetFinalAssessment()
        {
            //alternativeId, points
            ProjectAssessment result = new ProjectAssessment()
            {
                Items = new List<ProjectAssessmentItem>()
            };
            foreach (var alternative in Alternatives)
            {
                var alternativeAssessments = Assessments
                    .SelectMany(x => x.Items).Where(item => item.AlternativeId == alternative.AlternativeId)
                    .ToDictionary(x => new { x.ExpertId, x.FactorId }, x => x.Points.Value).OrderBy(x => x.Key.ExpertId).ThenBy(x => x.Key.FactorId);

                List<decimal> levels = GetLevels();
                Dictionary<decimal, decimal[]> levelPoints = new Dictionary<decimal, decimal[]>();

                for (int i = 0; i < levels.Count; i++)
                {
                    var level = levels[i];
                    levelPoints.Add(level, new decimal[Factors.Count]);

                    for (int j = 0; j < Factors.Count; j++)
                    {
                        var factor = Factors[j];
                        List<decimal> expertPointsForDecision = new List<decimal>();
                        foreach (var expert in Experts)
                        {
                            expertPointsForDecision.Add(alternativeAssessments.Single(x => x.Key.ExpertId == expert.UserId && x.Key.FactorId == factor.FactorId).Value);
                        }

                        var aggregatedDecisionForLevel = expertPointsForDecision.Where(x => x >= level).Count();
                        levelPoints[level][j] = aggregatedDecisionForLevel;
                    }
                }

                for (int i = 0; i < Factors.Count; i++)
                {
                    result.Items.Add(new ProjectAssessmentItem()
                    {
                        AlternativeId = alternative.AlternativeId,
                        FactorId = Factors[i].FactorId,
                        Points = levelPoints.Select(x => x.Value[i] / Experts.Count).Average()
                    });
                }
            }
            this.FinalAssessment = result;
        }

        private List<decimal> GetLevels()
        {
            List<decimal> levels = new List<decimal>();

            for (decimal i = 0; i < 1; i += 0.1m)
            {
                levels.Add(i);
            }

            return levels;
        }

        public void SetPsychometricQuestionnairePoints()
        {
            var points = PsychometricQuestionnaire.Sum(x => x.Points);
            var max = PsychometricQuestionnaire.Sum(x => x.Question.Answers.Max(answer => answer.Points));

            PsychometricQuestionnairePoints = points / max;
        }

        public IEnumerable<Tuple<Alternative, int>> GetRangedAlternatives()
        {
            //var alternativeCount = Alternatives.Count;
            //var alternatives = Alternatives.OrderBy(x => x.AlternativeId).ToList();

            //for (int i = 0; i < alternativeCount; i++)
            //{
            //    var alternative = alternatives[i];

            //    foreach (var aggregation in AggregationResults)
            //    {
            //        var aggregationPlaces = aggregation.Items.OrderByDescending(x => x.Aggregation).Select((x, index) => new { x.AlternativeId, index });
            //    }
            //}

            return AggregationResults.SelectMany(result => result.Items.OrderByDescending(item => item.Aggregation).Select((x, index) => new { x.AlternativeId, Index = index }))
                .Where(x => x.Index == 0)
                .GroupBy(x => x.AlternativeId)
                .OrderByDescending(x => x.Count()).Select(x => new Tuple<Alternative, int>(Alternatives.Single(alternative => alternative.AlternativeId == x.Key), x.Count())).ToList();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
