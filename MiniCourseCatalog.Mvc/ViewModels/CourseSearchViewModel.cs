namespace MiniCourseCatalog.Mvc.ViewModels;

public class CourseSearchViewModel
{
    public string Keyword { get; set; } = "";
    public decimal? MinFee { get; set; }
    public List<CourseListItemViewModel> Courses { get; set; } = new();
}