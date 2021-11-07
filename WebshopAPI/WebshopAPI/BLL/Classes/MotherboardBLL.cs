using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.BLL.Classes
{
    public class MotherboardBLL : BaseBLL<Motherboard>, IMotherboardBLL
    {
        public Task<IEnumerable<Motherboard>> GetCompatibleMotherboardsByCPUSocket(CPUSocketEnum CPUSocket)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Motherboard>> GetCompatibleMotherboardsByMemorySocket(RAMSocketTypeEnum MemorySocket)
        {
            throw new NotImplementedException();
        }
    }
}
