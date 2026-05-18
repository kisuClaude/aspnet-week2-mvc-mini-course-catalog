namespace MiniCourseCatalog.Mvc.ViewModels;

public class CourseDetailViewModel
{
    public int Id { get; set; }
    public string CourseCode { get; set; } = "";
    public string Title { get; set; } = "";
    public string Department { get; set; } = "";
    public string Instructor { get; set; } = "";
    public decimal TuitionFee { get; set; }
    public int AvailableSeats { get; set; }
    public int WarningThreshold { get; set; }
    public DateTime LastUpdatedAt { get; set; }

    public string FeeText => $"{TuitionFee:N0} VND";
    public string LastUpdatedText => LastUpdatedAt.ToString("dd/MM/yyyy HH:mm");

    public string EnrollmentStatus
    {
        get
        {
            if (AvailableSeats <= 0) return "Đã đầy";
            if (AvailableSeats <= WarningThreshold) return "Sắp đầy";
            return "Còn chỗ";
        }
    }

    public string AdvisorySuggestion
    {
        get
        {
            if (AvailableSeats <= 0) return "Khóa học đã đóng đăng ký do kín chỗ.";
            if (AvailableSeats <= WarningThreshold) return $"Nên khuyên sinh viên đăng ký ngay. Chỉ còn {AvailableSeats} chỗ.";
            return "Khóa học vẫn mở, sinh viên có thể đăng ký bình thường.";
        }
    }
}