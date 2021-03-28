using Microsoft.EntityFrameworkCore.Migrations;

namespace UoW.Database.Robert.Migrations
{
    public partial class westerosonboardsyllabusactivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseCategoryTypes_CategoryTypeId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CategoryTypeId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CategoryTypeId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CourseCategoryTypeId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CourseSyllabi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(600)", maxLength: 400, nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSyllabi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSyllabi_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseActivities",
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
                name: "IX_Courses_CourseCategoryTypeId",
                table: "Courses",
                column: "CourseCategoryTypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_CourseSyllabi_CourseId",
                table: "CourseSyllabi",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSyllabi_Title_CourseId",
                table: "CourseSyllabi",
                columns: new[] { "Title", "CourseId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseCategoryTypes_CourseCategoryTypeId",
                table: "Courses",
                column: "CourseCategoryTypeId",
                principalTable: "CourseCategoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseCategoryTypes_CourseCategoryTypeId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseActivities");

            migrationBuilder.DropTable(
                name: "CourseSyllabi");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseCategoryTypeId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseCategoryTypeId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CategoryTypeId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryTypeId",
                table: "Courses",
                column: "CategoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseCategoryTypes_CategoryTypeId",
                table: "Courses",
                column: "CategoryTypeId",
                principalTable: "CourseCategoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
