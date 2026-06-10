using Microsoft.AspNetCore.Mvc;
using MiniCourseCatalog.Mvc.Services;
using MiniCourseCatalog.Mvc.ViewModels;
using System.Threading.Tasks;

namespace MiniCourseCatalog.Mvc.Controllers;

public class CoursesController : Controller
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IActionResult> Index()
    {
        var courses = await _courseService.GetCourseListAsync();
        return View(courses);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var course = await _courseService.GetCourseDetailAsync(id);
        if (course == null)
        {
            return NotFound($"Không tìm thấy khóa học có id = {id}");
        }
        return View(course);
    }

    public async Task<IActionResult> Stats()
    {
        var stats = await _courseService.GetStatsAsync();
        return View(stats);
    }

    [HttpGet]
    public async Task<IActionResult> Search(string? keyword, decimal? minFee)
    {
        var courses = await _courseService.GetFilteredCoursesAsync(null, minFee, null);
        if (!string.IsNullOrWhiteSpace(keyword))
        {
            courses = courses.Where(c => 
                c.Title.Contains(keyword, System.StringComparison.OrdinalIgnoreCase) ||
                c.CourseCode.Contains(keyword, System.StringComparison.OrdinalIgnoreCase) ||
                c.Department.Contains(keyword, System.StringComparison.OrdinalIgnoreCase)).ToList();
        }

        var viewModel = new CourseSearchViewModel
        {
            Keyword = keyword ?? "",
            MinFee = minFee,
            Courses = courses
        };
        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Filter(int? categoryId, decimal? minPrice, decimal? maxPrice)
    {
        var categories = await _courseService.GetCategoriesWithCountsAsync();
        var courses = await _courseService.GetFilteredCoursesAsync(categoryId, minPrice, maxPrice);

        var viewModel = new CourseSearchViewModel
        {
            CategoryId = categoryId,
            MinFee = minPrice,
            MaxFee = maxPrice,
            Courses = courses,
            Categories = categories
        };
        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var categories = await _courseService.GetCategoriesWithCountsAsync();
        ViewBag.Categories = categories;
        
        var viewModel = new CourseCreateViewModel 
        { 
            AvailableSeats = 30, 
            WarningThreshold = 5
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CourseCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var categories = await _courseService.GetCategoriesWithCountsAsync();
            ViewBag.Categories = categories;
            return View(model);
        }

        await _courseService.CreateCourseAsync(model);
        TempData["SuccessMessage"] = $"Đã thêm thành công khóa học: {model.Title}";
        return RedirectToAction(nameof(Index)); 
    }
}
