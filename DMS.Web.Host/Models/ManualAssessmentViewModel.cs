using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DMS.Web.Host.Models
{
    [Validator(typeof(ManualAssessmentViewModelValidator))]
    public class ManualAssessmentViewModel
    {
        public List<ManualAssessmentViewModelItem> Items { get; set; }

        public ManualAssessmentViewModel()
        {
            Items = new List<ManualAssessmentViewModelItem>();
        }
    }

    [Validator(typeof(ManualAssessmentViewModelItemValidator))]
    public class ManualAssessmentViewModelItem
    {
        public int AlternativeId { get; set; }
        public string AlternativeName { get; set; }
        public int FactorId { get; set; }
        public string FactorName { get; set; }

        public string Points { get; set; }

        internal decimal GetPoints()
        {
            return Convert.ToDecimal(Points, CultureInfo.InvariantCulture);
        }
    }
}