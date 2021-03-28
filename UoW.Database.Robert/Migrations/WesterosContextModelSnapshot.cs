﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UoW.Database.Robert;

namespace UoW.Database.Robert.Migrations
{
    [DbContext(typeof(WesterosContext))]
    partial class WesterosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UoW.Database.Robert.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutAuthor")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("char(2)")
                        .HasMaxLength(2);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("MiddleName")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Prefix")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Suffix")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasCheckConstraint("CK_Author_Gender", "[Gender] = 'M' OR [Gender] = 'F' OR [Gender] = 'I'");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.Batch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(400)")
                        .HasMaxLength(400);

                    b.Property<int>("EndYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EndYear")
                        .IsUnique();

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutBook")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<DateTime>("DateOfPublish")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("EbookUrl")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Edition")
                        .IsRequired()
                        .HasColumnType("char(4)")
                        .HasMaxLength(4);

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25);

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Isbn")
                        .IsUnique();

                    b.HasIndex("PublisherId", "Title")
                        .IsUnique();

                    b.ToTable("Books");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.BookAuthor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.BookLedger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("BookStatusTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DueOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LendedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("BookStatusTypeId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("SerialNumber")
                        .IsUnique();

                    b.HasIndex("StudentId");

                    b.ToTable("BookLedgers");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.BookStatusType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("BookStatusTypes");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.ContactType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ContactTypes");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("CourseCategoryTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("CourseCategoryTypeId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.CourseActivityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CourseActivityTypes");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.CourseCategoryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CourseCategoryTypes");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.CourseModuleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CourseModuleTypes");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.CourseSyllabus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(600)")
                        .HasMaxLength(400);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("Title", "CourseId")
                        .IsUnique();

                    b.ToTable("CourseSyllabi");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.CourseSyllabusActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseActivityTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CourseSyllabusId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(600)")
                        .HasMaxLength(400);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CourseActivityTypeId");

                    b.HasIndex("CourseSyllabusId");

                    b.HasIndex("Title", "CourseActivityTypeId", "CourseSyllabusId")
                        .IsUnique();

                    b.ToTable("CourseSyllabusActivities");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbr")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("AboutDepartment")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Abbr")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutFaculty")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfJoin")
                        .HasColumnType("datetime2");

                    b.Property<int>("FacultyTypeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("char(2)")
                        .HasMaxLength(2);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("MiddleName")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Prefix")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("PrimaryDepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Suffix")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("FacultyTypeId");

                    b.HasIndex("PrimaryDepartmentId");

                    b.ToTable("Faculties");

                    b.HasCheckConstraint("CK_Faculty_Gender", "[Gender] = 'M' OR [Gender] = 'F' OR [Gender] = 'I'");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.FacultyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("FacultyTypes");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.PublisherAddressContactXref", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("AddressLine2")
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("AddressLine3")
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("char(2)")
                        .HasMaxLength(2);

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("char(2)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("PublisherAddressContactXrefs");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.PublisherContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Intel")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("PublisherContactTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PublisherContactTypeId");

                    b.HasIndex("PublisherId", "PublisherContactTypeId", "Intel")
                        .IsUnique();

                    b.ToTable("PublisherContacts");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BatchId")
                        .HasColumnType("int");

                    b.Property<int>("CurrentSemesterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfJoin")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("char(2)")
                        .HasMaxLength(2);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("MiddleName")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Prefix")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("RollNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentStatusTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Suffix")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("BatchId");

                    b.HasIndex("CurrentSemesterId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("StudentStatusTypeId");

                    b.ToTable("Students");

                    b.HasCheckConstraint("CK_Student_Gender", "[Gender] = 'M' OR [Gender] = 'F' OR [Gender] = 'I'");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.StudentStatusType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("StudentStatusTypes");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.Book", b =>
                {
                    b.HasOne("UoW.Database.Robert.Entities.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.BookAuthor", b =>
                {
                    b.HasOne("UoW.Database.Robert.Entities.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UoW.Database.Robert.Entities.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.BookLedger", b =>
                {
                    b.HasOne("UoW.Database.Robert.Entities.Book", "Book")
                        .WithMany("BookLedgers")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UoW.Database.Robert.Entities.BookStatusType", "BookStatusType")
                        .WithMany("BookLedgers")
                        .HasForeignKey("BookStatusTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UoW.Database.Robert.Entities.Faculty", "Faculty")
                        .WithMany("BookLedgers")
                        .HasForeignKey("FacultyId");

                    b.HasOne("UoW.Database.Robert.Entities.Student", "Student")
                        .WithMany("BookLedgers")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.Course", b =>
                {
                    b.HasOne("UoW.Database.Robert.Entities.CourseCategoryType", "CourseCategoryType")
                        .WithMany("Courses")
                        .HasForeignKey("CourseCategoryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.CourseSyllabus", b =>
                {
                    b.HasOne("UoW.Database.Robert.Entities.Course", "Course")
                        .WithMany("CourseSyllabi")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.CourseSyllabusActivity", b =>
                {
                    b.HasOne("UoW.Database.Robert.Entities.CourseActivityType", "CourseActivityType")
                        .WithMany("CourseActivities")
                        .HasForeignKey("CourseActivityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UoW.Database.Robert.Entities.CourseSyllabus", "CourseSyllabus")
                        .WithMany("CourseActivities")
                        .HasForeignKey("CourseSyllabusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.Faculty", b =>
                {
                    b.HasOne("UoW.Database.Robert.Entities.FacultyType", "FacultyType")
                        .WithMany("Faculties")
                        .HasForeignKey("FacultyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UoW.Database.Robert.Entities.Department", "PrimaryDepartment")
                        .WithMany("Faculties")
                        .HasForeignKey("PrimaryDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.PublisherAddressContactXref", b =>
                {
                    b.HasOne("UoW.Database.Robert.Entities.PublisherContact", "PublisherContact")
                        .WithOne("PublisherAddressContactXref")
                        .HasForeignKey("UoW.Database.Robert.Entities.PublisherAddressContactXref", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.PublisherContact", b =>
                {
                    b.HasOne("UoW.Database.Robert.Entities.ContactType", "PublisherContactType")
                        .WithMany("PublisherContacts")
                        .HasForeignKey("PublisherContactTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UoW.Database.Robert.Entities.Publisher", "Publisher")
                        .WithMany("PublisherContacts")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UoW.Database.Robert.Entities.Student", b =>
                {
                    b.HasOne("UoW.Database.Robert.Entities.Batch", "Batch")
                        .WithMany("Students")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UoW.Database.Robert.Entities.Semester", "Semester")
                        .WithMany("Students")
                        .HasForeignKey("CurrentSemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UoW.Database.Robert.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UoW.Database.Robert.Entities.StudentStatusType", "StudentStatusType")
                        .WithMany("Students")
                        .HasForeignKey("StudentStatusTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
