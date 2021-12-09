using WebshopAPI.DAL.DTOs;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.Services.DTOConverter
{
    public static class DTOConverter
    {
        public static ProductGridDataDTO AsProductGridDataDTO(this BaseProduct baseProduct)
        {
            return new ProductGridDataDTO
            {
                ID = baseProduct.ID,
                ProductName = baseProduct.ProductName,
                Brand = baseProduct.Brand,
                SellPrice = baseProduct.SellPrice,
                ProductType = baseProduct.ProductType
            };
        }
    }
}
