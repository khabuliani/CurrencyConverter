﻿using AutoMapper;
using ValueConverter.Shared;
using ValueConverter.Shared.Paging;
using ValuteConverter.Core.Dto;
using ValuteConverter.Core.Extensions;
using ValuteConverter.Core.Repositories;
using ValuteConverter.Domain.Models;
using Microsoft.Extensions.Configuration;
using ValuteConverter.Core.Services.CalulatorServices;

namespace ValuteConverter.Core.Services.Transactions;

public class TransactionsServices : ITransactionsServices
{
    private readonly IRepository<CurrencyCourse> _currencyCourse;
    private readonly IRepository<Transaction> _transaction;
    private readonly IMapper _mapper;
    private readonly IConfiguration _appConfiguration;
    private readonly ICalculatorService _calculatorService;

    public TransactionsServices(
        IRepository<Transaction> transaction,
        IMapper mapper,
        IRepository<CurrencyCourse> currencyCourse,
        IConfiguration appConfiguration,
        ICalculatorService calculatorService)
    {
        _transaction = transaction;
        _mapper = mapper;
        _currencyCourse = currencyCourse;
        _appConfiguration = appConfiguration;
        _calculatorService = calculatorService;
    }

    public async Task<TransactionResult> Create(TransactionDto input)
    {  
        var cal = new CalculatorDto()
        {
            ToBuy = input.ToBuy,
            ToBuyCurrencyId = input.ToBuyCurrencyId,
            ToSellCurrencyId = input.ToSellCurrencyId,
            ToSell = input.ToSell,
        };
        var calculate = await _calculatorService.Calculate(cal);

        if(input.ToSell == 0)
        {
            
            input.ToSell = calculate.ToSell;
        }
        else
        {
            if (input.ToBuy == 0)
            {
                input.ToBuy = calculate.ToBuy;
            }
            else 
            {
                if (calculate.ToSell != input.ToSell || calculate.ToBuy != input.ToBuy)
                {
                    throw new Exception("Incorrect amount");
                }
            }
        }

        if (input.CreatorClientId == null)
        {
            var course = _currencyCourse.FirstOrDefault(x => x.Id == input.ToBuyCurrencyId);

            if (course == null) 
            {
                throw new Exception("Currency not found");
            }

            decimal price = course.BuyingPrice * input.ToBuy;

            if (price > int.Parse(_appConfiguration["Limits:AnonimusLimit"]))
            {
                throw new Exception("You can't buy that abount of Currency anonimus");
            }
        }
        else
        {
            var transactions = _transaction.GetAll()
                                    .Where(x => x.CreatorClientId == input.CreatorClientId)
                                    .Where(x => x.CreationDate >= DateTime.Today).ToList();
            var courses = _currencyCourse.GetAll().ToList();
            decimal price = courses.Single(x => x.Id == input.ToBuyCurrencyId).SellingPrice *(decimal) input.ToBuy;

            foreach (var t in transactions)
            {
                price += courses.Single(x => x.Id == t.ToBuyCurrencyId).SellingPrice  * t.ToBuy;
            }

            if(price > int.Parse(_appConfiguration["Limits:DayLimit"]))
            {
                throw new Exception("You can't buy that abount of Currency per day");
            }
        }

        var transaction = _mapper.Map<Transaction>(input);
        transaction.CreationDate = DateTime.Now;
        input.Id = _transaction.InsertAndGetId(transaction);
        return TransactionResult.Success;
    }

    public async Task<TransactionDto> Get(int id)
    {
        var transaction = _transaction.FirstOrDefault(x => x.Id == id);

        if (transaction == null)
        {
            throw new Exception("transaction not found");
        }

        var result = _mapper.Map<TransactionDto>(transaction);
        return result;
    }

    public async Task<PagedResultDto<TransactionDto>> GetAll(GetAlltransactionDto input)
    {
        var currencies = _transaction.GetAll()
                                        .WhereIf(input.PersonalNumber != null, x => x.CreatorClient.PersonalNumber == input.PersonalNumber)
                                        .WhereIf(input.ToSellCurrencyId != null, x => x.ToSellCurrencyId == input.ToSellCurrencyId)
                                        .WhereIf(input.ToBuyCurrencyId != null, x => x.ToBuyCurrencyId == input.ToBuyCurrencyId)
                                        .WhereIf(input.StartDate != null, x => x.CreationDate >= input.StartDate)
                                        .WhereIf(input.EndDate != null, x => x.CreationDate <= input.EndDate);
        var result = new PagedResultDto<TransactionDto>();
        result.TotalCount = currencies.Count();
        currencies = currencies.PageBy(input);
        result.Items = _mapper.Map<List<TransactionDto>>(currencies.ToList());
        return result;
    }

    public async Task<PagedResultDto<TransactionsDto>> GetAllTransactions(GetAlltransactionDto input)
    {
        var currencies = _transaction.GetAllIncluding(x => x.ToBuyCurrency,x => x.ToSellCurrency, x => x.CreatorClient)
                                        .WhereIf(input.PersonalNumber != null, x => x.CreatorClient.PersonalNumber == input.PersonalNumber)
                                        .WhereIf(input.ToSellCurrencyId != null, x => x.ToSellCurrencyId == input.ToSellCurrencyId)
                                        .WhereIf(input.ToBuyCurrencyId != null, x => x.ToBuyCurrencyId == input.ToBuyCurrencyId)
                                        .WhereIf(input.StartDate != null, x => x.CreationDate >= input.StartDate)
                                        .WhereIf(input.EndDate != null, x => x.CreationDate <= input.EndDate);
        var result = new PagedResultDto<TransactionsDto>();
        result.TotalCount = currencies.Count();
        currencies = currencies.PageBy(input);
        var query = from t in currencies
                       select new TransactionsDto
                       {
                           Id = t.Id,
                           SellCurrency = t.ToSellCurrency.Code,
                           ToSell = t.ToSell,
                           BuyCurrency = t.ToBuyCurrency.Code,
                           ToBuy = t.ToBuy,
                           CreatorClient = t.CreatorClientId == null? "":t.CreatorClient.PersonalNumber,
                        };
        result.Items = query.ToList();
        return result;
    }
}
