using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.DAL.DALInterfaces
{
    public interface IRAMDAL : IBaseDAL<RAM>
    {
        Task<IEnumerable<RAM>> GetCompatibleMemoriesByMotherboardMemorySocket(string MemorySocket);
    }
}
