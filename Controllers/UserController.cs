using Microsoft.AspNetCore.Mvc;
using ST10258400_Erin_CLDV_POE.Models;

namespace ST10258400_Erin_CLDV_POE.Controllers
{
    public class UserController : Controller
    {
        public UserTable usrtbl = new UserTable();


        [HttpPost]
        public ActionResult Privacy(UserTable Users)
        {
            var result = usrtbl.insert_User(Users);
            return RedirectToAction("MyWork", "Home");
        }


        [HttpGet]
        public ActionResult Privacy()
        {
            return View(usrtbl);
        }

        public IActionResult SignUp()
        {
            return View(); // This will make it visable on the webpage 
        }

    }
}

