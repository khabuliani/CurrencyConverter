﻿using Microsoft.AspNetCore.Mvc;

namespace ValuteConverter.Web.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
