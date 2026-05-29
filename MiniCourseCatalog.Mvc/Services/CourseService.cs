using MiniCourseCatalog.Mvc.Models;
using MiniCourseCatalog.Mvc.ViewModels;

namespace MiniCourseCatalog.Mvc.Services;

public class CourseService
{
    private readonly List<Course> _courses = new()
    {
        new Course { Id = 1, CourseCode = "MTH00001", Title = "Cơ sở lập trình", Department = "Toán-Tin", Instructor = "Nguyễn Hiền Lương", TuitionFee = 1500000, AvailableSeats = 50, WarningThreshold = 10, LastUpdatedAt = DateTime.Now },
        new Course { Id = 2, CourseCode = "MTH00002", Title = "Cấu trúc dữ liệu và giải thuật", Department = "Toán-Tin", Instructor = "Hà Văn Thảo", TuitionFee = 1800000, AvailableSeats = 5, WarningThreshold = 10, LastUpdatedAt = DateTime.Now },
        new Course { Id = 3, CourseCode = "MTH00003", Title = "Lập trình hướng đối tượng", Department = "Toán-Tin", Instructor = "Hà Văn Thảo", TuitionFee = 2000000, AvailableSeats = 0, WarningThreshold = 5, LastUpdatedAt = DateTime.Now },
        new Course { Id = 4, CourseCode = "MTH00004", Title = "Lập trình web", Department = "Toán-Tin", Instructor = "Hà Văn Thảo", TuitionFee = 1600000, AvailableSeats = 20, WarningThreshold = 5, LastUpdatedAt = DateTime.Now }
    };

    public List<Course> GetAll() => _courses;

    public Course? GetById(int id) => _courses.FirstOrDefault(c => c.Id == id);

    public CourseStatsViewModel GetStats()
    {
        return new CourseStatsViewModel
        {
            TotalCourses = _courses.Count,
            TotalAvailableSeats = _courses.Sum(c => c.AvailableSeats),
            TotalExpectedRevenue = _courses.Sum(c => c.TuitionFee * c.AvailableSeats),
            FullCourseCount = _courses.Count(c => c.AvailableSeats <= 0),
            AlmostFullCount = _courses.Count(c => c.AvailableSeats > 0 && c.AvailableSeats <= c.WarningThreshold)
        };
    }

    public List<Course> Search(string? keyword, decimal? minFee)
    {
        var query = _courses.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            query = query.Where(c => 
                c.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                c.CourseCode.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                c.Department.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        if (minFee.HasValue)
        {
            query = query.Where(c => c.TuitionFee >= minFee.Value);
        }

        return query.ToList();
    }

    public Course Create(CourseCreateViewModel model)
    {
        var newId = _courses.Count == 0 ? 1 : _courses.Max(c => c.Id) + 1;
        var course = new Course
        {
            Id = newId,
            CourseCode = $"NEW-{newId:D3}", 
            Title = model.Title,
            Department = model.Department,
            Instructor = model.Instructor,
            TuitionFee = model.TuitionFee,
            AvailableSeats = model.AvailableSeats,
            WarningThreshold = model.WarningThreshold,
            LastUpdatedAt = DateTime.Now
        };
        _courses.Add(course);
        return course;
    }
}