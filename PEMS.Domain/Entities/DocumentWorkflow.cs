using System.ComponentModel.DataAnnotations;

namespace PEMS.Domain.Entities;

public class DocumentWorkflow
{
    [Key]
    public int WorkflowId { get; set; }



    // =========================
    // Document Relation
    // =========================

    public int DocumentId { get; set; }

    public EngineeringDocument? Document { get; set; }






    // =========================
    // Status Transition
    // =========================


    // وضعیت قبلی
    public string FromStatus { get; set; } = string.Empty;



    // وضعیت جدید
    public string ToStatus { get; set; } = string.Empty;





    // نوع عملیات
    // Create
    // Submit
    // Review
    // Approve
    // Reject
    // Issue
    // Archive

    public string ActionType { get; set; }
        = string.Empty;







    // توضیحات اقدام

    public string? Comment { get; set; }







    // =========================
    // Audit
    // =========================


    public DateTime ActionDate { get; set; }
        = DateTime.Now;



    public int? ActionById { get; set; }


    public Employee? ActionBy { get; set; }





    public bool IsActive { get; set; } = true;

}