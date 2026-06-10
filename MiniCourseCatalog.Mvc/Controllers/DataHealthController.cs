using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MiniCourseCatalog.Mvc.Data;
using MiniCourseCatalog.Mvc.Models;
using MiniCourseCatalog.Mvc.Options;
using MiniCourseCatalog.Mvc.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCourseCatalog.Mvc.Controllers;

public class DataHealthController : Controller
{
    private readonly AppDbContext _context;
    private readonly AppSettings _settings;

    public DataHealthController(AppDbContext context, IOptions<AppSettings> options)
    {
        _context = context;
        _settings = options.Value;
    }

    public async Task<IActionResult> Index()
    {
        var model = new DataHealthViewModel
        {
            AppName = _settings.AppName,
            SupportEmail = _settings.SupportEmail,
            ConfiguredLowSeatThreshold = _settings.LowSeatThreshold,
            EnableSeedData = _settings.EnableSeedData
        };

        try
        {
            model.CanConnectToDb = await _context.Database.CanConnectAsync();
            if (model.CanConnectToDb)
            {
                model.TotalCourses = await _context.Courses.CountAsync();
                model.TotalCategories = await _context.CourseCategories.CountAsync();
                model.TotalStudents = await _context.Students.CountAsync();
                model.TotalEnrollments = await _context.Enrollments.CountAsync();

                // 1. Diagnose AsNoTracking Read-Only behaviors
                // When queried with AsNoTracking, the entities are not tracked by DbContext ChangeTracker.
                var tempCourseNoTracking = await _context.Courses.AsNoTracking().FirstOrDefaultAsync();
                if (tempCourseNoTracking != null)
                {
                    bool isTracked = _context.Entry(tempCourseNoTracking).State != EntityState.Detached;
                    model.ReadOnlyQueryTrackingBehavior = isTracked 
                        ? "Tracking (Not Expected for AsNoTracking)" 
                        : "AsNoTracking (Success: Entity is Detached)";
                }

                // 2. Diagnose Tracking Update behaviors
                var tempCourseTracking = await _context.Courses.FirstOrDefaultAsync();
                if (tempCourseTracking != null)
                {
                    bool isTracked = _context.Entry(tempCourseTracking).State == EntityState.Unchanged;
                    model.UpdateQueryTrackingBehavior = isTracked 
                        ? "Tracking Active (Success: Entity is Tracked as Unchanged)" 
                        : "Detached (Not Expected for write-updates)";
                }
            }
        }
        catch (Exception ex)
        {
            model.CanConnectToDb = false;
            model.TransactionTestResult = $"Database connection error: {ex.Message}";
        }

        return View(model);
    }

    // Trigger dynamic diagnostic transaction rollback verification check
    [HttpPost]
    public async Task<IActionResult> VerifyTransactionRollback()
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // Create a fake test student
            var testStudent = new Student { FullName = "Test Rollback Student", Email = "rollback@test.com" };
            _context.Students.Add(testStudent);
            await _context.SaveChangesAsync();

            // Create a fake enrollment
            var enrollment = new Enrollment
            {
                StudentId = testStudent.Id,
                EnrollmentDate = DateTime.Now,
                TotalTuition = 1000000,
                Remarks = "Test Transaction Rollback"
            };
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            // Intentionally force an error by registering with an invalid course ID
            var invalidDetail = new EnrollmentDetail
            {
                EnrollmentId = enrollment.Id,
                CourseId = -999, // Force DbUpdateException / ForeignKey constraint check failure
                PriceApplied = 1000000
            };
            _context.EnrollmentDetails.Add(invalidDetail);
            await _context.SaveChangesAsync(); // Should throw and trigger catch

            await transaction.CommitAsync();
            TempData["TransactionTestMessage"] = "Test failed: Enrollment saved despite constraint violations (No rollback occurred).";
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            TempData["TransactionTestMessage"] = $"SUCCESS: Transaction was successfully rolled back! Exception caught: {ex.InnerException?.Message ?? ex.Message}";
        }

        return RedirectToAction(nameof(Index));
    }
}
