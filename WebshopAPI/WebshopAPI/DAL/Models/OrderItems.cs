namespace WebshopAPI.DAL.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        public Order Order  { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
