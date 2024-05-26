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

        
        public IActionResult LandingLofingSignUp()
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