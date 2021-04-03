namespace UoW.Students.Martell.Application.StudentCourses
{
    using UoW.OData.Knight.Attributes;

    [ODataEntityMapper("StudentCourse")]
    public class StudentCourseAggregateDto
    {
        public StudentDto Student { get; set; }
        public CourseDto Course { get; set; }
    }
}
