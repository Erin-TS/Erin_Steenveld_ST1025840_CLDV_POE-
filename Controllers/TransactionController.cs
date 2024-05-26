using CloudDevelopment.Models;
using Microsoft.AspNetCore.Mvc;
using ST10258400_Erin_CLDV_POE.Models;
using System;
using System.Data.SqlClient;

namespace CloudDev101.Controllers
{
    public class TransactionController : Controller
    {

        // Connection string
        string conString = "Server=tcp:cloud-dev-poe.database.windows.net,1433;Initial Catalog=cloud-dev-poe-sql-database;Persist Security Info=False;User ID=Erin;Password=J@ckEr!n2003;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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

        // SQL query to insert a new transaction
        [HttpPost]
        public IActionResult AddToBasket(int productId, int userId)
        {
            try
            {
                // Retrieve the product details from the database
                var product = ProductTable.GetProductById(productId);

                // Create a new transaction object
                var transaction = new Transactions
                {
                    UserId = userId,
                    ProductId = productId,
                    TransactionDate = DateTime.Now,
                    Quantity = 1, // Assuming quantity is always 1 for now
                    TotalAmount = product.Price
                };

                // Insert the transaction into the database
                using (var con = new SqlConnection(conString))
                {
                    con.Open();
                    var sql = "INSERT INTO Transactions (UserID, ProductID, TransactionDate, Quantity, TotalAmount) VALUES (@UserId, @ProductId, @TransactionDate, @Quantity, @TotalAmount)";
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@UserId", transaction.UserId);
                    cmd.Parameters.AddWithValue("@ProductId", transaction.ProductId);
                    cmd.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                    cmd.Parameters.AddWithValue("@Quantity", transaction.Quantity);
                    cmd.Parameters.AddWithValue("@TotalAmount", transaction.TotalAmount);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                // Pass the transaction details to the view
                return View("TransactionDetails", transaction);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);

                // Return an error view or handle the exception as needed
                return View("Error");
            }
        }
    }
}