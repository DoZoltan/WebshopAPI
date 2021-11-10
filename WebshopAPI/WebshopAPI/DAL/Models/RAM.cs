using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Enums;
using WebshopAPI.Services.ModelValidators;

namespace WebshopAPI.DAL.Models
{
    public class Ram : BaseProduct
    {
        [Required]
        public int Gb { get; set; }
        [Required]
        public int Delay { get; set; }
        [Required]
        public int Speed { get; set; }
        [Required]
        [RamSocketValidator]
        public RamSocketEnum SocketType { get; set; }
    }
}
