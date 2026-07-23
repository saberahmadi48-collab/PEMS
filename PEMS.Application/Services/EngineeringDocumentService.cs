using PEMS.Application.DTOs;
using PEMS.Application.Interfaces;

namespace PEMS.Application.Services;

public class EngineeringDocumentService : IEngineeringDocumentService
{
    private readonly IEngineeringDocumentRepository _repository;

    public EngineeringDocumentService(
        IEngineeringDocumentRepository repository)
    {
        _repository = repository;
    }


    public async Task<List<EngineeringDocumentDto>> GetAllAsync()
    {
        var documents = await _repository.GetAllAsync();

        return documents.Select(x => new EngineeringDocumentDto
        {
            DocumentId = x.DocumentId,
            DocumentNo = x.DocumentNo,
            Title = x.Title,
            Description = x.Description,
            DocumentType = x.DocumentType,
            CreatedDate = x.CreatedDate
        }).ToList();
    }


    public async Task<EngineeringDocumentDto?> GetByIdAsync(int id)
    {
        var document = await _repository.GetByIdAsync(id);

        if (document == null)
            return null;


        return new EngineeringDocumentDto
        {
            DocumentId = document.DocumentId,
            DocumentNo = document.DocumentNo,
            Title = document.Title,
            Description = document.Description,
            DocumentType = document.DocumentType,
            CreatedDate = document.CreatedDate
        };
    }
}