using Microsoft.AspNetCore.Mvc;
using ValuteConverter.Core.Services.ClientServices;
using ValuteConverter.Domain.Dto;

namespace ValuteConverter.Web.Controllers;

public class ClientsController : Controller
{
    private readonly IClientService _clientService;
    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<ActionResult> Index(GetAllClientDto input)
    {
        return View(await _clientService.GetAll(input));
    }

    [HttpGet]
    public async Task<ActionResult> Details(int id)
    {
        return View(await _clientService.Get(id));
    }

    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
        return View(await _clientService.Get(id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(ClientDto client)
    {
        await _clientService.Update(client);
        return RedirectToAction("Index");
    }
}
