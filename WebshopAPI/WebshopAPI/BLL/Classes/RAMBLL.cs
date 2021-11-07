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
    public class RAMBLL : BaseBLL<RAM>, IRAMBLL
    {
        protected readonly IRAMDAL _RAMDAL;

        public RAMBLL(IRAMDAL RAMDAL)
            :base(RAMDAL)
        {
            _RAMDAL = RAMDAL;
        }

        public async Task<IEnumerable<RAM>> GetCompatibleMemoriesByMotherboardMemorySocket(RAMSocketTypeEnum MemorySocket)
        {
            if (Enum.IsDefined(typeof(RAMSocketTypeEnum), MemorySocket))
            {
                return await _RAMDAL.GetCompatibleMemoriesByMotherboardMemorySocket(MemorySocket);
            }

            return null;
        }
    }
}
