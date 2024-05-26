using System.Data.SqlClient;

namespace CloudDevelopment.Models
{
    public class Transactions
    {
        private static string _conString = "Server=tcp:cloud-dev-poe.database.windows.net,1433;Initial Catalog=cloud-dev-poe-sql-database;Persist Security Info=False;User ID=Erin;Password=J@ckEr!n2003;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }

        // Retrieve orders
        public static List<Transactions> GetAllOrders()
        {
            var transactions = new List<Transactions>();
            using var con = new SqlConnection(_conString);
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
                    ProductId = Convert.ToInt32(rdr["ProductID"]),
                    TransactionDate = Convert.ToDateTime(rdr["TransactionDate"]),
                    Quantity = Convert.ToInt32(rdr["Quantity"]),
                    TotalAmount = Convert.ToDecimal(rdr["TotalAmount"])
                };

                transactions.Add(transaction);
            }

            return transactions;
        }
    }
}