using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10258400_Erin_CLDV_POE.Models
{
    public class LoginModel
    {
        private static readonly string  ConString = "Server=tcp:cloud-dev-poe.database.windows.net,1433;Initial Catalog=cloud-dev-poe-sql-database;Persist Security Info=False;User ID=Erin;Password=J@ckEr!n2003;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static int SelectUser(string Email, string FirstName)
        {
            var userId = -1; // Default value if user is not found
            using var con = new SqlConnection(ConString);
            const string sql = "SELECT userID FROM Users WHERE Email = @Email AND FirstName = @FirstName";
            var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
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
