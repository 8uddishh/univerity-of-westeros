namespace UoW.Database.Robert.Entities
{
    public class StudentCourse
    {
        public int Id { get; set; }
        public decimal Percentage { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
