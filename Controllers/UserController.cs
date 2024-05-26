using Microsoft.AspNetCore.Mvc;
using ST10258400_Erin_CLDV_POE.Models;

namespace ST10258400_Erin_CLDV_POE.Controllers
{
    public class UserController : Controller
    {
        private readonly UserTable _userTable;


        public UserController()
        {
            _userTable = new UserTable();
        }



        [HttpPost]
        public ActionResult SignUp(UserTable user)
        {
            // Perform validation
            if (!ModelState.IsValid)
            {
                // Return to the sign-up view with validation errors
                return View(user);
            }

            // Insert the user into the database
            var result = _userTable.insert_User(user);

            // Redirect to the appropriate action after sign-up
            return RedirectToAction("MyWork", "Home");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(); // Render the sign-up form
        }
    }
}