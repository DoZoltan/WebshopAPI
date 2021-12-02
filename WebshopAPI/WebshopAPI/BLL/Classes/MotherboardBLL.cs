using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.DALInterfaces;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.BLL.Classes
{
    public class MotherboardBLL : BaseBLL<Motherboard>, IMotherboardBLL
    {
        protected readonly IMotherboardDAL _motherboardDAL;

        public MotherboardBLL(IMotherboardDAL motherboardDAL)
            :base(motherboardDAL)
        {
            _motherboardDAL = motherboardDAL;
        }

        public async Task<IEnumerable<Motherboard>> GetMotherboardsByCPU(CpuSocketEnum cpuSocket)
        {
            return await _motherboardDAL.GetMotherboardsByCPU(cpuSocket);
        }

        public async Task<IEnumerable<Motherboard>> GetMotherboardsByMemory(RamSocketEnum memorySocket)
        {
            return await _motherboardDAL.GetMotherboardsByMemory(memorySocket);
        }
    }
}
