using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Domain
{
    public class WeightGenerationResultItem
    {
        public int WeightGenerationResultItemId { get; set; }
        public int WeightGenerationResultId { get; set; }
        public virtual WeightGenerationResult WeightGenerationResult { get; set; }
        public int AlternativeId { get; set; }
        public virtual Alternative Alternative { get; set; }
        public int FactorId { get; set; }
        public virtual Factor Factor { get; set; }
        public decimal Weight { get; set; }
        public decimal? Rating { get; set; }
        public decimal? Probability { get; set; }
        public decimal? Possibility { get; set; }
    }
}
