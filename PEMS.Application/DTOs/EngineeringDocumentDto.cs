namespace PEMS.Application.DTOs;

public class EngineeringDocumentDto
{
    public int DocumentId { get; set; }

    public string DocumentNo { get; set; } = "";

    public string Title { get; set; } = "";

    public string DocumentType { get; set; } = "";

    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = "";

    public int DisciplineId { get; set; }

    public string DisciplineName { get; set; } = "";

    public string Status { get; set; } = "Draft";

    public string RevisionNo { get; set; } = "00";

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }
}