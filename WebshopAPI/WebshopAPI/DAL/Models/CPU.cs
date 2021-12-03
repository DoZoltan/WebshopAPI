using System;
using System.ComponentModel.DataAnnotations;
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
