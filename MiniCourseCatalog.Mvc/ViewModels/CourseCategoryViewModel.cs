namespace MiniCourseCatalog.Mvc.ViewModels;

public class CourseCategoryViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public int CourseCount { get; set; }
}
