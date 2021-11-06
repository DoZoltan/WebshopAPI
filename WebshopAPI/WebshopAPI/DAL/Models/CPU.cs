using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DAL.Models
{
    public class CPU : BaseProduct
    {
        public int CoreNumber { get; set; }
        public int L3Cache { get; set; }
        public int Speed { get; set; }
        public string SocketType { get; set; }
    }
}
