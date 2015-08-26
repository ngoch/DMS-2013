using FluentValidation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Web.Host.Models
{
    public class AddProjectViewModelValidator : AbstractValidator<AddProjectViewModel>
    {
        public AddProjectViewModelValidator()
        {
            RuleFor(model => model.Name).NotEmpty();
            //RuleFor(model => model.AssessmentQuestionCount).NotEmpty();
            RuleFor(model => model.Users).Must(ListsNotNull).WithMessage("ექსპერტების მითითება აუცილებელია");
            RuleFor(model => model.Factors).Must(ListsNotNull).WithMessage("სიმპტომების მითითება აუცილებელია");
            RuleFor(model => model.Alternatives).Must(ListsNotNull).WithMessage("დიაგნოზების მითითება აუცილებელია");
        }

        public bool ListsNotNull<T>(IEnumerable<T> list)
        {
            return list != null && list.Count() > 0;
        }
    }
}
