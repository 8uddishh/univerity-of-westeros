namespace UoW.Books.Snow
{
    using System;

    public class BookEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EbookUrl { get; set; }
        public string AboutBook { get; set; }
        public string Isbn { get; set; }
        public string Edition { get; set; }
        public int Year { get; set; }
        public int PublisherId { get; set; }
        public DateTime DateOfPublish { get; set; }
    }
}
