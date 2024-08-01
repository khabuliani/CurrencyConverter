using Microsoft.AspNetCore.Mvc;
using ValuteConverter.Core.Services.Transactions;
using ValuteConverter.Domain.Dto;
using ValuteConverter.Domain.Shared;
using ValuteConverter.Domain.Shared.Paging;

namespace ValuteConverter.Controllers;

[ApiController]
[Route($"api/[controller]/[action]")]
public class TransactionController : Controller
{
    private readonly ITransactionsServices _transactionsServices;
    public TransactionController(ITransactionsServices transactionsServices)
    {
        _transactionsServices = transactionsServices;
    }

    [HttpPost]
    public async Task<TransactionResult> Create(TransactionDto input)
    {
        return await _transactionsServices.Create(input);
    }

    [HttpGet]
    public async Task<TransactionDto> Get(int id)
    {
        return await _transactionsServices.Get(id);
    }

    [HttpGet]
    public async Task<PagedResultDto<TransactionDto>> GetAll(GetAlltransactionDto input)
    {
        return await _transactionsServices.GetAll(input);
    }
}
