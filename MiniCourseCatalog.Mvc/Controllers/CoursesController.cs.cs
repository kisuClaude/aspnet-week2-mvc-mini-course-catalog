using Microsoft.AspNetCore.Mvc;
using MiniCourseCatalog.Mvc.Models;
using MiniCourseCatalog.Mvc.Services;
using MiniCourseCatalog.Mvc.ViewModels;

namespace MiniCourseCatalog.Mvc.Controllers;

public class CoursesController : Controller
{
    private readonly CourseService _courseService;

    public CoursesController(CourseService courseService)
    {
        _courseService = courseService;
    }

    public IActionResult Index()
    {
        var courses = _courseService.GetAll().Select(ToListItemViewModel).ToList();
        return View(courses);
    }

    public IActionResult Detail(int id)
    {
        var course = _courseService.GetById(id);
        if (course == null)
        {
            return NotFound($"Không tìm thấy khóa học có id = {id}");
        }
        return View(ToDetailViewModel(course));
    }

    public IActionResult Stats()
    {
        return View(_courseService.GetStats());
    }

    public IActionResult Welcome()
    {
        return Content("Chào mừng bạn đến với hệ thống quản lý khóa học MVC.");
    }

    public IActionResult CourseJson()
    {
        return Json(_courseService.GetAll());
    }

    public IActionResult GoToList()
    {
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Force404()
    {
        return NotFound("Đây là response 404 từ action Force404.");
    }

    private static CourseListItemViewModel ToListItemViewModel(Course course)
    {
        return new CourseListItemViewModel
        {
            Id = course.Id, CourseCode = course.CourseCode, Title = course.Title,
            Department = course.Department, TuitionFee = course.TuitionFee,
            AvailableSeats = course.AvailableSeats, WarningThreshold = course.WarningThreshold
        };
    }

    private static CourseDetailViewModel ToDetailViewModel(Course course)
    {
        return new CourseDetailViewModel
        {
            Id = course.Id, CourseCode = course.CourseCode, Title = course.Title,
            Department = course.Department, Instructor = course.Instructor,
            TuitionFee = course.TuitionFee, AvailableSeats = course.AvailableSeats,
            WarningThreshold = course.WarningThreshold, LastUpdatedAt = course.LastUpdatedAt
        };
    }

    [HttpGet]
    public IActionResult Search(string? keyword, decimal? minFee)
    {
        var courses = _courseService.Search(keyword, minFee)
            .Select(ToListItemViewModel).ToList();

        var viewModel = new CourseSearchViewModel
        {
            Keyword = keyword ?? "",
            MinFee = minFee,
            Courses = courses
        };
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var viewModel = new CourseCreateViewModel 
        { 
            AvailableSeats = 30, 
            WarningThreshold = 5
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CourseCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _courseService.Create(model);
        TempData["SuccessMessage"] = $"Đã thêm thành công khóa học: {model.Title}";
        return RedirectToAction(nameof(Index)); 
    }
}