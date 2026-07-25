using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PEMS.Application.Interfaces;
using PEMS.Domain.Entities;
using PEMS.Persistence.Context;

namespace PEMS.Web.Controllers;


public class EngineeringDocumentsController : Controller
{
    private readonly IEngineeringDocumentService _service;
    private readonly PEMSDbContext _context;
    private readonly IDocumentWorkflowService _workflowService;


    public EngineeringDocumentsController(
        IEngineeringDocumentService service,
        PEMSDbContext context,
        IDocumentWorkflowService workflowService)
    {
        _service = service;
        _context = context;
        _workflowService = workflowService;
    }



    // =========================
    // LIST
    // =========================

    public async Task<IActionResult> Index()
    {
        var documents = await _service.GetAllAsync();

        return View(documents);
    }





    // =========================
    // CREATE GET
    // =========================

    [HttpGet]
    public IActionResult Create()
    {
        LoadDropdowns();

        return View();
    }





    // =========================
    // CREATE POST
    // =========================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        EngineeringDocument document)
    {

        if (!ModelState.IsValid)
        {
            LoadDropdowns();
            return View(document);
        }



        document.Status = "Draft";

        document.RevisionNo = "00";



        // ایجاد مدرک اصلی

        await _service.AddAsync(document);





        // =========================
        // Initial Revision
        // =========================


        var revision = new DocumentRevision
        {
            DocumentId = document.DocumentId,

            RevisionNo = "00",

            Status = "Draft",

            Comment = "Initial Revision",

            RevisionDate = DateTime.Now,

            IsActive = true
        };


        await _context.DocumentRevisions
            .AddAsync(revision);






        // =========================
        // Initial Workflow
        // =========================


        var workflow = new DocumentWorkflow
        {
            DocumentId = document.DocumentId,

            FromStatus = "",

            ToStatus = "Created",

            ActionType = "Create",

            Comment = "Document Created",

            ActionDate = DateTime.Now,

            IsActive = true
        };


        await _context.DocumentWorkflows
            .AddAsync(workflow);




        await _context.SaveChangesAsync();



        return RedirectToAction(nameof(Index));

    }






    // =========================
    // DETAILS
    // =========================


    public async Task<IActionResult> Details(int id)
    {

        var document =
            await _service.GetByIdAsync(id);


        if (document == null)
            return NotFound();


        return View(document);

    }





    // =========================
    // EDIT GET
    // =========================


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {

        var document =
            await _service.GetEntityByIdAsync(id);


        if (document == null)
            return NotFound();


        LoadDropdowns();


        return View(document);

    }





