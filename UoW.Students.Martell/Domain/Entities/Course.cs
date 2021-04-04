namespace UoW.Students.Martell.Domain.Entities
{
    using System.Collections.Generic;
    using UoW.Courses.Storm;

    public class Course : CourseEntity
    {
        public IList<StudentCourse> StudentCourses { get; set; }
    }
}
