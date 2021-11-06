using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAPI.DAL.Models
{
    public class BaseProduct
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string ImgURL { get; set; }
        public int AcquisitionPrice { get; set; }
        public int SellPrice { get; set; }
    }
}
