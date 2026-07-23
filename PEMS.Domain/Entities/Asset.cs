using System.ComponentModel.DataAnnotations;

namespace PEMS.Domain.Entities;

public class Asset
{
    [Key]
    public int AssetId { get; set; }

    // ارتباط با Equipment
    public int EquipmentId { get; set; }

    public Equipment? Equipment { get; set; }

    // شماره Asset
    // مثال: AST-P101
    public string AssetNumber { get; set; } = string.Empty;

    // محل عملکردی
    // مثال: Unit-100 / Area-A
    public string? FunctionalLocation { get; set; }

    // اهمیت تجهیز
    // Critical, High, Medium, Low
    public string? Criticality { get; set; }

    // کلاس تعمیراتی
    // Rotating, Static, Electrical...
    public string? MaintenanceClass { get; set; }

    // تاریخ راه‌اندازی
    public DateTime? CommissioningDate { get; set; }

    // وضعیت تجهیز
    // Active, Standby, Retired
    public string Status { get; set; } = "Active";

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public bool IsActive { get; set; } = true;
}