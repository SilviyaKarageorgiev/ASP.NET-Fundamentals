using Microsoft.AspNetCore.Mvc;
using TextSplitter.ViewModels;

namespace TextSplitter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(TextSplitViewModel textViewModel)
        {
            return View(textViewModel);
        }

        [HttpPost]
        public IActionResult Split(TextSplitViewModel textViewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Index", textViewModel);
            }

            string[] words = textViewModel.TextToSplit
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string splitText = string.Join(Environment.NewLine, words);
            textViewModel.SplitText = splitText;
            return this.RedirectToAction("Index", textViewModel);
        }
    }
}