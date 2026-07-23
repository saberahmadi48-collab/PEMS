using System.ComponentModel.DataAnnotations;

namespace PEMS.Domain.Entities;

public class Equipment
{
    [Key]
    public int EquipmentId { get; set; }

    // شماره تگ تجهیز
    public string TagNumber { get; set; } = string.Empty;

    // نام تجهیز
    public string Name { get; set; } = string.Empty;

    // نوع تجهیز
    // Pump, Motor, Valve, Instrument, Tank ...
    public string EquipmentType { get; set; } = string.Empty;

    // ارتباط با پروژه
    public int ProjectId { get; set; }

    public Project? Project { get; set; }

    // ارتباط با دیسیپلین
    public int DisciplineId { get; set; }

    public Discipline? Discipline { get; set; }

    // سازنده
    public string? Manufacturer { get; set; }

    // مدل
    public string? Model { get; set; }

    // شماره سریال
    public string? SerialNumber { get; set; }

    // وضعیت تجهیز
    // Active, Spare, Retired
    public string Status { get; set; } = "Active";

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;
}