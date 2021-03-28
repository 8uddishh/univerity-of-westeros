namespace UoW.Students.Sand
{
    using System;

    public class StudentEntity
    {
        public int Id { get; set; }
        public string RollNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfJoin { get; set; }
        public int DepartmentId { get; set; }
        public int BatchId { get; set; }
        public int StudentStatusTypeId { get; set; }
        public int CurrentSemesterId { get; set; }
    }
}
