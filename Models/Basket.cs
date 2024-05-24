using Microsoft.AspNetCore.Mvc;
namespace ST10258400_Erin_CLDV_POE.Models
{
    public class BasketItem
    {
        public int BasketId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
