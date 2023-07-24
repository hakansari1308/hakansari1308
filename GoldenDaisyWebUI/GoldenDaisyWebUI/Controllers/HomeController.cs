using GoldenDaisyWebUI.Data;
using GoldenDaisyWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GoldenDaisyWebUI.Controllers
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
        
        public IActionResult Hakkimizda()
        {
            return View();
        }
        public IActionResult Randevu()
        {
            return View();
        }
        public IActionResult Iletisim()
        {
            return View();
        }
        public IActionResult adminlist()
        {
            return View();
        }
        public IActionResult profil()
        {
            return View();
        }
        public IActionResult login() {
        return View();
        }
        public IActionResult sign() {
            return View();
        }
        public IActionResult duyuru()
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