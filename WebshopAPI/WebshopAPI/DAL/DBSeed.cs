using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.Models;

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
                    ProductName = "",
                    Brand = "",
                    ImgURL = "",
                    AcquisitionPrice = 0,
                    SellPrice = 0,
                    CoreNumber = 0,
                    L3Cache = 0,
                    Speed = 0,
                    SocketType = "",
                },

                new CPU
                {
                    ProductName = "",
                    Brand = "",
                    ImgURL = "",
                    AcquisitionPrice = 0,
                    SellPrice = 0,
                    CoreNumber = 0,
                    L3Cache = 0,
                    Speed = 0,
                    SocketType = "",
                }
            );

            modelBuilder.Entity<RAM>().HasData(
                new RAM
                {
                    ProductName = "",
                    Brand = "",
                    ImgURL = "",
                    AcquisitionPrice = 0,
                    SellPrice = 0,
                    Gb = 0,
                    Height = 0,
                    Delay = 0,
                    Speed = 0,
                    SocketType = "",
                },

                new RAM
                {
                    ProductName = "",
                    Brand = "",
                    ImgURL = "",
                    AcquisitionPrice = 0,
                    SellPrice = 0,
                    Gb = 0,
                    Height = 0,
                    Delay = 0,
                    Speed = 0,
                    SocketType = "",
                }
            );

            modelBuilder.Entity<Motherboard>().HasData(
                new Motherboard
                {
                    ProductName = "",
                    Brand = "",
                    ImgURL = "",
                    AcquisitionPrice = 0,
                    SellPrice = 0,
                    Usb3Amount = 0,
                    Wifi = true,
                    SizeStandard = "",
                    CPUSocketType = "",
                    MemorySocketType = "",
                    MaxMemorySize = 0,
                    NumberOfMemorySockets = 0,
                },

                new Motherboard
                {
                    ProductName = "",
                    Brand = "",
                    ImgURL = "",
                    AcquisitionPrice = 0,
                    SellPrice = 0,
                    Usb3Amount = 0,
                    Wifi = true,
                    SizeStandard = "",
                    CPUSocketType = "",
                    MemorySocketType = "",
                    MaxMemorySize = 0,
                    NumberOfMemorySockets = 0,
                }
            );
        }
    }
}
