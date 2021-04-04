namespace UoW.Students.Martell.Web.Specifications
{
    using MediatR;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Query;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Linq;
    using System.Text.RegularExpressions;
    using UoW.Students.Martell.Application.Courses.Specifications;
    using UoW.Students.Martell.Application.StudentCourses.Specifications;
    using UoW.Students.Martell.Application.Students.Specifications;
    using UoW.Students.Martell.Application.StudentStatusTypes.Specifications;
    using ArithOps = Microsoft.AspNet.OData.Query.AllowedArithmeticOperators;
    using FunctionOps = Microsoft.AspNet.OData.Query.AllowedFunctions;
    using LogicalOps = Microsoft.AspNet.OData.Query.AllowedLogicalOperators;

    public class RestrictedEnableQueryAttribute : EnableQueryAttribute
    {
        public RestrictedEnableQueryAttribute() : base()
        {
            AllowedLogicalOperators = LogicalOps.And |
                LogicalOps.Equal |
                LogicalOps.GreaterThan |
                LogicalOps.GreaterThanOrEqual |
                LogicalOps.LessThan |
                LogicalOps.LessThanOrEqual |
                LogicalOps.NotEqual;

            AllowedArithmeticOperators = ArithOps.None;

            MaxExpansionDepth = 1;

            AllowedFunctions = FunctionOps.EndsWith | FunctionOps.StartsWith | FunctionOps.Contains;

            MaxTop = 100;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
        {
            var defaultAccessor = new HttpContextAccessor();
            var mediator = new Mediator(null);
            var isAggregateRoute = queryOptions.Request.Path.Value.Contains("aggregates");
            var path = isAggregateRoute ? $"aggregates/{queryOptions.Context.Path.NavigationSource.Name}" :
                queryOptions.Context.Path.NavigationSource.Name;
            ODataQueryOptions newoptions;
            switch (path)
            {
                case "aggregates/courses":
                    var courseContext = new CourseAggregateODataQueryContext(defaultAccessor, mediator);
                    newoptions = courseContext.SpawnOdataQueryOptions(queryOptions.Request);
                    break;
                case "aggregates/student-courses":
                    var studentCourseContext = new StudentCourseAggregateODataQueryContext(defaultAccessor, mediator);
                    newoptions = studentCourseContext.SpawnOdataQueryOptions(queryOptions.Request);
                    break;
                case "aggregates/students":
                    var studentContext = new StudentAggregateODataQueryContext(defaultAccessor, mediator);
                    newoptions = studentContext.SpawnOdataQueryOptions(queryOptions.Request);
                    break;
                case "aggregates/student-status-types":
                    var studentStatusTypeContext = new StudentStatusTypeAggregateODataQueryContext(defaultAccessor, mediator);
                    newoptions = studentStatusTypeContext.SpawnOdataQueryOptions(queryOptions.Request);
                    break;
                default:
                    newoptions = queryOptions;
                    break;
            }

            return base.ApplyQuery(queryable, newoptions);
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            var request = actionExecutedContext.HttpContext.Request;
            var querystring = request.QueryString;
            querystring = new QueryString(Regex.Replace(querystring.Value, "[&%24]*skip=\\s*(\\d+)", ""));
            querystring = new QueryString(Regex.Replace(querystring.Value, "[&%24]*top=\\s*(\\d+)", ""));
            actionExecutedContext.HttpContext.Request.QueryString = querystring;
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
