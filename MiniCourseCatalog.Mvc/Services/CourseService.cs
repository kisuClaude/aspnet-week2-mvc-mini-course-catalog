using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MiniCourseCatalog.Mvc.Models;
using MiniCourseCatalog.Mvc.Options;
using MiniCourseCatalog.Mvc.Repositories;
using MiniCourseCatalog.Mvc.ViewModels;

namespace MiniCourseCatalog.Mvc.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly AppSettings _settings;

    public CourseService(ICourseRepository courseRepository, IOptions<AppSettings> options)
    {
        _courseRepository = courseRepository;
        _settings = options.Value;
    }

    public async Task<List<CourseListItemViewModel>> GetCourseListAsync()
    {
        var courses = await _courseRepository.GetAllReadOnlyAsync();
        return courses.Select(MapToListItem).ToList();
    }

    public async Task<List<CourseListItemViewModel>> GetFilteredCoursesAsync(int? categoryId, decimal? minFee, decimal? maxFee)
    {
        var courses = await _courseRepository.GetFilteredAsync(categoryId, minFee, maxFee);
        return courses.Select(MapToListItem).ToList();
    }

    public async Task<CourseDetailViewModel?> GetCourseDetailAsync(int id)
    {
        var course = await _courseRepository.GetByIdAsync(id);
        if (course == null) return null;

        return new CourseDetailViewModel
        {
            Id = course.Id,
            CourseCode = course.CourseCode,
            CourseSku = course.CourseSku,
            Title = course.Title,
            Department = course.Department,
            Instructor = course.Instructor,
            TuitionFee = course.TuitionFee,
            AvailableSeats = course.AvailableSeats,
            WarningThreshold = course.WarningThreshold,
            LastUpdatedAt = course.LastUpdatedAt,
            CategoryName = course.Category?.Name ?? "Không xác định",
            // Flag if the course is low on seats (using Option Pattern limit)
            IsSlightlyEmpty = course.AvailableSeats > 0 && course.AvailableSeats <= _settings.LowSeatThreshold
        };
    }

    public async Task<CourseStatsViewModel> GetStatsAsync()
    {
        var courses = await _courseRepository.GetAllReadOnlyAsync();
        return new CourseStatsViewModel
        {
            TotalCourses = courses.Count,
            TotalAvailableSeats = courses.Sum(c => c.AvailableSeats),
            TotalExpectedRevenue = courses.Sum(c => c.TuitionFee * c.AvailableSeats),
            FullCourseCount = courses.Count(c => c.AvailableSeats <= 0),
            // Use LowSeatThreshold from strongly-typed Options instead of a hardcoded value!
            AlmostFullCount = courses.Count(c => c.AvailableSeats > 0 && c.AvailableSeats <= _settings.LowSeatThreshold)
        };
    }

    public async Task<List<CourseCategoryViewModel>> GetCategoriesWithCountsAsync()
    {
        var categories = await _courseRepository.GetCategoriesWithCoursesAsync();
        return categories.Select(c => new CourseCategoryViewModel
        {
            Id = c.Id,
            Name = c.Name,
            Code = c.Code,
            CourseCount = c.Courses.Count
        }).ToList();
    }

    public async Task CreateCourseAsync(CourseCreateViewModel model)
    {
        // Default category code mapping or default CategoryId
        var course = new Course
        {
            CourseCode = model.CourseCode,
            CourseSku = model.CourseSku,
            Title = model.Title,
            Department = model.Department,
            Instructor = model.Instructor,
            TuitionFee = model.TuitionFee,
            AvailableSeats = model.AvailableSeats,
            WarningThreshold = model.WarningThreshold,
            CategoryId = model.CategoryId > 0 ? model.CategoryId : 1, // Fallback default category
            LastUpdatedAt = DateTime.Now
        };

        await _courseRepository.AddAsync(course);
        await _courseRepository.SaveChangesAsync();
    }

    private CourseListItemViewModel MapToListItem(Course course)
    {
        return new CourseListItemViewModel
        {
            Id = course.Id,
            CourseCode = course.CourseCode,
            CourseSku = course.CourseSku,
            Title = course.Title,
            Department = course.Department,
            TuitionFee = course.TuitionFee,
            AvailableSeats = course.AvailableSeats,
            WarningThreshold = course.WarningThreshold,
            CategoryName = course.Category?.Name ?? "Không xác định",
            // Apply strongly-typed config for UI highlights
            IsLowSeats = course.AvailableSeats > 0 && course.AvailableSeats <= _settings.LowSeatThreshold
        };
    }
}