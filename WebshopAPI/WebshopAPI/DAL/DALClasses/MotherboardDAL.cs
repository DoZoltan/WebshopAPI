using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.DALInterfaces;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.DAL.DALClasses
{
    public class MotherboardDAL : BaseDAL<Motherboard>, IMotherboardDAL
    {
        protected readonly ShopContext _context;

        public MotherboardDAL(ShopContext context)
            :base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Motherboard>> GetCompatibleMotherboardsByCPUSocket(CPUSocketEnum CPUSocket)
        {
            return await _context.Motherboards.Where(moth => moth.CPUSocketType == CPUSocket).ToListAsync();
        }

        public async Task<IEnumerable<Motherboard>> GetCompatibleMotherboardsByMemorySocket(RAMSocketTypeEnum MemorySocket)
        {
            return await _context.Motherboards.Where(moth => moth.MemorySocketType == MemorySocket).ToListAsync();
        }
    }
}
