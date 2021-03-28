namespace UoW.Database.Robert.Entities 
{
    public class FacultyCourse
    {
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public int CourseId { get; set; }

        public Faculty Faculty { get; set; }
        public Course Course { get; set; }
    }
}
