using Microsoft.AspNetCore.Mvc;
using ValuteConverter.Core.Services.CurrencyCourseServices;
using ValuteConverter.Core.Services.CurrencyServices;
using ValuteConverter.Domain.Dto;

namespace ValuteConverter.Web.Controllers
{
    public class CurrencyCoursesController : Controller
    {
        private readonly ICurrencyCourseService _currencyCourseService;
        public CurrencyCoursesController(ICurrencyCourseService currencyCourseService)
        {
            _currencyCourseService = currencyCourseService;
        }
        [HttpGet]
        public async Task<ActionResult> Index(GetAllCurrencyDto input)
        {

            return View(await _currencyCourseService.GetAll(input));
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return View(await _currencyCourseService.Get(id));
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CurrencyCourseDto currency)
        {
            currency = await _currencyCourseService.Create(currency);
            return View(currency);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            return View(await _currencyCourseService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(CurrencyCourseDto currency)
        {
            await _currencyCourseService.Update(currency);
            return RedirectToAction("Index");
        }

    }
}
