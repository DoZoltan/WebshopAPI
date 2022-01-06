namespace WebshopAPI.DAL.Models
{
    public class CartContent
    {
        public int Id { get; set; }
        public ShoppingCart Cart { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }
    }
}
