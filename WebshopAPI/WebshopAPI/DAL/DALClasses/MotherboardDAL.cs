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

        public async Task<IEnumerable<Motherboard>> GetMotherboardsByCPU(CpuSocketEnum cpuSocket)
        {
            return await _context.Motherboards.Where(moth => moth.CpuSocketType == cpuSocket).ToListAsync();
        }

        public async Task<IEnumerable<Motherboard>> GetMotherboardsByMemory(RamSocketEnum memorySocket)
        {
            return await _context.Motherboards.Where(moth => moth.MemorySocketType == memorySocket).ToListAsync();
        }
    }
}
