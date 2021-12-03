using System.Collections.Generic;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.DALInterfaces;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.BLL.Classes
{
    public class CpuBLL : BaseBLL<Cpu>, ICpuBLL
    {
        protected readonly ICpuDAL _CpuDAL;

        public CpuBLL(ICpuDAL CpuDAL)
            :base(CpuDAL)
        {
            _CpuDAL = CpuDAL;
        }

        public async Task<IEnumerable<Cpu>> GetCpusBySocket(CpuSocketEnum socket)
        {
            return await _CpuDAL.GetCpusBySocket(socket);
        }
    }
}
