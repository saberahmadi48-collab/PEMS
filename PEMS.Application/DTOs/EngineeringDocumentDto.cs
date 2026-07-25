namespace PEMS.Application.DTOs;

public class EngineeringDocumentDto
{

    public int DocumentId { get; set; }


    // =========================
    // Basic Information
    // =========================

    public string DocumentNo { get; set; } = "";

    public string Title { get; set; } = "";

    public string DocumentType { get; set; } = "";

    public string? Description { get; set; }



    // Project

    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = "";



    // Discipline

    public int DisciplineId { get; set; }

    public string DisciplineName { get; set; } = "";



    // Status

    public string Status { get; set; } = "Draft";


    public string RevisionNo { get; set; } = "00";



    public DateTime CreatedDate { get; set; }



    // =========================
    // Engineering Information
    // =========================


    public string? IssuePurpose { get; set; }


    public string? PreparedBy { get; set; }


    public string? CheckedBy { get; set; }


    public string? ApprovedBy { get; set; }




    // =========================
    // Attachments
    // =========================


    public List<DocumentAttachmentDto> Attachments { get; set; }
        = new();




    // =========================
    // Revision History
    // =========================


    public List<DocumentRevisionDto> Revisions { get; set; }
        = new();




    // =========================
    // Workflow History
    // =========================


    public List<DocumentWorkflowDto> Workflows { get; set; }
        = new();

}