using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain
{
    /// <summary>
    /// ტესტების პასუხები
    /// </summary>
    public class TestAssessmentQuestionWithAnswer
    {
        public int TestAssessmentQuestionWithAnswerId { get; set; }
        
        public double Alfa { get; set; }
        public int AlternativeId { get; set; }
        public virtual Alternative Alternative { get; set; }

        public virtual ICollection<Factor> Factors { get; set; }
        public int Index { get; set; }

        public string GetBody()
        {
            return string.Format("ჩამოთვალეთ ის ფაქტორები, რომლებიც არანაკლებ {1} დონით შეესაბამება {0} ალტერნატივის არჩევის                                            შესაძლებლობას ({1} დონის კვეთის სიმრავლე)", Alternative.AlternativeName, Alfa);
        }
    }
}
