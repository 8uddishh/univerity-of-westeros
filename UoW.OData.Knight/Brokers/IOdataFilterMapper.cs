namespace UoW.OData.Knight.Brokers
{
    using Microsoft.AspNet.OData.Query;
    using Microsoft.OData.UriParser;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IOdataFilterMapper<TDto, TEntity>
        where TDto : new()
        where TEntity : new()
    {
        Expression<Func<TEntity, bool>> MapAsSearchExpression(ODataQueryOptions<TDto> oDataQueryOptions);
        Expression<Func<TEntity, bool>> MapAsSearchExpression(FilterClause filterClause);

        Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> EqualityChecks { get; }
        Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> GreaterThanChecks { get; }
        Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> GreaterThanEqualChecks { get; }
        Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> LesserThanChecks { get; }
        Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> LesserThanEqualChecks { get; }
        Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> NotEqualChecks { get; }
        Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> StartsWithChecks { get; }
        Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> EndsWithChecks { get; }
        Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> ContainsChecks { get; }
    }
}
