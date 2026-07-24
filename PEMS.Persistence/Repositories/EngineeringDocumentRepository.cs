using Microsoft.EntityFrameworkCore;
using PEMS.Application.Interfaces;
using PEMS.Domain.Entities;
using PEMS.Persistence.Context;

namespace PEMS.Persistence.Repositories;

public class EngineeringDocumentRepository
    : IEngineeringDocumentRepository
{
    private readonly PEMSDbContext _context;

    public EngineeringDocumentRepository(PEMSDbContext context)
    {
        _context = context;
    }


    public async Task<List<EngineeringDocument>> GetAllAsync()
    {
        return await _context.EngineeringDocuments
            .ToListAsync();
    }


    public async Task<EngineeringDocument?> GetByIdAsync(int id)
    {
        return await _context.EngineeringDocuments
            .FirstOrDefaultAsync(x => x.DocumentId == id);
    }


    public async Task AddAsync(EngineeringDocument document)
    {
        await _context.EngineeringDocuments.AddAsync(document);
        await _context.SaveChangesAsync();
    }


    public async Task UpdateAsync(EngineeringDocument document)
    {
        _context.EngineeringDocuments.Update(document);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteAsync(EngineeringDocument document)
    {
        _context.EngineeringDocuments.Remove(document);
        await _context.SaveChangesAsync();
    }
}