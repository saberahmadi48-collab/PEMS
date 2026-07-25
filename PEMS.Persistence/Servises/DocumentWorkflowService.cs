using Microsoft.EntityFrameworkCore;
using PEMS.Application.Interfaces;
using PEMS.Domain.Entities;
using PEMS.Persistence.Context;

namespace PEMS.Persistence.Services;


public class DocumentWorkflowService
    : IDocumentWorkflowService
{

    private readonly PEMSDbContext _context;



    public DocumentWorkflowService(
        PEMSDbContext context)
    {
        _context = context;
    }





    public async Task SubmitAsync(
        int documentId,
        string? comment = null)
    {

        await ChangeStatusAsync(
            documentId,
            "Submitted",
            "Submit",
            comment,
            new[]
            {
                "Draft",
                "Rejected"
            });

    }







    public async Task ApproveAsync(
        int documentId,
        string? comment = null)
    {

        await ChangeStatusAsync(
            documentId,
            "Approved",
            "Approve",
            comment,
            new[]
            {
                "Submitted",
                "Review"
            });

    }







    public async Task RejectAsync(
        int documentId,
        string? comment = null)
    {

        await ChangeStatusAsync(
            documentId,
            "Rejected",
            "Reject",
            comment,
            new[]
            {
                "Submitted",
                "Review"
            });

    }









    private async Task ChangeStatusAsync(
        int documentId,
        string newStatus,
        string actionType,
        string? comment,
        string[] allowedStatuses)
    {


        var document =
            await _context.EngineeringDocuments
            .FirstOrDefaultAsync(
                x => x.DocumentId == documentId);



        if (document == null)
        {
            throw new Exception(
                "Document not found");
        }





        if (!allowedStatuses.Contains(
            document.Status))
        {

            throw new Exception(
                $"Cannot change status from {document.Status} to {newStatus}");

        }







        var workflow =
            new DocumentWorkflow
            {

                DocumentId = documentId,


                FromStatus =
                    document.Status,


                ToStatus =
                    newStatus,


                ActionType =
                    actionType,


                Comment =
                    comment,


                ActionDate =
                    DateTime.Now,


                IsActive = true

            };







        document.Status =
            newStatus;



        document.ModifiedDate =
            DateTime.Now;







        await _context.DocumentWorkflows
            .AddAsync(workflow);



        await _context.SaveChangesAsync();

    }

}