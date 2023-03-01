using HouseRent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using System.Dynamic;

namespace HouseRent.Controllers
{
    public class HouseRentController : Controller
    {
        private readonly ILogger<HouseRentController> _logger;

        public HouseRentController(ILogger<HouseRentController> logger, IConfiguration Configuration)
        {
            _logger = logger;

        }

        public IActionResult Index()
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