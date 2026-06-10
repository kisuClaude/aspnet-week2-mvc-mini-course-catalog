using System;
using System.Globalization;

namespace MiniCourseCatalog.Mvc.ViewModels;

public class CourseDetailViewModel
{
    public int Id { get; set; }
    public string CourseCode { get; set; } = string.Empty;
    public string CourseSku { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Instructor { get; set; } = string.Empty;
    public decimal TuitionFee { get; set; }
    public int AvailableSeats { get; set; }
    public int WarningThreshold { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    
    // Dynamic status checks using AppSettings configuration
    public bool IsSlightlyEmpty { get; set; }

    public string FeeText => TuitionFee.ToString("C0", new CultureInfo("vi-VN"));

    public string EnrollmentStatus => AvailableSeats <= 0 ? "Hết chỗ" : "Còn nhận đăng ký";

    public string AdvisorySuggestion => AvailableSeats <= 0 
        ? "Hãy đăng ký các khóa học khác tương đương." 
        : (AvailableSeats <= WarningThreshold ? "Nhanh tay đăng ký vì số chỗ còn lại rất ít!" : "Khóa học hiện đang mở rộng rãi cho học viên.");

    public string LastUpdatedText => LastUpdatedAt.ToString("dd/MM/yyyy HH:mm");
}