using System;
using System.ComponentModel.DataAnnotations;

namespace MiniCourseCatalog.Mvc.ViewModels;

public class CourseCreateViewModel
{
    [Required(ErrorMessage = "Mã khóa học là bắt buộc.")]
    [StringLength(20, ErrorMessage = "Mã khóa học không quá 20 ký tự.")]
    [Display(Name = "Mã khóa học")]
    public string CourseCode { get; set; } = string.Empty;

    [Required(ErrorMessage = "SKU khóa học là bắt buộc.")]
    [StringLength(50, ErrorMessage = "SKU khóa học không quá 50 ký tự.")]
    [Display(Name = "SKU khóa học")]
    public string CourseSku { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tiêu đề khóa học là bắt buộc.")]
    [StringLength(150, ErrorMessage = "Tiêu đề không được vượt quá 150 ký tự.")]
    [Display(Name = "Tiêu đề")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Khoa/Bộ môn phụ trách là bắt buộc.")]
    [StringLength(100, ErrorMessage = "Tên khoa không quá 100 ký tự.")]
    [Display(Name = "Khoa phụ trách")]
    public string Department { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tên giảng viên là bắt buộc.")]
    [StringLength(100, ErrorMessage = "Tên giảng viên không quá 100 ký tự.")]
    [Display(Name = "Giảng viên")]
    public string Instructor { get; set; } = string.Empty;

    [Range(0, 100000000, ErrorMessage = "Học phí phải từ 0 đến 100,000,000đ.")]
    [Display(Name = "Học phí (VNĐ)")]
    public decimal TuitionFee { get; set; }

    [Range(0, 1000, ErrorMessage = "Số chỗ tối đa từ 0 đến 1000.")]
    [Display(Name = "Số chỗ hiện có")]
    public int AvailableSeats { get; set; }

    [Range(0, 100, ErrorMessage = "Ngưỡng cảnh báo từ 0 đến 100.")]
    [Display(Name = "Ngưỡng cảnh báo sắp hết chỗ")]
    public int WarningThreshold { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn danh mục khóa học.")]
    [Display(Name = "Danh mục khóa học")]
    public int CategoryId { get; set; }
}