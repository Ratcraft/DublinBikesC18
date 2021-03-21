using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DublinBikes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DublinBikes.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcBikeContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcBikeContext>>()))
        {
            // Look for any station.
            if (context.DublinBike.Any())
            {
                return;   // DB has been seeded
            }

                context.DublinBike.AddRange(
                    new DublinBike
                    {
                        Number = 42,
                        ContractName = "Dublin",
                        Name = "SMITHFIELD NORTH",
                        Address = "Smithfield North",
                        Latitude = 53.349562f,
                        Longitude = -6.278198f,
                        Banking = true,
                        Status = "OPEN",
                        Available_bikes = 40,
                        Available_stands = 10,
                        Capacity = 50
                    },



                    new DublinBike
                    {
                        Number = 30,
                        ContractName = "Dublin",
                        Name = "PARNELL SQUARE NORTH",
                        Address = "Parnell Square North",
                        Latitude = 53.353462f,
                        Longitude = -6.265305f,
                        Banking = true,
                        Status = "OPEN",
                        Available_bikes = 40,
                        Available_stands = 10,
                        Capacity = 50
                    },

                    new DublinBike
                    {
                        Number = 54,
                        ContractName = "Dublin",
                        Name = "CLONMEL STREET",
                        Address = "Clonmel Street",
                        Latitude = 53.98696f,
                        Longitude = -6.275879f,
                        Banking = true,
                        Status = "OPEN",
                        Available_bikes = 40,
                        Available_stands = 10,
                        Capacity = 50
                    },

                    new DublinBike
                    {
                        Number = 48,
                        ContractName = "Dublin",
                        Name = "EXCISE WALK",
                        Address = "Excise Walk",
                        Latitude = 53.207402f,
                        Longitude = -6.535775f,
                        Banking = true,
                        Status = "OPEN",
                        Available_bikes = 40,
                        Available_stands = 10,
                        Capacity = 50
                    }
                ) ;
            context.SaveChanges();
        }
    }
}
}
