namespace ValuteConverter.Core.Dto;

public class GetReportInputDto
{
    public string PersonalNumber { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
