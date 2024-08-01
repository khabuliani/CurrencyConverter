using ValuteConverter.Core.Dto;

namespace ValuteConverter.Core.Services.Reports;

public interface IReportService
{
    public Task<ReportDto> GetReport(GetReportInputDto input);
}
