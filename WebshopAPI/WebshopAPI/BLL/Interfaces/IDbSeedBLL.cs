using System.Threading.Tasks;

namespace WebshopAPI.BLL.Interfaces
{
    public interface IDbSeedBLL
    {
        Task<bool> Seed();
    }
}
