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

        public async Task<IEnumerable<Motherboard>> GetCompatibleMotherboardsByCPUSocket(CPUSocketEnum CPUSocket)
        {
            if (Enum.IsDefined(typeof(CPUSocketEnum), CPUSocket))
            {
                return await _motherboardDAL.GetCompatibleMotherboardsByCPUSocket(CPUSocket);
            }

            return null;
        }

        public async Task<IEnumerable<Motherboard>> GetCompatibleMotherboardsByMemorySocket(RAMSocketTypeEnum memorySocket)
        {
            if (Enum.IsDefined(typeof(RAMSocketTypeEnum), memorySocket))
            {
                return await _motherboardDAL.GetCompatibleMotherboardsByMemorySocket(memorySocket);
            }

            return null;
        }
    }
}
