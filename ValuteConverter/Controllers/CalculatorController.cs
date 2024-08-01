using Microsoft.AspNetCore.Mvc;
using ValuteConverter.Core.Services.CalulatorServices;
using ValuteConverter.Domain.Dto;

namespace ValuteConverter.Controllers
{
    [ApiController]
    [Route($"api/[controller]/[action]")]
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _calculatorService;
        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpPost]
        public async Task<CalculatorDto> Calculate(CalculatorDto input)
        {
            return await _calculatorService.Calculate(input);
        }
    }
}
