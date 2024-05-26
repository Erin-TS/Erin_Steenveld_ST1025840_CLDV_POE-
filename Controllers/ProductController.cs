using Microsoft.AspNetCore.Mvc;
using ST10258400_Erin_CLDV_POE.Models;

namespace ST10258400_Erin_CLDV_POE.Controllers
{
    public class ProductController : Controller
    {
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
        public IActionResult LadingLofingSignUp()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public ProductTable prodtbl = new ProductTable();

        [HttpPost]
        public IActionResult insert(ProductTable products)
        {
            var result2 = prodtbl.insert_product(products);
            return RedirectToAction("MyWork", "Home");
        }

        [HttpGet]
        public ActionResult insert()
        {
            return View();
        }
    }
}