using System;
using System.Collections.Generic;

namespace MiniCourseCatalog.Mvc.ViewModels;

public class EnrollmentHistoryViewModel
{
    public int EnrollmentId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }
    public decimal TotalTuition { get; set; }
    public string Remarks { get; set; } = string.Empty;
    public List<EnrollmentDetailHistoryViewModel> Details { get; set; } = new();
}

public class EnrollmentDetailHistoryViewModel
{
    public string CourseTitle { get; set; } = string.Empty;
    public string CourseCode { get; set; } = string.Empty;
    public string CourseSku { get; set; } = string.Empty;
    public decimal TuitionApplied { get; set; }
}
