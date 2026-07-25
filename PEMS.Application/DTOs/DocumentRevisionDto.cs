namespace PEMS.Application.DTOs;

public class DocumentRevisionDto
{
    public int RevisionId { get; set; }


    public string RevisionNo { get; set; } = "00";


    public string Status { get; set; } = "Draft";


    public string? Comment { get; set; }


    public DateTime RevisionDate { get; set; }


    public string PreparedBy { get; set; } = "";


    public string CheckedBy { get; set; } = "";


    public string ApprovedBy { get; set; } = "";
}