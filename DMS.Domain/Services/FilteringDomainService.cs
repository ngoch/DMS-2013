using DMS.Domain;
using DMS.Domain.Repositories;
using DMS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Services
{
    public class FilteringDomainService<TEntity, TFilterDefinition> : DomainServiceBase<TEntity>, IFilterService<TEntity, TFilterDefinition>
        where TFilterDefinition : FilterDefinitionBase
        where TEntity : class
    {
        protected new readonly IFilteringRepository<TEntity, TFilterDefinition> Repository;

        public FilteringDomainService(IFilteringRepository<TEntity, TFilterDefinition> repository)
            : base(repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<TEntity> Filter(TFilterDefinition filterDefinition, Infrastructure.CurrentPageInformation pagingInfo, Infrastructure.SortSpecification sortSpecification, out int fullCount)
        {
            return Repository.Filter(filterDefinition, pagingInfo, sortSpecification, out fullCount);
        }
    }
}
