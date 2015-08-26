using AutoMapper;
using DMS.Domain;
using DMS.Service;
using DMS.Web.Host.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS.Web.Host.Controllers
{
    public partial class AssessmentsController : DefaultController
    {
        readonly IProjectService _projectService;

        public AssessmentsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public virtual ActionResult Index()
        {
            //not to be uzdeloba
            var data = CurrentUser.Assesments;
            return View(AutoMapper.Mapper.Map<IEnumerable<ExpertAssessment>, IEnumerable<AssessmentTableRowModel>>(data));
        }

        public virtual ActionResult Details(int id)
        {
            var target = CurrentUser.Assesments.SingleOrDefault(assessment => assessment.ProjectId == id);

            return View(Mapper.Map<AssessmentDetailsViewModel>(target));
        }

        public virtual ActionResult TestAssessment(int id)
        {
            var target = CurrentUser.Assesments.SingleOrDefault(assessment => assessment.ProjectId == id);
            if (target.Questions == null || !target.Questions.Any())
            {
                target.GenerateQuestions();
                _projectService.Update(target.Project);
            }

            return RedirectToAction(MVC.Assessments.TestAssessmentQuestion(id, 0));
        }

        [HttpGet]
        public virtual ActionResult ManualAssessment(int id)
        {
            var target = CurrentUser.Assesments.SingleOrDefault(assessment => assessment.ProjectId == id);

            ManualAssessmentViewModel viewModel = new ManualAssessmentViewModel();
            var alternatives = target.Project.Alternatives;
            var factors = target.Project.Factors;

            foreach (var alternative in alternatives.OrderBy(x => x.AlternativeId))
            {
                foreach (var factor in factors.OrderBy(x => x.FactorId))
                {
                    viewModel.Items.Add(new ManualAssessmentViewModelItem()
                    {
                        AlternativeId = alternative.AlternativeId,
                        AlternativeName = alternative.ToString(),
                        FactorId = factor.FactorId,
                        FactorName = factor.ToString()
                    });
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult ManualAssessment(int id, ManualAssessmentViewModel viewModel)
        {
            var target = CurrentUser.Assesments.SingleOrDefault(assessment => assessment.ProjectId == id);

            if (ModelState.IsValid)
            {
                target.Items.Clear();
                target.Items = viewModel.Items.Select(item => new ExpertAssessmentItem()
                {
                    AlternativeId = item.AlternativeId,
                    FactorId = item.FactorId,
                    Points = item.GetPoints()
                }).ToList();
                _projectService.Update(target.Project);
                return RedirectToAction(MVC.Assessments.Details(id));
            }

            foreach (var item in viewModel.Items)
            {
                item.AlternativeName = target.Project.Alternatives.First(x => x.AlternativeId == item.AlternativeId).AlternativeName;
                item.FactorName = target.Project.Factors.First(x => x.FactorId == item.FactorId).FactorName;
            }

            return View(viewModel);
        }

        [HttpGet]
        public virtual ActionResult TestAssessmentQuestion(int id, int index)
        {
            var target = CurrentUser.Assesments.SingleOrDefault(assessment => assessment.ProjectId == id);
            var question = target.Questions.Single(q => q.Index == index);

            var viewModel = new TestAssessmentQuestionViewModel()
            {
                QuestionText = question.GetBody(),
                AllFactors = target.Project.Factors,
                ChosenFactors = question.Factors.Select(Factor => Factor.FactorId).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult TestAssessmentQuestion(int id, int index, IEnumerable<int> chosenFactors)
        {
            var target = CurrentUser.Assesments.SingleOrDefault(assessment => assessment.ProjectId == id);
            var question = target.Questions.Single(q => q.Index == index);

            question.Factors.Clear();
            if (chosenFactors != null)
            {

                var selected = target.Project.Factors.Where(Factor => chosenFactors.Any(chosen => chosen == Factor.FactorId)).ToArray();
                foreach (var item in selected)
                {
                    question.Factors.Add(item);
                }
            }

            var nextQuestionExists = target.Questions.Any(q => q.Index > index);

            if (nextQuestionExists)
            {
                _projectService.Update(target.Project);
                return RedirectToAction(MVC.Assessments.TestAssessmentQuestion(id, index + 1));
            }

            target.Items.Clear();
            target.Items = DMS.Domain.Yager.Calculation.CalcMembershipGrade(target.Questions, target.Project.Factors).ToList();
            _projectService.Update(target.Project);
            return RedirectToAction(MVC.Assessments.Details(id));
        }

        [HttpPost]
        public virtual ActionResult ConfirmAssessment(int id)
        {
            var target = CurrentUser.Assesments.SingleOrDefault(assessment => assessment.ProjectId == id);
            if (target.Items == null || !target.Items.Any() || target.Confirmed)
            {
                return RedirectToAction(MVC.Assessments.Details(id));
            }

            target.Confirmed = true;
            if (target.Project.Assessments.All(assessment => assessment.Confirmed))
            {
                target.Project.CalcAndSetFinalAssessment();
            }

            _projectService.Update(target.Project);
            return RedirectToAction(MVC.Assessments.Details(id));
        }
    }
}
