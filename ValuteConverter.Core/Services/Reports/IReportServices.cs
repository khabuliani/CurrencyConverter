using ValuteConverter.Domain.Dto;

namespace ValuteConverter.Core.Services.Reports;

public interface IReportServices
{
    public Task<ReportDto> GetReport(GetReportInputDto input);
}
