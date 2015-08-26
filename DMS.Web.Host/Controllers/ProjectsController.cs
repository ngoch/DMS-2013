using AutoMapper;
using DMS.Domain;
using DMS.Service;
using DMS.Web.Host.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMS.Web.Host.Helpers;
using DMS.Web.Host.Resources;
using DMS.Domain.Services;
using DMS.Domain.GenerateWeights;
using DMS.Domain.Fuzzy.Aggregation;
using System.Globalization;
using DMS.Domain.Repositories;

namespace DMS.Web.Host.Controllers
{
	public partial class ProjectsController : Controller
	{
		readonly IProjectService _projectService;
		readonly IUserService _userService;

		public ProjectsController(IProjectService projectService,
			IUserService userService)
		{
			_projectService = projectService;
			_userService = userService;
		}

		public virtual ActionResult Index()
		{
			var model = Mapper.Map<IEnumerable<ProjectTableRowModel>>(_projectService.GetAll());
			return View(model);
		}

		[HttpGet]
		public virtual ActionResult Add()
		{
			var viewModel = new AddProjectViewModel();
			viewModel.Alternatives = new List<AlternativeModel>()
			{
				new AlternativeModel()
				{
				}
			};
			viewModel.Factors = new List<FactorModel>()
			{
				new FactorModel()
				{
				}
			};
			SetupSelectLists(viewModel);
			ViewBag.Title = ViewTitles.AddProject;
			return View(viewModel);
		}

		[HttpPost]
		public virtual ActionResult Add(AddProjectViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var domainModel = Mapper.Map<Project>(viewModel);
				domainModel.AssessmentQuestionCount = 10;
				domainModel.Experts = new List<User>();
				foreach (var item in viewModel.Users)
				{
					domainModel.Experts.Add(_userService.Get(item));
				}
				_projectService.Add(domainModel);
				TempData.AddFlash(ApplicationStrings.ProjectAdded);
				return RedirectToAction(MVC.Projects.Index());
			}

			SetupSelectLists(viewModel);
			ViewBag.Title = ViewTitles.AddProject;
			return View(viewModel);
		}

		[HttpGet]
		public virtual ActionResult Action()
		{
			return View();
		}

		public virtual ActionResult AddAlternative(int index)
		{
			ViewData.TemplateInfo.HtmlFieldPrefix = string.Format("Alternatives[{0}]", index);
			return PartialView(@"~\Views\Projects\EditorTemplates\AlternativeModel.cshtml", new AlternativeModel());
		}

		public virtual ActionResult AddFactor(int index)
		{
			ViewData.TemplateInfo.HtmlFieldPrefix = string.Format("Factors[{0}]", index);
			return PartialView(@"~\Views\Projects\EditorTemplates\FactorModel.cshtml", new FactorModel());
		}

		private void SetupSelectLists(AddProjectViewModel viewModel)
		{
			viewModel.UsersSelectList = _userService.UsersSelectList();
		}

		public virtual ActionResult Details(int id)
		{
			return View(_projectService.Get(id));
		}

		[HttpGet]
		public virtual ActionResult Edit(int id)
		{
			Project project = _projectService.Get(id);

			AddProjectViewModel viewModel = Mapper.Map<AddProjectViewModel>(project);
			ViewBag.Title = ViewTitles.EditProject;
			SetupSelectLists(viewModel);
			return View(MVC.Projects.Views.Add, viewModel);
		}

