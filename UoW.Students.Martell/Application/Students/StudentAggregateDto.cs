namespace UoW.Students.Martell.Application.Students
{
    using System.Collections.Generic;
    using UoW.OData.Knight.Attributes;

    [ODataEntityMapper("Student")]
    public class StudentAggregateDto
    {
        public StudentStatusTypeDto StudentStatusType { get; set; }
        public IList<StudentCourseDto> StudentCourses { get; set; }
    }
}
