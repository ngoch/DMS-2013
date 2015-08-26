using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Web.Host.Models
{
    public class FillRatingsItemModelValidator : AbstractValidator<FillRatingsItemModel>
    {
        public FillRatingsItemModelValidator()
        {
            RuleFor(x => x.Values).NotEmpty();
        }
    }
}
