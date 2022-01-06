using System.Threading.Tasks;

namespace WebshopAPI.DAL.DALInterfaces
{
    public interface IDbSeedDAL
    {
        Task<bool> Seed();
    }
}
