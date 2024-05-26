using Microsoft.AspNetCore.Mvc;
using ST10258400_Erin_CLDV_POE.Models;

namespace ST10258400_Erin_CLDV_POE.Controllers
{
    public class LoginController : Controller
    {

        private readonly LoginModel _login;

        public LoginController()
        {

            _login = new LoginModel();

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
        public IActionResult LadingLofingSignUp()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Privacy(string email, string name)
        {
            var loginModel = new LoginModel();


            var userID = LoginModel.SelectUser(email, name);


            if (userID != -1)
            {


                return RedirectToAction("MyWork", "Home", new { userID = userID });
            }




            return View("Index");

        }

    }
}