namespace PEMS.Application.AI.Models;

public class AIAnalysisResult
{
    public string Summary { get; set; } = string.Empty;


    public List<string> Keywords { get; set; } = new();


    public List<string> ExtractedTags { get; set; } = new();


    public string DocumentTypePrediction { get; set; } = string.Empty;


    public double Confidence { get; set; }
}