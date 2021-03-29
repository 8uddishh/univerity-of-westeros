namespace UoW.Database.Robert.Entities
{
    using System.Collections.Generic;

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }
        public string AboutDepartment { get; set; }

        public IList<Faculty> PrimaryFaculties { get; set; }
        public IList<Student> Students { get; set; }
        public IList<DepartmentFaculty> DepartmentFaculties { get; set; }
        public IList<DepartmentCourse> DepartmentCourses { get; set; }
    }
}
