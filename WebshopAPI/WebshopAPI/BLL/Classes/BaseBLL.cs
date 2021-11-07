using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.BLL.Classes
{
    public class BaseBLL<T> : IBaseBLL<T> where T : BaseProduct
    {
        public Task<T> AddNew(T product)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T product)
        {
            throw new NotImplementedException();
        }
    }
}
