using ValuteConverter.Domain.Dto;
using ValuteConverter.Domain.Shared.Paging;

namespace ValuteConverter.Core.Services.CurrencyServices;

public interface ICurrencyService
{

    public Task<CurrencyDto> Create(CurrencyDto input);

    public Task<CurrencyDto> Update(CurrencyDto input);

    public Task<CurrencyDto> Get(int id);

    public Task Delete(int id);

    public Task<PagedResultDto<CurrencyDto>> GetAll(GetAllCurrencyDto input);
    public Task<List<CurrencyDto>> GetAllList(GetAllCurrencyDto input);
}
