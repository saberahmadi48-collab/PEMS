namespace PEMS.Application.DTOs;

public class DocumentAttachmentDto
{
    public int AttachmentId { get; set; }

    public string FileName { get; set; } = "";

    public string FileExtension { get; set; } = "";

    public string FilePath { get; set; } = "";

    public long FileSize { get; set; }

    public string? MimeType { get; set; }

    public string AIStatus { get; set; } = "";

    public string? AISummary { get; set; }

    public string? AIKeywords { get; set; }

    public DateTime UploadDate { get; set; }
}