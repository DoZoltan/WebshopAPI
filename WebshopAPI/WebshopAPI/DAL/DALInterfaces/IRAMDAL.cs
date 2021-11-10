using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.DAL.DALInterfaces
{
    public interface IRamDAL : IBaseDAL<Ram>
    {
        Task<IEnumerable<Ram>> GetMemoriesBySocket(RamSocketEnum socket);
    }
}
