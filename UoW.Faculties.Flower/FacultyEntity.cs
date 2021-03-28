namespace UoW.Faculties.Flower
{
    using System;

    public class FacultyEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string AboutFaculty { get; set; }
        public int FacultyTypeId { get; set; }
        public int PrimaryDepartmentId { get; set; }
    }
}
