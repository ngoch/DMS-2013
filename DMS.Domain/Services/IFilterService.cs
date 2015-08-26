using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DMS.Infrastructure;

namespace DMS.Domain.Services
{
    public interface IFilterService<TSource, TFilterDefinition> where TFilterDefinition : FilterDefinitionBase
    {
        IEnumerable<TSource> Filter(TFilterDefinition filterDefinition, CurrentPageInformation pagingInfo, SortSpecification sortSpecification, out int fullCount);
    }
}
