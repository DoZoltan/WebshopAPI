using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DAL.DALInterfaces
{
    public interface IBaseDAL<T>
    {
        Task<T> GetByID(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Delete(T product);
        Task<T> AddNew(T product);
        Task<T> Update(T product);
    }
}
