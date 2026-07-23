using Microsoft.AspNetCore.Mvc;
using PEMS.Application.Interfaces;

namespace PEMS.Web.Controllers;

public class EngineeringDocumentsController : Controller
{
    private readonly IEngineeringDocumentService _service;


    public EngineeringDocumentsController(
        IEngineeringDocumentService service)
    {
        _service = service;
    }


    public async Task<IActionResult> Index()
    {
        var documents = await _service.GetAllAsync();

        return View(documents);
    }
}