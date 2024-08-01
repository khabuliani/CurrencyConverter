using ValuteConverter.Domain.Dto;
using ValuteConverter.Domain.Models;
using ValuteConverter.Domain.Shared.Paging;
using ValuteConverter.Domain.Shared;

namespace ValuteConverter.Core.Services.Transactions;

public interface ITransactionsServices
{

    public Task<TransactionResult> Create(TransactionDto input);

    public Task<TransactionDto> Get(int id);

    public Task<PagedResultDto<TransactionDto>> GetAll(GetAlltransactionDto input);
}
