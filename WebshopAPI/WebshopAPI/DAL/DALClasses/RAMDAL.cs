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
    public class RAMDAL : BaseDAL<RAM>, IRAMDAL
    {
        protected readonly ShopContext _context; 

        public RAMDAL(ShopContext context)
            :base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RAM>> GetCompatibleMemoriesByMotherboardMemorySocket(RAMSocketTypeEnum MemorySocket)
        {
            return await _context.RAMs.Where(memory => memory.SocketType == MemorySocket).ToListAsync();
        }
    }
}
