using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XUnitTutorial.API.Interfaces;
using XUnitTutorial.API.Models;
using XUnitTutorial.UI.Models;

namespace XUnitTutorial.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productsService;

        public HomeController(IProductService productsService)
        {
            _productsService = productsService;
        }

        public IActionResult Index()
        {
            List<Product> products = _productsService.GetAllProduct().ToList();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
