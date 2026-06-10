using System;

namespace MiniCourseCatalog.Mvc.ViewModels;

public class DataHealthViewModel
{
    // Options values
    public string AppName { get; set; } = string.Empty;
    public string SupportEmail { get; set; } = string.Empty;
    public int ConfiguredLowSeatThreshold { get; set; }
    public bool EnableSeedData { get; set; }

    // Db Diagnostic stats
    public bool CanConnectToDb { get; set; }
    public int TotalCourses { get; set; }
    public int TotalCategories { get; set; }
    public int TotalStudents { get; set; }
    public int TotalEnrollments { get; set; }

    // Tracking diagnostic tests
    public string ReadOnlyQueryTrackingBehavior { get; set; } = "Unknown";
    public string UpdateQueryTrackingBehavior { get; set; } = "Unknown";

    // Transaction verification results
    public string TransactionTestResult { get; set; } = string.Empty;
}
