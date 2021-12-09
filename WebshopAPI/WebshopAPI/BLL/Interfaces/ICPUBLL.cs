using System.Collections.Generic;
using System.Threading.Tasks;
using WebshopAPI.DAL.DTOs;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.BLL.Interfaces
{
    public interface ICpuBLL : IBaseBLL<Cpu>
    {
        Task<IEnumerable<Cpu>> GetCpusBySocket(CpuSocketEnum socket);
        Task<IEnumerable<ProductGridDataDTO>> GetProductsForGridData();
    }
}
