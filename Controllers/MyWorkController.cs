using Microsoft.AspNetCore.Mvc;
using ST10258400_Erin_CLDV_POE.Models;

namespace ST10258400_Erin_CLDV_POE.Controllers
{
    public class MyWorkController : Controller
    {
        public IActionResult Index()
        {
            // Retrieve product data from the database
            var products = ProductTable.GetAllProducts(); // Assuming GetAllProducts() retrieves all products from the database

            // Pass product data to the view
            return View(products);
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult LadingLofingSignUp()
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
        public IActionResult MyWork()
        {
            return View();
        }
        public IActionResult Notification()
        {
            return View();
        }
        public IActionResult Orders()
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
    }
}