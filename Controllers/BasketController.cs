using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;
using ST10258400_Erin_CLDV_POE.Models;

namespace ST10258400_Erin_CLDV_POE.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            // Retrieve basket items from the database
            var basketItems = Basket.GetAllBasketItems(); // Assuming GetAllBasketItems() retrieves all basket items from the database

            // Pass basket items data to the view
            return View(basketItems);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            // Retrieve product details based on productId
            var product = Product.GetProductById(productId); // Assuming GetProductById(productId) retrieves product details from the database

            // Add the product to the basket
            Basket.AddToBasket(product); // Assuming AddToBasket(product) adds the product to the basket in the database

            // Redirect to the MyWork page or wherever appropriate
            return RedirectToAction("MyWork", "Home");
        }
    }
}
