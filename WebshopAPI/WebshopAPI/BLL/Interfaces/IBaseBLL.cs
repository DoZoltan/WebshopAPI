using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.BLL.Interfaces
{
    public interface IBaseBLL<T>
    {
        Task<T> GetByID(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> DeleteByID(int id);
        Task<T> AddNew(T product);
        Task<T> Update(T product);
    }
}
