namespace UoW.Database.Robert.Entities
{
    public class CourseSyllabusActivity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CourseActivityTypeId { get; set; }
        public int CourseSyllabusId { get; set; }

        public CourseSyllabus CourseSyllabus { get; set; }
        public CourseActivityType CourseActivityType { get; set; }
    }
}
