namespace UoW.Students.Martell.Domain.Entities
{
    using UoW.Students.Sand;

    public class StudentCourse : StudentCourseEntity
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
