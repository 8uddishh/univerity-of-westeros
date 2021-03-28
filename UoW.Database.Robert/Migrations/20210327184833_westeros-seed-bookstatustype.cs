using Microsoft.EntityFrameworkCore.Migrations;
using UoW.Database.Robert.Entities.Enums;

namespace UoW.Database.Robert.Migrations
{
    public partial class westerosseedbookstatustype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(BookStatusType.New | BookStatusType.Borrowed), "New and Borrowed", "New and Borrowed" }
            );

            migrationBuilder.InsertData(
                table: "BookStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(BookStatusType.Used | BookStatusType.Borrowed), "Used and Borrowed", "Used and Borrowed" }
            );

            migrationBuilder.InsertData(
                table: "BookStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(BookStatusType.New | BookStatusType.Available), "New and Available", "New and Available" }
            );

            migrationBuilder.InsertData(
                table: "BookStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(BookStatusType.Used | BookStatusType.Available), "Used and Available", "Used and Available" }
            );

            migrationBuilder.InsertData(
                table: "BookStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(BookStatusType.New | BookStatusType.Missing), "New and Missing", "New and Missing" }
            );

            migrationBuilder.InsertData(
                table: "BookStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(BookStatusType.Used | BookStatusType.Missing), "Used and Missing", "New and Missing" }
            );

            migrationBuilder.InsertData(
                table: "BookStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(BookStatusType.New | BookStatusType.Lost), "New and Lost", "New and Lost" }
            );

            migrationBuilder.InsertData(
                table: "BookStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(BookStatusType.Used | BookStatusType.Lost), "Used and Lost", "New and Lost" }
            );

            migrationBuilder.InsertData(
                table: "BookStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(BookStatusType.New | BookStatusType.Damaged), "New and Damaged", "New and Damaged" }
            );

            migrationBuilder.InsertData(
                table: "BookStatusTypes",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { (int)(BookStatusType.Used | BookStatusType.Damaged), "Used and Damaged", "New and Damaged" }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM BookStatusTypes", true);
        }
    }
}
