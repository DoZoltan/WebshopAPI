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
        [Range(1, 9999)]
        public int Gb { get; set; }
        [Range(1, 9999)]
        public int Delay { get; set; }
        [Range(1, 99999)]
        public int Speed { get; set; }
        [RamSocketValidator]
        public RamSocketEnum SocketType { get; set; }
    }
}
