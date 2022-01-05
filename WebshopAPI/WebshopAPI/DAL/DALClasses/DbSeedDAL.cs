using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.DALInterfaces;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.DAL.DALClasses
{
    public class DbSeedDAL : IDbSeedDAL
    {
        private readonly ShopContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbSeedDAL(ShopContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> Seed()
        {
            var isTheDbHasAnyData = _context.Set<Cpu>().Select(cpu => cpu).Any();

            if (!isTheDbHasAnyData)
            {
                await CreateCpus();
                await CreateRams();
                await CreateMotherboards();
                return await CreateAdminUser();
            }

            return false;
        }

        private async Task CreateCpus()
        {
            var cpu1 = new Cpu
            {
                ProductName = "Test CPU 1",
                Brand = "INTEL",
                ImgURL = "",
                AcquisitionPrice = 100,
                SellPrice = 110,
                ProductType = ProductTypeEnum.Cpu,
                CoreNumber = 8,
                L3Cache = 24,
                Speed = 3700,
                SocketType = CpuSocketEnum.LGA1700,
            };

            var cpu2 = new Cpu
            {
                ProductName = "Test CPU 2",
                Brand = "AMD",
                ImgURL = "",
                AcquisitionPrice = 120,
                SellPrice = 140,
                ProductType = ProductTypeEnum.Cpu,
                CoreNumber = 12,
                L3Cache = 32,
                Speed = 3900,
                SocketType = CpuSocketEnum.AM4,
            };

            var cpus = new List<Cpu>() { cpu1, cpu2 };
            await _context.Set<Cpu>().AddRangeAsync(cpus);
            await _context.SaveChangesAsync();
        }

        private async Task CreateRams()
        {
            var ram1 = new Ram
            {
                ProductName = "Test RAM 1",
                Brand = "G.SKILL",
                ImgURL = "",
                AcquisitionPrice = 30,
                SellPrice = 35,
                ProductType = ProductTypeEnum.Ram,
                Gb = 32,
                Delay = 8,
                Speed = 4200,
                SocketType = RamSocketEnum.DDR4,
            };

            var ram2 = new Ram
            {
                ProductName = "Test RAM 2",
                Brand = "KINGSTON",
                ImgURL = "",
                AcquisitionPrice = 80,
                SellPrice = 99,
                ProductType = ProductTypeEnum.Ram,
                Gb = 64,
                Delay = 12,
                Speed = 6700,
                SocketType = RamSocketEnum.DDR5,
            };

            var rams = new List<Ram>() { ram1, ram2 };
            await _context.Set<Ram>().AddRangeAsync(rams);
            await _context.SaveChangesAsync();
        }

        private async Task CreateMotherboards()
        {
            var moth1 = new Motherboard
            {
                ProductName = "Test Motherboard 1",
                Brand = "ASUS",
                ImgURL = "",
                AcquisitionPrice = 80,
                SellPrice = 95,
                ProductType = ProductTypeEnum.Motherboard,
                Usb3Amount = 8,
                Wifi = true,
                SizeStandard = MotherboardSizeStandardEnum.ATX,
                CpuSocketType = CpuSocketEnum.AM4,
                MemorySocketType = RamSocketEnum.DDR4,
                MaxMemorySize = 128,
                NumberOfMemorySockets = 4,
            };

            var moth2 = new Motherboard
            {
                ProductName = "Test Motherboard 2",
                Brand = "MSI",
                ImgURL = "",
                AcquisitionPrice = 110,
                SellPrice = 125,
                ProductType = ProductTypeEnum.Motherboard,
                Usb3Amount = 6,
                Wifi = true,
                SizeStandard = MotherboardSizeStandardEnum.EATX,
                CpuSocketType = CpuSocketEnum.LGA1700,
                MemorySocketType = RamSocketEnum.DDR5,
                MaxMemorySize = 128,
                NumberOfMemorySockets = 4,
            };

            var moths = new List<Motherboard>() { moth1, moth2 };
            await _context.Set<Motherboard>().AddRangeAsync(moths);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> CreateAdminUser()
        {
            var admin = new User
            {
                UserName = "Admin",
                Email = "admin@wbshop.com",
            };

            var isCreated = await _userManager.CreateAsync(admin, "ASD-123q");

            if (!isCreated.Succeeded)
            {
                return false;
            }

            IdentityRole identityRole = new IdentityRole()
            {
                Name = "Admin",
            };

            var identityResult = await _roleManager.CreateAsync(identityRole);

            if (!identityResult.Succeeded)
            {
                return false;
            }

            var addRoleResult = await _userManager.AddToRoleAsync(admin, identityRole.Name);

            if (!addRoleResult.Succeeded)
            {
                return false;
            }

            return true;
        }
    }
}
