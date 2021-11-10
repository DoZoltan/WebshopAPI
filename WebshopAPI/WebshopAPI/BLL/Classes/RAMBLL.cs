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
    public class RamBLL : BaseBLL<Ram>, IRamBLL
    {
        protected readonly IRamDAL _RamDAL;

        public RamBLL(IRamDAL RamDAL)
            :base(RamDAL)
        {
            _RamDAL = RamDAL;
        }

        public async Task<IEnumerable<Ram>> GetMemoriesBySocket(RamSocketEnum socket)
        {
            if (Enum.IsDefined(typeof(RamSocketEnum), socket))
            {
                return await _RamDAL.GetMemoriesBySocket(socket);
            }

            return null;
        }
    }
}
