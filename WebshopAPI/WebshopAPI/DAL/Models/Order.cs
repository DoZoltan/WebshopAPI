using System;

namespace WebshopAPI.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
