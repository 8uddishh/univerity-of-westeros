namespace UoW.OData.Knight
{
    using Microsoft.AspNet.OData.Query;
    using Microsoft.OData.UriParser;
    using System.Linq;
    using UoW.OData.Knight.Brokers;

    public abstract class OdataNavigator<TDto, TEntity> : IOdataNavigator<TDto, TEntity>
        where TDto : new()
        where TEntity : new()
    {
        public abstract IQueryable<TEntity> SafeApplyNavigationSource(ExpandedNavigationSelectItem selectedItem, IQueryable<TEntity> queryable);
        public IQueryable<TEntity> ApplyNavigations(ODataQueryOptions<TDto> queryOptions, IQueryable<TEntity> queryable)
        {
            if (queryOptions.SelectExpand?.SelectExpandClause?.SelectedItems?.Any() ?? false)
            {
                var selectExpandClause = queryOptions.SelectExpand.SelectExpandClause;
                var selectedItems = selectExpandClause.SelectedItems.Where(x => x is ExpandedNavigationSelectItem)
                    .Select(x => x as ExpandedNavigationSelectItem)
                    .Where(x => x.FilterOption != null);

                foreach (var selectedItem in selectedItems)
                {
                    queryable = SafeApplyNavigationSource(selectedItem, queryable);
                }
            }

            return queryable;
        }
    }
}
