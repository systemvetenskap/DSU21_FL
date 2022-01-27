using DSU21.Models;
using DSU21.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DSU21.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbRepository _repo;

        public HomeController(ILogger<HomeController> logger, IDbRepository repo)
        {
            _logger = logger;
           _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            // seed database
            var pirate = _repo.GetPirateById(4);
            //var ship = await _repo.AddShipAsync("Powder cannons");
            var ship = _repo.GetShip(4546);
            await Task.Delay(0);
            return View();
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
