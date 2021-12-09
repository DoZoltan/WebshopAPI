using System.Collections.Generic;
using System.Threading.Tasks;
using WebshopAPI.DAL.DTOs;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.BLL.Interfaces
{
    public interface IMotherboardBLL : IBaseBLL<Motherboard>
    {
        Task<IEnumerable<Motherboard>> GetMotherboardsByMemory(RamSocketEnum memorySocket);
        Task<IEnumerable<Motherboard>> GetMotherboardsByCPU(CpuSocketEnum cpuSocket);
        Task<IEnumerable<ProductGridDataDTO>> GetProductsForGridData();
    }
}
