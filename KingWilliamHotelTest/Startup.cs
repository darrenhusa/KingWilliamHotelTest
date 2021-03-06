﻿using KingWilliamHotelTest.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KingWilliamHotelTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IReservationRepository, EfReservationRepository>();
            services.AddTransient<IRoomRepository, EfRoomRepository>();
            services.AddTransient<IRoomDesRepository, EfRoomDesRepository>();
            services.AddTransient<ICustomerRepository, EfCustomerRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Reservation}/{action=GetValues}/{id?}");
                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Reservation}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Customer}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}/{id?}");
            });

            DbInitializer.Initialize(app);
        }
    }
}
