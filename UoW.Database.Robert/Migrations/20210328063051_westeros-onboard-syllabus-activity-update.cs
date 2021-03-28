using Microsoft.EntityFrameworkCore.Migrations;

namespace UoW.Database.Robert.Migrations
{
    public partial class westerosonboardsyllabusactivityupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseActivities");

            migrationBuilder.CreateTable(
                name: "CourseSyllabusActivities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(600)", maxLength: 400, nullable: false),
                    CourseActivityTypeId = table.Column<int>(nullable: false),
                    CourseSyllabusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSyllabusActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSyllabusActivities_CourseActivityTypes_CourseActivityTypeId",
                        column: x => x.CourseActivityTypeId,
                        principalTable: "CourseActivityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSyllabusActivities_CourseSyllabi_CourseSyllabusId",
                        column: x => x.CourseSyllabusId,
                        principalTable: "CourseSyllabi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSyllabusActivities_CourseActivityTypeId",
                table: "CourseSyllabusActivities",
                column: "CourseActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSyllabusActivities_CourseSyllabusId",
                table: "CourseSyllabusActivities",
                column: "CourseSyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSyllabusActivities_Title_CourseActivityTypeId_CourseSyllabusId",
                table: "CourseSyllabusActivities",
                columns: new[] { "Title", "CourseActivityTypeId", "CourseSyllabusId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSyllabusActivities");

            migrationBuilder.CreateTable(
                name: "CourseActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseActivityTypeId = table.Column<int>(type: "int", nullable: false),
                    CourseSyllabusId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(600)", maxLength: 400, nullable: false),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseActivities_CourseActivityTypes_CourseActivityTypeId",
                        column: x => x.CourseActivityTypeId,
                        principalTable: "CourseActivityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseActivities_CourseSyllabi_CourseSyllabusId",
                        column: x => x.CourseSyllabusId,
                        principalTable: "CourseSyllabi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseActivities_CourseActivityTypeId",
                table: "CourseActivities",
                column: "CourseActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseActivities_CourseSyllabusId",
                table: "CourseActivities",
                column: "CourseSyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseActivities_Title_CourseActivityTypeId_CourseSyllabusId",
                table: "CourseActivities",
                columns: new[] { "Title", "CourseActivityTypeId", "CourseSyllabusId" },
                unique: true);
        }
    }
}
