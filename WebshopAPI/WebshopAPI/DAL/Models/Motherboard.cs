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
        [Required]
        public int Usb3Amount { get; set; }
        [Required]
        public bool Wifi { get; set; }
        [Required]
        [SizeStandardValidator]
        public MotherboardSizeStandardEnum SizeStandard { get; set; }
        [Required]
        [CpuSocketValidator]
        public CpuSocketEnum CpuSocketType { get; set; }
        [Required]
        [RamSocketValidator]
        public RamSocketEnum MemorySocketType { get; set; }
        [Required]
        public int MaxMemorySize { get; set; }
        [Required]
        public int NumberOfMemorySockets { get; set; }
    }
}
