namespace UoW.Students.Martell.Application.Courses.Queries
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;

    public class CountCoursesQuery : IRequest<long>
    {
        public ODataQueryOptions<CourseAggregateDto> QueryOptions { get; set; }
    }
}
