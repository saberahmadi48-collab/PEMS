using System.ComponentModel.DataAnnotations;

namespace PEMS.Domain.Entities;

public class DocumentAttachment
{
    [Key]
    public int AttachmentId { get; set; }


    public int DocumentId { get; set; }

    public EngineeringDocument? Document { get; set; }


    public string FileName { get; set; } = string.Empty;

    public string FileExtension { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public long FileSize { get; set; }

    public string? MimeType { get; set; }

    public string AIStatus { get; set; } = "Pending";

    public string? AISummary { get; set; }

    public string? AIKeywords { get; set; }

    public string? AITags { get; set; }

    public double? AIConfidence { get; set; }

    public DateTime UploadDate { get; set; } = DateTime.Now;

    public bool IsActive { get; set; } = true;
}