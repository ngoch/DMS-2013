using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Web.Host.Models
{
    public class ManualAssessmentViewModelItemValidator : AbstractValidator<ManualAssessmentViewModelItem>
    {
        public ManualAssessmentViewModelItemValidator()
        {
            RuleFor(x => x.AlternativeId).NotEmpty();
            RuleFor(x => x.FactorId).NotEmpty();
            RuleFor(x => x.Points).NotEmpty();
            RuleFor(x => x.Points).Matches(@"^[+]?\d+(\.\d+)?$");
        }
    }
}
