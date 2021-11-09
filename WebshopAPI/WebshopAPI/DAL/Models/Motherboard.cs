using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Enums;

namespace WebshopAPI.DAL.Models
{
    public class Motherboard : BaseProduct
    {
        public int Usb3Amount { get; set; }
        public bool Wifi { get; set; }
        public MotherboardSizeStandardEnum SizeStandard { get; set; }
        public CpuSocketEnum CpuSocketType { get; set; }
        public RamSocketTypeEnum MemorySocketType { get; set; }
        public int MaxMemorySize { get; set; }
        public int NumberOfMemorySockets { get; set; }
    }
}
