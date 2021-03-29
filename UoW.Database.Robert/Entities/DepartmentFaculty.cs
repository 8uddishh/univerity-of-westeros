namespace UoW.Database.Robert.Entities
{
    public class DepartmentFaculty
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int FacultyId { get; set; }

        public Department Department { get; set; }
        public Faculty Faculty { get; set; }
    }
}
