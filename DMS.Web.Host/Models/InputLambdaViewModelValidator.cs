using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Web.Host.Models
{
    public class InputLambdaViewModelValidator : AbstractValidator<InputLambdaViewModel>
    {
        public InputLambdaViewModelValidator()
        {
            RuleFor(x => x.Value).NotEmpty().Matches(@"^[+]?\d+(\.\d+)?$");
        }
    }
}
