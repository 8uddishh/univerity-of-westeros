using Microsoft.EntityFrameworkCore.Migrations;
using UoW.Database.Robert.Entities.Enums;

namespace UoW.Database.Robert.Migrations
{
    public partial class westerosseedstudentstatustype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StudentStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(StudentStatusType.Active), "Active", "Active" }
            );

            migrationBuilder.InsertData(
                table: "StudentStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(StudentStatusType.Active | StudentStatusType.ExtendedAbsence), "Active but absent", "Active but absent" }
            );

            migrationBuilder.InsertData(
                table: "StudentStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(StudentStatusType.Active | StudentStatusType.Defaulted), "Active but defaulted", "Active but defaulted" }
            );

            migrationBuilder.InsertData(
                table: "StudentStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(StudentStatusType.Inactive | StudentStatusType.ExtendedAbsence), "Inactive due to absence", "Inactive due to absence" }
            );

            migrationBuilder.InsertData(
                table: "StudentStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(StudentStatusType.Inactive | StudentStatusType.Deceased), "Inactive due to death", "Inactive due to death" }
            );

            migrationBuilder.InsertData(
                table: "StudentStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(StudentStatusType.Inactive | StudentStatusType.Defaulted), "Inactive due to defaulting on payments", "Inactive due to defaulting on payments" }
            );

            migrationBuilder.InsertData(
                table: "StudentStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(StudentStatusType.Inactive | StudentStatusType.Suspended), "Inactive due to suspension", "Inactive due to suspension" }
            );

            migrationBuilder.InsertData(
                table: "StudentStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(StudentStatusType.Inactive | StudentStatusType.Rusticated), "Inactive due to rustication", "Inactive due to rustication" }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM StudentStatusTypes", true);
        }
    }
}
