using System.Collections.Generic;
using System.Threading.Tasks;
using MiniCourseCatalog.Mvc.Models;

namespace MiniCourseCatalog.Mvc.Repositories;

public interface ICourseRepository
{
    Task<List<Course>> GetAllAsync();
    Task<List<Course>> GetAllReadOnlyAsync();
    Task<List<Course>> GetFilteredAsync(int? categoryId, decimal? minFee, decimal? maxFee);
    Task<List<CourseCategory>> GetCategoriesWithCoursesAsync();
    Task<Course?> GetByIdAsync(int id);
    Task AddAsync(Course course);
    Task SaveChangesAsync();
}
