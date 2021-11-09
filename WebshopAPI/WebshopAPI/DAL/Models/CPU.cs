using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Enums;

namespace WebshopAPI.DAL.Models
{
    public class Cpu : BaseProduct
    {
        public int CoreNumber { get; set; }
        public int L3Cache { get; set; }
        public int Speed { get; set; }
        public CpuSocketEnum SocketType { get; set; }
    }
}
