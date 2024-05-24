using Microsoft.AspNetCore.Mvc;
using ST10258400_Erin_CLDV_POE.Models;

namespace ST10258400_Erin_CLDV_POE.Controllers
{
    public class ProductDisplayController : Controller
    {
        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult MyWork()
        {
            return View();
        }

        public IActionResult Index(int userID)
        {
            // Get all products from the database
            List<ProductDisplayModel> products = GetProductsFromDatabase();

            // Pass products to the view
            ViewBag.MyWork = products;

            // Pass userID to the view (if needed)
            ViewData["userID"] = userID;

            return View();
        }

        // Method to fetch products from the database
        private List<ProductDisplayModel> GetProductsFromDatabase()
        {
            // Implement your logic to fetch products from the database
            // For demonstration, let's assume we have a list of products
            List<ProductDisplayModel> products = new List<ProductDisplayModel>
            {
                new ProductDisplayModel { ProductID = 1, ProductName = "Product 1", Price = 10.99m, Description = "Description 1", QuantityInStock = true },
                new ProductDisplayModel { ProductID = 2, ProductName = "Product 2", Price = 20.99m, Description = "Description 2", QuantityInStock = false },
                // Add more products as needed
            };

            return products;
        }
    }
}