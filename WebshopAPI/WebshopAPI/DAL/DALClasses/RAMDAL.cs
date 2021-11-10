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
    public class RamDAL : BaseDAL<Ram>, IRamDAL
    {
        protected readonly ShopContext _context; 

        public RamDAL(ShopContext context)
            :base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ram>> GetMemoriesBySocket(RamSocketEnum socket)
        {
            return await _context.Rams.Where(memory => memory.SocketType == socket).ToListAsync();
        }
    }
}
