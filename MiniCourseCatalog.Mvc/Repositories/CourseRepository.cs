using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniCourseCatalog.Mvc.Data;
using MiniCourseCatalog.Mvc.Models;

namespace MiniCourseCatalog.Mvc.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _context;

    public CourseRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Course>> GetAllAsync()
    {
        return _context.Courses
            .Include(c => c.Category)
            .ToListAsync();
    }

    public Task<List<Course>> GetAllReadOnlyAsync()
    {
        return _context.Courses
            .Include(c => c.Category)
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<List<Course>> GetFilteredAsync(int? categoryId, decimal? minFee, decimal? maxFee)
    {
        var query = _context.Courses
            .Include(c => c.Category)
            .AsNoTracking();

        if (categoryId.HasValue)
        {
            query = query.Where(c => c.CategoryId == categoryId.Value);
        }

        if (minFee.HasValue)
        {
            query = query.Where(c => c.TuitionFee >= minFee.Value);
        }

        if (maxFee.HasValue)
        {
            query = query.Where(c => c.TuitionFee <= maxFee.Value);
        }

        return query.ToListAsync();
    }

    public Task<List<CourseCategory>> GetCategoriesWithCoursesAsync()
    {
        return _context.CourseCategories
            .Include(c => c.Courses)
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<Course?> GetByIdAsync(int id)
    {
        return _context.Courses
            .Include(c => c.Category)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
