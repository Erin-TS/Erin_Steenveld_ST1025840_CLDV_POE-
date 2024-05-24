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
    }
}
