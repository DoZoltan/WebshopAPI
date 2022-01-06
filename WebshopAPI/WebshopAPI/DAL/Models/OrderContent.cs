namespace WebshopAPI.DAL.Models
{
    public class OrderContent
    {
        public int Id { get; set; }
        public Order Order  { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }
    }
}
