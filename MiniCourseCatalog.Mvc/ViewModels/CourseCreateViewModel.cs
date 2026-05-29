using System.ComponentModel.DataAnnotations;

namespace MiniCourseCatalog.Mvc.ViewModels;

public class CourseCreateViewModel
{
    [Required(ErrorMessage = "Tên khóa học không được để trống")]
    [StringLength(100, ErrorMessage = "Tên khóa học không được vượt quá 100 ký tự")]
    public string Title { get; set; } = "";

    [Required(ErrorMessage = "Khoa/Ban không được để trống")]
    public string Department { get; set; } = "";

    [Required(ErrorMessage = "Tên giảng viên không được để trống")]
    public string Instructor { get; set; } = "";

    [Range(0, 50000000, ErrorMessage = "Học phí phải từ 0 đến 50.000.000")]
    public decimal TuitionFee { get; set; }

    [Range(1, 500, ErrorMessage = "Số lượng chỗ phải từ 1 đến 500")]
    public int AvailableSeats { get; set; }

    [Range(1, 100, ErrorMessage = "Ngưỡng cảnh báo phải từ 1 đến 100")]
    public int WarningThreshold { get; set; }
}