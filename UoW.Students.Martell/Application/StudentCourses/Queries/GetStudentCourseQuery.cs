namespace UoW.Students.Martell.Application.StudentCourses.Queries
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;

    public class GetStudentCourseQuery : IRequest<StudentCourseAggregateDto>
    {
        public int StudentCourseId { get; set; }
        public ODataQueryOptions<StudentCourseAggregateDto> QueryOptions { get; set; }
    }
}
