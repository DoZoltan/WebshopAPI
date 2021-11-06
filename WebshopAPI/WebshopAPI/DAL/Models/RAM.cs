using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DAL.Models
{
    public class RAM : BaseProduct
    {
        public int Gb { get; set; }
        public int Height { get; set; }
        public int Delay { get; set; }
        public int Speed { get; set; }
        public string SocketType { get; set; }
    }
}
