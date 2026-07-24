using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PEMS.Application.Interfaces;
using PEMS.Domain.Entities;
using PEMS.Persistence.Context;

namespace PEMS.Web.Controllers;

public class EngineeringDocumentsController : Controller
{
    private readonly IEngineeringDocumentService _service;
    private readonly PEMSDbContext _context;


    public EngineeringDocumentsController(
        IEngineeringDocumentService service,
        PEMSDbContext context)
    {
        _service = service;
        _context = context;
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


        await _service.AddAsync(document);


        return RedirectToAction(nameof(Index));
    }




    // =========================
    // DETAILS
    // =========================

    public async Task<IActionResult> Details(int id)
    {
        var document = await _service.GetByIdAsync(id);


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
        var document = await _service.GetEntityByIdAsync(id);


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


        await _service.UpdateAsync(document);


        return RedirectToAction(nameof(Index));
    }




    // =========================
    // DELETE
    // =========================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var document = await _service.GetEntityByIdAsync(id);


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
        ViewBag.Projects = new SelectList(
            _context.Projects,
            "ProjectId",
            "ProjectName"
        );


        ViewBag.Disciplines = new SelectList(
            _context.Disciplines,
            "DisciplineId",
            "Name"
        );
    }

}