		[HttpPost]
		public virtual ActionResult Edit(int id, AddProjectViewModel viewModel)
		{
			Project project = _projectService.Get(id);

			if (ModelState.IsValid)
			{
				project.Name = viewModel.Name;

				var editedExperts = viewModel.Users;
				var originalExperts = project.Experts.Select(x => x.UserId);

				var newExperts = editedExperts.Except(originalExperts).ToArray();
				var removedExperts = originalExperts.Except(editedExperts).ToArray();

				if (project.FinalAssessment != null && (newExperts.Any() || removedExperts.Any()))
				{
					ModelState.AddModelError(string.Empty, ApplicationStrings.CannotEditExpertsOnGeneratedFinal);
				}
				else
				{
					foreach (var item in removedExperts)
					{
						var removedExpert = project.Experts.FirstOrDefault(x => x.UserId == item);
						var removedAssessment = project.Assessments.FirstOrDefault(x => x.ExpertId == item);
						project.Experts.Remove(removedExpert);
						project.Assessments.Remove(removedAssessment);
					}
					foreach (var item in newExperts)
					{
						project.Experts.Add(_userService.Get(item));
						_projectService.SetExpertAssessments(project);
					}
					_projectService.Update(project);
					TempData.AddFlash(ApplicationStrings.ProjectAdded);
					return RedirectToAction(MVC.Projects.Index());
				}
			}

			SetupSelectLists(viewModel);
			ViewBag.Title = ViewTitles.EditProject;
			return View(MVC.Projects.Views.Add, viewModel);
		}

		[HttpGet]
		public virtual ActionResult Delete(int id)
		{
			Project project = _projectService.Get(id);
			return View(MVC.Projects.Views.Delete, (object)project.ToString());
		}

		[HttpPost, ActionName("Delete")]
		public virtual ActionResult DeleteConfirmed(int id)
		{
			Project p = _projectService.Get(id);
			if (p.FinalAssessment != null)
			{
				p.FinalAssessment.Items.Clear();
				p.FinalAssessment = null;
			}
			if (p.WeightGenerationResults != null)
			{
				foreach (var item in p.WeightGenerationResults)
				{
					item.Items.Clear();
				}
				p.WeightGenerationResults.Clear();
			}
			_projectService.Delete(p);
			return RedirectToAction(MVC.Projects.Index());
		}

		public virtual ActionResult OrnessTest(float? a, int? n)
		{
			return null;
			/*
			List<double> result = new List<double>();
			if (a.HasValue && n.HasValue)
			{
				DMS.Domain.GenerateWeights.WeightGeneratorOrness orness = new Domain.GenerateWeights.WeightGeneratorOrness();
				orness.Alfa = a.Value;
				orness.WeightAmountN = n.Value;
				result = orness.GenerateWeights();
			}
			return View(result);
			 * */
		}

		public virtual ActionResult QuantifierTest(float? a, int? n)
		{
			return null;
			//List<double> result = new List<double>();
			//if (a.HasValue && n.HasValue)
			//{
			//    WeightGeneratorQuantifier quantifier = new WeightGeneratorQuantifier();
			//    result = quantifier.GenerateWeights(n.Value, a.Value);
			//}
			//return View(result);
		}

		[HttpGet]
		public virtual ActionResult GenerateWeights(int id, WeightGenerationMethod method)
		{
			Project project = _projectService.Get(id);
			WeightGenerationResult result = project.WeightGenerationResults.SingleOrDefault(x => x.GenerationMethod == method);
			var viewModel = new GenerateWeightsRequestModel();
			viewModel.Id = id;
			viewModel.Method = method;
			viewModel.ExistingResult = result;
			return PartialView(viewModel);
		}

