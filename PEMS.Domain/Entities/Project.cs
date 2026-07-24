namespace PEMS.Domain.Entities;

public class Project
{
    public int ProjectId { get; set; }

    // کد یکتا پروژه
    public string ProjectCode { get; set; } = string.Empty;

    // نام پروژه
    public string ProjectName { get; set; } = string.Empty;

    // کارفرما
    public string? ClientName { get; set; }

    // محل اجرای پروژه
    public string? Location { get; set; }

    // تاریخ شروع
    public DateTime? StartDate { get; set; }

    // تاریخ پایان
    public DateTime? EndDate { get; set; }

    // وضعیت پروژه
    // Planning, Active, Completed, Cancelled
    public string Status { get; set; } = "Planning";

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public ICollection<EngineeringDocument> EngineeringDocuments { get; set; }
= new List<EngineeringDocument>();
}