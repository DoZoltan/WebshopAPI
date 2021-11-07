using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.BLL.Interfaces
{
    interface IMotherboardBLL : IBaseBLL<Motherboard>
    {
        Task<IEnumerable<Motherboard>> GetCompatibleMotherboardsByMemorySocket(RAMSocketTypeEnum MemorySocket);
        Task<IEnumerable<Motherboard>> GetCompatibleMotherboardsByCPUSocket(CPUSocketEnum CPUSocket);
    }
}
