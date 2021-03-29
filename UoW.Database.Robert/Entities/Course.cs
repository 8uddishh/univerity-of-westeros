namespace UoW.Database.Robert.Entities
{
    using System.Collections.Generic;

    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int CourseCategoryTypeId { get; set; }

        public CourseCategoryType CourseCategoryType { get; set; }
        public IList<CourseSyllabus> CourseSyllabi { get; set; }
        public IList<StudentCourse> StudentCourses { get; set; }
        public IList<FacultyCourse> FacultyCourses { get; set; }
        public IList<DepartmentCourse> DepartmentCourses { get; set; }
    }
}
