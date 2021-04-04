namespace UoW.Students.Martell.Application.Courses.Queries
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;

    public class GetCourseQuery : IRequest<CourseAggregateDto>
    {
        public int CourseId { get; set; }
        public ODataQueryOptions<CourseAggregateDto> QueryOptions { get; set; }
    }
}
