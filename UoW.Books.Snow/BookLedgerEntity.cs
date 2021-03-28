namespace UoW.Books.Snow
{
    using System;

    public class BookLedgerEntity
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? LendedOn { get; set; }
        public DateTime? DueOn { get; set; }
        public int BookId { get; set; }
        public int BookStatusTypeId { get; set; }
        public int? StudentId { get; set; }
        public int? FacultyId { get; set; }
    }
}