		[HttpPost]
		public virtual ActionResult GenerateWeights(int id, WeightGenerationMethod method, GenerateWeightsRequestModel viewModel)
		{
			Project project = _projectService.Get(id);
			WeightGenerationResult result = project.WeightGenerationResults.SingleOrDefault(x => x.GenerationMethod == method);
			viewModel.ExistingResult = result;
			if (ModelState.IsValid)
			{
				WeightGenerationResult weightGenerationResult = result ?? new WeightGenerationResult() { GenerationMethod = viewModel.Method };
				var alfa = Convert.ToDecimal(viewModel.Alfa, CultureInfo.InvariantCulture);
				weightGenerationResult.Alfa = alfa;
				weightGenerationResult.Items = weightGenerationResult.Items ?? new List<WeightGenerationResultItem>();
				ClearExistingWeights(weightGenerationResult);
				switch (viewModel.Method)
				{
					case WeightGenerationMethod.Method1:
					case WeightGenerationMethod.Method2:
					case WeightGenerationMethod.Method3:
						var finalAssessmentMatrix = project.FinalAssessment.ToMatrix();
						List<List<decimal>> weights = GenerateWeightWithA.GenerateWeight(alfa, finalAssessmentMatrix, viewModel.Method);

						for (int i = 0; i < weights.Count; i++)
						{
							for (int j = 0; j < weights[i].Count; j++)
							{
								WeightGenerationResultItem item = new WeightGenerationResultItem();
								item.AlternativeId = project.Alternatives.ElementAt(i).AlternativeId;
								item.FactorId = project.Factors.ElementAt(j).FactorId;
								item.Weight = Convert.ToDecimal(weights[i][j]);

								weightGenerationResult.Items.Add(item);
							}
						}

						break;
					case WeightGenerationMethod.Orness:
						var orness = DMS.Domain.GenerateWeights.SearchSolutionOress.GenerateWeight(Convert.ToDouble(viewModel.Alfa, CultureInfo.InvariantCulture), project.Factors.Count);
						foreach (var alternative in project.Alternatives)
						{
							for (int i = 0; i < orness.Count; i++)
							{
								WeightGenerationResultItem item = new WeightGenerationResultItem();
								item.Weight = Convert.ToDecimal(orness[i]);
								item.Factor = project.Factors.ElementAt(i);
								item.Alternative = alternative;
								weightGenerationResult.Items.Add(item);
							}
						}
						break;
					case WeightGenerationMethod.Quantifier:
						var quantifier = DMS.Domain.GenerateWeights.WeightGeneratorQuantifier.GenerateWeights(Convert.ToDouble(viewModel.Alfa, CultureInfo.InvariantCulture), project.Factors.Count);
						foreach (var alternative in project.Alternatives)
						{
							for (int i = 0; i < quantifier.Count; i++)
							{
								WeightGenerationResultItem item = new WeightGenerationResultItem();
								item.Weight = Convert.ToDecimal(quantifier[i]);
								item.Factor = project.Factors.ElementAt(i);
								item.Alternative = alternative;
								weightGenerationResult.Items.Add(item);
							}
						}
						break;
				}

				project.WeightGenerationResults.Add(weightGenerationResult);

				_projectService.Update(project);

				viewModel.ExistingResult = weightGenerationResult;
			}

			return PartialView(viewModel);
		}

		private static void ClearExistingWeights(WeightGenerationResult weightGenerationResult)
		{
			DMSDbContext dbContext = DependencyResolver.Current.GetService<DMSDbContext>();
			weightGenerationResult.Items.ToList().ForEach(item =>
			{
				dbContext.Entry(item).State = System.Data.EntityState.Deleted;
			});
		}

		public virtual ActionResult DoAggregation(int id, AggregationType aggregationType, decimal? lambda = null)
		{
			var project = _projectService.Get(id);

			//check weights

			if ((new AggregationType[] { AggregationType.IOWG, AggregationType.IOWA, AggregationType.IGOWA }).Contains(aggregationType) &&
				project.WeightGenerationResults.Any(x => x.Items.First().Rating == null))
			{
				return RedirectToAction(MVC.Projects.FillRatings(id, aggregationType));
			}

			if (aggregationType == AggregationType.POWA &&
	project.WeightGenerationResults.Any(x => x.Items.First().Probability == null))
			{
				return RedirectToAction(MVC.Projects.FillProbabilities(id, aggregationType));
			}

			if ((new AggregationType[] { AggregationType.ASPOWA_MIN, AggregationType.ASPOWA_MAX, AggregationType.ASPOWA_MEAN }).Contains(aggregationType) &&
	project.WeightGenerationResults.Any(x => x.Items.First().Possibility == null))
			{
				return RedirectToAction(MVC.Projects.FillPossibilities(id, aggregationType));
			}

			if ((aggregationType == AggregationType.IGOWA ||
				aggregationType == AggregationType.GOWA ||
				aggregationType == AggregationType.POWA ||
				aggregationType == AggregationType.ASPOWA_MIN ||
				aggregationType == AggregationType.ASPOWA_MEAN ||
				aggregationType == AggregationType.ASPOWA_MAX) && !lambda.HasValue)
			{
				return RedirectToAction(MVC.Projects.InputLambda(id, aggregationType));
			}


			var aggregationResult = GetAggregationResult(project, aggregationType, lambda);

			foreach (var item in aggregationResult)
			{
				item.AggregationType = aggregationType;
				project.AggregationResults.Add(item);
			}

			_projectService.Update(project);

			return Redirect(Url.Action(MVC.Projects.Details(id)) + "#aggregation-tab");
		}

