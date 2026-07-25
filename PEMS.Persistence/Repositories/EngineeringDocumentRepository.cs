using Microsoft.EntityFrameworkCore;
using PEMS.Application.Interfaces;
using PEMS.Domain.Entities;
using PEMS.Persistence.Context;

namespace PEMS.Persistence.Repositories;

public class EngineeringDocumentRepository
    : IEngineeringDocumentRepository
{
    private readonly PEMSDbContext _context;


    public EngineeringDocumentRepository(
        PEMSDbContext context)
    {
        _context = context;
    }



    public async Task<List<EngineeringDocument>> GetAllAsync()
    {
        return await _context.EngineeringDocuments

            .Where(x => x.IsActive)

            .Include(x => x.Discipline)

            .Include(x => x.Project)

            .Include(x => x.Attachments)

            .ToListAsync();
    }





    public async Task<EngineeringDocument?> GetByIdAsync(int id)
    {
        return await _context.EngineeringDocuments

            .Where(x => x.IsActive)

            .Include(x => x.Discipline)

            .Include(x => x.Project)

            .Include(x => x.Attachments)


            .Include(x => x.Revisions)
                .ThenInclude(x => x.PreparedBy)

            .Include(x => x.Revisions)
                .ThenInclude(x => x.CheckedBy)

            .Include(x => x.Revisions)
                .ThenInclude(x => x.ApprovedBy)


            .Include(x => x.Workflows)
                .ThenInclude(x => x.ActionBy)


            .FirstOrDefaultAsync(
                x => x.DocumentId == id);
    }





    public async Task AddAsync(
        EngineeringDocument document)
    {
        await _context.EngineeringDocuments.AddAsync(document);

        await _context.SaveChangesAsync();
    }





    public async Task UpdateAsync(
        EngineeringDocument document)
    {
        document.ModifiedDate = DateTime.Now;

        _context.EngineeringDocuments.Update(document);

        await _context.SaveChangesAsync();
    }





    public async Task DeleteAsync(
        EngineeringDocument document)
    {
        document.IsActive = false;

        document.Status = "Archived";

        document.DeletedDate = DateTime.Now;


        await _context.SaveChangesAsync();
    }
}