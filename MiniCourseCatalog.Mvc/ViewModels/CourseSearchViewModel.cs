using System.Collections.Generic;

namespace MiniCourseCatalog.Mvc.ViewModels;

public class CourseSearchViewModel
{
    public string Keyword { get; set; } = string.Empty;
    public decimal? MinFee { get; set; }
    public decimal? MaxFee { get; set; }
    public int? CategoryId { get; set; }
    public List<CourseListItemViewModel> Courses { get; set; } = new();
    
    // For dropdown filter lists
    public List<CourseCategoryViewModel> Categories { get; set; } = new();
}