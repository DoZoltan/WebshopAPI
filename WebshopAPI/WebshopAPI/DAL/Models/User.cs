using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WebshopAPI.DAL.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ShoppingCart Cart { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
