namespace UoW.Students.Martell.Application.StudentCourses.Queries
{
    using MediatR;
    using Microsoft.AspNet.OData.Query;
    using System.Collections.Generic;

    public class SearchStudentCoursesQuery : IRequest<IEnumerable<StudentCourseAggregateDto>>
    {
        public ODataQueryOptions<StudentCourseAggregateDto> QueryOptions { get; set; }
    }
}
