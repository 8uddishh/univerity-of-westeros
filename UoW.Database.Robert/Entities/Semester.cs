namespace UoW.Database.Robert.Entities
{
    using System.Collections.Generic;

    public class Semester
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<Student> Students { get; set; }
    }
}
