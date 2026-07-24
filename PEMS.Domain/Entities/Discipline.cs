namespace PEMS.Domain.Entities;

public class Discipline
{
    public int DisciplineId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; }

    public ICollection<EngineeringDocument> EngineeringDocuments { get; set; }
        = new List<EngineeringDocument>();
}