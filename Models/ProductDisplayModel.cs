using Microsoft.AspNetCore.Mvc;

namespace ST10258400_Erin_CLDV_POE.Models
{
    public class ProductDisplayModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool QuantityInStock { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }
    }
}