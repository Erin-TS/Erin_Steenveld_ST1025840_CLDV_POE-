using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10258400_Erin_CLDV_POE.Models
{
    public class ProductTable
    {
        public static string ConString = "Server=tcp:cloud-dev-poe.database.windows.net,1433;Initial Catalog=cloud-dev-poe-sql-database;Persist Security Info=False;User ID=Erin;Password=J@ckEr!n2003;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection Con = new(ConString);

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }

        public int insert_product(ProductTable p)
        {
            try
            {
                const string sql = "INSERT INTO Products (ProductID, ProductName, Description, Price, QuantityInStock, ImagePath, Category) VALUES (@ProductID, @ProductName, @Description, @Price, @QuantityInStock, @ImagePath, @Category)";
                var cmd = new SqlCommand(sql, Con);
                var random = new Random();
                var randomNumber = random.Next(100, 10001);

                cmd.Parameters.AddWithValue("@ProductID", randomNumber);
                cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
                cmd.Parameters.AddWithValue("@Description", p.Description);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@QuantityInStock", p.QuantityInStock);
                cmd.Parameters.AddWithValue("@ImagePath", p.ImagePath);
                cmd.Parameters.AddWithValue("@Category", p.Category);

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

        // Method to retrieve all products from the database
        public static List<ProductTable> GetAllProducts()
        {
            var products = new List<ProductTable>();
            using var con = new SqlConnection(ConString);
            const string sql = "SELECT * FROM Products";
            var cmd = new SqlCommand(sql, con);

            con.Open();
            var rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                var product = new ProductTable
                {
                    ProductID = Convert.ToInt32(rdr["ProductID"]),
                    ProductName = rdr["ProductName"].ToString(),
                    Price = Convert.ToDecimal(rdr["Price"]),
                    Description = rdr["Description"].ToString(),
                    QuantityInStock = Convert.ToInt32(rdr["QuantityInStock"]),
                    ImagePath = rdr["ImagePath"].ToString(),
                    Category = rdr["Category"].ToString()
                };

                products.Add(product);
            }

            return products;
        }
    }
}