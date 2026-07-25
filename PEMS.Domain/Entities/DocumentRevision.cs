using System.ComponentModel.DataAnnotations;

namespace PEMS.Domain.Entities;

public class DocumentRevision
{
    [Key]
    public int RevisionId { get; set; }


    public int DocumentId { get; set; }

    public EngineeringDocument? Document { get; set; }



    // Revision Number
    public string RevisionNo { get; set; } = "00";


    // Previous Revision
    public string? PreviousRevisionNo { get; set; }



    // Draft / Review / Approved / Rejected
    public string Status { get; set; } = "Draft";



    public string? IssuePurpose { get; set; }



    public string? Comment { get; set; }



    public DateTime RevisionDate { get; set; }
        = DateTime.Now;



    // Prepared By
    public int? PreparedById { get; set; }

    public Employee? PreparedBy { get; set; }



    // Checked By
    public int? CheckedById { get; set; }

    public Employee? CheckedBy { get; set; }



    // Approved By
    public int? ApprovedById { get; set; }

    public Employee? ApprovedBy { get; set; }



    public bool IsActive { get; set; } = true;
}