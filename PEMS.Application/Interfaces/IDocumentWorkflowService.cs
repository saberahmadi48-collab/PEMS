namespace PEMS.Application.Interfaces;

public interface IDocumentWorkflowService
{
    Task SubmitAsync(
        int documentId,
        string? comment = null);


    Task ApproveAsync(
        int documentId,
        string? comment = null);


    Task RejectAsync(
        int documentId,
        string? comment = null);
}