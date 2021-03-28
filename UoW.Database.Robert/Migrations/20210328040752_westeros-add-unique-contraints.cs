using Microsoft.EntityFrameworkCore.Migrations;

namespace UoW.Database.Robert.Migrations
{
    public partial class westerosadduniquecontraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentStatusTypes_Name",
                table: "StudentStatusTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_Name",
                table: "Semesters",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FacultyTypes_Name",
                table: "FacultyTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseModuleTypes_Name",
                table: "CourseModuleTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategoryTypes_Name",
                table: "CourseCategoryTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseActivityTypes_Name",
                table: "CourseActivityTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypes_Name",
                table: "ContactTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookStatusTypes_Name",
                table: "BookStatusTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Batches_EndYear",
                table: "Batches",
                column: "EndYear",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentStatusTypes_Name",
                table: "StudentStatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_Semesters_Name",
                table: "Semesters");

            migrationBuilder.DropIndex(
                name: "IX_FacultyTypes_Name",
                table: "FacultyTypes");

            migrationBuilder.DropIndex(
                name: "IX_CourseModuleTypes_Name",
                table: "CourseModuleTypes");

            migrationBuilder.DropIndex(
                name: "IX_CourseCategoryTypes_Name",
                table: "CourseCategoryTypes");

            migrationBuilder.DropIndex(
                name: "IX_CourseActivityTypes_Name",
                table: "CourseActivityTypes");

            migrationBuilder.DropIndex(
                name: "IX_ContactTypes_Name",
                table: "ContactTypes");

            migrationBuilder.DropIndex(
                name: "IX_BookStatusTypes_Name",
                table: "BookStatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_Batches_EndYear",
                table: "Batches");
        }
    }
}
