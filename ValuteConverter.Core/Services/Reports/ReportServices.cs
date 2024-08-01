﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValuteConverter.Core.Extensions;
using ValuteConverter.Core.Repositories;
using ValuteConverter.Domain.Dto;
using ValuteConverter.Domain.Models;

namespace ValuteConverter.Core.Services.Reports;

public class ReportServices : IReportServices
{
    private readonly IRepository<Transaction> _transaction;
    private readonly IRepository<Client> _client;
    public ReportServices(
        IRepository<Transaction> transaction, 
        IRepository<Client> client)
    {
        _transaction = transaction;
        _client = client;
    }

    public async Task<ReportDto> GetReport(GetReportInputDto input)
    {
        var result = new ReportDto();
        result.PersonalNumber = input.PersonalNumber;
        var transactions = _transaction.GetAll()
                                            .WhereIf(input.StartDate != null, x => x.CreationDate >= input.StartDate)
                                            .WhereIf(input.EndDate != null, x => x.CreationDate <= input.EndDate);
        result.OwnOperations = transactions.Where(x => x.CreatorClient.PersonalNumber == input.PersonalNumber).Count();
        result.AllOperations = transactions.Where(x => x.CreatorClient.PersonalNumber == input.PersonalNumber || 
                                    x.CreatorClient.RecomendatorPersonalNumber == input.PersonalNumber).Count();
        return result;
    }
}
