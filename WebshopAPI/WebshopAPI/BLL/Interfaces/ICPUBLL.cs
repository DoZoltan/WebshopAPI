using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.BLL.Interfaces
{
    public interface ICPUBLL : IBaseBLL<CPU>
    {
        Task<IEnumerable<CPU>> GetCompatibleCPUsByMotherboardCPUSocket(CPUSocketEnum CPUSocket);
    }
}
