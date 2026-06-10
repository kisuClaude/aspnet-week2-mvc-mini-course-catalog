using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniCourseCatalog.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRealScheduleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CourseCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "Name" },
                values: new object[] { "AV", "Anh văn" });

            migrationBuilder.UpdateData(
                table: "CourseCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "Name" },
                values: new object[] { "LLCT", "Lý luận chính trị" });

            migrationBuilder.UpdateData(
                table: "CourseCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "Name" },
                values: new object[] { "KHTN", "Khoa học tự nhiên & Đại cương" });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 4, "TD", "Thể dục" },
                    { 5, "SHHH", "Sinh học & Hóa học" },
                    { 6, "THTH", "Toán học & Tin học" },
                    { 7, "VL", "Vật lý" }
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableSeats", "CourseCode", "CourseSku", "Department", "Instructor", "Title", "WarningThreshold" },
                values: new object[] { 20, "ADD00031", "SKU-25C2_1", "Anh văn", "Giảng viên Anh văn", "Anh văn 1 (Lớp 25C2_1)", 5 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableSeats", "CourseCode", "CourseSku", "Department", "Instructor", "Title", "TuitionFee", "WarningThreshold" },
                values: new object[] { 9, "ADD00031", "SKU-25C3_1", "Anh văn", "Giảng viên Anh văn", "Anh văn 1 (Lớp 25C3_1)", 1500000.0, 5 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableSeats", "CourseCode", "CourseSku", "Department", "Instructor", "Title", "TuitionFee" },
                values: new object[] { 8, "ADD00031", "SKU-25C4_1", "Anh văn", "Giảng viên Anh văn", "Anh văn 1 (Lớp 25C4_1)", 1500000.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableSeats", "CourseCode", "CourseSku", "Department", "Instructor", "Title", "TuitionFee" },
                values: new object[] { 6, "ADD00031", "SKU-25S4_1", "Anh văn", "Giảng viên Anh văn", "Anh văn 1 (Lớp 25S4_1)", 1500000.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvailableSeats", "CategoryId", "CourseCode", "CourseSku", "Department", "Instructor", "Title", "TuitionFee" },
                values: new object[] { 16, 1, "ADD00032", "SKU-AV2-25S4_1", "Anh văn", "Giảng viên Anh văn", "Anh văn 2 (Lớp 25S4_1)", 1500000.0 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AvailableSeats", "CategoryId", "CourseCode", "CourseSku", "Department", "Instructor", "LastUpdatedAt", "Title", "TuitionFee", "WarningThreshold" },
                values: new object[,]
                {
                    { 6, 2, 1, "ADD00032", "SKU-AV2-25S5_1", "Anh văn", "Giảng viên Anh văn", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anh văn 2 (Lớp 25S5_1)", 1500000.0, 5 },
                    { 7, 23, 1, "ADD00032", "SKU-AV2-25S6_1", "Anh văn", "Giảng viên Anh văn", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anh văn 2 (Lớp 25S6_1)", 1500000.0, 5 },
                    { 8, 10, 1, "ADD00033", "SKU-AV3-25C2_1", "Anh văn", "Giảng viên Anh văn", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anh văn 3 (Lớp 25C2_1)", 1500000.0, 5 },
                    { 9, 0, 2, "BAA00003", "SKU-HCM-24_7", "Lý luận chính trị", "Giảng viên LLCT", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tư tưởng Hồ Chí Minh (Lớp 24_7)", 1000000.0, 10 },
                    { 10, 0, 2, "BAA00003", "SKU-HCM-24_5", "Lý luận chính trị", "Giảng viên LLCT", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tư tưởng Hồ Chí Minh (Lớp 24_5)", 1000000.0, 10 },
                    { 11, 0, 2, "BAA00004", "SKU-PLDC-25CTT6", "Lý luận chính trị", "Giảng viên LLCT", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pháp luật đại cương (Lớp 25CTT6)", 1500000.0, 10 },
                    { 12, 0, 2, "BAA00004", "SKU-PLDC-25CTT4", "Lý luận chính trị", "Giảng viên LLCT", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pháp luật đại cương (Lớp 25CTT4)", 1500000.0, 10 },
                    { 13, 0, 2, "BAA00101", "SKU-MLN-25KVL2", "Lý luận chính trị", "Giảng viên LLCT", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Triết học Mác - Lênin (Lớp 25KVL2)", 1500000.0, 10 },
                    { 14, 0, 2, "BAA00104", "SKU-LSD-25DTV2", "Lý luận chính trị", "Giảng viên LLCT", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lịch sử Đảng Cộng sản Việt Nam (Lớp 25DTV2)", 1000000.0, 10 },
                    { 15, 0, 3, "BAA00005", "SKU-KTDC-25KDC1", "Kinh tế", "Giảng viên Kinh tế", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kinh tế đại cương (Lớp 25KDC1)", 1000000.0, 5 },
                    { 16, 0, 3, "BAA00006", "SKU-TLDC-25_1", "Tâm lý", "Giảng viên Tâm lý", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tâm lý đại cương (Lớp 25_1)", 1000000.0, 5 },
                    { 17, 0, 3, "BAA00008", "SKU-KN-25KDL", "Kỹ năng", "Giảng viên Kỹ năng", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kỹ năng làm việc nhóm và học tập", 1000000.0, 5 },
                    { 18, 0, 4, "BAA00021", "SKU-TD1-25TNT2", "Thể chất", "Giảng viên Thể dục", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thể dục 1 (Lớp 25TNT2)", 1000000.0, 5 },
                    { 19, 3, 4, "BAA00022", "SKU-TD2-25VT_T2Ti1", "Thể chất", "Giảng viên Thể dục", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thể dục 2 (Lớp 25VT_T2Ti1)", 1000000.0, 5 },
                    { 20, 0, 4, "BAA00022", "SKU-TD2-25VT_T3Ti1", "Thể chất", "Giảng viên Thể dục", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thể dục 2 (Lớp 25VT_T3Ti1)", 1000000.0, 5 },
                    { 21, 0, 5, "BIO00001", "SKU-SDC1-25HDH1", "Sinh học", "Giảng viên Sinh học", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinh đại cương 1 (Lớp 25HDH1)", 1500000.0, 5 },
                    { 22, 0, 5, "BIO00002", "SKU-SDC2-25CSH3", "Sinh học", "Giảng viên Sinh học", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinh đại cương 2 (Lớp 25CSH3)", 1500000.0, 5 },
                    { 23, 0, 5, "CHE00001", "SKU-HDC1-25CVD1", "Hóa học", "Giảng viên Hóa học", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hóa đại cương 1 (Lớp 25CVD1)", 1500000.0, 5 },
                    { 24, 0, 6, "CSC00003", "SKU-THCS-C2A", "Toán-Tin", "Giảng viên Tin học", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tin học cơ sở (Lớp C2A)", 1500000.0, 5 },
                    { 25, 0, 6, "MTH00013", "SKU-VTP2A-25KDL1", "Toán-Tin", "Giảng viên Toán", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vi tích phân 2A (Lớp 25KDL1)", 1500000.0, 5 },
                    { 26, 0, 6, "MTH00055", "SKU-CSLT-25TTH1", "Toán-Tin", "Giảng viên Tin học", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cơ sở lập trình (Lớp 25TTH1)", 2000000.0, 10 },
                    { 27, 0, 7, "PHY00001", "SKU-VLDC1-25CTT5", "Vật lý", "Giảng viên Vật lý", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vật lý đại cương 1 (Lớp 25CTT5)", 1500000.0, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "CourseCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "Name" },
                values: new object[] { "IT", "Công nghệ thông tin" });

            migrationBuilder.UpdateData(
                table: "CourseCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "Name" },
                values: new object[] { "LANG", "Ngoại ngữ" });

            migrationBuilder.UpdateData(
                table: "CourseCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "Name" },
                values: new object[] { "SOFT", "Kỹ năng mềm" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableSeats", "CourseCode", "CourseSku", "Department", "Instructor", "Title", "WarningThreshold" },
                values: new object[] { 50, "MTH00001", "SKU-IT-CSLT", "Toán-Tin", "Nguyễn Hiền Lương", "Cơ sở lập trình", 10 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableSeats", "CourseCode", "CourseSku", "Department", "Instructor", "Title", "TuitionFee", "WarningThreshold" },
                values: new object[] { 5, "MTH00002", "SKU-IT-CTDL", "Toán-Tin", "Hà Văn Thảo", "Cấu trúc dữ liệu và giải thuật", 1800000.0, 10 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableSeats", "CourseCode", "CourseSku", "Department", "Instructor", "Title", "TuitionFee" },
                values: new object[] { 0, "MTH00003", "SKU-IT-OOP", "Toán-Tin", "Hà Văn Thảo", "Lập trình hướng đối tượng", 2000000.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableSeats", "CourseCode", "CourseSku", "Department", "Instructor", "Title", "TuitionFee" },
                values: new object[] { 20, "MTH00004", "SKU-IT-WEB", "Toán-Tin", "Hà Văn Thảo", "Lập trình web", 1600000.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvailableSeats", "CategoryId", "CourseCode", "CourseSku", "Department", "Instructor", "Title", "TuitionFee" },
                values: new object[] { 15, 2, "ENG00001", "SKU-LANG-IELTS", "Ngoại ngữ", "John Doe", "IELTS 6.5 Cấp tốc", 4500000.0 });
        }
    }
}
