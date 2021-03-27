using Microsoft.EntityFrameworkCore.Migrations;

namespace UoW.Database.Robert.Migrations
{
    public partial class westerosseedfacultytype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FacultyTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Dean", "Dean of College" }
            );

            migrationBuilder.InsertData(
                table: "FacultyTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "HOD", "Head of Department" }
            );

            migrationBuilder.InsertData(
                table: "FacultyTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Professor", "Professor" }
            );

            migrationBuilder.InsertData(
                table: "FacultyTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Lecturer", "Lecturer" }
            );

            migrationBuilder.InsertData(
                table: "FacultyTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Laboratory Assistant", "Laboratory Assistant" }
            );

            migrationBuilder.InsertData(
                table: "FacultyTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "Faculty Assistant", "Laboratory Assistant" }
            );

            migrationBuilder.InsertData(
                table: "FacultyTypes",
                columns: new[] { "Name", "Description" },
                values: new object[] { "PeT", "Physical Education Trainer" }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM FacultyTypes", true);
        }
    }
}
