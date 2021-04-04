namespace UoW.Students.Martell.Application.Courses.Queries
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;
    using System.Collections.Generic;

    public class SearchCoursesQuery : IRequest<IEnumerable<CourseAggregateDto>>
    {
        public ODataQueryOptions<CourseAggregateDto> QueryOptions { get; set; }
    }
}
