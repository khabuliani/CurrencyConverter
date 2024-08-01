using AutoMapper;
using ValuteConverter.Core.Dto;
using ValuteConverter.Core.Extensions;
using ValuteConverter.Core.Repositories;
using ValuteConverter.Domain.Models;

namespace ValuteConverter.Core.Services.ClientServices;

public class ClientService : IClientService
{
    private readonly IRepository<Client> _client;
    private readonly IMapper _mapper;
    public ClientService(
        IRepository<Client> client, 
        IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }
    public async Task<ClientDto> Create(ClientDto input)
    {
        var oldClient = _client.FirstOrDefault(x => x.PersonalNumber == input.PersonalNumber);
        if (oldClient != null)
        {
            throw new Exception("Client with this Personal Number already exists");
        }
        var client = _mapper.Map<Client>(input);
        client.CreationDate = DateTime.Now;
        input.Id = _client.InsertAndGetId(client);
        return input;
    }

    public async Task<ClientDto> Update(ClientDto input)
    {
        var oldClient = _client.FirstOrDefault(x => x.Id == input.Id);
        if (oldClient == null)
        {
            throw new Exception("Client not found");
        }
        if (oldClient.PersonalNumber != input.PersonalNumber)
        {
            var otherClient = _client.FirstOrDefault(x => x.PersonalNumber == input.PersonalNumber);
            if (oldClient == null)
            {
                throw new Exception("Client with this Personal Number already exists");
            }
        }
        oldClient.FirstName = input.FirstName;
        oldClient.LastName = input.LastName;
        oldClient.PersonalNumber = input.PersonalNumber;
        oldClient.RecomendatorPersonalNumber = input.RecomendatorPersonalNumber;
        _client.Update(oldClient);
        return input;
    }

    public async Task<ClientDto> Get(int id)
    {
        var oldClient = _client.FirstOrDefault(x => x.Id == id);
        if (oldClient == null)
        {
            throw new Exception("Client not found");
        }
        var result = _mapper.Map<ClientDto>(oldClient);
        return result;
    }

    public async Task<ClientDto> GetByPersonalNumber(string personalNumber)
    {
        var oldClient = _client.FirstOrDefault(x => x.PersonalNumber == personalNumber);
        if (oldClient == null)
        {
            throw new Exception("Client not found");
        }
        var result = _mapper.Map<ClientDto>(oldClient);
        return result;
    }

    public async Task<PagedResultDto<ClientDto>> GetAll(GetAllClientDto input)
    {
        var clients = _client.GetAll().WhereIf(input.PersonalNumber != null,x => x.PersonalNumber.Contains(input.PersonalNumber));
        var result = new PagedResultDto<ClientDto>();
        result.TotalCount = clients.Count();
        clients = clients.PageBy(input);
        result.Items =  _mapper.Map<List<ClientDto>>(clients.ToList());
        return result;
    }
}
