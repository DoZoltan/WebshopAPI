using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.DALInterfaces;

namespace WebshopAPI.BLL.Classes
{
    public class DbSeedBLL : IDbSeedBLL
    {
        private readonly IDbSeedDAL _dbSeedDAL;
        
        public DbSeedBLL(IDbSeedDAL dbSeedDAL)
        {
            _dbSeedDAL = dbSeedDAL;
        }

        public async Task<bool> Seed()
        {
            return await _dbSeedDAL.Seed();
        }
    }
}