    // =========================
    // EDIT POST
    // =========================


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        EngineeringDocument document)
    {

        if (!ModelState.IsValid)
        {
            LoadDropdowns();
            return View(document);
        }


        document.ModifiedDate = DateTime.Now;


        await _service.UpdateAsync(document);


        return RedirectToAction(nameof(Index));

    }





    // =========================
    // DELETE DOCUMENT
    // =========================


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {

        var document =
            await _service.GetEntityByIdAsync(id);


        if (document == null)
            return NotFound();


        await _service.DeleteAsync(document);


        return RedirectToAction(nameof(Index));

    }
        // =========================
    // DROPDOWNS
    // =========================

    private void LoadDropdowns()
    {
        ViewBag.Projects =
            new SelectList(
                _context.Projects,
                "ProjectId",
                "ProjectName"
            );


        ViewBag.Disciplines =
            new SelectList(
                _context.Disciplines,
                "DisciplineId",
                "Name"
            );
    }





    // =========================
    // UPLOAD ATTACHMENT GET
    // =========================

    [HttpGet]
    public IActionResult UploadAttachment(int id)
    {
        ViewBag.DocumentId = id;

        return View();
    }





    // =========================
    // UPLOAD ATTACHMENT POST
    // =========================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UploadAttachment(
        int documentId,
        IFormFile file)
    {

        if(file == null || file.Length == 0)
        {
            ModelState.AddModelError(
                "",
                "Please select a file"
            );

            ViewBag.DocumentId = documentId;

            return View();
        }



        var uploadPath =
            Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "uploads",
                "documents"
            );



        if(!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);




        var storedFileName =
            Guid.NewGuid()
            +
            Path.GetExtension(file.FileName);



        var physicalPath =
            Path.Combine(
                uploadPath,
                storedFileName
            );



        using(var stream =
              new FileStream(
                  physicalPath,
                  FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }




        var attachment =
            new DocumentAttachment
            {
                DocumentId = documentId,

                FileName = file.FileName,

                FileExtension =
                    Path.GetExtension(file.FileName),


                FilePath =
                    "/uploads/documents/" + storedFileName,


                FileSize = file.Length,


                MimeType = file.ContentType,


                AIStatus = "Pending",


                UploadDate = DateTime.Now,


                IsActive = true
            };



        await _context.DocumentAttachments
            .AddAsync(attachment);



        await _context.SaveChangesAsync();



        return RedirectToAction(
            nameof(Details),
            new { id = documentId }
        );
    }





    // =========================
    // DOWNLOAD ATTACHMENT
    // =========================

    public async Task<IActionResult> DownloadAttachment(int id)
    {

        var attachment =
            await _context.DocumentAttachments
            .FirstOrDefaultAsync(x =>
                x.AttachmentId == id &&
                x.IsActive);



        if(attachment == null)
            return NotFound();




        var path =
            Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                attachment.FilePath.TrimStart('/')
            );



        if(!System.IO.File.Exists(path))
            return NotFound();



        var bytes =
            await System.IO.File.ReadAllBytesAsync(path);



        return File(
            bytes,
            attachment.MimeType ??
            "application/octet-stream",
            attachment.FileName
        );

    }





    // =========================
    // DELETE ATTACHMENT
    // =========================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteAttachment(int id)
    {

        var attachment =
            await _context.DocumentAttachments
            .FirstOrDefaultAsync(x =>
                x.AttachmentId == id);



        if(attachment == null)
            return NotFound();



        // Soft Delete

        attachment.IsActive = false;



        await _context.SaveChangesAsync();



        return RedirectToAction(
            nameof(Details),
            new
            {
                id = attachment.DocumentId
            });

    }



    // =========================
    // CREATE REVISION
    // =========================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateRevision(int id)
    {
        var document =
            await _context.EngineeringDocuments
            .Include(x => x.Revisions)
            .FirstOrDefaultAsync(
                x => x.DocumentId == id);



        if (document == null)
            return NotFound();



        var lastRevision =
            document.Revisions
            .OrderByDescending(x => x.RevisionId)
            .FirstOrDefault();



        int nextRevision =
            lastRevision == null
            ?
            0
            :
            int.Parse(lastRevision.RevisionNo) + 1;



        var revision =
            new DocumentRevision
            {
                DocumentId = id,

                RevisionNo =
                    nextRevision.ToString("00"),

                Status = "Draft",

                Comment =
                    "New Revision Created",

                RevisionDate =
                    DateTime.Now,

                IsActive = true
            };



        await _context.DocumentRevisions
            .AddAsync(revision);



        document.RevisionNo =
            nextRevision.ToString("00");


        document.Status =
            "Draft";


        document.ModifiedDate =
            DateTime.Now;



        await _context.SaveChangesAsync();



        return RedirectToAction(
            nameof(Details),
            new { id });
    }
    // =========================
    // WORKFLOW ACTIONS
    // =========================


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Submit(int id)
    {

        var document =
            await _context.EngineeringDocuments
            .FirstOrDefaultAsync(
                x => x.DocumentId == id);



        if (document == null)
            return NotFound();



        // فقط Draft یا Rejected اجازه Submit دارد

        if (document.Status != "Draft" &&
           document.Status != "Rejected")
        {
            TempData["Error"] =
                "Document cannot be submitted in current status";

            return RedirectToAction(
                nameof(Details),
                new { id });
        }



        await _workflowService.SubmitAsync(
            id,
            "Submitted for review"
        );



        return RedirectToAction(
            nameof(Details),
            new { id });

    }







    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Approve(int id)
    {

        var document =
            await _context.EngineeringDocuments
            .FirstOrDefaultAsync(
                x => x.DocumentId == id);



        if (document == null)
            return NotFound();



        // فقط Submitted قابل Approval است

        if (document.Status != "Submitted" &&
           document.Status != "Review")
        {
            TempData["Error"] =
                "Only submitted documents can be approved";

            return RedirectToAction(
                nameof(Details),
                new { id });
        }



        await _workflowService.ApproveAsync(
            id,
            "Approved"
        );



        return RedirectToAction(
            nameof(Details),
            new { id });

    }








    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Reject(int id)
    {

        var document =
            await _context.EngineeringDocuments
            .FirstOrDefaultAsync(
                x => x.DocumentId == id);



        if (document == null)
            return NotFound();




        // فقط Submitted یا Review قابل Reject است

        if (document.Status != "Submitted" &&
           document.Status != "Review")
        {
            TempData["Error"] =
                "Only submitted documents can be rejected";

            return RedirectToAction(
                nameof(Details),
                new { id });
        }




        await _workflowService.RejectAsync(
            id,
            "Rejected"
        );



        return RedirectToAction(
            nameof(Details),
            new { id });

    }


}