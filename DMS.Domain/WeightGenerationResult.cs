using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain
{
    public class WeightGenerationResult
    {
        public int WeightGenerationResultId { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual WeightGenerationMethod GenerationMethod { get; set; }
        public virtual ICollection<WeightGenerationResultItem> Items { get; set; }
        public virtual decimal Alfa { get; set; }

        public List<List<double>> ToMatrix()
        {
            var result = ToMatrixInternal().ToList();

            return result;
        }

        private List<List<double>> ToMatrixInternal()
        {
            var grouped = Items.OrderBy(item => item.AlternativeId).GroupBy(x => x.AlternativeId);

            return grouped.Select(y => y.Select(x => Convert.ToDouble(x.Weight)).ToList()).ToList();
        }

        public List<decimal> GetWeights(Alternative alternative)
        {
            return Items.Where(x => x.AlternativeId == alternative.AlternativeId).OrderBy(x => x.FactorId).Select(x => x.Weight).ToList();
        }

        public List<decimal> GetRatings(Alternative alternative)
        {
            return Items.Where(x => x.AlternativeId == alternative.AlternativeId).OrderBy(x => x.FactorId).Select(x => x.Rating.Value).ToList();
        }

        public List<decimal> GetProbabilities(Alternative alternative)
        {
            return Items.Where(x => x.AlternativeId == alternative.AlternativeId).OrderBy(x => x.FactorId).Select(x => x.Probability.Value).ToList();
        }

        public List<decimal> GetPossibilities(Alternative alternative)
        {
            return Items.Where(x => x.AlternativeId == alternative.AlternativeId).OrderBy(x => x.FactorId).Select(x => x.Possibility.Value).ToList();
        }

        public IEnumerable<WeightGenerationResultItem> GetFirstAlternativeFactors()
        {
            var firstAlternative = Project.Alternatives.OrderBy(x => x.AlternativeId).First();
            return Items.Where(item => item.AlternativeId == firstAlternative.AlternativeId).OrderBy(item => item.FactorId);
        }

        public void SetRatings(ref List<WeightGenerationResultItem> items, IList<decimal> ratings)
        {
            for (int i = 0; i < Project.Factors.Count; i++)
            {
                var id = items[i].WeightGenerationResultItemId;
                var item = items.SingleOrDefault(x => x.WeightGenerationResultItemId == id);
                item.Rating = ratings[i];
            }
        }
    }
}
