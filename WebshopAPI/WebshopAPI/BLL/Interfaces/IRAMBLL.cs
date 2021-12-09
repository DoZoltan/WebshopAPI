using System.Collections.Generic;
using System.Threading.Tasks;
using WebshopAPI.DAL.DTOs;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.BLL.Interfaces
{
    public interface IRamBLL : IBaseBLL<Ram>
    {
        Task<IEnumerable<Ram>> GetMemoriesBySocket(RamSocketEnum socket);
        Task<IEnumerable<ProductGridDataDTO>> GetProductsForGridData();
    }
}
