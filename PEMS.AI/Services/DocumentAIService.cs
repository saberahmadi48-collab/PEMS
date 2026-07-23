using PEMS.Application.AI.Interfaces;
using PEMS.Application.AI.Models;

namespace PEMS.Application.AI.Services;

public class DocumentAIService : IDocumentAIService
{

    public async Task<AIAnalysisResult> AnalyzeDocumentAsync(
        string filePath)
    {

        // Temporary AI engine placeholder

        return new AIAnalysisResult
        {
            Summary = "AI analysis pending",

            DocumentTypePrediction =
                "Unknown",

            Confidence = 0
        };
    }
}