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
    public class CPUBLL : BaseBLL<CPU>, ICPUBLL
    {
        protected readonly ICPUDAL _CPUDAL;

        public CPUBLL(ICPUDAL CPUDAL)
            :base(CPUDAL)
        {
            _CPUDAL = CPUDAL;
        }

        public async Task<IEnumerable<CPU>> GetCompatibleCPUsByMotherboardCPUSocket(CPUSocketEnum CPUSocket)
        {
            if (Enum.IsDefined(typeof(CPUSocketEnum), CPUSocket))
            {
                return await _CPUDAL.GetCompatibleCPUsByMotherboardCPUSocket(CPUSocket);
            }

            return null;
        }
    }
}
