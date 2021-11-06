using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.DAL.DAL_Interfaces
{
    public interface IRAMDAL : IBaseDAL<RAM>
    {
        Task<IEnumerable<RAM>> GetCompatibleMemoriesByMotherboardMemorySocket(string MemorySocket);
    }
}
