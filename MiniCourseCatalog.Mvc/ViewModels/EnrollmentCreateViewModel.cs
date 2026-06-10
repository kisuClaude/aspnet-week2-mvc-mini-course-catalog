using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniCourseCatalog.Mvc.ViewModels;

public class EnrollmentCreateViewModel
{
    [Required(ErrorMessage = "Vui lòng chọn học viên.")]
    [Display(Name = "Học viên")]
    public int StudentId { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn khóa học.")]
    [Display(Name = "Khóa học")]
    public int CourseId { get; set; }

    [StringLength(250, ErrorMessage = "Ghi chú không quá 250 ký tự.")]
    [Display(Name = "Ghi chú đăng ký")]
    public string? Remarks { get; set; }
}

public class StudentViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class EnrollmentFormViewModel
{
    public List<StudentViewModel> Students { get; set; } = new();
    public List<CourseListItemViewModel> Courses { get; set; } = new();
    public EnrollmentCreateViewModel FormModel { get; set; } = new();
}
