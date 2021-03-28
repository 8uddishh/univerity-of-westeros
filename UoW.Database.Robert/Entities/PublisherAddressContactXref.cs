﻿namespace UoW.Database.Robert.Entities
{
    public class PublisherAddressContactXref
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public PublisherContact PublisherContact { get; set; }
    }
}
