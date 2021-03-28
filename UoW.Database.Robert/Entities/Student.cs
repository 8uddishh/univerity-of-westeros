namespace UoW.Database.Robert.Entities
{
    using System;
    using System.Collections.Generic;

    public class Student
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


        public Department Department { get; set; }
        public Batch Batch { get; set; }
        public StudentStatusType StudentStatusType { get; set; }
        public Semester Semester { get; set; }

        public IList<BookLedger> BookLedgers { get; set; }
    }
}
