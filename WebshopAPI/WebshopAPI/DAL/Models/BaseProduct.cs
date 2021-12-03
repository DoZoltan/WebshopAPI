using System;
using System.ComponentModel.DataAnnotations;
using WebshopAPI.Enums;
using WebshopAPI.Services.ModelValidators;

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
        [Range(1, 99999)]
        public int AcquisitionPrice { get; set; }
        [Range(1, 99999)]
        public int SellPrice { get; set; }
        [ProductTypeValidator]
        public ProductTypeEnum ProductType { get; set; }
    }
}
