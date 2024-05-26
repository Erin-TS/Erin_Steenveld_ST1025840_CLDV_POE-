using Microsoft.AspNetCore.Mvc;
using ST10258400_Erin_CLDV_POE.Models;
using System.Diagnostics;
using System.Data.SqlClient;
using ST10258400_Erin_CLDV_POE.Models;

namespace ST10258400_Erin_CLDV_POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LandingLofingSignUp()
        {
            return View();
        }
        public IActionResult Login()
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
        public IActionResult TransactionDetails()
        {

            return View();
        }
        public IActionResult Wishlist()
        {
            return View();
        }
        public IActionResult insert()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult MyWork(int UserID)
        {
            var products = ProductTable.GetAllProducts();
            ViewData["Products"] = products;
            ViewData["UserID"] = UserID;
            return View();
        }

        public IActionResult Orders()
        {
            var orders = Transactions.GetAllOrders();

            ViewData["Orders"] = orders;
            return View();
        }

        public IActionResult LadingLofingSignUp()
        {
            return View();
        }

     
        public IActionResult Insert()
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