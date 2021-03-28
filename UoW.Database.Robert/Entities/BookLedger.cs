namespace UoW.Database.Robert.Entities
{
    using System;

    public class BookLedger
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? LendedOn { get; set; }
        public DateTime? DueOn { get; set; }
        public int BookId { get; set; }
        public int BookStatusTypeId { get; set; }
        public int? StudentId { get; set; }
        public int? FacultyId { get; set; }


        public Book Book { get; set; }
        public BookStatusType BookStatusType { get; set; }
        public Student Student { get; set; }
        public Faculty Faculty { get; set; }
    }
}
