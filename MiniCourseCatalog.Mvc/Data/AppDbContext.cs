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
            new CourseCategory { Id = 1, Name = "Công nghệ thông tin", Code = "IT" },
            new CourseCategory { Id = 2, Name = "Ngoại ngữ", Code = "LANG" },
            new CourseCategory { Id = 3, Name = "Kỹ năng mềm", Code = "SOFT" }
        );

        modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, CourseCode = "MTH00001", CourseSku = "SKU-IT-CSLT", Title = "Cơ sở lập trình", Department = "Toán-Tin", Instructor = "Nguyễn Hiền Lương", TuitionFee = 1500000, AvailableSeats = 50, WarningThreshold = 10, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 1 },
            new Course { Id = 2, CourseCode = "MTH00002", CourseSku = "SKU-IT-CTDL", Title = "Cấu trúc dữ liệu và giải thuật", Department = "Toán-Tin", Instructor = "Hà Văn Thảo", TuitionFee = 1800000, AvailableSeats = 5, WarningThreshold = 10, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 1 },
            new Course { Id = 3, CourseCode = "MTH00003", CourseSku = "SKU-IT-OOP", Title = "Lập trình hướng đối tượng", Department = "Toán-Tin", Instructor = "Hà Văn Thảo", TuitionFee = 2000000, AvailableSeats = 0, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 1 },
            new Course { Id = 4, CourseCode = "MTH00004", CourseSku = "SKU-IT-WEB", Title = "Lập trình web", Department = "Toán-Tin", Instructor = "Hà Văn Thảo", TuitionFee = 1600000, AvailableSeats = 20, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 1 },
            new Course { Id = 5, CourseCode = "ENG00001", CourseSku = "SKU-LANG-IELTS", Title = "IELTS 6.5 Cấp tốc", Department = "Ngoại ngữ", Instructor = "John Doe", TuitionFee = 4500000, AvailableSeats = 15, WarningThreshold = 5, LastUpdatedAt = DateTime.Parse("2026-06-10"), CategoryId = 2 }
        );

        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, FullName = "Trần Văn Hùng", Email = "hungtv@gmail.com" },
            new Student { Id = 2, FullName = "Nguyễn Thị Mai", Email = "maint@gmail.com" }
        );
    }
}
