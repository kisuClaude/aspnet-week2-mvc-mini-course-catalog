using System;
using System.Collections.Generic;

namespace MiniCourseCatalog.Mvc.Models;

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    public DateTime EnrollmentDate { get; set; } = DateTime.Now;
    public decimal TotalTuition { get; set; }
    public string Remarks { get; set; } = string.Empty;
    public ICollection<EnrollmentDetail> EnrollmentDetails { get; set; } = new List<EnrollmentDetail>();
}
