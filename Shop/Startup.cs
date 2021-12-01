
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data.Interface;
using Shop.Data.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Repository;
using Shop.Data;
using Shop.Data.Models;

namespace Shop
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
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddMvcCore();
            services.AddRouting();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));          
            services.AddMvc(option => option.EnableEndpointRouting = false);
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Data.ApplicationContext>(options =>
                options.UseSqlServer(connection));
            services.AddControllersWithViews();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseDeveloperExceptionPage();
            //app.UseStatusCodePages();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
            using (var scope = app.ApplicationServices.CreateScope())
            {
                ApplicationContext context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                DBObjects.Initial(context);
            }
            
        }
    }
}
