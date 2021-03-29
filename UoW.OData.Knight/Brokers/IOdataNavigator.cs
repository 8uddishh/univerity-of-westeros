namespace UoW.OData.Knight.Brokers
{
    using Microsoft.AspNet.OData.Query;
    using System.Linq;

    public interface IOdataNavigator<TDto, TEntity>
        where TDto : new()
        where TEntity : new()
    {
        IQueryable<TEntity> ApplyNavigations(ODataQueryOptions<TDto> queryOptions, IQueryable<TEntity> queryable);
    }
}
