using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations.Schema;
using ST10258400_Erin_CLDV_POE.Models;


namespace ST10258400_Erin_CLDV_POE.Models
{
    public class BasketTable
    {
        public int BasketId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
    }
