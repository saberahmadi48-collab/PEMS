using System.ComponentModel.DataAnnotations;

namespace PEMS.Domain.Entities;

public class DocumentRevision
{
    [Key]
    public int RevisionId { get; set; }

    // ارتباط با مدرک اصلی
    public int DocumentId { get; set; }

    public EngineeringDocument? Document { get; set; }

    // شماره Revision
    public string RevisionNo { get; set; } = "00";

    // وضعیت Revision
    // Draft, Review, Approved, Rejected
    public string Status { get; set; } = "Draft";

    // توضیحات تغییرات
    public string? Comment { get; set; }

    // تاریخ Revision
    public DateTime RevisionDate { get; set; } = DateTime.Now;

    // تهیه کننده
    public int? PreparedById { get; set; }

    public Employee? PreparedBy { get; set; }

    // بازبین
    public int? CheckedById { get; set; }

    public Employee? CheckedBy { get; set; }

    // تایید کننده
    public int? ApprovedById { get; set; }

    public Employee? ApprovedBy { get; set; }

    public bool IsActive { get; set; } = true;
}