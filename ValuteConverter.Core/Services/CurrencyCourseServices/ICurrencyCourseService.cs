using ValueConverter.Shared.Paging;
using ValuteConverter.Core.Dto;

namespace ValuteConverter.Core.Services.CurrencyCourseServices;

public interface ICurrencyCourseService
{

    public Task<CurrencyCourseDto> Create(CurrencyCourseDto input);

    public Task<CurrencyCourseDto> Update(CurrencyCourseDto input);

    public Task<CurrencyCourseDto> Get(int id);

    public Task Delete(int id);

    public Task<PagedResultDto<CurrencyCourseDto>> GetAll(GetAllCurrencyDto input);
}
