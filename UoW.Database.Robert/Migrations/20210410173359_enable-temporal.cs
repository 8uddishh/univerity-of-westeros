using Microsoft.EntityFrameworkCore.Migrations;
using UoW.Database.Robert.Utils;

namespace UoW.Database.Robert.Migrations
{
    public partial class enabletemporal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddTemporalTableSupport("Authors");
            migrationBuilder.AddTemporalTableSupport("Batches");
            migrationBuilder.AddTemporalTableSupport("BookAuthors");
            migrationBuilder.AddTemporalTableSupport("BookLedgers");
            migrationBuilder.AddTemporalTableSupport("Books");
            migrationBuilder.AddTemporalTableSupport("BookStatusTypes");
            migrationBuilder.AddTemporalTableSupport("ContactTypes");
            migrationBuilder.AddTemporalTableSupport("CourseActivityTypes");
            migrationBuilder.AddTemporalTableSupport("CourseCategoryTypes");
            migrationBuilder.AddTemporalTableSupport("CourseModuleTypes");
            migrationBuilder.AddTemporalTableSupport("Courses");
            migrationBuilder.AddTemporalTableSupport("CourseSyllabusActivities");
            migrationBuilder.AddTemporalTableSupport("CourseSyllabi");
            migrationBuilder.AddTemporalTableSupport("DepartmentCourseModules");
            migrationBuilder.AddTemporalTableSupport("DepartmentCourses");
            migrationBuilder.AddTemporalTableSupport("DepartmentFaculties");
            migrationBuilder.AddTemporalTableSupport("Departments");
            migrationBuilder.AddTemporalTableSupport("FacultyAddressContactXrefs");
            migrationBuilder.AddTemporalTableSupport("FacultyContacts");
            migrationBuilder.AddTemporalTableSupport("FacultyCourses");
            migrationBuilder.AddTemporalTableSupport("Faculties");
            migrationBuilder.AddTemporalTableSupport("FacultyTypes");
            migrationBuilder.AddTemporalTableSupport("PublisherAddressContactXrefs");
            migrationBuilder.AddTemporalTableSupport("PublisherContacts");
            migrationBuilder.AddTemporalTableSupport("Publishers");
            migrationBuilder.AddTemporalTableSupport("Semesters");
            migrationBuilder.AddTemporalTableSupport("StudentCourses");
            migrationBuilder.AddTemporalTableSupport("Students");
            migrationBuilder.AddTemporalTableSupport("StudentStatusTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTemporalTableSupport("Authors");
            migrationBuilder.DropTemporalTableSupport("Batches");
            migrationBuilder.DropTemporalTableSupport("BookAuthors");
            migrationBuilder.DropTemporalTableSupport("BookLedger");
            migrationBuilder.DropTemporalTableSupport("Books");
            migrationBuilder.DropTemporalTableSupport("BookStatusTypes");
            migrationBuilder.DropTemporalTableSupport("ContactTypes");
            migrationBuilder.DropTemporalTableSupport("CourseActivityTypes");
            migrationBuilder.DropTemporalTableSupport("CourseCategoryTypes");
            migrationBuilder.DropTemporalTableSupport("CourseModuleTypes");
            migrationBuilder.DropTemporalTableSupport("Courses");
            migrationBuilder.DropTemporalTableSupport("CourseSyllabusActivities");
            migrationBuilder.DropTemporalTableSupport("CourseSyllabi");
            migrationBuilder.DropTemporalTableSupport("DepartmentCourseModules");
            migrationBuilder.DropTemporalTableSupport("DepartmentCourses");
            migrationBuilder.DropTemporalTableSupport("DepartmentFaculties");
            migrationBuilder.DropTemporalTableSupport("Departments");
            migrationBuilder.DropTemporalTableSupport("FacultyAddressContactXrefs");
            migrationBuilder.DropTemporalTableSupport("FacultyContacts");
            migrationBuilder.DropTemporalTableSupport("FacultyCourses");
            migrationBuilder.DropTemporalTableSupport("Faculties");
            migrationBuilder.DropTemporalTableSupport("FacultyTypes");
            migrationBuilder.DropTemporalTableSupport("PublisherAddressContactXrefs");
            migrationBuilder.DropTemporalTableSupport("PublisherContacts");
            migrationBuilder.DropTemporalTableSupport("Publishers");
            migrationBuilder.DropTemporalTableSupport("Semesters");
            migrationBuilder.DropTemporalTableSupport("StudentCourses");
            migrationBuilder.DropTemporalTableSupport("Students");
            migrationBuilder.DropTemporalTableSupport("StudentStatusTypes");
        }
    }
}
