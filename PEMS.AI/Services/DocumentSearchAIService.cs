using PEMS.Application.AI.Search.Interfaces;
using PEMS.Application.AI.Search.Models;
using PEMS.Application.Interfaces;

namespace PEMS.Application.AI.Search.Services;

public class DocumentSearchAIService
    : IDocumentSearchAIService
{

    private readonly IEngineeringDocumentRepository _repository;


    public DocumentSearchAIService(
        IEngineeringDocumentRepository repository)
    {
        _repository = repository;
    }



    public async Task<List<DocumentSearchResult>> SearchAsync(
        DocumentSearchRequest request)
    {

        var documents = await _repository.GetAllAsync();


        var result = documents
            .Where(x =>
                x.Title.Contains(
                    request.Direction,
                    StringComparison.OrdinalIgnoreCase)
                ||
                x.DocumentNo.Contains(
                    request.Direction,
                    StringComparison.OrdinalIgnoreCase))
            .Select(x => new DocumentSearchResult
            {
                DocumentId = x.DocumentId,

                DocumentNumber = x.DocumentNo,

                Title = x.Title,

                Reason = "Matched by document information",

                SimilarityScore = 0.80
            })
            .ToList();


        return result;
    }
}