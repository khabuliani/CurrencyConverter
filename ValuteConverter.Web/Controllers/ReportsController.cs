using Microsoft.AspNetCore.Mvc;
using ValuteConverter.Core.Dto;
using ValuteConverter.Core.Services.Reports;

namespace ValuteConverter.Web.Controllers;

public class ReportsController : Controller
{
    private readonly IReportService _reportService;
    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }
    [HttpGet]
    public ActionResult Index()
    {
        return View(new GetReportInputDto());
    }

    [HttpPost]
    public async Task<ActionResult> Index(GetReportInputDto input)
    {
            var report = await _reportService.GetReport(input);
            return View("Report", report);
    }
}
