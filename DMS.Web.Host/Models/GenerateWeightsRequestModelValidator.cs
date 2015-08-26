using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.Web.Host.Models
{
    public class GenerateWeightsRequestModelValidator : AbstractValidator<GenerateWeightsRequestModel>
    {
        public GenerateWeightsRequestModelValidator()
        {
            RuleFor(x => x.Alfa).NotEmpty();
            RuleFor(x => x.Method).NotEmpty();
            RuleFor(x => x.Alfa).Matches(@"^[+]?\d+(\.\d+)?$");
            When(x => x.Method == Domain.WeightGenerationMethod.Orness || x.Method == Domain.WeightGenerationMethod.Quantifier, () => RuleFor(x => x.N));
        }
    }
}