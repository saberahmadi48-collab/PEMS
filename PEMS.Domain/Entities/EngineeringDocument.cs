using System.ComponentModel.DataAnnotations;
namespace PEMS.Domain.Entities;

public class EngineeringDocument
{
    [Key]
    public int DocumentId { get; set; }

    // شماره مدرک مهندسی
    public string DocumentNo { get; set; } = string.Empty;

    // عنوان مدرک
    public string Title { get; set; } = string.Empty;

    // نوع مدرک
    // Drawing, Datasheet, Calculation, Specification
    public string DocumentType { get; set; } = string.Empty;

    // ارتباط با پروژه
    public int ProjectId { get; set; }

    public Project? Project { get; set; }

    // ارتباط با دیسیپلین
    public int DisciplineId { get; set; }

    public Discipline? Discipline { get; set; }

    // وضعیت مدرک
    // Draft, Review, Approved, Rejected
    public string Status { get; set; } = "Draft";

    // شماره Revision
    public string RevisionNo { get; set; } = "00";

    // توضیحات
    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public ICollection<DocumentAttachment>? Attachments { get; set; }
}