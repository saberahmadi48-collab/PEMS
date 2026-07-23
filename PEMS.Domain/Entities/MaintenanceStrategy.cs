using System.ComponentModel.DataAnnotations;

namespace PEMS.Domain.Entities;

public class MaintenanceStrategy
{
    [Key]
    public int MaintenanceStrategyId { get; set; }

    // ارتباط با تجهیز
    public int EquipmentId { get; set; }

    public Equipment? Equipment { get; set; }

    // نوع استراتژی
    // Preventive, Predictive, Corrective, CBM
    public string StrategyType { get; set; } = string.Empty;

    // تناوب انجام
    // Daily, Weekly, Monthly, Yearly
    public string? Frequency { get; set; }

    // شرح فعالیت
    public string? Description { get; set; }

    // تاریخ شروع
    public DateTime? StartDate { get; set; }

    // وضعیت
    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;
}