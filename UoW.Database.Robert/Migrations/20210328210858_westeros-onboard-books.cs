using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UoW.Database.Robert.Migrations
{
    public partial class westerosonboardbooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Prefix = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Suffix = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    AboutAuthor = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.CheckConstraint("CK_Author_Gender", "[Gender] = 'M' OR [Gender] = 'F' OR [Gender] = 'I'");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Abbr = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    WebsiteUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    AboutDepartment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Prefix = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Suffix = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    DateOfJoin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AboutFaculty = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FacultyTypeId = table.Column<int>(nullable: false),
                    PrimaryDepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                    table.CheckConstraint("CK_Faculty_Gender", "[Gender] = 'M' OR [Gender] = 'F' OR [Gender] = 'I'");
                    table.ForeignKey(
                        name: "FK_Faculties_FacultyTypes_FacultyTypeId",
                        column: x => x.FacultyTypeId,
                        principalTable: "FacultyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faculties_Departments_PrimaryDepartmentId",
                        column: x => x.PrimaryDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RollNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Prefix = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Suffix = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    DateOfJoin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    BatchId = table.Column<int>(nullable: false),
                    StudentStatusTypeId = table.Column<int>(nullable: false),
                    CurrentSemesterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.CheckConstraint("CK_Student_Gender", "[Gender] = 'M' OR [Gender] = 'F' OR [Gender] = 'I'");
                    table.ForeignKey(
                        name: "FK_Students_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Semesters_CurrentSemesterId",
                        column: x => x.CurrentSemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_StudentStatusTypes_StudentStatusTypeId",
                        column: x => x.StudentStatusTypeId,
                        principalTable: "StudentStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    EbookUrl = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    AboutBook = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Isbn = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Edition = table.Column<string>(type: "char(4)", maxLength: 4, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    PublisherId = table.Column<int>(nullable: false),
                    DateOfPublish = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublisherContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intel = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    PublisherId = table.Column<int>(nullable: false),
                    PublisherContactTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublisherContacts_ContactTypes_PublisherContactTypeId",
                        column: x => x.PublisherContactTypeId,
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublisherContacts_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLedgers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LendedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookId = table.Column<int>(nullable: false),
                    BookStatusTypeId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: true),
                    FacultyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLedgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookLedgers_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLedgers_BookStatusTypes_BookStatusTypeId",
                        column: x => x.BookStatusTypeId,
                        principalTable: "BookStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLedgers_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookLedgers_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublisherAddressContactXrefs",
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
                    table.PrimaryKey("PK_PublisherAddressContactXrefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublisherAddressContactXrefs_PublisherContacts_Id",
                        column: x => x.Id,
                        principalTable: "PublisherContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId",
                table: "BookAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookId",
                table: "BookAuthors",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLedgers_BookId",
                table: "BookLedgers",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLedgers_BookStatusTypeId",
                table: "BookLedgers",
                column: "BookStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLedgers_FacultyId",
                table: "BookLedgers",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLedgers_SerialNumber",
                table: "BookLedgers",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookLedgers_StudentId",
                table: "BookLedgers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Isbn",
                table: "Books",
                column: "Isbn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId_Title",
                table: "Books",
                columns: new[] { "PublisherId", "Title" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Abbr",
                table: "Departments",
                column: "Abbr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_FacultyTypeId",
                table: "Faculties",
                column: "FacultyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_PrimaryDepartmentId",
                table: "Faculties",
                column: "PrimaryDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PublisherContacts_PublisherContactTypeId",
                table: "PublisherContacts",
                column: "PublisherContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PublisherContacts_PublisherId_PublisherContactTypeId_Intel",
                table: "PublisherContacts",
                columns: new[] { "PublisherId", "PublisherContactTypeId", "Intel" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_Name",
                table: "Publishers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_BatchId",
                table: "Students",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CurrentSemesterId",
                table: "Students",
                column: "CurrentSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentStatusTypeId",
                table: "Students",
                column: "StudentStatusTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookLedgers");

            migrationBuilder.DropTable(
                name: "PublisherAddressContactXrefs");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "PublisherContacts");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
