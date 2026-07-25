using System.ComponentModel.DataAnnotations;

namespace PEMS.Domain.Entities;

public class EngineeringDocument
{
    [Key]
    public int DocumentId { get; set; }



    // =========================
    // Basic Information
    // =========================


    // شماره مدرک مهندسی
    public string DocumentNo { get; set; } = string.Empty;



    // عنوان مدرک
    public string Title { get; set; } = string.Empty;



    // توضیحات
    public string? Description { get; set; }



    // نوع مدرک
    // Drawing, Datasheet, Procedure, Report ...
    public string DocumentType { get; set; } = string.Empty;






    // =========================
    // Project Relation
    // =========================


    public int ProjectId { get; set; }


    public Project? Project { get; set; }








    // =========================
    // Discipline Relation
    // =========================


    public int DisciplineId { get; set; }


    public Discipline? Discipline { get; set; }








    // =========================
    // Engineering Information
    // =========================


    // For Approval
    // For Construction
    // For Information

    public string? IssuePurpose { get; set; }




    // تهیه کننده

    public string? PreparedBy { get; set; }




    // بررسی کننده

    public string? CheckedBy { get; set; }




    // تایید کننده

    public string? ApprovedBy { get; set; }








    // =========================
    // Document Status
    // =========================


    // Draft
    // Submitted
    // Under Review
    // Approved
    // Issued
    // Rejected
    // Superseded
    // Archived

    public string Status { get; set; } = "Draft";





    // Revision جاری

    public string RevisionNo { get; set; } = "00";









    // =========================
    // Dates
    // =========================


    public DateTime CreatedDate { get; set; }
        = DateTime.Now;



    public DateTime? ModifiedDate { get; set; }









    // =========================
    // Soft Delete / Archive
    // =========================


    // فعال بودن مدرک

    public bool IsActive { get; set; } = true;



    // تاریخ Archive شدن

    public DateTime? DeletedDate { get; set; }




    // شخص Archive کننده

    public int? DeletedById { get; set; }


    public Employee? DeletedBy { get; set; }









    // =========================
    // Attachments
    // =========================


    public ICollection<DocumentAttachment> Attachments { get; set; }
        = new List<DocumentAttachment>();









    // =========================
    // Revision History
    // =========================


    public ICollection<DocumentRevision> Revisions { get; set; }
        = new List<DocumentRevision>();









    // =========================
    // Workflow History
    // =========================


    public ICollection<DocumentWorkflow> Workflows { get; set; }
        = new List<DocumentWorkflow>();

}