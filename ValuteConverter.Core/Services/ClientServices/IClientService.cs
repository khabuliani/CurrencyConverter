using ValueConverter.Shared.Paging;
using ValuteConverter.Core.Dto;

namespace ValuteConverter.Core.Services.ClientServices;

public interface IClientService
{
    public Task<ClientDto> Create(ClientDto input);

    public Task<ClientDto> Update(ClientDto input);

    public Task<ClientDto> Get(int id);

    public Task<ClientDto> GetByPersonalNumber(string personalNumber);

    public Task<PagedResultDto<ClientDto>> GetAll(GetAllClientDto input);
}
