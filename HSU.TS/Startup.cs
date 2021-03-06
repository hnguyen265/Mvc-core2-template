﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSU.TS.Data;
using HSU.TS.Data.Configurations;
using HSU.TS.Data.Interfaces;
using HSU.TS.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HSU.TS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<MyDbContext>(options => options.UseInMemoryDatabase("LibraryContext"));
            //services.AddDbContext<MyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultDatabase")));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<SessionConfig>(Configuration.GetSection("SessionConfig"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            DbInitializer.Seed(app);
        }
    }
}
