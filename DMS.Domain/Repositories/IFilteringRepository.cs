using DMS.Domain;
using DMS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Repositories
{
    public interface IFilteringRepository<TEntity, TFilterDefinition> : IRepository<TEntity>
        where TFilterDefinition : FilterDefinitionBase
        where TEntity : class
    {
        IEnumerable<TEntity> Filter(TFilterDefinition filterDefinition, CurrentPageInformation pagingInfo, SortSpecification sortSpecification, out int fullCount);
    }
}
