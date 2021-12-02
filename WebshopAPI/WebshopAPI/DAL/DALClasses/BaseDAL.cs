using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.DALInterfaces;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.DAL.DALClasses
{
    // Meg kell mondani, h a T milyen típusú lehet (jelenleg BaseProduct) -->
    // innen tudni, h annak milyen property-je / metódusai vannak
    public class BaseDAL<T> : IBaseDAL<T> where T : BaseProduct
    {
        private readonly ShopContext _context;

        public BaseDAL(ShopContext context)
        {
            _context = context;
        }

        public async Task<T> AddNew(T product)
        {
            var result = await _context.Set<T>().AddAsync(product);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<T> Delete(T product)
        {
            var result = _context.Set<T>().Remove(product);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByID(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(prod => prod.ID == id);
        }

        public async Task<T> Update(T product)
        {
            var result = _context.Set<T>().Update(product);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<T>> SearchByBrand(string brandPart)
        {
            return await _context.Set<T>().Where(prod => prod.Brand.Contains(brandPart)).ToListAsync();
        }

        public async Task<IEnumerable<T>> SearchByProductName(string namePart)
        {
            return await _context.Set<T>().Where(prod => prod.ProductName.Contains(namePart)).ToListAsync();
        }

        //kombinálva
        // return await _context.Set<T>().Where(prod => prod.ProductName.Contains(inputPart) || prod.Brand.Contains(inputPart)).ToListAsync();

    }
}
