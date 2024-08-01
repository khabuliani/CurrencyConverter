using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValuteConverter.Domain.Dto;

namespace ValuteConverter.Core.Services.CalulatorServices;

public interface ICalculatorService
{
    public Task<CalculatorDto> Calculate(CalculatorDto input);
}
