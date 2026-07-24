using PEMS.Application.DTOs;
using PEMS.Domain.Entities;

namespace PEMS.Application.Interfaces;

public interface IEngineeringDocumentService
{
    Task<List<EngineeringDocumentDto>> GetAllAsync();

    Task<EngineeringDocumentDto?> GetByIdAsync(int id);

    Task AddAsync(EngineeringDocument document);

    Task<EngineeringDocument?> GetEntityByIdAsync(int id);

    Task UpdateAsync(EngineeringDocument document);

    Task DeleteAsync(EngineeringDocument document);
}