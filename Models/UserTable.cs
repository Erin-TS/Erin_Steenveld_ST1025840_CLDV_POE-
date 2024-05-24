using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10258400_Erin_CLDV_POE.Models
{
    public class UserTable
    {
        public static string ConString = "Server=tcp:cloud-dev-poe.database.windows.net,1433;Initial Catalog=cloud-dev-poe-sql-database;Persist Security Info=False;User ID=Erin;Password=J@ckEr!n2003;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection Con = new(ConString);


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public int insert_User(UserTable m)
        {
            try
            {
                const string sql = "INSERT INTO [Users] (UserID,FirstName, LastName, Email) VALUES (@UserID,@FirstName, @LastName, @Email)";
                //const string sql = "INSERT INTO userTable (userID, FirstName, LastName, userEmail) VALUES (@userID, @FirstName, @LastName, @userEmail)";
                var cmd = new SqlCommand(sql, Con);
                var random = new Random();
                var randomNumber = random.Next(1, 1001);
                cmd.Parameters.AddWithValue("@UserID", randomNumber);
                cmd.Parameters.AddWithValue("@FirstName", m.FirstName);
                cmd.Parameters.AddWithValue("@LastName", m.LastName);
                cmd.Parameters.AddWithValue("@Email", m.Email);
                Con.Open();
                var rowsAffected = cmd.ExecuteNonQuery();
                Con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }
        }
    }
}
