using Asp.netCoreMVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netCoreMVC
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
            //services.AddControllers();
            //AddController method Registers everything that is needed for Web API Development.


            services.AddControllersWithViews();
            //AddControllersWithViews method registers everything that is needed for Web App Development using Controllers and Views.
            //It registers everything that AddController installs plus the support for Views


            //services.AddRazorPages();
            //The AddRazorPages method registers everything everything needed for Web app development using the Razor Pages.



            //only one instance is available throughout the application and for every request.
            //The instance is created for the first request and the same is available throughout the application
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();


            //When we register a type as Scoped, one instance is available throughout the application per request.
            //When a new request comes in, the new instance is created.
            //services.AddScoped()


            //When we register a type as Transient, every time a new instance is created.
            //Transient creates new instance for every service/ controller as well as for every request and every user.
            //services.AddTransient()

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
