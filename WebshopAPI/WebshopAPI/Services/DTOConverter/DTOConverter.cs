using WebshopAPI.DAL.DTOs;
using WebshopAPI.DAL.DTOs.ResponseDTOs;
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

        public static UserDataResponseDTO AsUserDataResponseDTO(this User user)
        {
            return new UserDataResponseDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                BirthDate = user.BirthDate,
                RegistrationDate = user.RegistrationDate,
            };
        }
    }
}
