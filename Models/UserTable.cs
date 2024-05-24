using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10258400_Erin_CLDV_POE.Models
{
    public class UserTable
    {
        public static string ConString = "Server=tcp:cloud-dev-poe.database.windows.net,1433;Initial Catalog=cloud-dev-poe-sql-database;Persist Security Info=False;User ID=Erin;Password=J@ckEr!n2003;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection Con = new(ConString);


        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Email { get; set; }


        public int insert_User(UserTable m)
        {
            try
            {
                const string sql = "INSERT INTO userTable (UserName, UserSurname, Email) VALUES (@UserName, @UserSurname, @Email)";
                //const string sql = "INSERT INTO userTable (userID, userName, userSurname, userEmail) VALUES (@userID, @userName, @userSurname, @userEmail)";
                var cmd = new SqlCommand(sql, Con);
                var random = new Random();
                var randomNumber = random.Next(1, 1001);
                //cmd.Parameters.AddWithValue("@userID", randomNumber);
                cmd.Parameters.AddWithValue("@UserName", m.UserName);
                cmd.Parameters.AddWithValue("@userSurname", m.UserSurname);
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
