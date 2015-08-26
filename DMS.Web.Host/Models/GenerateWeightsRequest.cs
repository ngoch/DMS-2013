using DMS.Domain;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.Web.Host.Models
{
    [Validator(typeof(GenerateWeightsRequestModelValidator))]
    public class GenerateWeightsRequestModel
    {
        public int Id { get; set; }

        public string Alfa { get; set; }

        public WeightGenerationResult ExistingResult { get; set; }

        public WeightGenerationMethod Method { get; set; }

        public int N { get; set; }
    }
}