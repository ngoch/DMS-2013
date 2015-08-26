using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Web.Host.Models
{
    public class FillRatingsItemValueValidator : AbstractValidator<FillRatingsItemValue>
    {
        public FillRatingsItemValueValidator()
        {
            RuleFor(x => x.Value).NotEmpty();
            RuleFor(x => x.Value).Matches(@"^[+]?\d+(\.\d+)?$");
        }
    }
}
