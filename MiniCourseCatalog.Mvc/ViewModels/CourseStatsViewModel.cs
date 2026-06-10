using System.Globalization;

namespace MiniCourseCatalog.Mvc.ViewModels;

public class CourseStatsViewModel
{
    public int TotalCourses { get; set; }
    public int TotalAvailableSeats { get; set; }
    public decimal TotalExpectedRevenue { get; set; }
    public int FullCourseCount { get; set; }
    public int AlmostFullCount { get; set; }

    public string TotalExpectedRevenueText => TotalExpectedRevenue.ToString("C0", new CultureInfo("vi-VN"));
}