using ValuteConverter.Core.Dto;

namespace ValuteConverter.Core.Services.CalulatorServices;

public interface ICalculatorService
{
    public Task<CalculatorDto> Calculate(CalculatorDto input);
}
