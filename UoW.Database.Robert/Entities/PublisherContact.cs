namespace UoW.Database.Robert.Entities
{
    public class PublisherContact
    {
        public int Id { get; set; }
        public string Intel { get; set; }
        public int PublisherId { get; set; }
        public int PublisherContactTypeId { get; set; }


        public Publisher Publisher { get; set; }
        public ContactType PublisherContactType { get; set; }
        public PublisherAddressContactXref PublisherAddressContactXref { get; set; }
    }
}
