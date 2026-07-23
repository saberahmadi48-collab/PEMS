using System.ComponentModel.DataAnnotations;

namespace PEMS.Domain.Entities;

public class SparePart
{
    [Key]
    public int SparePartId { get; set; }

    // شماره قطعه
    // مثال: BRG-6312
    public string PartNumber { get; set; } = string.Empty;

    // نام قطعه
    public string PartName { get; set; } = string.Empty;

    // سازنده
    public string? Manufacturer { get; set; }

    // مدل / کد سازنده
    public string? Model { get; set; }

    // واحد اندازه‌گیری
    // PCS, SET, KG
    public string? Unit { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public bool IsActive { get; set; } = true;
}