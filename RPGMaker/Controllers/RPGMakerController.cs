using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RPGMaker.Controllers
{
    public class RPGMakerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RPGMaker()
        {
            return View();
        }

        public IActionResult Rules()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}