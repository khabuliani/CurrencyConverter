using Microsoft.AspNetCore.Mvc;
using ValuteConverter.Core.Services.CurrencyServices;
using ValuteConverter.Domain.Dto;

namespace ValuteConverter.Web.Controllers
{
    public class CurrenciesController : Controller
    {
        private readonly ICurrencyService _currencyAppService;
        public CurrenciesController(ICurrencyService currencyAppService)
        {
            _currencyAppService = currencyAppService;
        }
        [HttpGet]
        public async Task<ActionResult> Index(GetAllCurrencyDto input)
        {

            return View(await _currencyAppService.GetAll(input));
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return View(await _currencyAppService.Get(id));
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CurrencyDto currency)
        {
            currency = await _currencyAppService.Create(currency);
            return View(currency);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            return View(await _currencyAppService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(CurrencyDto currency)
        {
            await _currencyAppService.Update(currency);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {

            return View(await _currencyAppService.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _currencyAppService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

