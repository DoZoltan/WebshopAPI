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
        [Range(1, 999)]
        public int CoreNumber { get; set; }
        [Range(1, 999)]
        public int L3Cache { get; set; }
        [Range(1, 99999)]
        public int Speed { get; set; }
        [CpuSocketValidator]
        public CpuSocketEnum SocketType { get; set; }
    }
}
