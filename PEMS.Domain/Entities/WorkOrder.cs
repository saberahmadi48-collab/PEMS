using System.ComponentModel.DataAnnotations;

namespace PEMS.Domain.Entities;

public class WorkOrder
{
    [Key]
    public int WorkOrderId { get; set; }

    // تجهیز مرتبط
    public int EquipmentId { get; set; }

    public Equipment? Equipment { get; set; }

    // برنامه نگهداری مرتبط (اختیاری)
    public int? MaintenancePlanId { get; set; }

    public MaintenancePlan? MaintenancePlan { get; set; }

    // شماره دستور کار
    // مثال: WO-2026-0001
    public string WorkOrderNumber { get; set; } = string.Empty;

    // نوع کار
    // Preventive, Corrective, Emergency
    public string WorkOrderType { get; set; } = string.Empty;

    // اولویت
    // Low, Medium, High, Critical
    public string Priority { get; set; } = "Medium";

    // وضعیت
    // Open, Assigned, InProgress, Completed, Closed
    public string Status { get; set; } = "Open";

    // مسئول انجام کار
    public string? AssignedTo { get; set; }

    // تاریخ شروع
    public DateTime? StartDate { get; set; }

    // تاریخ پایان
    public DateTime? CompletionDate { get; set; }

    // شرح فعالیت
    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public bool IsActive { get; set; } = true;
}