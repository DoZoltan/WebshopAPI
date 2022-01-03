using System.Collections.Generic;

namespace WebshopAPI.DAL.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public User Owner { get; set; }
        public string OwnerId { get; set; }
    }
}
