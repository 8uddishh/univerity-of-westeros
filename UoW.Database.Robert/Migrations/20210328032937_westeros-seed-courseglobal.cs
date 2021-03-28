using Microsoft.EntityFrameworkCore.Migrations;

namespace UoW.Database.Robert.Migrations
{
    public partial class westerosseedcourseglobal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // CourseCategoryTypes
            migrationBuilder.InsertData(
                table: "CourseCategoryTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "HS", "Humanities and social sciences" }
            );

            migrationBuilder.InsertData(
                table: "CourseCategoryTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "BS", "Basic sciences" }
            );

            migrationBuilder.InsertData(
                table: "CourseCategoryTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "ES", "Engineering sciences" }
            );

            migrationBuilder.InsertData(
                table: "CourseCategoryTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "HC", "Hardcore" }
            );

            migrationBuilder.InsertData(
                table: "CourseCategoryTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "MSC", "Mathematics softcores" }
            );

            migrationBuilder.InsertData(
                table: "CourseCategoryTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "PSC", "Professional softcores" }
            );

            migrationBuilder.InsertData(
                table: "CourseCategoryTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "PE1", "Professional electives track 1" }
            );

            migrationBuilder.InsertData(
                table: "CourseCategoryTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "PE2", "Professional electives track 2" }
            );

            migrationBuilder.InsertData(
                table: "CourseCategoryTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "PE3", "Professional electives track 3" }
            );

            migrationBuilder.InsertData(
                table: "CourseCategoryTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "PE4", "Professional electives track 4" }
            );

            migrationBuilder.InsertData(
                table: "CourseCategoryTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "PE5", "Professional electives track 5" }
            );

            migrationBuilder.InsertData(
                table: "CourseCategoryTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "PE6", "Professional electives track 6" }
            );

            migrationBuilder.InsertData(
                table: "CourseCategoryTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "PE7", "Professional electives track 7" }
            );

            migrationBuilder.InsertData(
                table: "CourseCategoryTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "EEC", "Employablity enhancement courses" }
            );

            // CourseActivityTypes
            migrationBuilder.InsertData(
                table: "CourseActivityTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Lecture", "Lecture" }
            );

            migrationBuilder.InsertData(
                table: "CourseActivityTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Tutorial", "Tutorial" }
            );

            migrationBuilder.InsertData(
                table: "CourseActivityTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Assignment", "Assignment" }
            );

            migrationBuilder.InsertData(
                table: "CourseActivityTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Quiz", "Quiz" }
            );

            migrationBuilder.InsertData(
                table: "CourseActivityTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Project", "Project" }
            );

            migrationBuilder.InsertData(
                table: "CourseActivityTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Practical", "Practical" }
            );

            migrationBuilder.InsertData(
                table: "CourseActivityTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Group Discussion", "Group Discussion" }
            );

            migrationBuilder.InsertData(
                table: "CourseActivityTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Seminar", "Seminar" }
            );

            // CourseModuleTypes
            migrationBuilder.InsertData(
                table: "CourseModuleTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Module I", "Module 1" }
            );

            migrationBuilder.InsertData(
                table: "CourseModuleTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Module II", "Module 2" }
            );

            migrationBuilder.InsertData(
                table: "CourseModuleTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Module III", "Module 3" }
            );

            migrationBuilder.InsertData(
                table: "CourseModuleTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Module IV", "Module 4" }
            );

            migrationBuilder.InsertData(
                table: "CourseModuleTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Module V", "Module 5" }
            );

            migrationBuilder.InsertData(
                table: "CourseModuleTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Module VI", "Module 6" }
            );

            migrationBuilder.InsertData(
                table: "CourseModuleTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Module VII", "Module 7" }
            );

            migrationBuilder.InsertData(
                table: "CourseModuleTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Module VIII", "Module 8" }
            );

            migrationBuilder.InsertData(
                table: "CourseModuleTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Module IX", "Module 9" }
            );

            migrationBuilder.InsertData(
                table: "CourseModuleTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Module X", "Module 10" }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM CourseCategoryTypes", true);
            migrationBuilder.Sql("DELETE FROM CourseActivityTypes", true);
            migrationBuilder.Sql("DELETE FROM CourseModuleTypes", true);
        }
    }
}
