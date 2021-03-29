using Microsoft.EntityFrameworkCore.Migrations;

namespace UoW.Database.Robert.Migrations
{
    public partial class westerosonboarddepartmentrelated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CourseSyllabi_Title_CourseId",
                table: "CourseSyllabi");

            migrationBuilder.AddColumn<int>(
                name: "CourseModuleTypeId",
                table: "CourseSyllabi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DepartmentCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    SemesterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentCourses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentCourses_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentFaculties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(nullable: false),
                    FacultyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentFaculties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentFaculties_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentFaculties_Faculties_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentCourseModules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentCourseId = table.Column<int>(nullable: false),
                    CourseModuleTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentCourseModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentCourseModules_CourseModuleTypes_CourseModuleTypeId",
                        column: x => x.CourseModuleTypeId,
                        principalTable: "CourseModuleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentCourseModules_DepartmentCourses_DepartmentCourseId",
                        column: x => x.DepartmentCourseId,
                        principalTable: "DepartmentCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSyllabi_CourseModuleTypeId",
                table: "CourseSyllabi",
                column: "CourseModuleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSyllabi_Title_CourseId_CourseModuleTypeId",
                table: "CourseSyllabi",
                columns: new[] { "Title", "CourseId", "CourseModuleTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCourseModules_CourseModuleTypeId",
                table: "DepartmentCourseModules",
                column: "CourseModuleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCourseModules_DepartmentCourseId_CourseModuleTypeId",
                table: "DepartmentCourseModules",
                columns: new[] { "DepartmentCourseId", "CourseModuleTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCourses_CourseId",
                table: "DepartmentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCourses_SemesterId",
                table: "DepartmentCourses",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCourses_DepartmentId_CourseId_SemesterId",
                table: "DepartmentCourses",
                columns: new[] { "DepartmentId", "CourseId", "SemesterId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentFaculties_DepartmentId_FacultyId",
                table: "DepartmentFaculties",
                columns: new[] { "DepartmentId", "FacultyId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSyllabi_CourseModuleTypes_CourseModuleTypeId",
                table: "CourseSyllabi",
                column: "CourseModuleTypeId",
                principalTable: "CourseModuleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSyllabi_CourseModuleTypes_CourseModuleTypeId",
                table: "CourseSyllabi");

            migrationBuilder.DropTable(
                name: "DepartmentCourseModules");

            migrationBuilder.DropTable(
                name: "DepartmentFaculties");

            migrationBuilder.DropTable(
                name: "DepartmentCourses");

            migrationBuilder.DropIndex(
                name: "IX_CourseSyllabi_CourseModuleTypeId",
                table: "CourseSyllabi");

            migrationBuilder.DropIndex(
                name: "IX_CourseSyllabi_Title_CourseId_CourseModuleTypeId",
                table: "CourseSyllabi");

            migrationBuilder.DropColumn(
                name: "CourseModuleTypeId",
                table: "CourseSyllabi");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSyllabi_Title_CourseId",
                table: "CourseSyllabi",
                columns: new[] { "Title", "CourseId" },
                unique: true);
        }
    }
}
