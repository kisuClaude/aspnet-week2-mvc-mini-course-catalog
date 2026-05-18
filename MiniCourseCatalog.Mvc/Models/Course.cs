namespace MiniCourseCatalog.Mvc.Models;

public class Course
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
}