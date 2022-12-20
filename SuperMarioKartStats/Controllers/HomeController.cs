using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SQLitePCL;
using SuperMarioKartStats.Models;
using System.Diagnostics;

namespace SuperMarioKartStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StatisticContext _context;
        //private Dictionary<string, Driver> Drivers;
        private StatisticsViewModel? StatisticsViewModel;

        public HomeController(ILogger<HomeController> logger, StatisticContext context)
        {
            _logger = logger;
            _context = context;
          //_= _context.ProcessAsync();
        }

        public IActionResult Index()
        {


            List<SelectListItem> stats = new List<SelectListItem>();
            StatisticsViewModel = new StatisticsViewModel(_context);

            foreach (var x in StatisticsViewModel.Stats)
            {
                stats.Add(new SelectListItem { Value = x, Text = x });
            }
            ViewBag.StatsList = stats;

            stats = new List<SelectListItem>();
            foreach (var x in StatisticsViewModel.Drivers)
            {
                stats.Add(new SelectListItem { Value = x.Key.ToString(), Text = x.Name });
            }
            ViewBag.Drivers = stats;

            stats = new List<SelectListItem>();
            foreach (var x in StatisticsViewModel.Bodies)
            {
                stats.Add(new SelectListItem { Value = x.Key.ToString(), Text = x.Name });
            }
            ViewBag.Bodies = stats;

            stats = new List<SelectListItem>();
            foreach (var x in StatisticsViewModel.Tires)
            {
                stats.Add(new SelectListItem { Value = x.Key.ToString(), Text = x.Name });

            }
            ViewBag.Tires = stats;

            stats = new List<SelectListItem>();
            foreach (var x in StatisticsViewModel.Gliders)
            {
                stats.Add(new SelectListItem { Value = x.Key.ToString(), Text = x.Name });

            }
            ViewBag.Gliders = stats;

            //ViewBag.Driver = new SelectList(Drivers, "Key", "Name");
            //ViewBag.Bodies = new SelectList(Bodies, "Key", "Name");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DriverStatsDropdown(StatisticsViewModel model)
        {
            return RedirectToAction("StatisticsDropdown");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}