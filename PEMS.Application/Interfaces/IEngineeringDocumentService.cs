using PEMS.Application.DTOs;

namespace PEMS.Application.Interfaces;

public interface IEngineeringDocumentService
{
    Task<List<EngineeringDocumentDto>> GetAllAsync();

    Task<EngineeringDocumentDto?> GetByIdAsync(int id);
}