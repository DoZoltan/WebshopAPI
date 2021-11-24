using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.BLL.Interfaces
{
    public interface ISearchBLL
    {
        Task<IEnumerable<BaseProduct>> SearchByProductName(string namePart);
        Task<IEnumerable<BaseProduct>> SearchByBrand(string brandPart);
    }
}
