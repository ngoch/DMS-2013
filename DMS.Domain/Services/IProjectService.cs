using DMS.Domain;
using DMS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Service
{
    public interface IProjectService : IDomainService<Project>
    {
        void SetExpertAssessments(Project entity);
    }
}
