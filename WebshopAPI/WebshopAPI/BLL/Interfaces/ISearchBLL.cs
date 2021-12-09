using System.Collections.Generic;
using System.Threading.Tasks;
using WebshopAPI.DAL.DTOs;

namespace WebshopAPI.BLL.Interfaces
{
    public interface ISearchBLL
    {
        Task<IEnumerable<ProductGridDataDTO>> SearchByProductName(string namePart);
        Task<IEnumerable<ProductGridDataDTO>> SearchByBrand(string brandPart);
    }
}
