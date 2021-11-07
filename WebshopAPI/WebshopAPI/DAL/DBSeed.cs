using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.DAL
{
    public static class DBSeed
    {
        //Extension metódus a ModelBuilder osztályhoz
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CPU>().HasData(
                new CPU
                {
                    ID = 1,
                    ProductName = "Test CPU 1",
                    Brand = "INTEL",
                    ImgURL = "",
                    AcquisitionPrice = 100,
                    SellPrice = 110,
                    CoreNumber = 8,
                    L3Cache = 24,
                    Speed = 3700,
                    SocketType = CPUSocketEnum.LGA1700,
                },

                new CPU
                {
                    ID = 2,
                    ProductName = "Test CPU 2",
                    Brand = "AMD",
                    ImgURL = "",
                    AcquisitionPrice = 120,
                    SellPrice = 140,
                    CoreNumber = 12,
                    L3Cache = 32,
                    Speed = 3900,
                    SocketType = CPUSocketEnum.AM4,
                }
            );

            modelBuilder.Entity<RAM>().HasData(
                new RAM
                {
                    ID = 1,
                    ProductName = "Test RAM 1",
                    Brand = "G.SKILL",
                    ImgURL = "",
                    AcquisitionPrice = 30,
                    SellPrice = 35,
                    Gb = 32,
                    Delay = 8,
                    Speed = 4200,
                    SocketType = "DDR4",
                },

                new RAM
                {
                    ID = 2,
                    ProductName = "Test RAM 2",
                    Brand = "KINGSTON",
                    ImgURL = "",
                    AcquisitionPrice = 80,
                    SellPrice = 99,
                    Gb = 64,
                    Delay = 12,
                    Speed = 6700,
                    SocketType = "DDR5",
                }
            );

            modelBuilder.Entity<Motherboard>().HasData(
                new Motherboard
                {
                    ID = 1,
                    ProductName = "Test Motherboard 1",
                    Brand = "ASUS",
                    ImgURL = "",
                    AcquisitionPrice = 80,
                    SellPrice = 95,
                    Usb3Amount = 8,
                    Wifi = true,
                    SizeStandard = "ATX",
                    CPUSocketType = CPUSocketEnum.AM4,
                    MemorySocketType = "DDR4",
                    MaxMemorySize = 128,
                    NumberOfMemorySockets = 4,
                },

                new Motherboard
                {
                    ID = 2,
                    ProductName = "Test Motherboard 2",
                    Brand = "MSI",
                    ImgURL = "",
                    AcquisitionPrice = 110,
                    SellPrice = 125,
                    Usb3Amount = 6,
                    Wifi = true,
                    SizeStandard = "EATX",
                    CPUSocketType = CPUSocketEnum.LGA1700,
                    MemorySocketType = "DDR5",
                    MaxMemorySize = 128,
                    NumberOfMemorySockets = 4,
                }
            );
        }
    }
}
