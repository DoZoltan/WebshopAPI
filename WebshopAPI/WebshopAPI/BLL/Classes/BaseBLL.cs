using System.Collections.Generic;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.DALInterfaces;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.BLL.Classes
{
    public class BaseBLL<T> : IBaseBLL<T> where T : BaseProduct
    {
        protected readonly IBaseDAL<T> _baseDAL;

        public BaseBLL(IBaseDAL<T> baseDAL)
        {
            _baseDAL = baseDAL;
        }

        public async Task<T> AddNew(T product)
        {
            if (product != null)
            {
                return await _baseDAL.AddNew(product);
            }

            return null;
        }

        public async Task<T> Delete(T product)
        {
            return await _baseDAL.Delete(product);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _baseDAL.GetAll();
        }

        public async Task<T> GetByID(int id)
        {
            if (id > 0)
            {
                return await _baseDAL.GetByID(id);
            }

            return null;
        }

        public async Task<T> Update(T product)
        {
            if (product != null)
            {
                return await _baseDAL.Update(product);
            }

            return null;
        }
    }
}
