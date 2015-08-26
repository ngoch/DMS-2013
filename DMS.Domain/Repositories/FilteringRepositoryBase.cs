using DMS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using DMS.Domain;
using DMS.Domain.Services;

namespace DMS.Domain.Repositories
{
    public abstract class FilteringRepositoryBase<T, TFilterDefinition> : RepositoryBase<T>, IFilteringRepository<T, TFilterDefinition>
        where T : class
        where TFilterDefinition : FilterDefinitionBase
    {

        public FilteringRepositoryBase(DMSDbContext dbContext)
            : base(dbContext)
        { }

        public virtual IQueryable<T> PrepareFilter(TFilterDefinition filterDefinition)
        {
            if (filterDefinition == null)
            {
                throw new ArgumentNullException("filterDefinition");
            }

            IQueryable<T> data = GetAll();

            if (filterDefinition.IsDefined())
            {
                foreach (var filterPredicate in BuildFilterPredicates(filterDefinition))
                {
                    data = data.Where(filterPredicate);
                }
            }

            if (!string.IsNullOrWhiteSpace(filterDefinition.SearchQuery))
            {
                data = data.Where(BuildSearchPredicate(filterDefinition.SearchQuery));
            }

            return data;
        }

        public virtual IEnumerable<T> Filter(TFilterDefinition filterDefinition, CurrentPageInformation pagingInfo, SortSpecification sortSpecification, out int count)
        {
            var data = PrepareFilter(filterDefinition);
            count = data.Count();

            return SortAndPage(data, sortSpecification, pagingInfo);
        }

        public virtual IQueryable<T> SortAndPage(IQueryable<T> data, SortSpecification sortSpecification, CurrentPageInformation pagingInfo)
        {
            string sort = null;
            if (sortSpecification != null && !string.IsNullOrWhiteSpace(sort = sortSpecification.ToString()))
            {
                return Page(data.OrderBy(sort), pagingInfo);
            }

            return Page(data.OrderByDescending(DefaultOrderSelector()), pagingInfo);
        }

        public abstract IEnumerable<Expression<Func<T, bool>>> BuildFilterPredicates(TFilterDefinition filterDefinition);
        public abstract Expression<Func<T, bool>> BuildSearchPredicate(string query);
        public abstract Expression<Func<T, int>> DefaultOrderSelector();
    }
}
