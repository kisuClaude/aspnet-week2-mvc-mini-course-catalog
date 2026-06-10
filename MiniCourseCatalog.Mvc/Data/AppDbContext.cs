using Microsoft.EntityFrameworkCore;
using MiniCourseCatalog.Mvc.Models;

namespace MiniCourseCatalog.Mvc.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<CourseCategory> CourseCategories => Set<CourseCategory>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<EnrollmentDetail> EnrollmentDetails => Set<EnrollmentDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseCategory>(entity =>
        {
            entity.ToTable("CourseCategories");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Code).IsRequired().HasMaxLength(20);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Courses");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(150);
            entity.Property(e => e.CourseCode).IsRequired().HasMaxLength(20);
            entity.Property(e => e.CourseSku).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Instructor).IsRequired().HasMaxLength(100);
            entity.Property(e => e.TuitionFee).HasConversion<double>().IsRequired();
            
            entity.HasOne(e => e.Category)
                  .WithMany(c => c.Courses)
                  .HasForeignKey(e => e.CategoryId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Students");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.ToTable("Enrollments");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.TotalTuition).HasConversion<double>().IsRequired();
            entity.HasOne(e => e.Student)
                  .WithMany(s => s.Enrollments)
                  .HasForeignKey(e => e.StudentId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<EnrollmentDetail>(entity =>
        {
            entity.ToTable("EnrollmentDetails");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PriceApplied).HasConversion<double>().IsRequired();
            
            entity.HasOne(e => e.Enrollment)
                  .WithMany(o => o.EnrollmentDetails)
                  .HasForeignKey(e => e.EnrollmentId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Course)
                  .WithMany()
                  .HasForeignKey(e => e.CourseId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Seed Data
        modelBuilder.Entity<CourseCategory>().HasData(
            new CourseCategory { Id = 1, Name = "Anh văn", Code = "AV" },
            new CourseCategory { Id = 2, Name = "Lý luận chính trị", Code = "LLCT" },
            new CourseCategory { Id = 3, Name = "Khoa học tự nhiên & Đại cương", Code = "KHTN" },
            new CourseCategory { Id = 4, Name = "Thể dục", Code = "TD" },
            new CourseCategory { Id = 5, Name = "Sinh học & Hóa học", Code = "SHHH" },
            new CourseCategory { Id = 6, Name = "Toán học & Tin học", Code = "THTH" },
            new CourseCategory { Id = 7, Name = "Vật lý", Code = "VL" }
        );

        modelBuilder.Entity<Course>().HasData(
            // Anh văn (Category 1)
            new Course { Id = 1, CourseCode = "ADD00031", CourseSku = "SKU-25C2_1", Title = "Anh văn 1 (Lớp 25C2_1)", Department = "Anh văn", Instructor = "Giảng viên Anh văn", TuitionFee = 1500000, AvailableSeats = 20, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 1 },
            new Course { Id = 2, CourseCode = "ADD00031", CourseSku = "SKU-25C3_1", Title = "Anh văn 1 (Lớp 25C3_1)", Department = "Anh văn", Instructor = "Giảng viên Anh văn", TuitionFee = 1500000, AvailableSeats = 9, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 1 },
            new Course { Id = 3, CourseCode = "ADD00031", CourseSku = "SKU-25C4_1", Title = "Anh văn 1 (Lớp 25C4_1)", Department = "Anh văn", Instructor = "Giảng viên Anh văn", TuitionFee = 1500000, AvailableSeats = 8, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 1 },
            new Course { Id = 4, CourseCode = "ADD00031", CourseSku = "SKU-25S4_1", Title = "Anh văn 1 (Lớp 25S4_1)", Department = "Anh văn", Instructor = "Giảng viên Anh văn", TuitionFee = 1500000, AvailableSeats = 6, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 1 },
            new Course { Id = 5, CourseCode = "ADD00032", CourseSku = "SKU-AV2-25S4_1", Title = "Anh văn 2 (Lớp 25S4_1)", Department = "Anh văn", Instructor = "Giảng viên Anh văn", TuitionFee = 1500000, AvailableSeats = 16, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 1 },
            new Course { Id = 6, CourseCode = "ADD00032", CourseSku = "SKU-AV2-25S5_1", Title = "Anh văn 2 (Lớp 25S5_1)", Department = "Anh văn", Instructor = "Giảng viên Anh văn", TuitionFee = 1500000, AvailableSeats = 2, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 1 },
            new Course { Id = 7, CourseCode = "ADD00032", CourseSku = "SKU-AV2-25S6_1", Title = "Anh văn 2 (Lớp 25S6_1)", Department = "Anh văn", Instructor = "Giảng viên Anh văn", TuitionFee = 1500000, AvailableSeats = 23, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 1 },
            new Course { Id = 8, CourseCode = "ADD00033", CourseSku = "SKU-AV3-25C2_1", Title = "Anh văn 3 (Lớp 25C2_1)", Department = "Anh văn", Instructor = "Giảng viên Anh văn", TuitionFee = 1500000, AvailableSeats = 10, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 1 },

            // Lý luận chính trị (Category 2)
            new Course { Id = 9, CourseCode = "BAA00003", CourseSku = "SKU-HCM-24_7", Title = "Tư tưởng Hồ Chí Minh (Lớp 24_7)", Department = "Lý luận chính trị", Instructor = "Giảng viên LLCT", TuitionFee = 1000000, AvailableSeats = 0, WarningThreshold = 10, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 2 },
            new Course { Id = 10, CourseCode = "BAA00003", CourseSku = "SKU-HCM-24_5", Title = "Tư tưởng Hồ Chí Minh (Lớp 24_5)", Department = "Lý luận chính trị", Instructor = "Giảng viên LLCT", TuitionFee = 1000000, AvailableSeats = 0, WarningThreshold = 10, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 2 },
            new Course { Id = 11, CourseCode = "BAA00004", CourseSku = "SKU-PLDC-25CTT6", Title = "Pháp luật đại cương (Lớp 25CTT6)", Department = "Lý luận chính trị", Instructor = "Giảng viên LLCT", TuitionFee = 1500000, AvailableSeats = 0, WarningThreshold = 10, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 2 },
            new Course { Id = 12, CourseCode = "BAA00004", CourseSku = "SKU-PLDC-25CTT4", Title = "Pháp luật đại cương (Lớp 25CTT4)", Department = "Lý luận chính trị", Instructor = "Giảng viên LLCT", TuitionFee = 1500000, AvailableSeats = 0, WarningThreshold = 10, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 2 },
            new Course { Id = 13, CourseCode = "BAA00101", CourseSku = "SKU-MLN-25KVL2", Title = "Triết học Mác - Lênin (Lớp 25KVL2)", Department = "Lý luận chính trị", Instructor = "Giảng viên LLCT", TuitionFee = 1500000, AvailableSeats = 0, WarningThreshold = 10, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 2 },
            new Course { Id = 14, CourseCode = "BAA00104", CourseSku = "SKU-LSD-25DTV2", Title = "Lịch sử Đảng Cộng sản Việt Nam (Lớp 25DTV2)", Department = "Lý luận chính trị", Instructor = "Giảng viên LLCT", TuitionFee = 1000000, AvailableSeats = 0, WarningThreshold = 10, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 2 },

            // Khoa học tự nhiên & Đại cương (Category 3)
            new Course { Id = 15, CourseCode = "BAA00005", CourseSku = "SKU-KTDC-25KDC1", Title = "Kinh tế đại cương (Lớp 25KDC1)", Department = "Kinh tế", Instructor = "Giảng viên Kinh tế", TuitionFee = 1000000, AvailableSeats = 0, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 3 },
            new Course { Id = 16, CourseCode = "BAA00006", CourseSku = "SKU-TLDC-25_1", Title = "Tâm lý đại cương (Lớp 25_1)", Department = "Tâm lý", Instructor = "Giảng viên Tâm lý", TuitionFee = 1000000, AvailableSeats = 0, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 3 },
            new Course { Id = 17, CourseCode = "BAA00008", CourseSku = "SKU-KN-25KDL", Title = "Kỹ năng làm việc nhóm và học tập", Department = "Kỹ năng", Instructor = "Giảng viên Kỹ năng", TuitionFee = 1000000, AvailableSeats = 0, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 3 },

            // Thể dục (Category 4)
            new Course { Id = 18, CourseCode = "BAA00021", CourseSku = "SKU-TD1-25TNT2", Title = "Thể dục 1 (Lớp 25TNT2)", Department = "Thể chất", Instructor = "Giảng viên Thể dục", TuitionFee = 1000000, AvailableSeats = 0, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 4 },
            new Course { Id = 19, CourseCode = "BAA00022", CourseSku = "SKU-TD2-25VT_T2Ti1", Title = "Thể dục 2 (Lớp 25VT_T2Ti1)", Department = "Thể chất", Instructor = "Giảng viên Thể dục", TuitionFee = 1000000, AvailableSeats = 3, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 4 },
            new Course { Id = 20, CourseCode = "BAA00022", CourseSku = "SKU-TD2-25VT_T3Ti1", Title = "Thể dục 2 (Lớp 25VT_T3Ti1)", Department = "Thể chất", Instructor = "Giảng viên Thể dục", TuitionFee = 1000000, AvailableSeats = 0, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 4 },

            // Sinh học & Hóa học (Category 5)
            new Course { Id = 21, CourseCode = "BIO00001", CourseSku = "SKU-SDC1-25HDH1", Title = "Sinh đại cương 1 (Lớp 25HDH1)", Department = "Sinh học", Instructor = "Giảng viên Sinh học", TuitionFee = 1500000, AvailableSeats = 0, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 5 },
            new Course { Id = 22, CourseCode = "BIO00002", CourseSku = "SKU-SDC2-25CSH3", Title = "Sinh đại cương 2 (Lớp 25CSH3)", Department = "Sinh học", Instructor = "Giảng viên Sinh học", TuitionFee = 1500000, AvailableSeats = 0, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 5 },
            new Course { Id = 23, CourseCode = "CHE00001", CourseSku = "SKU-HDC1-25CVD1", Title = "Hóa đại cương 1 (Lớp 25CVD1)", Department = "Hóa học", Instructor = "Giảng viên Hóa học", TuitionFee = 1500000, AvailableSeats = 0, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 5 },

            // Toán học & Tin học (Category 6)
            new Course { Id = 24, CourseCode = "CSC00003", CourseSku = "SKU-THCS-C2A", Title = "Tin học cơ sở (Lớp C2A)", Department = "Toán-Tin", Instructor = "Giảng viên Tin học", TuitionFee = 1500000, AvailableSeats = 0, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 6 },
            new Course { Id = 25, CourseCode = "MTH00013", CourseSku = "SKU-VTP2A-25KDL1", Title = "Vi tích phân 2A (Lớp 25KDL1)", Department = "Toán-Tin", Instructor = "Giảng viên Toán", TuitionFee = 1500000, AvailableSeats = 0, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 6 },
            new Course { Id = 26, CourseCode = "MTH00055", CourseSku = "SKU-CSLT-25TTH1", Title = "Cơ sở lập trình (Lớp 25TTH1)", Department = "Toán-Tin", Instructor = "Giảng viên Tin học", TuitionFee = 2000000, AvailableSeats = 0, WarningThreshold = 10, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 6 },

            // Vật lý (Category 7)
            new Course { Id = 27, CourseCode = "PHY00001", CourseSku = "SKU-VLDC1-25CTT5", Title = "Vật lý đại cương 1 (Lớp 25CTT5)", Department = "Vật lý", Instructor = "Giảng viên Vật lý", TuitionFee = 1500000, AvailableSeats = 0, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 7 }
        );

        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, FullName = "Trần Văn Hùng", Email = "hungtv@gmail.com" },
            new Student { Id = 2, FullName = "Nguyễn Thị Mai", Email = "maint@gmail.com" }
        );
    }
}
