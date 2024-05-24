using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10258400_Erin_CLDV_POE.Models
{
    public class LoginModel
    {
        private static readonly string ConString = "Server=tcp:clouddev-sql-server101.database.windows.net,1433;Initial Catalog=clod-sql-DB;Persist Security Info=False;User ID=Kashvir;Password=BrunoCorral1234#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static int SelectUser(string email, string name)
        {
            var userId = -1; // Default value if user is not found
            using var con = new SqlConnection(ConString);
            const string sql = "SELECT userID FROM userTable WHERE userEmail = @userEmail AND userName = @userName";
            var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@userEmail", email);
            cmd.Parameters.AddWithValue("@userName", name);
            try
            {
                con.Open();
                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value) userId = Convert.ToInt32(result);
            }
            catch (Exception)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw;
            }

            return userId;
        }
    }
}
