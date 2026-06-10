using System.Globalization;

namespace MiniCourseCatalog.Mvc.ViewModels;

public class CourseListItemViewModel
{
    public int Id { get; set; }
    public string CourseCode { get; set; } = string.Empty;
    public string CourseSku { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public decimal TuitionFee { get; set; }
    public int AvailableSeats { get; set; }
    public int WarningThreshold { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    
    // Configured low stock styling state
    public bool IsLowSeats { get; set; }

    // Display helpers preserved or added for Views
    public string FeeText => TuitionFee.ToString("C0", new CultureInfo("vi-VN"));

    public string EnrollmentStatus => AvailableSeats <= 0 ? "Hết chỗ" : "Còn nhận đăng ký";

    public string EnrollmentStatusClass => AvailableSeats <= 0 ? "badge-danger" : "badge-success";
}