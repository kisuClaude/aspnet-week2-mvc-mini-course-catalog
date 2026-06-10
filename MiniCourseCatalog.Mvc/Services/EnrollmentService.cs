using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniCourseCatalog.Mvc.Models;
using MiniCourseCatalog.Mvc.Repositories;
using MiniCourseCatalog.Mvc.ViewModels;

namespace MiniCourseCatalog.Mvc.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly ICourseRepository _courseRepository;

    public EnrollmentService(IEnrollmentRepository enrollmentRepository, ICourseRepository courseRepository)
    {
        _enrollmentRepository = enrollmentRepository;
        _courseRepository = courseRepository;
    }

    public async Task<List<EnrollmentHistoryViewModel>> GetEnrollmentHistoryAsync()
    {
        var enrollments = await _enrollmentRepository.GetAllReadOnlyAsync();
        return enrollments.Select(e => new EnrollmentHistoryViewModel
        {
            EnrollmentId = e.Id,
            StudentName = e.Student?.FullName ?? "Không xác định",
            EnrollmentDate = e.EnrollmentDate,
            TotalTuition = e.TotalTuition,
            Remarks = e.Remarks,
            Details = e.EnrollmentDetails.Select(d => new EnrollmentDetailHistoryViewModel
            {
                CourseTitle = d.Course?.Title ?? "Khóa học đã xóa",
                CourseCode = d.Course?.CourseCode ?? "N/A",
                CourseSku = d.Course?.CourseSku ?? "N/A",
                TuitionApplied = d.PriceApplied
            }).ToList()
        }).ToList();
    }

    public async Task<List<StudentViewModel>> GetStudentsListAsync()
    {
        var students = await _enrollmentRepository.GetStudentsAsync();
        return students.Select(s => new StudentViewModel
        {
            Id = s.Id,
            FullName = s.FullName,
            Email = s.Email
        }).ToList();
    }

    public async Task<EnrollmentFormViewModel> GetEnrollmentFormDetailsAsync()
    {
        var students = await _enrollmentRepository.GetStudentsAsync();
        var courses = await _courseRepository.GetAllReadOnlyAsync();

        return new EnrollmentFormViewModel
        {
            Students = students.Select(s => new StudentViewModel { Id = s.Id, FullName = s.FullName, Email = s.Email }).ToList(),
            Courses = courses.Select(c => new CourseListItemViewModel
            {
                Id = c.Id,
                CourseCode = c.CourseCode,
                CourseSku = c.CourseSku,
                Title = c.Title,
                TuitionFee = c.TuitionFee,
                AvailableSeats = c.AvailableSeats
            }).ToList()
        };
    }

    public async Task CreateEnrollmentTransactionAsync(EnrollmentCreateViewModel model)
    {
        using var transaction = await _enrollmentRepository.BeginTransactionAsync();
        try
        {
            var student = await _enrollmentRepository.GetStudentByIdAsync(model.StudentId);
            if (student == null)
            {
                throw new Exception("Học viên không tồn tại trong hệ thống.");
            }

            var course = await _courseRepository.GetByIdAsync(model.CourseId);
            if (course == null)
            {
                throw new Exception("Khóa học không tồn tại.");
            }

            if (course.AvailableSeats <= 0)
            {
                throw new InvalidOperationException($"Khóa học '{course.Title}' đã hết chỗ đăng ký!");
            }

            var enrollment = new Enrollment
            {
                StudentId = model.StudentId,
                EnrollmentDate = DateTime.Now,
                TotalTuition = course.TuitionFee,
                Remarks = model.Remarks ?? "Đăng ký trực tuyến"
            };

            await _enrollmentRepository.AddAsync(enrollment);
            await _enrollmentRepository.SaveChangesAsync();

            var detail = new EnrollmentDetail
            {
                EnrollmentId = enrollment.Id,
                CourseId = course.Id,
                PriceApplied = course.TuitionFee
            };

            course.AvailableSeats -= 1;
            course.LastUpdatedAt = DateTime.Now;

            await _enrollmentRepository.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
