using Microsoft.AspNetCore.Mvc;
using ValueConverter.Shared;
using ValueConverter.Shared.Paging;
using ValuteConverter.Core.Dto;
using ValuteConverter.Core.Services.Transactions;

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

    [HttpPost]
    public async Task<PagedResultDto<TransactionDto>> GetAll(GetAlltransactionDto input)
    {
        return await _transactionsServices.GetAll(input);
    }

    [HttpPost]
    public async Task<PagedResultDto<TransactionsDto>> GetAllTransactions(GetAlltransactionDto input)
    {
        return await _transactionsServices.GetAllTransactions(input);
    }
}
