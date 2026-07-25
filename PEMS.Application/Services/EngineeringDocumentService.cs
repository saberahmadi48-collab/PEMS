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

            ProjectId = x.ProjectId,

            ProjectName = x.Project != null
                ? x.Project.ProjectName
                : "",


            DisciplineId = x.DisciplineId,

            DisciplineName = x.Discipline != null
                ? x.Discipline.Name
                : "",


            Status = x.Status,

            RevisionNo = x.RevisionNo,

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


            // Basic Information

            DocumentNo = document.DocumentNo,

            Title = document.Title,

            Description = document.Description,

            DocumentType = document.DocumentType,


            ProjectId = document.ProjectId,

            ProjectName = document.Project != null
                ? document.Project.ProjectName
                : "",


            DisciplineId = document.DisciplineId,

            DisciplineName = document.Discipline != null
                ? document.Discipline.Name
                : "",



            Status = document.Status,

            RevisionNo = document.RevisionNo,

            CreatedDate = document.CreatedDate,



            // Engineering Information

            IssuePurpose = document.IssuePurpose,

            PreparedBy = document.PreparedBy,

            CheckedBy = document.CheckedBy,

            ApprovedBy = document.ApprovedBy,



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

                .ToList(),




            // Revision History

            Revisions = document.Revisions

                .Where(x => x.IsActive)

                .Select(x => new DocumentRevisionDto
                {
                    RevisionId = x.RevisionId,

                    RevisionNo = x.RevisionNo,

                    Status = x.Status,

                    Comment = x.Comment,

                    RevisionDate = x.RevisionDate,


                    PreparedBy = x.PreparedBy != null
                        ? x.PreparedBy.FirstName + " " + x.PreparedBy.LastName
                        : "",


                    CheckedBy = x.CheckedBy != null
                        ? x.CheckedBy.FirstName + " " + x.CheckedBy.LastName
                        : "",


                    ApprovedBy = x.ApprovedBy != null
                        ? x.ApprovedBy.FirstName + " " + x.ApprovedBy.LastName
                        : ""

                })

                .ToList(),





            // Workflow History

            Workflows = document.Workflows

    .Where(x => x.IsActive)

    .Select(x => new DocumentWorkflowDto
    {
        WorkflowId = x.WorkflowId,

        FromStatus = x.FromStatus,

        ToStatus = x.ToStatus,

        ActionType = x.ActionType,

        Comment = x.Comment,

        ActionDate = x.ActionDate,


        ActionBy = x.ActionBy != null
            ? x.ActionBy.FirstName + " " + x.ActionBy.LastName
            : ""

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