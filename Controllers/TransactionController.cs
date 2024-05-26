using System.Data.SqlClient;
using ST10258400_Erin_CLDV_POE.Models;
using Microsoft.AspNetCore.Mvc;
using ST10258400_Erin_CLDV_POE.Models;

namespace ST10258400_Erin_CLDV_POE.Controllers;

public class TransactionController : Controller
{
    private readonly Transactions _transactions;
    public TransactionController()
    {
        _transactions = new Transactions();
    }

    [HttpPost]
    public ActionResult PurchaseNow(int UserID, int productId, string ProductName,decimal price)
    {
        try
        {
            var conString = "Server=tcp:cloud-dev-poe.database.windows.net,1433;Initial Catalog=cloud-dev-poe-sql-database;Persist Security Info=False;User ID=Erin;Password=J@ckEr!n2003;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (var con = new SqlConnection(conString))
            {
                var sql = "INSERT INTO Transactions (UserID, ProductID, TransactionDate, Quantity, TotalAmount,ProductName) VALUES (@UserID, @ProductID, @TransactionDate, @Quantity, @TotalAmount,@ProductName)";
                var cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@Quantity", 1);
                cmd.Parameters.AddWithValue("@TotalAmount", price);
                cmd.Parameters.AddWithValue("@ProductName", ProductName);

                con.Open();
                var rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    return RedirectToAction("Orders", "Transaction");
                return View("Error");
            }
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = ex.Message;
            return View("Error");
        }
    }

    [HttpGet]
    public ActionResult Orders()
    {
        var transactions = Transactions.GetAllOrders();
        return View(transactions);
    }

}