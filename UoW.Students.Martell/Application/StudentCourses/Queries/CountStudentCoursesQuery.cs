namespace UoW.Students.Martell.Application.StudentCourses.Queries
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;

    public class CountStudentCoursesQuery : IRequest<long>
    {
        public ODataQueryOptions<StudentCourseAggregateDto> QueryOptions { get; set; }
    }
}
