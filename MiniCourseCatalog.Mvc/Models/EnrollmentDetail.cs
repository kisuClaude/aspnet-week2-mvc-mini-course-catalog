namespace MiniCourseCatalog.Mvc.Models;

public class EnrollmentDetail
{
    public int Id { get; set; }
    public int EnrollmentId { get; set; }
    public Enrollment? Enrollment { get; set; }
    public int CourseId { get; set; }
    public Course? Course { get; set; }
    public decimal PriceApplied { get; set; }
}
