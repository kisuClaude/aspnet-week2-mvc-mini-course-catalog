namespace MiniCourseCatalog.Mvc.ViewModels;

public class CourseListItemViewModel
{
    public int Id { get; set; }
    public string CourseCode { get; set; } = "";
    public string Title { get; set; } = "";
    public string Department { get; set; } = "";
    public decimal TuitionFee { get; set; }
    public int AvailableSeats { get; set; }
    public int WarningThreshold { get; set; }

    public string FeeText => $"{TuitionFee:N0} VND";
    public decimal PotentialRevenue => TuitionFee * AvailableSeats;
    public string PotentialRevenueText => $"{PotentialRevenue:N0} VND";

    public string EnrollmentStatus
    {
        get
        {
            if (AvailableSeats <= 0) return "Đã đầy";
            if (AvailableSeats <= WarningThreshold) return "Sắp đầy";
            return "Còn chỗ";
        }
    }

    public string EnrollmentStatusClass
    {
        get
        {
            if (AvailableSeats <= 0) return "badge badge-danger";
            if (AvailableSeats <= WarningThreshold) return "badge badge-warning";
            return "badge badge-success";
        }
    }
}