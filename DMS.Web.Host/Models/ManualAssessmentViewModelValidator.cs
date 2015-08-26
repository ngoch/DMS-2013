using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Web.Host.Models
{
    public class ManualAssessmentViewModelValidator : AbstractValidator<ManualAssessmentViewModel>
    {
        public ManualAssessmentViewModelValidator()
        {
            RuleFor(x => x.Items).NotEmpty();
        }
    }
}
