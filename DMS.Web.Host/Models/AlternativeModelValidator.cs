using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Web.Host.Models
{
    public class AlternativeModelValidator : AbstractValidator<AlternativeModel>
    {
        public AlternativeModelValidator()
        {
            RuleFor(model => model.Name).NotEmpty();
        }
    }
}
