using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Enums;

namespace WebshopAPI.DAL.Models
{
    public class Ram : BaseProduct
    {
        public int Gb { get; set; }
        public int Delay { get; set; }
        public int Speed { get; set; }
        public RamSocketTypeEnum SocketType { get; set; }
    }
}
