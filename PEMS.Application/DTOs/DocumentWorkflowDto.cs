namespace PEMS.Application.DTOs;

public class DocumentWorkflowDto
{
    public int WorkflowId { get; set; }


    public string FromStatus { get; set; } = string.Empty;


    public string ToStatus { get; set; } = string.Empty;


    public string? Comment { get; set; }


    public DateTime ActionDate { get; set; }


    public string ActionBy { get; set; } = "";
}