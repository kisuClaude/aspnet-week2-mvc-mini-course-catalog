using Microsoft.AspNetCore.Mvc;
using MiniCourseCatalog.Mvc.Services;
using System.Threading.Tasks;

namespace MiniCourseCatalog.Mvc.Controllers;

public class CourseCategoriesController : Controller
{
    private readonly ICourseService _courseService;

    public CourseCategoriesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _courseService.GetCategoriesWithCountsAsync();
        return View(categories);
    }
}
