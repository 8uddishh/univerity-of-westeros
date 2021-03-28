namespace UoW.Courses.Storm
{
    public class CourseSyllabusActivityEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CourseActivityTypeId { get; set; }
        public int CourseSyllabusId { get; set; }
    }
}
