using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Data.SqlClient;



namespace ST10258400_Erin_CLDV_POE.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult InsertProduct()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PlaceOrder(int userID, int ProductID, int price)
        {
            try
            {
                var ConString = "Server=tcp:clouddev-sql-server101.database.windows.net,1433;Initial Catalog=clod-sql-DB;Persist Security Info=False;User ID=Kashvir;Password=BrunoCorral1234#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                Console.WriteLine(userID);
                Console.WriteLine(ProductID);
                var con = new SqlConnection(ConString);
                var sql =
                    "INSERT INTO Transactions (TransactionID, UserID, ProductID, TransactionDate, Quantity, TotalAmount) VALUES (@TransactionID, @UserID, @ProductID, @TransactionDate, @Quantity, @TotalAmount)";

                var cmd = new SqlCommand(sql, con);
                {
                    var random = new Random();
                    var randomNumber = random.Next(1, 1001);

                    cmd.Parameters.AddWithValue("@TransactionID", randomNumber);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@ProductID", ProductID);
                    cmd.Parameters.AddWithValue("@TotalAmount", price);
                    cmd.Parameters.AddWithValue("Quantity", 1);
                    cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now);

                    con.Open();

                    var rowsAffected = cmd.ExecuteNonQuery();

                    con.Close();

                    if (rowsAffected > 0)
                        return RedirectToAction("Orders", "Home");
                    return View("Orders");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.StackTrace);
                return View("Error");
            }
        }
    }
}
