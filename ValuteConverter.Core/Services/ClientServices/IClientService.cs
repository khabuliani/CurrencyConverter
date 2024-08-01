using ValuteConverter.Domain.Dto;
using ValuteConverter.Domain.Shared.Paging;

namespace ValuteConverter.Core.Services.ClientServices;

public interface IClientService
{
    public Task<ClientDto> Create(ClientDto input);

    public Task<ClientDto> Update(ClientDto input);

    public Task<ClientDto> Get(int id);

    public Task<PagedResultDto<ClientDto>> GetAll(GetAllClientDto input);
}
