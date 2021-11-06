using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.DALInterfaces;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.DAL.DALClasses
{
    public class CPUDAL : BaseDAL<CPU>, ICPUDAL
    {
        protected readonly ShopContext _context;

        public CPUDAL(ShopContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CPU>> GetCompatibleCPUsByMotherboardCPUSocket(string CPUSocket)
        {
            return await _context.CPUs.Where(cpu => cpu.SocketType == CPUSocket).ToListAsync();
        }
    }
}
