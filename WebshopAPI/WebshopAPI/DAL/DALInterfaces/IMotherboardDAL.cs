using System.Collections.Generic;
using System.Threading.Tasks;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.DAL.DALInterfaces
{
    public interface IMotherboardDAL : IBaseDAL<Motherboard>
    {
        Task<IEnumerable<Motherboard>> GetMotherboardsByMemory(RamSocketEnum memorySocket);
        Task<IEnumerable<Motherboard>> GetMotherboardsByCPU(CpuSocketEnum cpuSocket);
    }
}