		private IEnumerable<AggregationResult> GetAggregationResult(Project project, AggregationType aggregationType, decimal? lambda = null)
		{
			var aggregationResult = new AggregationResult();
			aggregationResult.Items = new List<AggregationResultItem>();
			aggregationResult.Project = project;

			IAggregation aggregation = null;

			switch (aggregationType)
			{
				case AggregationType.MIN:
				case AggregationType.MAX:
				case AggregationType.AVERAGE:
					aggregation = AggregationFactory.CreateSimpleAggregation(aggregationType);
					foreach (var alternative in project.Alternatives.OrderBy(x => x.AlternativeId))
					{
						var row = project.FinalAssessment.Items.Where(x => x.AlternativeId == alternative.AlternativeId)
							.OrderBy(x => x.FactorId).ToList();
						var points = row.Select(x => x.Points).ToList();

						var calculatedAggregation = aggregation.Calc(points);
						aggregationResult.Items.Add(new AggregationResultItem()
						{
							Alternative = alternative,
							Aggregation = calculatedAggregation,
						});
					}
					break;
				case AggregationType.OWA:
				case AggregationType.OWG:
					foreach (var weight in project.WeightGenerationResults)
					{
						aggregationResult = new AggregationResult();
						aggregationResult.Items = new List<AggregationResultItem>();
						aggregationResult.Project = project;
						aggregationResult.Weight = weight;

						foreach (var alternative in project.Alternatives.OrderBy(x => x.AlternativeId))
						{
							var row = project.FinalAssessment.Items.Where(x => x.AlternativeId == alternative.AlternativeId)
								.OrderBy(x => x.FactorId).ToList();
							var points = row.Select(x => x.Points).ToList();

							List<decimal> weights = weight.GetWeights(alternative);

							aggregation = AggregationFactory.CreateWeightAggregation(aggregationType, weights.ToList());

							var calculatedAggregation = aggregation.Calc(points);
							aggregationResult.Items.Add(new AggregationResultItem()
							{
								Alternative = alternative,
								Aggregation = calculatedAggregation
							});
						}

						yield return aggregationResult;
					}
					break;

				case AggregationType.IOWA:
				case AggregationType.IOWG:
					foreach (var weight in project.WeightGenerationResults)
					{
						aggregationResult = new AggregationResult();
						aggregationResult.Items = new List<AggregationResultItem>();
						aggregationResult.Project = project;
						aggregationResult.Weight = weight;

						foreach (var alternative in project.Alternatives.OrderBy(x => x.AlternativeId))
						{
							var row = project.FinalAssessment.Items.Where(x => x.AlternativeId == alternative.AlternativeId)
								.OrderBy(x => x.FactorId).ToList();
							var points = row.Select(x => x.Points).ToList();

							List<decimal> weights = weight.GetWeights(alternative);
							List<decimal> ratings = weight.GetRatings(alternative);

							aggregation = AggregationFactory.CreateParamAggregation(aggregationType, weights.ToList(), ratings);

							var calculatedAggregation = aggregation.Calc(points);
							aggregationResult.Items.Add(new AggregationResultItem()
							{
								Alternative = alternative,
								Aggregation = calculatedAggregation
							});
						}

						yield return aggregationResult;
					}
					break;
				case AggregationType.IGOWA:
					foreach (var weight in project.WeightGenerationResults)
					{
						aggregationResult = new AggregationResult();
						aggregationResult.Items = new List<AggregationResultItem>();
						aggregationResult.Project = project;
						aggregationResult.Weight = weight;

						foreach (var alternative in project.Alternatives.OrderBy(x => x.AlternativeId))
						{
							var row = project.FinalAssessment.Items.Where(x => x.AlternativeId == alternative.AlternativeId)
								.OrderBy(x => x.FactorId).ToList();
							var points = row.Select(x => x.Points).ToList();

							List<decimal> weights = weight.GetWeights(alternative);
							List<decimal> ratings = weight.GetRatings(alternative);

							aggregation = AggregationFactory.CreateParamAggregation(aggregationType, weights.ToList(), ratings, lambda.Value);

							var calculatedAggregation = aggregation.Calc(points);
							aggregationResult.Items.Add(new AggregationResultItem()
							{
								Alternative = alternative,
								Aggregation = calculatedAggregation
							});
						}

						yield return aggregationResult;
					}
					break;
				case AggregationType.GOWA:
					foreach (var weight in project.WeightGenerationResults)
					{
						aggregationResult = new AggregationResult();
						aggregationResult.Items = new List<AggregationResultItem>();
						aggregationResult.Project = project;
						aggregationResult.Weight = weight;
						aggregationResult.Lambda = lambda;

						foreach (var alternative in project.Alternatives.OrderBy(x => x.AlternativeId))
						{
							var row = project.FinalAssessment.Items.Where(x => x.AlternativeId == alternative.AlternativeId)
								.OrderBy(x => x.FactorId).ToList();
							var points = row.Select(x => x.Points).ToList();

							List<decimal> weights = weight.GetWeights(alternative);

							aggregation = AggregationFactory.CreateParamAggregation(aggregationType, weights.ToList(), lambda.Value);

							var calculatedAggregation = aggregation.Calc(points);
							aggregationResult.Items.Add(new AggregationResultItem()
							{
								Alternative = alternative,
								Aggregation = calculatedAggregation
							});
						}

						yield return aggregationResult;
					}
					break;
				case AggregationType.POWA:
					foreach (var weight in project.WeightGenerationResults)
					{
						aggregationResult = new AggregationResult();
						aggregationResult.Items = new List<AggregationResultItem>();
						aggregationResult.Project = project;
						aggregationResult.Weight = weight;
						aggregationResult.Lambda = lambda;

						foreach (var alternative in project.Alternatives.OrderBy(x => x.AlternativeId))
						{
							var row = project.FinalAssessment.Items.Where(x => x.AlternativeId == alternative.AlternativeId)
								.OrderBy(x => x.FactorId).ToList();
							var points = row.Select(x => x.Points).ToList();

							List<decimal> weights = weight.GetWeights(alternative);

							List<decimal> probabilities = weight.GetProbabilities(alternative);

							aggregation = AggregationFactory.CreateParamAggregation(aggregationType, weights.ToList(), probabilities, lambda);

							var calculatedAggregation = aggregation.Calc(points);
							aggregationResult.Items.Add(new AggregationResultItem()
							{
								Alternative = alternative,
								Aggregation = calculatedAggregation
							});
						}

						yield return aggregationResult;
					}
					break;
				case AggregationType.ASPOWA_MIN:
				case AggregationType.ASPOWA_MAX:
				case AggregationType.ASPOWA_MEAN:
					foreach (var weight in project.WeightGenerationResults)
					{
						aggregationResult = new AggregationResult();
						aggregationResult.Items = new List<AggregationResultItem>();
						aggregationResult.Project = project;
						aggregationResult.Weight = weight;
						aggregationResult.Lambda = lambda;

						foreach (var alternative in project.Alternatives.OrderBy(x => x.AlternativeId))
						{
							var row = project.FinalAssessment.Items.Where(x => x.AlternativeId == alternative.AlternativeId)
								.OrderBy(x => x.FactorId).ToList();
							var points = row.Select(x => x.Points).ToList();

							List<decimal> weights = weight.GetWeights(alternative);

							List<decimal> possibilities = weight.GetPossibilities(alternative);

							aggregation = AggregationFactory.CreateParamAggregation(aggregationType, weights.ToList(), possibilities, lambda);

							var calculatedAggregation = aggregation.Calc(points);
							aggregationResult.Items.Add(new AggregationResultItem()
							{
								Alternative = alternative,
								Aggregation = calculatedAggregation
							});
						}

						yield return aggregationResult;
					}
					break;
			}

			yield return aggregationResult;
		}

