namespace UoW.Courses.Storm
{
    public class CourseSyllabusEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        public int CourseModuleTypeId { get; set; }
    }
}
