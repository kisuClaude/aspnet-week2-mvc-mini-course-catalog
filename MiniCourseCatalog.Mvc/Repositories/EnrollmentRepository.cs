using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MiniCourseCatalog.Mvc.Data;
using MiniCourseCatalog.Mvc.Models;

namespace MiniCourseCatalog.Mvc.Repositories;

public class EnrollmentRepository : IEnrollmentRepository
{
    private readonly AppDbContext _context;

    public EnrollmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Enrollment>> GetAllReadOnlyAsync()
    {
        return _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.EnrollmentDetails)
                .ThenInclude(d => d.Course)
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<List<Student>> GetStudentsAsync()
    {
        return _context.Students.AsNoTracking().ToListAsync();
    }

    public Task<Student?> GetStudentByIdAsync(int id)
    {
        return _context.Students.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Enrollment enrollment)
    {
        await _context.Enrollments.AddAsync(enrollment);
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

    public Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return _context.Database.BeginTransactionAsync();
    }
}
