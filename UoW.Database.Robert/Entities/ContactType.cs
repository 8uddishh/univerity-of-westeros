namespace UoW.Database.Robert.Entities
{
    using System.Collections.Generic;

    public class ContactType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<PublisherContact> PublisherContacts { get; set; }
        public IList<FacultyContact> FacultyContacts { get; set; }
    }
}
