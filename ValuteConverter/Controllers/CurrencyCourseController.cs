﻿using Microsoft.AspNetCore.Mvc;
using ValueConverter.Shared.Paging;
using ValuteConverter.Core.Dto;
using ValuteConverter.Core.Services.CurrencyCourseServices;

namespace ValuteConverter.Controllers;

[ApiController]
[Route($"api/[controller]/[action]")]
public class CurrencyCourseController : Controller
{
    private readonly ICurrencyCourseService _currencyCourseService;
    public CurrencyCourseController(ICurrencyCourseService currencyCourseService)
    {
        _currencyCourseService = currencyCourseService;
    }

    [HttpPost]
    public async Task<CurrencyCourseDto> Create(CurrencyCourseDto input)
    {
        return await _currencyCourseService.Create(input);
    }

    [HttpPut]
    public async Task<CurrencyCourseDto> Update(CurrencyCourseDto input)
    {
        return await _currencyCourseService.Update(input);
    }

    [HttpGet]
    public async Task<CurrencyCourseDto> Get(int id)
    {
        return await _currencyCourseService.Get(id);
    }

    [HttpDelete]
    public async Task Delete(int id)
    {
        await _currencyCourseService.Delete(id);
    }

    [HttpPost]
    public async Task<PagedResultDto<CurrencyCourseDto>> GetAll(GetAllCurrencyDto input)
    {
        return await _currencyCourseService.GetAll(input);
    }
}
