using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Enums;
using WebshopAPI.Services.ModelValidators;

namespace WebshopAPI.DAL.Models
{
    public class Motherboard : BaseProduct
    {
        [Range(1, 99)]
        public int Usb3Amount { get; set; }
        [Required]
        public bool Wifi { get; set; }
        [SizeStandardValidator]
        public MotherboardSizeStandardEnum SizeStandard { get; set; }
        [CpuSocketValidator]
        public CpuSocketEnum CpuSocketType { get; set; }
        [RamSocketValidator]
        public RamSocketEnum MemorySocketType { get; set; }
        [Range(1, 99999)]
        public int MaxMemorySize { get; set; }
        [Range(1, 99)]
        public int NumberOfMemorySockets { get; set; }
    }
}
