namespace UoW.Database.Robert.Entities
{
    using System.Collections.Generic;

    public class CourseCategoryType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<Course> Courses { get; set; }
    }
}
