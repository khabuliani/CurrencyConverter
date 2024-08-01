using Microsoft.AspNetCore.Mvc;
using ValuteConverter.Core.Dto;
using ValuteConverter.Core.Services.Reports;

namespace ValuteConverter.Controllers;

[ApiController]
[Route($"api/[controller]/[action]")]
public class ReportController : Controller
{
    private readonly IReportService _reportService;
    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpPost]
    public async Task<ReportDto> GetReport(GetReportInputDto input)
    {
        return await _reportService.GetReport(input);
    }
}
