using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.Enums;

namespace WebshopAPI.DAL.Models
{
    public class BaseProduct
    {
        public int ID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Brand { get; set; }
        public string ImgURL { get; set; }
        [Required]
        public int AcquisitionPrice { get; set; }
        [Required]
        public int SellPrice { get; set; }
        [Required]
        public ProductTypeEnum ProductType { get; set; }
    }
}
