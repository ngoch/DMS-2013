using DMS.Domain;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Web.Host.Models
{
    public class FillRatingsViewModel
    {
        [Required]
        public List<FillRatingsItemModel> Ratings { get; set; }
    }

    [Validator(typeof(FillRatingsItemModelValidator))]
    public class FillRatingsItemModel
    {
        public int WeightId { get; set; }
        public List<FillRatingsItemValue> Values { get; set; }
        public List<string> FactorNames { get; set; }
        public WeightGenerationMethod Method { get; set; }
    }
}