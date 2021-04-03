namespace UoW.Students.Martell.Application.Courses
{
    using System.Collections.Generic;
    using UoW.OData.Knight.Attributes;

    [ODataEntityMapper("Course")]
    public class CourseAggregateDto : CourseDto
    {
        public IList<StudentCourseDto> StudentCourses { get; set; }
    }
}
