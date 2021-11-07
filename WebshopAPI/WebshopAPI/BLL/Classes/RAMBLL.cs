using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.BLL.Classes
{
    public class RAMBLL : BaseBLL<RAM>, IRAMBLL
    {
        public Task<IEnumerable<RAM>> GetCompatibleMemoriesByMotherboardMemorySocket(RAMSocketTypeEnum MemorySocket)
        {
            throw new NotImplementedException();
        }
    }
}
