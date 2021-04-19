using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using School.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Students.Any())
                {
                    context.Students.AddRange(
                        new Student()
                        {
                            Id = 1,
                            FullName = "Stephany Ashcraft",
                            DataOfBirth = new DateTime(2000, 4, 14)
                        },
                new Student()
                {
                    Id = 2,
                    FullName = "Olga Lester",
                    DataOfBirth = new DateTime(1990, 10, 11)
                },
                new Student()
                {
                    Id = 3,
                    FullName = "Charlie Curtis",
                    DataOfBirth = new DateTime(1997, 8, 24)
                }
                        );



                    context.SaveChanges();
                }
            }
        }
    }
}
