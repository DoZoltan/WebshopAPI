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
            try
            {
                // A T típusátol függően legyen a megfelelő DbSet<> kiválasztva a context osztályban
                // majd azon legyen végrehalytva a művelet
                _context.Set<T>().Add(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }

            var lastId = await _context.Set<T>().MaxAsync(prod => prod.ID);
            return await GetByID(lastId);
        }

        public async Task<T> Delete(T product)
        {
            try
            {
                _context.Set<T>().Remove(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }

            return product;
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
            try
            {
                _context.Set<T>().Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }

            return await GetByID(product.ID);
        }
    }
}
