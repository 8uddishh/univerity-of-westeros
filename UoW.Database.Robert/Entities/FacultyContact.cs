namespace UoW.Database.Robert.Entities
{
    public class FacultyContact
    {
        public int Id { get; set; }
        public string Intel { get; set; }
        public int FacultyId { get; set; }
        public int FacultyContactTypeId { get; set; }

        public Faculty Faculty { get; set; }
        public ContactType FacultyContactType { get; set; }
        public FacultyAddressContactXref FacultyAddressContactXref { get; set; }
    }
}