		public virtual ActionResult AggregationDetails(int id, int aggregationId)
		{
			var project = _projectService.Get(id);

			var aggregation = project.AggregationResults.Single(x => x.AggregationResultId == aggregationId);

			return View(aggregation);
		}

		[HttpGet]
		public virtual ActionResult StartPsychometricQuestionnaire(int id)
		{
			var project = _projectService.Get(id);
			if (project.PsychometricQuestionnaire == null || !project.PsychometricQuestionnaire.Any())
			{
				var questionRepository = DependencyResolver.Current.GetService<IPsychometricQuestionRepository>();
				var questions = questionRepository.GetAll().ToList().Select((question, index) => new PsychometricQuestionWithAnswer()
				{
					Question = question,
					Index = index
				});

				project.PsychometricQuestionnaire = questions.ToArray();

				_projectService.Update(project);
			}

			return RedirectToAction(MVC.Projects.PsychometricQuestionnaireQuestion(id, 0));
		}

		[HttpGet]
		public virtual ActionResult PsychometricQuestionnaireQuestion(int id, int index)
		{
			var project = _projectService.Get(id);
			var question = project.PsychometricQuestionnaire.Single(q => q.Index == index);

			var viewModel = new PsychometricQuestionViewModel()
			{
				QuestionText = question.Question.Body,
				AllAnswers = question.Question.Answers.OrderBy(x => x.Index).ToList(),
				SelectedAnswers = question.SelectedAnswers.Select(a => a.PsychometricQuestionPossibleAnswerId).ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		public virtual ActionResult PsychometricQuestionnaireQuestion(int id, int index, IEnumerable<int> selectedAnswers)
		{
			var project = _projectService.Get(id);
			var question = project.PsychometricQuestionnaire.Single(q => q.Index == index);

			question.SelectedAnswers.Clear();
			if (selectedAnswers != null)
			{
				var selected = question.Question.Answers.Where(answer => selectedAnswers.Any(chosen => chosen == answer.PsychometricQuestionPossibleAnswerId)).ToArray();
				foreach (var item in selected)
				{
					question.SelectedAnswers.Add(item);
				}
				question.SetPoints();
			}

			var nextQuestionExists = project.PsychometricQuestionnaire.Any(q => q.Index > index);

			if (nextQuestionExists)
			{
				_projectService.Update(project);
				return RedirectToAction(MVC.Projects.PsychometricQuestionnaireQuestion(id, index + 1));
			}
			else
			{
				project.SetPsychometricQuestionnairePoints();
			}

			_projectService.Update(project);

			return Redirect(Url.Action(MVC.Projects.Details(id)) + "#weight-generation");
		}

		private static FillRatingsViewModel GetFillRatingsViewModel(Project project, FillRatingsViewModel existing = null)
		{
			existing = existing ?? new FillRatingsViewModel();
			var firstAlternative = project.Alternatives.First();
			existing.Ratings = project.WeightGenerationResults.Select(x => new FillRatingsItemModel()
			{
				WeightId = x.WeightGenerationResultId,
				Method = x.GenerationMethod,
				FactorNames = x.GetFirstAlternativeFactors().Select(factor => factor.Factor.FactorName).ToList(),
			}).ToList();
			return existing;
		}

		[HttpGet]
		public virtual ActionResult FillRatings(int id, AggregationType aggregationType)
		{
			var project = _projectService.Get(id);
			FillRatingsViewModel vm = GetFillRatingsViewModel(project);
			ViewBag.Title = ViewTitles.FillRatings;
			return View(vm);
		}

		[HttpPost]
		public virtual ActionResult FillRatings(int id, AggregationType aggregationType, FillRatingsViewModel viewModel)
		{
			Project project = _projectService.Get(id);

			if (ModelState.IsValid)
			{
				foreach (var rating in viewModel.Ratings)
				{
					var weight = project.WeightGenerationResults.Single(x => x.WeightGenerationResultId == rating.WeightId);
					var factors = weight.GetFirstAlternativeFactors().ToList();

					for (int i = 0; i < factors.Count; i++)
					{
						weight.Items.Where(x => x.FactorId == factors[i].FactorId).ToList().ForEach(x => x.Rating = rating.Values[i].GetValue());
					}
				}

				_projectService.Update(project);

				return RedirectToAction(MVC.Projects.DoAggregation(id, aggregationType));
			}

			viewModel = GetFillRatingsViewModel(project, viewModel);
			ViewBag.Title = ViewTitles.FillRatings;
			return View(viewModel);
		}

		[HttpGet]
		public virtual ActionResult FillPossibilities(int id, AggregationType aggregationType)
		{
			var project = _projectService.Get(id);
			FillRatingsViewModel vm = GetFillRatingsViewModel(project);
			ViewBag.Title = ViewTitles.FillPossibilities;
			return View(Views.FillRatings, vm);
		}

		[HttpPost]
		public virtual ActionResult FillPossibilities(int id, AggregationType aggregationType, FillRatingsViewModel viewModel)
		{
			Project project = _projectService.Get(id);

			if (ModelState.IsValid)
			{
				foreach (var rating in viewModel.Ratings)
				{
					var weight = project.WeightGenerationResults.Single(x => x.WeightGenerationResultId == rating.WeightId);
					var factors = weight.GetFirstAlternativeFactors().ToList();

					for (int i = 0; i < factors.Count; i++)
					{
						weight.Items.Where(x => x.FactorId == factors[i].FactorId).ToList().ForEach(x => x.Possibility = rating.Values[i].GetValue());
					}
				}

				_projectService.Update(project);

				return RedirectToAction(MVC.Projects.DoAggregation(id, aggregationType));
			}

			viewModel = GetFillRatingsViewModel(project, viewModel);
			ViewBag.Title = ViewTitles.FillPossibilities;
			return View(Views.FillRatings, viewModel);
		}

		[HttpGet]
		public virtual ActionResult FillProbabilities(int id, AggregationType aggregationType)
		{
			var project = _projectService.Get(id);
			FillRatingsViewModel vm = GetFillRatingsViewModel(project);
			ViewBag.Title = ViewTitles.FillProbabilities;
			return View(Views.FillRatings, vm);
		}

		[HttpPost]
		public virtual ActionResult FillProbabilities(int id, AggregationType aggregationType, FillRatingsViewModel viewModel)
		{
			Project project = _projectService.Get(id);

			if (ModelState.IsValid)
			{
				foreach (var rating in viewModel.Ratings)
				{
					var weight = project.WeightGenerationResults.Single(x => x.WeightGenerationResultId == rating.WeightId);
					var factors = weight.GetFirstAlternativeFactors().ToList();

					for (int i = 0; i < factors.Count; i++)
					{
						weight.Items.Where(x => x.FactorId == factors[i].FactorId).ToList().ForEach(x => x.Probability = rating.Values[i].GetValue());
					}
				}

				_projectService.Update(project);

				return RedirectToAction(MVC.Projects.DoAggregation(id, aggregationType));
			}

			viewModel = GetFillRatingsViewModel(project, viewModel);
			ViewBag.Title = ViewTitles.FillProbabilities;
			return View(Views.FillRatings, viewModel);
		}

		[HttpGet]
		public virtual ActionResult InputLambda(int id, AggregationType aggregationType)
		{
			return View(new InputLambdaViewModel());
		}

		[HttpPost]
		public virtual ActionResult InputLambda(int id, AggregationType aggregationType, InputLambdaViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				return RedirectToAction(MVC.Projects.DoAggregation(id, aggregationType, viewModel.GetValue()));
			}

			return View(viewModel);
		}
	}
}

