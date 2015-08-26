using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Web.Host.Models
{
    public class LogOnViewModelValidator : AbstractValidator<LogOnModel>
    {
        public LogOnViewModelValidator()
        {
            RuleFor(m => m.UserName).NotEmpty();
            RuleFor(m => m.Password).NotEmpty();
        }
    }
}
