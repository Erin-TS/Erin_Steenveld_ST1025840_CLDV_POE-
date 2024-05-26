using Microsoft.AspNetCore.Mvc;
using ST10258400_Erin_CLDV_POE.Models;

namespace ST10258400_Erin_CLDV_POE.Controllers
{
    public class ProductController : Controller
    {
    
        public IActionResult MyWork()
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
            return View(prodtbl);
        }
    }
}