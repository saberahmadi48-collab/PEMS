using System.ComponentModel.DataAnnotations;

namespace PEMS.Domain.Entities;

public class DocumentWorkflow
{
    [Key]
    public int WorkflowId { get; set; }

    // مدرک مرتبط
    public int DocumentId { get; set; }

    public EngineeringDocument? Document { get; set; }

    // وضعیت قبلی
    public string FromStatus { get; set; } = string.Empty;

    // وضعیت جدید
    public string ToStatus { get; set; } = string.Empty;

    // توضیحات اقدام
    public string? Comment { get; set; }

    // زمان تغییر وضعیت
    public DateTime ActionDate { get; set; } = DateTime.Now;

    // شخص انجام دهنده عملیات
    public int? ActionById { get; set; }

    public Employee? ActionBy { get; set; }

    public bool IsActive { get; set; } = true;
}