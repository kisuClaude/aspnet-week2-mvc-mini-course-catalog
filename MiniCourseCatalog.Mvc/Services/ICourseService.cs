using System.Collections.Generic;
using System.Threading.Tasks;
using MiniCourseCatalog.Mvc.ViewModels;

namespace MiniCourseCatalog.Mvc.Services;

public interface ICourseService
{
    Task<List<CourseListItemViewModel>> GetCourseListAsync();
    Task<List<CourseListItemViewModel>> GetFilteredCoursesAsync(int? categoryId, decimal? minFee, decimal? maxFee);
    Task<CourseDetailViewModel?> GetCourseDetailAsync(int id);
    Task<CourseStatsViewModel> GetStatsAsync();
    Task<List<CourseCategoryViewModel>> GetCategoriesWithCountsAsync();
    Task CreateCourseAsync(CourseCreateViewModel model);
}
