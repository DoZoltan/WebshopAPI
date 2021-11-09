using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.BLL.Interfaces
{
    public interface ICpuBLL : IBaseBLL<Cpu>
    {
        Task<IEnumerable<Cpu>> GetCpusBySocket(CpuSocketEnum socket);
    }
}
