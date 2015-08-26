using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain
{
    public static class ExpertonsMethod
    {
        public static ProjectAssessment MergeExpertAssessments(List<ExpertAssessmentItem> assessments, IEnumerable<Alternative> Alternatives, IEnumerable<Factor> Factors)
        {
            List<ProjectAssessmentItem> result = new List<ProjectAssessmentItem>();

            List<decimal> levels = GetLevels(assessments.Count());

            Dictionary<decimal, decimal[]> levelPoints = new Dictionary<decimal, decimal[]>();

            /*for (int i = 0; i < levels.Count; i++)
            {
                var level = levels[i];
                levelPoints.Add(level, new decimal[Alternatives.Count()]);

                for (int j = 0; j < Alternatives.Count(); j++)
                {
                    List<decimal> expertPointsForDecision = new List<decimal>();

                    for (int k = 0; k < assessments.Count(); k++)
                    {
                        expertPointsForDecision.Add(assessments[k][j]);
                    }

                    var aggregatedDecisionForLevel = expertPointsForDecision.Where(x => x >= level).Count();
                    levelPoints[level][j] = aggregatedDecisionForLevel;
                }
            }

            List<decimal> finalResults = new List<decimal>();
            for (int i = 0; i < expertPoints[0].Length; i++)
            {
                finalResults.Add(levelPoints.Select(x => x.Value[i] / expertPoints.Length).Average());
            }*/
            
            return new ProjectAssessment()
            {
                Items = result
            };
        }

        private static List<decimal> GetLevels(int p)
        {
            List<decimal> levels = new List<decimal>();

            for (decimal i = 0; i < 1; i += 0.1m)
            {
                levels.Add(i);
            }

            return levels;
        }
    }
}
