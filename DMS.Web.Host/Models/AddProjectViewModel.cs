using DMS.Web.Host.Resources;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DMS.Web.Host.Models
{
    [Validator(typeof(AddProjectViewModelValidator))]
    public class AddProjectViewModel
    {
        [Display(Name = "ProjectName", ResourceType = typeof(ApplicationStrings))]
        public string Name { get; set; }

        [Display(Name = "Alternatives", ResourceType = typeof(ApplicationStrings))]
        public IList<AlternativeModel> Alternatives { get; set; }

        [Display(Name = "Factors", ResourceType = typeof(ApplicationStrings))]
        public IList<FactorModel> Factors { get; set; }

        public IEnumerable<SelectListItem> UsersSelectList { get; set; }

        [Display(Name = "Experts", ResourceType = typeof(ApplicationStrings))]
        public IEnumerable<int> Users { get; set; }

        /*[Display(Name = "QuestionCount", ResourceType = typeof(ApplicationStrings))]
        public int? AssessmentQuestionCount { get; set; }*/

        public AddProjectViewModel()
        {
            Alternatives = Enumerable.Empty<AlternativeModel>().ToList();
            Factors = Enumerable.Empty<FactorModel>().ToList();
        }
    }

    [Validator(typeof(AlternativeModelValidator))]
    public class AlternativeModel
    {
        public int? AlternativeId { get; set; }
        public string Name { get; set; }
    }

    [Validator(typeof(FactorModelValidator))]
    public class FactorModel
    {
        public int? FactorId { get; set; }
        public string Name { get; set; }
    }
}
