using Microsoft.AspNetCore.Mvc;
using MiniCourseCatalog.Mvc.Services;
using MiniCourseCatalog.Mvc.ViewModels;
using System;
using System.Threading.Tasks;

namespace MiniCourseCatalog.Mvc.Controllers;

public class EnrollmentsController : Controller
{
    private readonly IEnrollmentService _enrollmentService;

    public EnrollmentsController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    public async Task<IActionResult> Index()
    {
        var history = await _enrollmentService.GetEnrollmentHistoryAsync();
        return View(history);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var details = await _enrollmentService.GetEnrollmentFormDetailsAsync();
        return View(details);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EnrollmentCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var details = await _enrollmentService.GetEnrollmentFormDetailsAsync();
            details.FormModel = model;
            return View(details);
        }

        try
        {
            await _enrollmentService.CreateEnrollmentTransactionAsync(model);
            TempData["SuccessMessage"] = "Đăng ký khóa học thành công! (Số ghế khả dụng đã được giảm)";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Đăng ký thất bại: {ex.Message}";
            var details = await _enrollmentService.GetEnrollmentFormDetailsAsync();
            details.FormModel = model;
            return View(details);
        }
    }
}
