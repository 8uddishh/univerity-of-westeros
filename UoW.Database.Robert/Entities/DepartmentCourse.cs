namespace UoW.Database.Robert.Entities
{
    using System.Collections.Generic;

    public class DepartmentCourse
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public int SemesterId { get; set; }


        public Department Department { get; set; }
        public Course Course { get; set; }
        public Semester Semester { get; set; }

        public IList<DepartmentCourseModule> DepartmentCourseModules { get; set; }
    }
}
