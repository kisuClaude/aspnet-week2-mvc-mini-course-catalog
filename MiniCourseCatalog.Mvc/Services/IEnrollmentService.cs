using System.Collections.Generic;
using System.Threading.Tasks;
using MiniCourseCatalog.Mvc.ViewModels;

namespace MiniCourseCatalog.Mvc.Services;

public interface IEnrollmentService
{
    Task<List<EnrollmentHistoryViewModel>> GetEnrollmentHistoryAsync();
    Task<List<StudentViewModel>> GetStudentsListAsync();
    Task<EnrollmentFormViewModel> GetEnrollmentFormDetailsAsync();
    Task CreateEnrollmentTransactionAsync(EnrollmentCreateViewModel model);
}
