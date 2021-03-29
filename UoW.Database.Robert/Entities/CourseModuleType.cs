namespace UoW.Database.Robert.Entities
{
    using System.Collections.Generic;

    public class CourseModuleType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<DepartmentCourseModule> DepartmentCourseModules { get; set; }
        public IList<CourseSyllabus> CourseSyllabi { get; set; }
    }
}
