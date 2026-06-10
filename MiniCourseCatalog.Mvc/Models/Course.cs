using System;

namespace MiniCourseCatalog.Mvc.Models;

public class Course
{
    public int Id { get; set; }
    public string CourseCode { get; set; } = string.Empty;
    public string CourseSku { get; set; } = string.Empty; // Added new field SKU
    public string Title { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Instructor { get; set; } = string.Empty;
    public decimal TuitionFee { get; set; }
    public int AvailableSeats { get; set; }
    public int WarningThreshold { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    
    // Relationship
    public int CategoryId { get; set; }
    public CourseCategory? Category { get; set; }
}