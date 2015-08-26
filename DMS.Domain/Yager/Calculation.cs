using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Yager
{
    public static class Calculation
    {
        public static IEnumerable<ExpertAssessmentItem> CalcMembershipGrade(IEnumerable<TestAssessmentQuestionWithAnswer> allIntervals, IEnumerable<Factor> Factors)
        {
            List<ExpertAssessmentItem> results = new List<ExpertAssessmentItem>();
            foreach (var item in allIntervals.GroupBy(x => x.AlternativeId))
            {
                var intervals = item.ToList();

                int m = intervals.Count();
                var xelements = new List<XElement>();
                foreach (var fact in Factors)
                {
                    xelements.Add(new XElement
                    {
                        AlternativeId = intervals[0].AlternativeId,
                        FactorId = fact.FactorId,
                        MembershipGrade = 0
                    });
                }

                foreach (var projFactor in Factors)
                {
                    foreach (var interval in intervals)
                    {
                        if (interval.Factors.Any(Factor => Factor.FactorId == projFactor.FactorId))
                        {
                            int k = interval.Factors.Count;

                            //if (!xelements.Any(x => x.FactorId == projFactor.FactorId))
                            //{
                            //    xelements.Add(new XElement { FactorId = projFactor.FactorId, AlternativeId = interval.AlternativeId });
                            //}
                            xelements.Single(x => x.FactorId == projFactor.FactorId).Ti += 1.0m / k;
                        }
                    }
                }

                foreach (var xelement in xelements)
                {
                    xelement.Pi = xelement.Ti / m;
                }

                xelements = xelements.OrderBy(x => x.Pi).ToList();

                for (int i = 0; i < xelements.Count; i++)
                {
                    xelements[i].MembershipGrade = (xelements.Count - i) * xelements[i].Pi;
                    for (int j = 0; j < i; j++)
                    {
                        xelements[i].MembershipGrade += xelements[j].Pi;
                    }
                }

                results.AddRange(xelements.Select(xElement => new ExpertAssessmentItem()
                {
                    FactorId = xElement.FactorId,
                    AlternativeId = xElement.AlternativeId,
                    Points = xElement.MembershipGrade
                }));
            }
            return results;
        }

        /// <summary>
        /// კალკულაციის შედეგები
        /// </summary>
        internal class XElement
        {
            public int XElementId { get; set; }
            public decimal Ti { get; set; }
            public decimal Pi { get; set; }
            public decimal MembershipGrade { get; set; }

            public int FactorId { get; set; }
            public int AlternativeId { get; set; }
        }
    }
}
