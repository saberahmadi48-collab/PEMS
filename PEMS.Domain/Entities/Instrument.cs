using System.ComponentModel.DataAnnotations;

namespace PEMS.Domain.Entities;

public class Instrument
{
    [Key]
    public int InstrumentId { get; set; }

    // ارتباط با تجهیز اصلی
    public int EquipmentId { get; set; }

    public Equipment? Equipment { get; set; }

    // شماره تگ ابزار دقیق
    public string TagNumber { get; set; } = string.Empty;

    // نوع ابزار
    // PT, LT, FT, TT, Control Valve ...
    public string InstrumentType { get; set; } = string.Empty;

    // سازنده
    public string? Manufacturer { get; set; }

    // مدل
    public string? Model { get; set; }

    // رنج اندازه گیری حد پایین
    public decimal? RangeMin { get; set; }

    // رنج اندازه گیری حد بالا
    public decimal? RangeMax { get; set; }

    // واحد اندازه گیری
    public string? Unit { get; set; }

    // نوع سیگنال
    // 4-20mA, Digital, HART, FF
    public string? SignalType { get; set; }

    // دوره کالیبراسیون (روز)
    public int? CalibrationInterval { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public bool IsActive { get; set; } = true;
}