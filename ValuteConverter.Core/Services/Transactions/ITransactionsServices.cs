using ValueConverter.Shared;
using ValueConverter.Shared.Paging;
using ValuteConverter.Core.Dto;

namespace ValuteConverter.Core.Services.Transactions;

public interface ITransactionsServices
{

    public Task<TransactionResult> Create(TransactionDto input);

    public Task<TransactionDto> Get(int id);

    public Task<PagedResultDto<TransactionDto>> GetAll(GetAlltransactionDto input);

    public Task<PagedResultDto<TransactionsDto>> GetAllTransactions(GetAlltransactionDto input);
}
