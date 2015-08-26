using DMS.Domain;
using DMS.Domain.Repositories;
using DMS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Service
{
    public class ProjectService : DomainServiceBase<Project>, IProjectService
    {
        public ProjectService(IProjectRepository projectRepository)
            : base(projectRepository)
        {

        }

        public override void Add(Project entity)
        {
            SetExpertAssessments(entity);

            base.Add(entity);
        }

        public void SetExpertAssessments(Project entity)
        {
            entity.Assessments = entity.Assessments ?? new List<ExpertAssessment>();
            foreach (var expert in entity.Experts.Where(expert => !entity.Assessments.Any(assessment => assessment.ExpertId == expert.UserId)))
            {
                var assessment = new ExpertAssessment()
                {
                    Project = entity,
                    Method = null,
                    Expert = expert,
                    Items = new List<ExpertAssessmentItem>()
                };

                foreach (var Factor in entity.Factors)
                {
                    foreach (var Alternative in entity.Alternatives)
                    {
                        assessment.Items.Add(new ExpertAssessmentItem()
                        {
                            Assessment = assessment,
                            Alternative = Alternative,
                            Factor = Factor,
                            Expert = expert,
                            Project = entity
                        });
                    }
                }

                entity.Assessments.Add(assessment);
            }

            entity.AssesmentQuestionGenerationItems = new List<AssessmentQuestionGenerationItem>();

            for (int i = 0; i < entity.AssessmentQuestionCount; i++)
            {
                entity.AssesmentQuestionGenerationItems.Add(new AssessmentQuestionGenerationItem()
                {
                    Project = entity,
                    Alfa = Math.Round((1.0 / entity.AssessmentQuestionCount * (i + 1.0)), 2)
                });
            }
        }
    }
}
