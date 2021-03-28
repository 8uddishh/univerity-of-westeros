namespace UoW.Database.Robert.Entities
{
    using System;
    using System.Collections.Generic;

    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string AboutAuthor { get; set; }

        public IList<BookAuthor> BookAuthors { get; set; }
    }
}
