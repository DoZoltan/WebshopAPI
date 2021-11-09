using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Enums;
using WebshopAPI.Services.ModelValidators;

namespace WebshopAPI.DAL.Models
{
    public class Cpu : BaseProduct
    {
        [Required]
        public int CoreNumber { get; set; }
        [Required]
        public int L3Cache { get; set; }
        [Required]
        public int Speed { get; set; }
        [Required]
        [CpuSocketValidator]
        public CpuSocketEnum SocketType { get; set; }
    }
}
