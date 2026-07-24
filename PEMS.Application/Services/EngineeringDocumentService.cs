using PEMS.Application.DTOs;
using PEMS.Application.Interfaces;
using PEMS.Domain.Entities;

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

            CreatedDate = x.CreatedDate,


            // Relations

            DisciplineName = x.Discipline != null
                ? x.Discipline.Name
                : "",


            ProjectName = x.Project != null
                ? x.Project.ProjectName
                : ""


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


            CreatedDate = document.CreatedDate,



            // Relations

            DisciplineName = document.Discipline != null
                ? document.Discipline.Name
                : "",



            ProjectName = document.Project != null
                ? document.Project.ProjectName
                : "",



            Status = document.Status,


            RevisionNo = document.RevisionNo,



            // Attachments

            Attachments = document.Attachments

                .Where(x => x.IsActive)

                .Select(x => new DocumentAttachmentDto
                {
                    AttachmentId = x.AttachmentId,

                    FileName = x.FileName,

                    FileExtension = x.FileExtension,

                    FilePath = x.FilePath,

                    FileSize = x.FileSize,

                    MimeType = x.MimeType,

                    AIStatus = x.AIStatus,

                    AISummary = x.AISummary,

                    AIKeywords = x.AIKeywords,

                    UploadDate = x.UploadDate

                })

                .ToList()
        };
    }




    public async Task AddAsync(
        EngineeringDocument document)
    {
        await _repository.AddAsync(document);
    }





    public async Task<EngineeringDocument?> GetEntityByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }





    public async Task UpdateAsync(
        EngineeringDocument document)
    {
        await _repository.UpdateAsync(document);
    }





    public async Task DeleteAsync(
        EngineeringDocument document)
    {
        await _repository.DeleteAsync(document);
    }
}