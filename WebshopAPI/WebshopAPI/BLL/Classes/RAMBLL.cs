using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.DALInterfaces;
using WebshopAPI.DAL.DTOs;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;
using WebshopAPI.Services.DTOConverter;

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
            return await _RamDAL.GetMemoriesBySocket(socket);
        }

        public async Task<IEnumerable<ProductGridDataDTO>> GetProductsForGridData()
        {
            return (await GetAll()).Select(product => product.AsProductGridDataDTO());
        }
    }
}
