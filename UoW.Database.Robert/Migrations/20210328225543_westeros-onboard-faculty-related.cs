using Microsoft.EntityFrameworkCore.Migrations;

namespace UoW.Database.Robert.Migrations
{
    public partial class westerosonboardfacultyrelated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacultyContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intel = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    FacultyId = table.Column<int>(nullable: false),
                    FacultyContactTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacultyContacts_ContactTypes_FacultyContactTypeId",
                        column: x => x.FacultyContactTypeId,
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyContacts_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultyCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacultyCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyCourses_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Percentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultyAddressContactXrefs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    AddressLine3 = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    Country = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyAddressContactXrefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacultyAddressContactXrefs_FacultyContacts_Id",
                        column: x => x.Id,
                        principalTable: "FacultyContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacultyContacts_FacultyContactTypeId",
                table: "FacultyContacts",
                column: "FacultyContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyContacts_FacultyId_FacultyContactTypeId_Intel",
                table: "FacultyContacts",
                columns: new[] { "FacultyId", "FacultyContactTypeId", "Intel" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FacultyCourses_FacultyId",
                table: "FacultyCourses",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyCourses_CourseId_FacultyId",
                table: "FacultyCourses",
                columns: new[] { "CourseId", "FacultyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId_StudentId",
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacultyAddressContactXrefs");

            migrationBuilder.DropTable(
                name: "FacultyCourses");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "FacultyContacts");
        }
    }
}
