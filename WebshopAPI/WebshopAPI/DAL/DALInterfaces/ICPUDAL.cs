using System.Collections.Generic;
using System.Threading.Tasks;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.DAL.DALInterfaces
{
    public interface ICpuDAL : IBaseDAL<Cpu>
    {
        Task<IEnumerable<Cpu>> GetCpusBySocket(CpuSocketEnum socket);
    }
}
