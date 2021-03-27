using Microsoft.EntityFrameworkCore.Migrations;

namespace UoW.Database.Robert.Migrations
{
    public partial class westerosseedglobal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ContactTypes
            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Address", "Address of the person/organization" }
            );

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Home Phone", "Home Phone of the person/organization" }
            );

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Cell Phone", "Cell Phone of the person/organization" }
            );

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Desk Phone", "Desk Phone of the person/organization" }
            );

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Official Email", "Official Email of the person/organization" }
            );

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Personal Email", "Personal Email of the person/organization" }
            );

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Facebook", "Facebook of the person/organization" }
            );

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Twitter", "Twitter of the person/organization" }
            );

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Blog", "Blog of the person/organization" }
            );

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "GitHub", "GitHub of the person/organization" }
            );

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "YouTube", "YouTube of the person/organization" }
            );

            // Semesters
            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Name", "Descriptiom" },
                values: new object[] { "I", "Semester 1" }
            );

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Name", "Descriptiom" },
                values: new object[] { "II", "Semester 2" }
            );

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Name", "Descriptiom" },
                values: new object[] { "III", "Semester 3" }
            );

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Name", "Descriptiom" },
                values: new object[] { "IV", "Semester 4" }
            );

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Name", "Descriptiom" },
                values: new object[] { "V", "Semester 5" }
            );

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Name", "Descriptiom" },
                values: new object[] { "VI", "Semester 6" }
            );

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Name", "Descriptiom" },
                values: new object[] { "VII", "Semester 7" }
            );

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Name", "Descriptiom" },
                values: new object[] { "VIII", "Semester 8" }
            );

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Name", "Descriptiom" },
                values: new object[] { "IX", "Semester 9" }
            );

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Name", "Descriptiom" },
                values: new object[] { "X", "Semester 10" }
            );

            // Batches
            migrationBuilder.InsertData(
                table: "Batches",
                columns: new[] { "EndYear", "Description" },
                values: new object[] { 2021, "Batch end year 2021" }
            );

            migrationBuilder.InsertData(
                table: "Batches",
                columns: new[] { "EndYear", "Description" },
                values: new object[] { 2022, "Batch end year 2022" }
            );

            migrationBuilder.InsertData(
                table: "Batches",
                columns: new[] { "EndYear", "Description" },
                values: new object[] { 2023, "Batch end year 2023" }
            );

            migrationBuilder.InsertData(
                table: "Batches",
                columns: new[] { "EndYear", "Description" },
                values: new object[] { 2024, "Batch end year 2024" }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ContactTypes", true);

            migrationBuilder.Sql("DELETE FROM Semesters", true);

            migrationBuilder.Sql("DELETE FROM Batches", true);
        }
    }
}
