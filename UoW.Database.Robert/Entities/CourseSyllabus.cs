namespace UoW.Database.Robert.Entities
{
    using System.Collections.Generic;

    public class CourseSyllabus
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        public int CourseModuleTypeId { get; set; }

        public Course Course { get; set; }
        public CourseModuleType CourseModuleType { get; set; }

        public IList<CourseSyllabusActivity> CourseActivities { get; set; }
    }
}
