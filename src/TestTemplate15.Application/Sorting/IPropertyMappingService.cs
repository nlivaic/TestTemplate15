using System.Collections.Generic;
using TestTemplate15.Application.Sorting.Models;

namespace TestTemplate15.Application.Sorting
{
    public interface IPropertyMappingService
    {
        IEnumerable<SortCriteria> Resolve(BaseSortable sortableSource, BaseSortable sortableTarget);
    }
}
