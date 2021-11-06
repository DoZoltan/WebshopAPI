using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DAL.DAL_Interfaces
{
    public interface IBaseDAL<T>
    {
        Task<T> GetByID(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> DeleteByID(int id);
        Task<T> AddNew(T product);
        Task<T> Update(T product);
    }
}
