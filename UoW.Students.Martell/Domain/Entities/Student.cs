namespace UoW.Students.Martell.Domain.Entities
{
    using System.Collections.Generic;
    using UoW.Students.Sand;

    public class Student : StudentEntity
    {
        public StudentStatusType StudentStatusType { get; set; }
        public IList<StudentCourse> StudentCourses { get; set; }
    }
}
