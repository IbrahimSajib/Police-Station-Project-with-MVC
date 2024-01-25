using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Police_Station.Models;
using Police_Station.Models.DbContext;
using System.Diagnostics;

namespace Police_Station.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PoliceStationDbContext _context;

        public HomeController(ILogger<HomeController> logger,PoliceStationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Admin,Police")]
        public IActionResult Dashboard()
        {
            ViewBag.totalPolice = _context.PoliceOfficers.Count();
            ViewBag.totalCriminals = _context.Criminals.Count();
            ViewBag.totalCaseApplications = _context.CaseApplications.Count();
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
