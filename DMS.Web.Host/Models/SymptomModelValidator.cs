using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Web.Host.Models
{
    public class FactorModelValidator : AbstractValidator<FactorModel>
    {
        public FactorModelValidator()
        {
            RuleFor(model => model.Name).NotEmpty();
        }
    }
}
