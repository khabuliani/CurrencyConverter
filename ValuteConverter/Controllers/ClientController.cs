using Microsoft.AspNetCore.Mvc;
using ValuteConverter.Core.Services.ClientServices;
using ValuteConverter.Domain.Dto;
using ValuteConverter.Domain.Shared.Paging;

namespace ValuteConverter.Controllers;

[ApiController]
[Route($"api/[controller]/[action]")]
public class ClientController : Controller
{
    private readonly IClientService _clientService;
    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost]
    public async Task<ClientDto> Create(ClientDto input)
    {
        return await _clientService.Create(input);
    }

    [HttpPut]
    public async Task<ClientDto> Update(ClientDto input)
    {
        return await _clientService.Update(input);
    }

    [HttpGet]
    public async Task<ClientDto> Get(int id)
    {
        return await _clientService.Get(id);
    }

    [HttpPost]
    public async Task<PagedResultDto<ClientDto>> GetAll(GetAllClientDto input)
    {
        return await _clientService.GetAll(input);
    }
}
