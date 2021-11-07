using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.BLL.Classes
{
    public class CPUBLL : BaseBLL<CPU>, ICPUBLL
    {
        public Task<IEnumerable<CPU>> GetCompatibleCPUsByMotherboardCPUSocket(CPUSocketEnum CPUSocket)
        {
            throw new NotImplementedException();
        }
    }
}
