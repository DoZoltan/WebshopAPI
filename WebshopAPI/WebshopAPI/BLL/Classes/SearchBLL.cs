using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.DALInterfaces;
using WebshopAPI.DAL.DTOs;
using WebshopAPI.Services.DTOConverter;

namespace WebshopAPI.BLL.Classes
{
    public class SearchBLL : ISearchBLL
    {
        protected readonly ICpuDAL _CpuDAL;
        protected readonly IRamDAL _RamDAL;
        protected readonly IMotherboardDAL _MotherboardDAL;

        public SearchBLL(ICpuDAL CpuDAL, IRamDAL RamDAL, IMotherboardDAL MotherboardDAL)
        {
            _CpuDAL = CpuDAL;
            _RamDAL = RamDAL;
            _MotherboardDAL = MotherboardDAL;
        }

        public async Task<IEnumerable<ProductGridDataDTO>> SearchByBrand(string brandPart)
        {
            List<ProductGridDataDTO> results = new();
            
            if (!string.IsNullOrEmpty(brandPart))
            {
                results.AddRange((await _CpuDAL.SearchByBrand(brandPart)).Select(product => product.AsProductGridDataDTO()));
                results.AddRange((await _RamDAL.SearchByBrand(brandPart)).Select(product => product.AsProductGridDataDTO()));
                results.AddRange((await _MotherboardDAL.SearchByBrand(brandPart)).Select(product => product.AsProductGridDataDTO()));
            }

            return results;
        }

        public async Task<IEnumerable<ProductGridDataDTO>> SearchByProductName(string namePart)
        {
            List<ProductGridDataDTO> results = new();

            if (!string.IsNullOrEmpty(namePart))
            {
                results.AddRange((await _CpuDAL.SearchByProductName(namePart)).Select(product => product.AsProductGridDataDTO()));
                results.AddRange((await _RamDAL.SearchByProductName(namePart)).Select(product => product.AsProductGridDataDTO()));
                results.AddRange((await _MotherboardDAL.SearchByProductName(namePart)).Select(product => product.AsProductGridDataDTO()));
            }

            return results;
        }
    }
}
