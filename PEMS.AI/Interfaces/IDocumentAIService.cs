using PEMS.Application.AI.Models;

namespace PEMS.Application.AI.Interfaces;

public interface IDocumentAIService
{
    Task<AIAnalysisResult> AnalyzeDocumentAsync(
        string filePath);
}