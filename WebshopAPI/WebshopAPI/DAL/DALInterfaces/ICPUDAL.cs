using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.DAL.DALInterfaces
{
    public interface ICPUDAL : IBaseDAL<CPU>
    {
        Task<IEnumerable<CPU>> GetCompatibleCPUsByMotherboardCPUSocket(CPUSocketEnum CPUSocket);
    }
}
