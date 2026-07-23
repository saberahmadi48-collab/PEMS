using System.ComponentModel.DataAnnotations;

namespace PEMS.Domain.Entities;

public class InspectionRecord
{
    [Key]
    public int InspectionRecordId { get; set; }

    // تجهیز مورد بازرسی
    public int EquipmentId { get; set; }

    public Equipment? Equipment { get; set; }

    // نوع بازرسی
    // Thickness, Visual, Vibration...
    public string InspectionType { get; set; } = string.Empty;

    // تاریخ بازرسی
    public DateTime InspectionDate { get; set; }

    // بازرس
    public string? Inspector { get; set; }

    // نتیجه
    // Acceptable, Reject, Warning
    public string? Result { get; set; }

    // وضعیت تجهیز
    // Good, Fair, Poor
    public string? Condition { get; set; }

    // پیشنهاد اصلاحی
    public string? Recommendation { get; set; }

    // تاریخ بازرسی بعدی
    public DateTime? NextInspectionDate { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public bool IsActive { get; set; } = true;
}