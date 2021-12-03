using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.DALInterfaces;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.DAL.DALClasses
{
    public class CpuDAL : BaseDAL<Cpu>, ICpuDAL
    {
        protected readonly ShopContext _context;

        public CpuDAL(ShopContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cpu>> GetCpusBySocket(CpuSocketEnum socket)
        {
            return await _context.Cpus.Where(cpu => cpu.SocketType == socket).ToListAsync();
        }
    }
}
