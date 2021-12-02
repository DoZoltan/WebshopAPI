using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.DALInterfaces;
using WebshopAPI.DAL.Models;

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

        // DTO használata, itt nincs szükség a válaszban minden adatra az adott termékről
        // Admin keresésnél pedig még kevesebb adat kell

        public async Task<IEnumerable<BaseProduct>> SearchByBrand(string brandPart)
        {
            List<BaseProduct> results = new();
            
            if (!string.IsNullOrEmpty(brandPart))
            {
                results.AddRange(await _CpuDAL.SearchByBrand(brandPart));
                results.AddRange(await _RamDAL.SearchByBrand(brandPart));
                results.AddRange(await _MotherboardDAL.SearchByBrand(brandPart));
            }

            return results;
        }

        public async Task<IEnumerable<BaseProduct>> SearchByProductName(string namePart)
        {
            List<BaseProduct> results = new();

            if (!string.IsNullOrEmpty(namePart))
            {
                results.AddRange(await _CpuDAL.SearchByProductName(namePart));
                results.AddRange(await _RamDAL.SearchByProductName(namePart));
                results.AddRange(await _MotherboardDAL.SearchByProductName(namePart));
            }

            return results;
        }
    }
}
