namespace UoW.Database.Robert.Entities
{
    using System.Collections.Generic;

    public class CourseActivityType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<CourseSyllabusActivity> CourseActivities { get;set; }
    }
}
