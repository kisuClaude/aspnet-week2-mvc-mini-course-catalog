using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniCourseCatalog.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    CourseSku = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: false),
                    Instructor = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TuitionFee = table.Column<double>(type: "REAL", nullable: false),
                    AvailableSeats = table.Column<int>(type: "INTEGER", nullable: false),
                    WarningThreshold = table.Column<int>(type: "INTEGER", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_CourseCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CourseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalTuition = table.Column<double>(type: "REAL", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EnrollmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    PriceApplied = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrollmentDetails_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnrollmentDetails_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "IT", "Công nghệ thông tin" },
                    { 2, "LANG", "Ngoại ngữ" },
                    { 3, "SOFT", "Kỹ năng mềm" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FullName" },
                values: new object[,]
                {
                    { 1, "hungtv@gmail.com", "Trần Văn Hùng" },
                    { 2, "maint@gmail.com", "Nguyễn Thị Mai" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AvailableSeats", "CategoryId", "CourseCode", "CourseSku", "Department", "Instructor", "LastUpdatedAt", "Title", "TuitionFee", "WarningThreshold" },
                values: new object[,]
                {
                    { 1, 50, 1, "MTH00001", "SKU-IT-CSLT", "Toán-Tin", "Nguyễn Hiền Lương", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ sở lập trình", 1500000.0, 10 },
                    { 2, 5, 1, "MTH00002", "SKU-IT-CTDL", "Toán-Tin", "Hà Văn Thảo", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cấu trúc dữ liệu và giải thuật", 1800000.0, 10 },
                    { 3, 0, 1, "MTH00003", "SKU-IT-OOP", "Toán-Tin", "Hà Văn Thảo", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lập trình hướng đối tượng", 2000000.0, 5 },
                    { 4, 20, 1, "MTH00004", "SKU-IT-WEB", "Toán-Tin", "Hà Văn Thảo", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lập trình web", 1600000.0, 5 },
                    { 5, 15, 2, "ENG00001", "SKU-LANG-IELTS", "Ngoại ngữ", "John Doe", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "IELTS 6.5 Cấp tốc", 4500000.0, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentDetails_CourseId",
                table: "EnrollmentDetails",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentDetails_EnrollmentId",
                table: "EnrollmentDetails",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrollmentDetails");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "CourseCategories");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
