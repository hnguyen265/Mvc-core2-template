using HSU.TS.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSU.TS.Data
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                //var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
                //optionsBuilder.UseInMemoryDatabase();
                //_dbContext = new MyDbContext(optionsBuilder.Options);

               // var context = serviceScope.ServiceProvider.GetService<MyDbContext>();
                //var context = app.ApplicationServices.GetService<MyDbContext>();

                var context = serviceScope.ServiceProvider.GetService<MyDbContext>();

                // Add Customers
                var justin = new Student { FirstName = "Justin Noon", LastName ="Sleep" };
                var honda = new Student { FirstName = "Honda Noon", LastName = "CUP" };

                context.Students.Add(justin);
                context.Students.Add(honda);
              

                context.SaveChanges();
            }
        }
    }
}
