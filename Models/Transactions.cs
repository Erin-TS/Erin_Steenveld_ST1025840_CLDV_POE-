using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10258400_Erin_CLDV_POE.Models
{
    public class Transactions
    {
        public static string ConString = "Server=tcp:cloud-dev-poe.database.windows.net,1433;Initial Catalog=cloud-dev-poe-sql-database;Persist Security Info=False;User ID=Erin;Password=J@ckEr!n2003;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
       
        public static SqlConnection Con = new(ConString);

        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int ProductID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        // Retrieve orders
        public static List<Transactions> GetAllOrders()
        {
            var transactions = new List<Transactions>();

            using var con = new SqlConnection(ConString);
            const string sql = "SELECT * FROM Transactions";
            var cmd = new SqlCommand(sql, con);

            con.Open();
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var transaction = new Transactions
                {
                    TransactionId = Convert.ToInt32(rdr["TransactionID"]),
                    UserId = Convert.ToInt32(rdr["UserID"]),
                    ProductID = Convert.ToInt32(rdr["ProductID"]),
                    TransactionDate = Convert.ToDateTime(rdr["TransactionDate"]),
                    Quantity = Convert.ToInt32(rdr["Quantity"]),
                    TotalPrice = Convert.ToDecimal(rdr["TotalPrice"])
                };
                transactions.Add(transaction);
            }

            return transactions;
        }
    }
}
