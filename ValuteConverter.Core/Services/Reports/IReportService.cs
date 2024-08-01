using ValuteConverter.Domain.Dto;

namespace ValuteConverter.Core.Services.Reports;

public interface IReportService
{
    public Task<ReportDto> GetReport(GetReportInputDto input);
}
