using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.BLL.Interfaces
{
    public interface IMotherboardBLL : IBaseBLL<Motherboard>
    {
        Task<IEnumerable<Motherboard>> GetMotherboardsByMemory(RamSocketEnum memorySocket);
        Task<IEnumerable<Motherboard>> GetMotherboardsByCPU(CpuSocketEnum cpuSocket);
    }
}
