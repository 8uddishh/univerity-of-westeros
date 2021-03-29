namespace UoW.OData.Knight
{
    using Microsoft.AspNet.OData.Query;
    using Microsoft.OData.UriParser;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using UoW.OData.Knight.Brokers;
    using UoW.OData.Knight.Common;

    public abstract class OdataFilterMapper<TDto, TEntity> : IOdataFilterMapper<TDto, TEntity>
        where TDto : new()
        where TEntity : new()
    {
        public abstract Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> EqualityChecks { get; }
        public abstract Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> GreaterThanChecks { get; }
        public abstract Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> GreaterThanEqualChecks { get; }
        public abstract Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> LesserThanChecks { get; }
        public abstract Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> LesserThanEqualChecks { get; }
        public abstract Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> NotEqualChecks { get; }
        public abstract Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> StartsWithChecks { get; }
        public abstract Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> EndsWithChecks { get; }
        public abstract Dictionary<string, Func<string, Expression<Func<TEntity, bool>>>> ContainsChecks { get; }

        public Expression<Func<TEntity, bool>> MapAsSearchExpression(FilterClause filterClause)
        {
            if (filterClause == null)
                return null;

            var visitor = new OdataFilterVisitor<object>();
            filterClause.Expression.Accept(visitor);
            var expressions = new List<Expression<Func<TEntity, bool>>>();

            foreach (var option in visitor.FilterOptions.Where(x => !string.IsNullOrEmpty(x.Value)))
            {
                if (!string.IsNullOrEmpty(option.Value))
                {
                    var sanitizedValue = option.Value.Replace("\'", "");
                    if (option.Operator == "Equal")
                    {
                        var whereClause = EqualityChecks[option.FieldName](sanitizedValue);
                        if (whereClause != null)
                        {
                            expressions.Add(whereClause);
                            continue;
                        }
                    }

                    if (option.Operator == "GreaterThan")
                    {
                        var whereClause = GreaterThanChecks[option.FieldName](sanitizedValue);
                        if (whereClause != null)
                        {
                            expressions.Add(whereClause);
                            continue;
                        }
                    }

                    if (option.Operator == "GreaterThanOrEqual")
                    {
                        var whereClause = GreaterThanEqualChecks[option.FieldName](sanitizedValue);
                        if (whereClause != null)
                        {
                            expressions.Add(whereClause);
                            continue;
                        }
                    }

                    if (option.Operator == "LessThan")
                    {
                        var whereClause = LesserThanChecks[option.FieldName](sanitizedValue);
                        if (whereClause != null)
                        {
                            expressions.Add(whereClause);
                            continue;
                        }
                    }

                    if (option.Operator == "LessThanOrEqual")
                    {
                        var whereClause = LesserThanEqualChecks[option.FieldName](sanitizedValue);
                        if (whereClause != null)
                        {
                            expressions.Add(whereClause);
                            continue;
                        }
                    }

                    if (option.Operator == "NotEqual")
                    {
                        var whereClause = NotEqualChecks[option.FieldName](sanitizedValue);
                        if (whereClause != null)
                        {
                            expressions.Add(whereClause);
                            continue;
                        }
                    }

                    if (option.Operator == "StartsWith")
                    {
                        var whereClause = StartsWithChecks[option.FieldName](sanitizedValue);
                        if (whereClause != null)
                        {
                            expressions.Add(whereClause);
                            continue;
                        }
                    }

                    if (option.Operator == "EndsWith")
                    {
                        var whereClause = EndsWithChecks[option.FieldName](sanitizedValue);
                        if (whereClause != null)
                        {
                            expressions.Add(whereClause);
                            continue;
                        }
                    }

                    if (option.Operator == "Contains")
                    {
                        var whereClause = ContainsChecks[option.FieldName](sanitizedValue);
                        if (whereClause != null)
                        {
                            expressions.Add(whereClause);
                            continue;
                        }
                    }
                }
            }
            return expressions.Any() ? expressions.AsCombinedExpression() : null;
        }

        public Expression<Func<TEntity, bool>> MapAsSearchExpression(ODataQueryOptions<TDto> oDataQueryOptions)
        {
            if (oDataQueryOptions.Filter?.FilterClause == null)
                return null;

            return MapAsSearchExpression(oDataQueryOptions.Filter.FilterClause);
        }
    }
}
