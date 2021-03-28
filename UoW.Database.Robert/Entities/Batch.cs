namespace UoW.Database.Robert.Entities
{
    using System.Collections.Generic;

    public class Batch
    {
        public int Id { get; set; }
        public int EndYear { get; set; }
        public string Description { get; set; }

        public IList<Student> Students { get; set; }
    }
}
