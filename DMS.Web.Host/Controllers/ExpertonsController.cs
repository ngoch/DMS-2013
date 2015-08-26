using DMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS.Web.Host.Controllers
{
    public partial class ExpertonsController : Controller
    {
        public virtual ActionResult Index()
        {
            ProjectService service = DependencyResolver.Current.GetService<ProjectService>();
            var p = service.GetAll().ToList();
            foreach (var item in p.Where(x => x.FinalAssessment == null))
            {
                item.CalcAndSetFinalAssessment();
                service.Update(item);
            }

            List<string> decisions = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                decisions.Add("გადაწყვეტილება " + i.ToString());
            }

            List<string> experts = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                experts.Add("ექსპერტი " + i.ToString());
            }

            decimal[][] expertPoints = new decimal[10][];

            Random rand = new Random();

            for (int i = 0; i < expertPoints.Length; i++)
            {
                expertPoints[i] = new decimal[decisions.Count];

                for (int j = 0; j < expertPoints[i].Length; j++)
                {
                    decimal value = 0 + (decimal)rand.Next(0, 10) / 10;
                    expertPoints[i][j] = value;
                }
            }

            ViewBag.ExpertPoints = expertPoints;

            List<decimal> levels = GetLevels(expertPoints.Length);

            Dictionary<decimal, decimal[]> levelPoints = new Dictionary<decimal, decimal[]>();

            for (int i = 0; i < levels.Count; i++)
            {
                var level = levels[i];
                levelPoints.Add(level, new decimal[decisions.Count]);

                for (int j = 0; j < decisions.Count; j++)
                {
                    List<decimal> expertPointsForDecision = new List<decimal>();

                    for (int k = 0; k < expertPoints.Length; k++)
                    {
                        expertPointsForDecision.Add(expertPoints[k][j]);
                    }

                    var aggregatedDecisionForLevel = expertPointsForDecision.Where(x => x >= level).Count();
                    levelPoints[level][j] = aggregatedDecisionForLevel;
                }
            }

            ViewBag.LevelPoints = levelPoints;

            List<decimal> finalResults = new List<decimal>();
            for (int i = 0; i < expertPoints[0].Length; i++)
            {
                finalResults.Add(levelPoints.Select(x => x.Value[i] / expertPoints.Length).Average());
            }
            ViewBag.FinalResults = finalResults;

            return View();
        }

        private List<decimal> GetLevels(int p)
        {
            List<decimal> levels = new List<decimal>();

            for (decimal i = 0; i < 1; i += 0.1m)
            {
                levels.Add(i);
            }

            return levels;
        }

    }
}
