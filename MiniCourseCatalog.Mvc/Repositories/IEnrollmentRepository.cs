using System.Collections.Generic;
using System.Threading.Tasks;
using MiniCourseCatalog.Mvc.Models;

namespace MiniCourseCatalog.Mvc.Repositories;

public interface IEnrollmentRepository
{
    Task<List<Enrollment>> GetAllReadOnlyAsync();
    Task<List<Student>> GetStudentsAsync();
    Task<Student?> GetStudentByIdAsync(int id);
    Task AddAsync(Enrollment enrollment);
    Task SaveChangesAsync();
    Task<Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction> BeginTransactionAsync();
}
