using _2b.SumNumbersMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2b.SumNumbersMvc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var summator = new Summator();
            return View(summator);
        }

        [HttpPost]
        public ActionResult Index(Summator summator)
        {
            summator.Result = SumNumbers(summator.FirstNumber, summator.SecondNumber);
            return View(summator);
        }

        private decimal SumNumbers(decimal first, decimal second)
        {
            return first + second;
        }
    }
}