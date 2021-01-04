using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResponseCaching.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ResponseCaching.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult CachePage()
        {
            ViewBag.tarih = DateTime.Now.ToLongTimeString();
            return View();
        }

        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false, VaryByQueryKeys = new[] { "id" })]
        public IActionResult CachePageWithParameter(int id)
        {
            ViewBag.id = id;
            ViewBag.tarih = DateTime.Now.ToLongTimeString();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}