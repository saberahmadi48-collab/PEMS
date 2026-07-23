using System.ComponentModel.DataAnnotations;

namespace PEMS.Domain.Entities;

public class MaintenanceSpareUsage
{
    [Key]
    public int MaintenanceSpareUsageId { get; set; }

    // دستور کار مرتبط
    public int WorkOrderId { get; set; }

    public WorkOrder? WorkOrder { get; set; }

    // قطعه مصرفی
    public int SparePartId { get; set; }

    public SparePart? SparePart { get; set; }

    // تعداد مصرف
    public decimal Quantity { get; set; }

    // قیمت واحد
    public decimal? UnitCost { get; set; }

    // هزینه کل
    public decimal? TotalCost { get; set; }

    // تاریخ مصرف
    public DateTime UsageDate { get; set; } = DateTime.Now;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public bool IsActive { get; set; } = true;
}