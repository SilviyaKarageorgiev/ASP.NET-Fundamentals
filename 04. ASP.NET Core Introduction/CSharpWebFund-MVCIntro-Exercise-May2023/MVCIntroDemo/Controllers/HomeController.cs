using Microsoft.AspNetCore.Mvc;
using MVCIntroDemo.ViewModels;
using System.Diagnostics;

namespace MVCIntroDemo.Controllers
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
            // How to pass data from controller to the view
            // 1. Using Model -> large structured data, usually forms and details pages
            // 2. Using ViewBag -> random data using dynamic object
            // 3. Using ViewData -> Random data using dictionary

            ViewBag.Message = "Hello world from ViewBag!";
            ViewData["Msg"] = "Hello world from ViewData!";

            // Знае се кое view да се визуализира - случва се по конвенция, която е следната: в папката Views трябва да има папка с името на контролера (в случая Home), а в папката Home трябва има View с името на Action-a (в случая Index)

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "This is an ASP.NET Core MVC app.";
            return View();
        }

        public IActionResult Numbers()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NumbersToN()
        {
            ViewData["Count"] = -1;
            return this.View();
        }

        [HttpPost]
        public IActionResult NumbersToN(int count = -1)
        {
            ViewData["Count"] = count;
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}