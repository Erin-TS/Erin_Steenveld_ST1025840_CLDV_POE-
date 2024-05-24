using Microsoft.AspNetCore.Mvc;
using ST10258400_Erin_CLDV_POE.Models;
using System.Diagnostics;

namespace ST10258400_Erin_CLDV_POE.Controllers
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

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
     
        public IActionResult Basket()
        {
            return View();
        }
        public IActionResult Wishlist()
        {
            return View();
        }
        public IActionResult Notification()
        {
            return View();
        }
        public IActionResult PaymentCheckout()
        {
            return View();
        }
      
      
        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult MyWork()
        {
            var products = ProductTable.GetAllProducts();
            ViewData["Products"] = products;
            ViewData["userID"] = 123; // Replace with actual user ID logic
            return View();
        }
        public IActionResult insert()
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
