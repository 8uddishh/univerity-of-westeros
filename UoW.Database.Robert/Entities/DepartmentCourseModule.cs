namespace UoW.Database.Robert.Entities
{
    public class DepartmentCourseModule
    {
        public int Id { get; set; }
        public int DepartmentCourseId { get; set; }
        public int CourseModuleTypeId { get; set; }

        public DepartmentCourse DepartmentCourse { get; set; }
        public CourseModuleType CourseModuleType { get; set; }
    }
}
