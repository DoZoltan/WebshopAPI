using System.Collections.Generic;

namespace WebshopAPI.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public User Owner { get; set; }
    }
}
