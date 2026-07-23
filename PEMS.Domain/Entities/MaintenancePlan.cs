using System.ComponentModel.DataAnnotations;

namespace PEMS.Domain.Entities;

public class MaintenancePlan
{
    [Key]
    public int MaintenancePlanId { get; set; }

    // تجهیز مرتبط
    public int EquipmentId { get; set; }

    public Equipment? Equipment { get; set; }

    // استراتژی نگهداری
    public int MaintenanceStrategyId { get; set; }

    public MaintenanceStrategy? MaintenanceStrategy { get; set; }

    // شماره برنامه
    // مثال: PM-P101-001
    public string PlanNumber { get; set; } = string.Empty;

    // عنوان برنامه
    public string Title { get; set; } = string.Empty;

    // فاصله زمانی اجرا بر حسب روز
    public int? IntervalDays { get; set; }

    // آخرین تاریخ اجرا
    public DateTime? LastExecutionDate { get; set; }

    // تاریخ اجرای بعدی
    public DateTime? NextDueDate { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;
}