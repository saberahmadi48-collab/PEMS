using PEMS.Domain.Entities;

namespace PEMS.Application.Interfaces;

public interface IEngineeringDocumentRepository
{
    Task<List<EngineeringDocument>> GetAllAsync();

    Task<EngineeringDocument?> GetByIdAsync(int id);

    Task AddAsync(EngineeringDocument document);

    Task UpdateAsync(EngineeringDocument document);

    Task DeleteAsync(EngineeringDocument document);
}