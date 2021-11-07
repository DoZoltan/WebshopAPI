using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.DAL.DALInterfaces
{
    public interface IMotherboardDAL : IBaseDAL<Motherboard>
    {
        Task<IEnumerable<Motherboard>> GetCompatibleMotherboardsByMemorySocket(string MemorySocket);
        Task<IEnumerable<Motherboard>> GetCompatibleMotherboardsByCPUSocket(CPUSocketEnum CPUSocket);
    }
}
